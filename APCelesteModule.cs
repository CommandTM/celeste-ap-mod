using System;
using Microsoft.Xna.Framework;

namespace Celeste.Mod.APCeleste {
    public class APCelesteModule : EverestModule {
        public static APCelesteModule Instance { get; private set; }

        public override Type SettingsType => typeof(APCelesteModuleSettings);
        public static APCelesteModuleSettings Settings => (APCelesteModuleSettings) Instance._Settings;

        public override Type SessionType => typeof(APCelesteModuleSession);
        public static APCelesteModuleSession Session => (APCelesteModuleSession) Instance._Session;

        public APCelesteModule() {
            Instance = this;
#if DEBUG
            // debug builds use verbose logging
            Logger.SetLogLevel(nameof(APCelesteModule), LogLevel.Verbose);
#else
            // release builds use info logging to reduce spam in log files
            Logger.SetLogLevel(nameof(APCelesteModule), LogLevel.Info);
#endif
        }

        public override void Load() {
            // TODO: apply any hooks that should always be active
        }

        public override void Unload() {
            // TODO: unapply any hooks applied in Load()
        }
    }
}