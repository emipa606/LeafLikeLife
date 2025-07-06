using Mlie;
using UnityEngine;
using Verse;

namespace LeafLikeLife;

public class LLLMod : Mod
{
    private static string currentVersion;
    private LLLModSettings settings;

    public LLLMod(ModContentPack con) : base(con)
    {
        settings = GetSettings<LLLModSettings>();
        currentVersion = VersionFromManifest.GetVersionFromModMetaData(con.ModMetaData);
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        var listing = new Listing_Standard();
        listing.Begin(inRect);
        listing.Label(
            "LLLConsciousnessLabel".Translate() + ": -" +
            (-LLLModSettings.AmountPenaltyConsciousness).ToStringPercent(),
            tooltip: "LLLConsciousnessTooltip".Translate());
        LLLModSettings.AmountPenaltyConsciousness = listing.Slider(LLLModSettings.AmountPenaltyConsciousness, -1f, 0f);
        listing.Label(
            "LLLMovementLabel".Translate() + ": -" + (-LLLModSettings.AmountPenaltyMovement).ToStringPercent(),
            tooltip: "LLLMovementTooltip".Translate());
        LLLModSettings.AmountPenaltyMovement = listing.Slider(LLLModSettings.AmountPenaltyMovement, -1f, 0f);
        listing.Label("LLLRestLabel".Translate() + ": -" + (-LLLModSettings.AmountPenaltyRest).ToStringPercent(),
            tooltip: "LLLRestTooltip".Translate());
        LLLModSettings.AmountPenaltyRest = listing.Slider(LLLModSettings.AmountPenaltyRest, -1f, 0f);
        listing.Label("LLLHungerLabel".Translate() + ": +" + LLLModSettings.AmountHungerRate.ToStringPercent(),
            tooltip: "LLLHungerTooltip".Translate());
        LLLModSettings.AmountHungerRate = listing.Slider(LLLModSettings.AmountHungerRate, 0f, 1f);
        listing.Gap();
        listing.Label("LLLAddictivenessLabel".Translate() + ": " + LLLModSettings.AmountAddictiveness.ToStringPercent(),
            tooltip: "LLLAddictivenessTooltip".Translate());
        LLLModSettings.AmountAddictiveness = listing.Slider(LLLModSettings.AmountAddictiveness, 0f, 0.40f);
        listing.Label("LLLToleranceLabel".Translate() + ": " + LLLModSettings.AmountToleranceToAddict.ToStringPercent(),
            tooltip: "LLLToleranceTooltip".Translate());
        LLLModSettings.AmountToleranceToAddict = listing.Slider(LLLModSettings.AmountToleranceToAddict, 0f, 1f);
        listing.Gap();
        listing.Label("LLLAsthmaLabel".Translate() + ": " + LLLModSettings.AmountAsthmaDaysChance,
            tooltip: "LLLAsthmaTooltip".Translate());
        LLLModSettings.AmountAsthmaDaysChance = (int)listing.Slider(LLLModSettings.AmountAsthmaDaysChance, 5, 2000);
        listing.Label("LLLCancerLabel".Translate() + ": " + LLLModSettings.AmountCancerDaysChance,
            tooltip: "LLLCancerTooltip".Translate());
        LLLModSettings.AmountCancerDaysChance = (int)listing.Slider(LLLModSettings.AmountCancerDaysChance, 5, 2000);
        listing.Gap();
        listing.Label("LLLWithdrawalLabel".Translate() + ": " + LLLModSettings.AmountPenaltyWithdrawal,
            tooltip: "LLLWithdrawalTooltip".Translate());
        LLLModSettings.AmountPenaltyWithdrawal = (int)listing.Slider(LLLModSettings.AmountPenaltyWithdrawal, -30, 0);

        listing.Gap();
        var buttonRect = listing.GetRect(30f);
        if (Widgets.ButtonText(buttonRect.LeftPart(0.45f), "LLLReset".Translate()))
        {
            LLLModSettings.ResetSettings();
        }

        if (Widgets.ButtonText(buttonRect.RightPart(0.45f), "LLLVanilla".Translate()))
        {
            LLLModSettings.VanillaSettings();
        }

        if (currentVersion != null)
        {
            listing.Gap();
            GUI.contentColor = Color.gray;
            listing.Label("LLLModversion".Translate(currentVersion));
            GUI.contentColor = Color.white;
        }

        listing.End();
        base.DoSettingsWindowContents(inRect);
    }

    public override void WriteSettings()
    {
        LLLUtility.UpdateAllChanges();

        base.WriteSettings();
    }

    public override string SettingsCategory()
    {
        return "LLLTitle".Translate();
    }
}