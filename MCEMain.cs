using MelonLoader;

[assembly: MelonInfo(typeof(MCELoader.MCEMain), MCELoader.BuildInfo.Name, MCELoader.BuildInfo.Version, MCELoader.BuildInfo.Author)]
namespace MCELoader;

public class MCEMain : MelonMod
{
    public static MCEMain Instance = Melon<MCEMain>.Instance;
    public static MelonLogger.Instance Logger => Melon<MCEMain>.Logger;
}
