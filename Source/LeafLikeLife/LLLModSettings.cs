using Verse;

namespace LeafLikeLife;

public class LLLModSettings : ModSettings
{
    public static float AmountPenaltyConsciousness = -0.15f;
    public static float AmountPenaltyMovement = -0.1f;
    public static float AmountPenaltyRest = -0.1f;
    public static float AmountHungerRate = 0.3f;

    public static float AmountAddictiveness = 0.01f;
    public static float AmountToleranceToAddict = 0.50f;

    public static int AmountAsthmaDaysChance = 360;
    public static int AmountCancerDaysChance = 720;

    public static int AmountPenaltyWithdrawal = -8;


    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AmountPenaltyConsciousness, "LLLamountPenaltyConsciousness", -0.15f);
        Scribe_Values.Look(ref AmountPenaltyMovement, "LLLamountPenaltyMovement", -0.1f);
        Scribe_Values.Look(ref AmountPenaltyRest, "LLLamountPenaltyRest", -0.1f);
        Scribe_Values.Look(ref AmountHungerRate, "LLLamountHungerRate", 0.3f);
        Scribe_Values.Look(ref AmountAddictiveness, "LLLamountAddictiveness", 0.01f);
        Scribe_Values.Look(ref AmountToleranceToAddict, "LLLamountToleranceToAddict", 0.50f);
        Scribe_Values.Look(ref AmountAsthmaDaysChance, "LLLamountAsthmaDaysChance", 360);
        Scribe_Values.Look(ref AmountCancerDaysChance, "LLLamountCancerDaysChance", 720);
        Scribe_Values.Look(ref AmountPenaltyWithdrawal, "LLLamountPenaltyWithdrawal", -8);
    }

    public static void ResetSettings()
    {
        AmountPenaltyConsciousness = -0.15f;
        AmountPenaltyMovement = -0.1f;
        AmountPenaltyRest = -0.1f;
        AmountHungerRate = 0.3f;
        AmountAddictiveness = 0.01f;
        AmountToleranceToAddict = 0.50f;
        AmountAsthmaDaysChance = 360;
        AmountCancerDaysChance = 720;
        AmountPenaltyWithdrawal = -8;
    }

    public static void VanillaSettings()
    {
        AmountPenaltyConsciousness = -0.3f;
        AmountPenaltyMovement = -0.1f;
        AmountPenaltyRest = -0.1f;
        AmountHungerRate = 0.3f;
        AmountAddictiveness = 0.02f;
        AmountToleranceToAddict = 0.15f;
        AmountAsthmaDaysChance = 180;
        AmountCancerDaysChance = 180;
        AmountPenaltyWithdrawal = -20;
    }
}