using MelonLoader;

[assembly: MelonInfo(typeof(MCELoader.MCEMain), MCELoader.BuildInfo.Name, MCELoader.BuildInfo.Version, MCELoader.BuildInfo.Author)]
namespace MCELoader;

public class MCEMain : MelonMod
{
    public static MCEMain Instance = Melon<MCEMain>.Instance;
    public static MelonLogger.Instance Logger => Melon<MCEMain>.Logger;

    public override void OnLateInitializeMelon()
    {
        MCELoader.Patches.ResourcesAPI_Load_NativeHook.Initalize();
    }

    public override void OnSceneWasLoaded(int buildIndex, string sceneName)
    {

        if (sceneName is "Splashes")
        {
            Loader.Initalize();
            MelonCoroutines.Start(Loader.StealAirframeGameCoroutine());
        }
        if (ResourceManager.TryGetPathFromName(sceneName, out string path))
        {
            Loader.MapWrapper wrapper = Loader.LoadedMaps.First(wrapper => wrapper.Map.ScenePath == path);
            Loader.HandleCustomMapLoad(wrapper);

        }
    }
}
