using Verse;

namespace LeafLikeLife;

[StaticConstructorOnStartup]
public static class LLLStartUp
{
    static LLLStartUp()
    {
        // Loads right before main menu
        LLLUtility.UpdateAllChanges();
    }
}