namespace MCELoader.Shared;

public class MCEManifest
{
    /// <summary> Randomly generated uuid, during map compile</summary>
    public Guid MapID = new(); // This should be different everytime a map is compiled

    /// <summary> The version of MCE Editor this map was compiled with</summary>
    public string EditorVersion;

    /// <summary> The version of MCE Loader this map was compiled for</summary>
    public string TargetLoaderVersion;

    /// <summary> The name of the map</summary>
    public string Name;

    /// <summary> The version of the map</summary>
    /// <remarks> Should be semvar </remarks>
    public string Version = "v0.0.0";

    /// <summary> The authors of the map</summary>
    public string[] Authors;

    /// <remarks> should be the path to the json for the `MapConfig` </remarks>
    public string RelativeMapConfigPath;
    /// <remarks> should be the path to the json for the `Map` </remarks>
    public string RelativeMapPath;

    /// <remarks> should be the path to the bundle with all the Assets</remarks>
    public string RelativeAssetBundlePath;
    /// <remarks> should be the path to the bundle with the Scene</remarks>
    public string RelativeSceneBundlePath;
}
