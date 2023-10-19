using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Helpers;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Packets;

namespace Celeste.Mod.APCeleste
{
    public class APCelesteModule : EverestModule
    {
        public static APCelesteModule Instance;

        public override Type SettingsType => typeof(APCelesteModuleSettings);
        public static APCelesteModuleSettings Settings => (APCelesteModuleSettings)Instance._Settings;

        public override Type SaveDataType => typeof(APCelesteModuleSaveData);
        public static APCelesteModuleSaveData SaveData => (APCelesteModuleSaveData)Instance._SaveData;

        public APCelesteModule()
        {
            Instance = this;
#if DEBUG
            // debug builds use verbose logging
            Logger.SetLogLevel(nameof(APCelesteModule), LogLevel.Verbose);
#else
            // release builds use info logging to reduce spam in log files
            Logger.SetLogLevel(nameof(APCelesteModule), LogLevel.Info);
#endif
        }
        private ArchipelagoSession currentAPSession;
        private string APpass;
        private int apID;
        private List<NetworkItem> allSentItems = new List<NetworkItem>();

        public override void Load()
        {
            Celeste.Instance.Components.Add(new MessageDisplay(Celeste.Instance));
            MessageDisplay.instance.AddMessage("Test display system written by \"bessnation\" on Discord");

            MessageDisplay.instance.AddMessage("Attempting connection to " + Settings.ArchipelagoSlot + " at " + Settings.ArchipelagoAddress + ":" + Settings.ArchipelagoPort);
            if (currentAPSession == null)
            {
                if (Settings.ArchipelagoPasswordToggle == false)
                {
                    APpass = null;
                } else
                {
                    APpass = Settings.ArchipelagoPassword;
                }
                currentAPSession = ArchipelagoSessionFactory.CreateSession(Settings.ArchipelagoAddress, Int32.Parse(Settings.ArchipelagoPort)); 
                currentAPSession.TryConnectAndLogin("Celeste", Settings.ArchipelagoSlot, ItemsHandlingFlags.AllItems, new Version(0, 4, 2) , null, null, APpass);
            } // Connects game to AP

            if (currentAPSession.ConnectionInfo.Slot == -1)
            {
                MessageDisplay.instance.AddMessage("Connection failed: please check settings");
            } else
            {
                MessageDisplay.instance.AddMessage("Connected in slot " + currentAPSession.ConnectionInfo.Slot);
            }

            On.Celeste.Strawberry.OnCollect += apBerryCollect; // Load AP Berry collect ON hook
            On.Celeste.Cassette.CollectRoutine += apCassetteCollect;
            On.Celeste.HeartGem.CollectRoutine += apHeartGemCollect;
            On.Celeste.LevelEnter.Routine += apOfflineCollect;
            currentAPSession.Items.ItemReceived += itemReceived;
        }

        private IEnumerator apOfflineCollect(On.Celeste.LevelEnter.orig_Routine orig, LevelEnter self)
        {
            if (currentAPSession != null)
            {
                registerSentItems();
                for (int k = 0; k < SaveData.collectedItems.Count; k++)
                {
                    for (int i = 0; i < currentAPSession.Items.AllItemsReceived.Count; i++)
                    {
                        if (allSentItems[i].Item == SaveData.collectedItems[k])
                        {
                            allSentItems.RemoveAt(i);
                            break;
                        }
                    }
                }

                for (int k = 0; k < allSentItems.Count; k++)
                {
                    processItem(allSentItems[k].Item);
                    currentAPSession.Items.DequeueItem();
                }
            }
            return orig(self);
        }

        private void itemReceived(ReceivedItemsHelper helper)
        {
            long id = helper.PeekItem().Item;
            processItem(id);
            helper.DequeueItem();
        }

        private IEnumerator apHeartGemCollect(On.Celeste.HeartGem.orig_CollectRoutine orig, HeartGem self, Player player)
        {
            Level level = self.Scene as Level;
            AreaKey area = level.Session.Area;
            apID = new APCelesteIDSheet().HeartIDToWorldID[AreaData.Get(level).Mode[(int)area.Mode].PoemID];
            currentAPSession.Locations.CompleteLocationChecks(apID);
            MessageDisplay.instance.AddMessage("Sent item at " + currentAPSession.Locations.GetLocationNameFromId(apID));
            return orig(self, player);
        }

        private IEnumerator apCassetteCollect(On.Celeste.Cassette.orig_CollectRoutine orig, Cassette self, Player player)
        {
            Level level = self.Scene as Level;
            apID = new APCelesteIDSheet().CassetteIDToWorldID[level.Session.Area.ID];
            currentAPSession.Locations.CompleteLocationChecks(apID);
            MessageDisplay.instance.AddMessage("Sent item at " + currentAPSession.Locations.GetLocationNameFromId(apID));
            return orig(self, player);
        }

        private void apBerryCollect(On.Celeste.Strawberry.orig_OnCollect orig, Strawberry self) //Intercepting berry collect code to add AP location send
        {
            orig(self); // Original collect code runs first
            apID = new APCelesteIDSheet().BerryIDToWorldID[self.ID.ToString()]; // Translate Berry ID to Ap ID
            currentAPSession.Locations.CompleteLocationChecks(apID); // Sends location of Berry
            MessageDisplay.instance.AddMessage("Sent item at " + currentAPSession.Locations.GetLocationNameFromId(apID));
        }

        public void processItem(long id)
        {
            switch (id)
            {
                case 69000000:
                    SaveData.addStrab();
                    SaveData.markItemAsProcessed(id);
                    return;
                case 69000001:
                    SaveData.markItemAsProcessed(id);
                    return;
                case 69000002:
                    SaveData.markItemAsProcessed(id);
                    return;
                case 69000003:
                    SaveData.markItemAsProcessed(id);
                    return;
            }
        }

        private void registerSentItems()
        {
            for (int k = 0; k < currentAPSession.Items.AllItemsReceived.Count; k++)
            {
                allSentItems.Add(currentAPSession.Items.AllItemsReceived[k]);
            }
        }

        public override void Unload()
        {
            // TODO: unapply any hooks applied in Load()
        }
    }
}