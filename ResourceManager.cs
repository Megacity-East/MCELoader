using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.AddressableAssets;
using Il2CppQuantum;

namespace MCELoader;

public static class ResourceManager
{

    public const string MCEBasePath = "MCE_Root";
    public const string QuantumResourceBasePath = "QuantumUser/Resources";

    private static Dictionary<string, object> _customResources = new();
    private static Dictionary<string, AssetObject> _customQuantumResources = new();
    private static Dictionary<string, string> _scenePathToSceneName = new();
    private static Dictionary<string, string> _sceneSceneNameToPath = new();
    private static List<ContentCatalogData.CompactLocation> _locations = new(1); // here for debug purposes with UE

    public static Dictionary<string, object> Resources => _customResources;
    public static Dictionary<string, AssetObject> QuantumResources => _customQuantumResources;


    public static bool TryGetResource(string path, out object resource) => _customResources.TryGetValue(path, out resource);
    public static bool TryGetSceneName(string path, out string name) => _scenePathToSceneName.TryGetValue(path, out name);
    public static bool TryGetPathFromName(string name, out string path) => _sceneSceneNameToPath.TryGetValue(name, out path);


    public static void RegisterScene(string path, string name)
    {
        MCEMain.Logger.Msg("Registering Scene");
        _scenePathToSceneName.Add(path, name);
        _sceneSceneNameToPath.Add(name, path);

        ResourceLocationMap resourceMap = Addressables.Instance.m_ResourceLocators[0].Locator.Cast<ResourceLocationMap>();
        int warehouseDeps = resourceMap.Locations["Warehouse"][0].DependencyHashCode;
        ContentCatalogData.CompactLocation compactLocation = new(resourceMap, path, "", null, null, warehouseDeps, name, Il2CppSystem.Type.GetType("UnityEngine.ResourceManagement.ResourceProviders.SceneInstance"));

        resourceMap.Add(name, compactLocation.Cast<IResourceLocation>());
        _locations.Add(compactLocation);
        MCEMain.Logger.Msg($"Registered Scene '{path}'");

    }
    public static AssetGuid RegisterQuantumResource(string path, AssetObject resource)
    {

        if (resource.name == String.Empty)
            resource.name = Path.GetFileName(path);

        resource.Path = path;
        AssetGuid guid = QuantumUnityDB.CreateRuntimeDeterministicGuid(resource);
        resource.Guid = guid;

        QuantumUnityDB.Global.AddAsset(resource);
        _customQuantumResources.Add(Path.Combine(QuantumResourceBasePath, path), resource);
        _customResources.Add(path, resource);
        return guid;
    }
    public static void RegisterResource(string path, object resource)
    {
        _customResources.Add(path, resource);
    }


}
