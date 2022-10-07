using Verse;

namespace FogWorld
{
    class ModSettings_Utility
    {
        public static bool SMP_SettingsEnableFogWorld()
        {
            return LoadedModManager.GetMod<FogWorld_Mod>().GetSettings<FogWorld_ModSettings>().SMP_SettingsEnableFogWorld;
        }

        public static bool SMP_SettingsEnableLightingChange()
        {
            return LoadedModManager.GetMod<FogWorld_Mod>().GetSettings<FogWorld_ModSettings>().SMP_SettingsEnableLightingChange;
        }

        public static float SMP_SettingsEnableLightingFactor()
        {
            return LoadedModManager.GetMod<FogWorld_Mod>().GetSettings<FogWorld_ModSettings>().SMP_SettingsEnableLightingFactor;
        }
    }
}
