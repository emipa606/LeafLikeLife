using System.Linq;
using RimWorld;
using Verse;

namespace LeafLikeLife;

public class LLLUtility
{
    private static readonly ThingDef smokeLeafJoint = ThingDef.Named("SmokeleafJoint");

    public static void UpdateAllChanges()
    {
        HediffDef.Named("SmokeleafHigh").stages
                .First(s => s.capMods.Any(m => m.capacity == PawnCapacityDefOf.Consciousness)).capMods
                .First(m => m.capacity == PawnCapacityDefOf.Consciousness).offset =
            LLLModSettings.amountPenaltyConsciousness;
        HediffDef.Named("SmokeleafHigh").stages
                .First(s => s.capMods.Any(m => m.capacity == PawnCapacityDefOf.Moving)).capMods
                .First(m => m.capacity == PawnCapacityDefOf.Moving).offset =
            LLLModSettings.amountPenaltyMovement;

        var restOffset =
            (IngestionOutcomeDoer_OffsetNeed)smokeLeafJoint.ingestible.outcomeDoers.Find(o =>
                o is IngestionOutcomeDoer_OffsetNeed);
        restOffset.offset = LLLModSettings.amountPenaltyRest;

        HediffDef.Named("SmokeleafHigh").stages[0].hungerRateFactorOffset = LLLModSettings.amountHungerRate;

        var comDrug = smokeLeafJoint.GetCompProperties<CompProperties_Drug>();

        comDrug.addictiveness = LLLModSettings.amountAddictiveness;
        comDrug.minToleranceToAddict = LLLModSettings.amountToleranceToAddict;

        var hediffAsthma = HediffDef.Named("SmokeleafTolerance").hediffGivers[0] as HediffGiver_RandomDrugEffect;
        var hediffCancer = HediffDef.Named("SmokeleafTolerance").hediffGivers[1] as HediffGiver_RandomDrugEffect;

        if (hediffAsthma != null)
        {
            hediffAsthma.baseMtbDays = LLLModSettings.amountAsthmaDaysChance;
        }

        if (hediffCancer != null)
        {
            hediffCancer.baseMtbDays = LLLModSettings.amountCancerDaysChance;
        }

        ThoughtDef.Named("SmokeleafWithdrawal").stages[1].baseMoodEffect = LLLModSettings.amountPenaltyWithdrawal;
    }
}