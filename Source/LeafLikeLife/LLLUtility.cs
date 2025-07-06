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
            LLLModSettings.AmountPenaltyConsciousness;
        HediffDef.Named("SmokeleafHigh").stages
                .First(s => s.capMods.Any(m => m.capacity == PawnCapacityDefOf.Moving)).capMods
                .First(m => m.capacity == PawnCapacityDefOf.Moving).offset =
            LLLModSettings.AmountPenaltyMovement;

        var restOffset =
            (IngestionOutcomeDoer_OffsetNeed)smokeLeafJoint.ingestible.outcomeDoers.Find(o =>
                o is IngestionOutcomeDoer_OffsetNeed);
        restOffset.offset = LLLModSettings.AmountPenaltyRest;

        HediffDef.Named("SmokeleafHigh").stages[0].hungerRateFactorOffset = LLLModSettings.AmountHungerRate;

        var comDrug = smokeLeafJoint.GetCompProperties<CompProperties_Drug>();

        comDrug.addictiveness = LLLModSettings.AmountAddictiveness;
        comDrug.minToleranceToAddict = LLLModSettings.AmountToleranceToAddict;

        var hediffAsthma = HediffDef.Named("SmokeleafTolerance").hediffGivers[0] as HediffGiver_RandomDrugEffect;
        var hediffCancer = HediffDef.Named("SmokeleafTolerance").hediffGivers[1] as HediffGiver_RandomDrugEffect;

        if (hediffAsthma != null)
        {
            hediffAsthma.baseMtbDays = LLLModSettings.AmountAsthmaDaysChance;
        }

        if (hediffCancer != null)
        {
            hediffCancer.baseMtbDays = LLLModSettings.AmountCancerDaysChance;
        }

        ThoughtDef.Named("SmokeleafWithdrawal").stages[1].baseMoodEffect = LLLModSettings.AmountPenaltyWithdrawal;
    }
}