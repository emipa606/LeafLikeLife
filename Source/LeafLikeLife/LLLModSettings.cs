using Verse;

namespace LeafLikeLife;

public class LLLModSettings : ModSettings
{
    public static float amountPenaltyConsciousness = -0.15f;
    public static float amountPenaltyMovement = -0.1f;
    public static float amountPenaltyRest = -0.1f;
    public static float amountHungerRate = 0.3f;

    public static float amountAddictiveness = 0.01f;
    public static float amountToleranceToAddict = 0.50f;

    public static int amountAsthmaDaysChance = 360;
    public static int amountCancerDaysChance = 720;

    public static int amountPenaltyWithdrawal = -8;


    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref amountPenaltyConsciousness, "LLLamountPenaltyConsciousness", -0.15f);
        Scribe_Values.Look(ref amountPenaltyMovement, "LLLamountPenaltyMovement", -0.1f);
        Scribe_Values.Look(ref amountPenaltyRest, "LLLamountPenaltyRest", -0.1f);
        Scribe_Values.Look(ref amountHungerRate, "LLLamountHungerRate", 0.3f);
        Scribe_Values.Look(ref amountAddictiveness, "LLLamountAddictiveness", 0.01f);
        Scribe_Values.Look(ref amountToleranceToAddict, "LLLamountToleranceToAddict", 0.50f);
        Scribe_Values.Look(ref amountAsthmaDaysChance, "LLLamountAsthmaDaysChance", 360);
        Scribe_Values.Look(ref amountCancerDaysChance, "LLLamountCancerDaysChance", 720);
        Scribe_Values.Look(ref amountPenaltyWithdrawal, "LLLamountPenaltyWithdrawal", -8);
    }

    public static void ResetSettings()
    {
        amountPenaltyConsciousness = -0.15f;
        amountPenaltyMovement = -0.1f;
        amountPenaltyRest = -0.1f;
        amountHungerRate = 0.3f;
        amountAddictiveness = 0.01f;
        amountToleranceToAddict = 0.50f;
        amountAsthmaDaysChance = 360;
        amountCancerDaysChance = 720;
        amountPenaltyWithdrawal = -8;
    }

    public static void VanillaSettings()
    {
        amountPenaltyConsciousness = -0.3f;
        amountPenaltyMovement = -0.1f;
        amountPenaltyRest = -0.1f;
        amountHungerRate = 0.3f;
        amountAddictiveness = 0.02f;
        amountToleranceToAddict = 0.15f;
        amountAsthmaDaysChance = 180;
        amountCancerDaysChance = 180;
        amountPenaltyWithdrawal = -20;
    }
}