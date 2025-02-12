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
            (-LLLModSettings.amountPenaltyConsciousness).ToStringPercent(),
            tooltip: "LLLConsciousnessTooltip".Translate());
        LLLModSettings.amountPenaltyConsciousness = listing.Slider(LLLModSettings.amountPenaltyConsciousness, -1f, 0f);
        listing.Label(
            "LLLMovementLabel".Translate() + ": -" + (-LLLModSettings.amountPenaltyMovement).ToStringPercent(),
            tooltip: "LLLMovementTooltip".Translate());
        LLLModSettings.amountPenaltyMovement = listing.Slider(LLLModSettings.amountPenaltyMovement, -1f, 0f);
        listing.Label("LLLRestLabel".Translate() + ": -" + (-LLLModSettings.amountPenaltyRest).ToStringPercent(),
            tooltip: "LLLRestTooltip".Translate());
        LLLModSettings.amountPenaltyRest = listing.Slider(LLLModSettings.amountPenaltyRest, -1f, 0f);
        listing.Label("LLLHungerLabel".Translate() + ": +" + LLLModSettings.amountHungerRate.ToStringPercent(),
            tooltip: "LLLHungerTooltip".Translate());
        LLLModSettings.amountHungerRate = listing.Slider(LLLModSettings.amountHungerRate, 0f, 1f);
        listing.Gap();
        listing.Label("LLLAddictivenessLabel".Translate() + ": " + LLLModSettings.amountAddictiveness.ToStringPercent(),
            tooltip: "LLLAddictivenessTooltip".Translate());
        LLLModSettings.amountAddictiveness = listing.Slider(LLLModSettings.amountAddictiveness, 0f, 0.40f);
        listing.Label("LLLToleranceLabel".Translate() + ": " + LLLModSettings.amountToleranceToAddict.ToStringPercent(),
            tooltip: "LLLToleranceTooltip".Translate());
        LLLModSettings.amountToleranceToAddict = listing.Slider(LLLModSettings.amountToleranceToAddict, 0f, 1f);
        listing.Gap();
        listing.Label("LLLAsthmaLabel".Translate() + ": " + LLLModSettings.amountAsthmaDaysChance,
            tooltip: "LLLAsthmaTooltip".Translate());
        LLLModSettings.amountAsthmaDaysChance = (int)listing.Slider(LLLModSettings.amountAsthmaDaysChance, 5, 2000);
        listing.Label("LLLCancerLabel".Translate() + ": " + LLLModSettings.amountCancerDaysChance,
            tooltip: "LLLCancerTooltip".Translate());
        LLLModSettings.amountCancerDaysChance = (int)listing.Slider(LLLModSettings.amountCancerDaysChance, 5, 2000);
        listing.Gap();
        listing.Label("LLLWithdrawalLabel".Translate() + ": " + LLLModSettings.amountPenaltyWithdrawal,
            tooltip: "LLLWithdrawalTooltip".Translate());
        LLLModSettings.amountPenaltyWithdrawal = (int)listing.Slider(LLLModSettings.amountPenaltyWithdrawal, -30, 0);

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