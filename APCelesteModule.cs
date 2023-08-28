using System;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;

namespace Celeste.Mod.APCeleste
{
    public class APCelesteModule : EverestModule
    {
        public static APCelesteModule Instance { get; private set; }

        public override Type SettingsType => typeof(APCelesteModuleSettings);
        public static APCelesteModuleSettings Settings => (APCelesteModuleSettings)Instance._Settings;

        public override Type SessionType => typeof(APCelesteModuleSession);
        public static APCelesteModuleSession Session => (APCelesteModuleSession)Instance._Session;

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

        public override void Load()
        {
            if (currentAPSession == null)
            {
                if (Settings.ArchipelagoPasswordToggle == false)
                {
                    APpass = null;
                } else
                {
                    APpass = Settings.ArchipelagoPassword;
                }
                currentAPSession = ArchipelagoSessionFactory.CreateSession(Settings.ArchipelagoAddress, ToInt32(Settings.ArchipelagoPort));
                currentAPSession.TryConnectAndLogin("Celeste", Settings.ArchipelagoSlot, new Version(0, 4, 0), ItemsHandlingFlags.AllItems, null, null, APpass);
            }
        }

        public override void Unload()
        {
            // TODO: unapply any hooks applied in Load()
        }
    }
}