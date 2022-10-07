using UnityEngine;
using Verse;
using System;

namespace FogWorld
{
    class FogWorld_Mod : Mod
    {
        FogWorld_ModSettings settings;
        public FogWorld_Mod(ModContentPack contentPack) : base(contentPack)
        {
            this.settings = GetSettings<FogWorld_ModSettings>();
        }

        public override string SettingsCategory() => "FogWorld";

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);

            listing_Standard.CheckboxLabeled("SMP_SettingsEnableFogWorld".Translate(), ref settings.SMP_SettingsEnableFogWorld);
            listing_Standard.Gap();

            listing_Standard.CheckboxLabeled("SMP_SettingsEnableLightingChange".Translate(), ref settings.SMP_SettingsEnableLightingChange);
            listing_Standard.Gap();

            listing_Standard.Label("SMP_SettingsEnableLightingFactor".Translate() + " (" + (100 - (settings.SMP_SettingsEnableLightingFactor * 100)) + "%)");
            settings.SMP_SettingsEnableLightingFactor = (float)Math.Round(listing_Standard.Slider(settings.SMP_SettingsEnableLightingFactor, 0, 1) / 0.1) * 0.1f;
            listing_Standard.Gap();

            listing_Standard.GapLine();
            listing_Standard.Gap();
            //reset
            Rect rectDefault = listing_Standard.GetRect(30f);
            TooltipHandler.TipRegion(rectDefault, "SMP_SettingsReset".Translate());
            if (Widgets.ButtonText(rectDefault, "SMP_SettingsReset".Translate(), true, true, true))
            {
                FogWorld_ModSettings.ResetSettings(settings);
            }
            listing_Standard.Gap();

            listing_Standard.End();
            base.DoSettingsWindowContents(inRect);
        }
    }
}
