using Verse;

namespace UndraftAfterTucking
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new HarmonyLib.Harmony($"MadaraUchiha.{nameof(UndraftAfterTucking)}");
            harmony.PatchAll();
        }
    }
}
