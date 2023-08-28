namespace Celeste.Mod.APCeleste
{
    public class APCelesteModuleSettings : EverestModuleSettings
    {
        // IP Address Setting
        [SettingMaxLength(40)]
        public string ArchipelagoAddress { get; set; } = "archipelago.gg";

        // Port Setting
        [SettingRange(10000, 99999)]
        [SettingInGame(false)]
        public int ArchipelagoPort { get; set; } = 38281;

        // Slot Setting
        [SettingMaxLength(16)]
        public string ArchipelagoSlot { get; set; } = "Player";

        // Confirm That Password Is Wanted
        public bool ArchipelagoPasswordToggle { get; set; } = false;

        // Password Setting
        [SettingMaxLength(40)]
        public string ArchipelagoPassword { get; set; } = null;
    }
}
