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
            yield return UndraftToil.For(__instance);
        }
    }

    [HarmonyPatch(typeof(JobDriver_CarryToCryptosleepCasket), "MakeNewToils")]
    public class CryptosleepCasketPatch
    {
        static IEnumerable<Toil> Postfix(IEnumerable<Toil> values, JobDriver_CarryToCryptosleepCasket __instance)
        {
            foreach (var toil in values) yield return toil;
            yield return UndraftToil.For(__instance);
        }
    }

    static class UndraftToil
    {
        public static Toil For(JobDriver driver)
        {
            return new Toil()
            {
                initAction = () =>
                {
                    var pawn = driver.pawn;
                    if (pawn.Drafted)
                    {
                        pawn.drafter.Drafted = false;
                    }
                }
            };
        }
    }
}
