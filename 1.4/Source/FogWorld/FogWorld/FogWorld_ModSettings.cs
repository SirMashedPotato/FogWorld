using Verse;

namespace FogWorld
{
    class FogWorld_ModSettings : ModSettings
    {
        public bool SMP_SettingsEnableFogWorld = true;
        public bool SMP_SettingsEnableLightingChange = false;
        public float SMP_SettingsEnableLightingFactor = 0.8f;

        public override void ExposeData()
        {
            Scribe_Values.Look(ref SMP_SettingsEnableFogWorld, "SMP_SettingsEnableFogWorld", true);
            Scribe_Values.Look(ref SMP_SettingsEnableLightingChange, "SMP_SettingsEnableLightingChange", false);
            Scribe_Values.Look(ref SMP_SettingsEnableLightingFactor, "SMP_SettingsEnableLightingFactor", 0.2f);

            base.ExposeData();
        }

        public static void ResetSettings(FogWorld_ModSettings settings)
        {
            settings.SMP_SettingsEnableFogWorld = true;
            settings.SMP_SettingsEnableLightingChange = false;
            settings.SMP_SettingsEnableLightingFactor = 0.8f;
        }
    }
}
