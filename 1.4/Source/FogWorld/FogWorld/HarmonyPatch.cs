using HarmonyLib;
using RimWorld;
using System.Reflection;
using Verse;
using System;

namespace FogWorld
{
    //Setting the Harmony instance
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.FogWorld");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    //patch to ensure weather is fog

    [HarmonyPatch(typeof(WeatherDecider))]
    [HarmonyPatch("ChooseNextWeather")]
    public static class WeatherDecider_ChooseNextWeather_Patch
    {
        [HarmonyPostfix]
        public static void FogOverride_Patch(WeatherDecider __instance, ref WeatherDef __result)
        {

            if (ModSettings_Utility.SMP_SettingsEnableFogWorld())
            {
                if(__result == RimWorld.WeatherDefOf.Clear && __instance.ForcedWeather != RimWorld.WeatherDefOf.Clear)
                {
                    __result = WeatherDefOf.Fog;
                }
            }
        }
    }

    [HarmonyPatch(typeof(WeatherDecider))]
    [HarmonyPatch("CurrentWeatherCommonality")]
    public static class WeatherDecider_CurrentWeatherCommonality_Patch
    {
        [HarmonyPostfix]
        public static void FogOverridePatch(WeatherDef weather, ref float __result)
        {
            if (ModSettings_Utility.SMP_SettingsEnableFogWorld())
            {
                if (!weather.defName.Contains("Fog"))
                {
                    __result = 0;
                }
            }
        }
    }

    //patch to decrease lighting levels during fog
    [HarmonyPatch(typeof(GenCelestial))]
    [HarmonyPatch("CelestialSunGlow")]
    [HarmonyPatch(new Type[] { typeof(Map), typeof(int) })]
    public static class GenCelestial_CelestialSunGlow_Patch
    {
        [HarmonyPostfix]
        public static void ModifyLightingDuringFog_Patch(ref Map map, ref float __result)
        {
            if (ModSettings_Utility.SMP_SettingsEnableLightingChange())
            {
                if (map.weatherManager.curWeather != null && map.weatherManager.curWeather.defName.Contains("Fog"))
                {
                    __result *= ModSettings_Utility.SMP_SettingsEnableLightingFactor();
                }
            }
        }
    }
}
