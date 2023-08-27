using System;
using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using MonoMod.Cil;

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

        public override void Load()
        {
            if (currentAPSession == null)
            {
                currentAPSession = ArchipelagoSessionFactory.CreateSession("archipelago.gg", 65151);
                currentAPSession.TryConnectAndLogin("Celeste", "Test567", ItemsHandlingFlags.AllItems, new Version(0, 4, 0));
            }
        }

        public override void Unload()
        {
            // TODO: unapply any hooks applied in Load()
        }
    }
}