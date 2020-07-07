using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace UndraftAfterTucking
{
    [HarmonyPatch(typeof(JobDriver_TakeToBed), "MakeNewToils")]
    public class Harmony
    {
        static IEnumerable<Toil> Postfix(IEnumerable<Toil> values, JobDriver_TakeToBed __instance)
        {
            foreach (var toil in values) yield return toil;
            var undraftToil = new Toil()
            {
                initAction = () =>
                {
                    var pawn = __instance.pawn;
                    if (pawn.Drafted)
                    {
                        pawn.drafter.Drafted = false;
                    }
                }
            };

            yield return undraftToil;
        }
    }
}