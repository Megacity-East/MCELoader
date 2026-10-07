using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
using System.IO.Compression;
using Il2CppView_Traffic;
using MelonLoader.Utils;
using Il2CppView_Main;
using Newtonsoft.Json;
using Il2CppQuantum;
using MelonLoader;
using UnityEngine;

using MCELoader.Shared;
using MCELoader.Extensions;

using MCEMap = MCELoader.Shared.ProxyTypes.Map;
using MCEMapConfig = MCELoader.Shared.ProxyTypes.MapConfig;

namespace MCELoader;

public static class Loader
{
    public static readonly string CustomMapsInstallDirectory = Path.Combine(MelonEnvironment.UserDataDirectory, "MCEMaps");

    public static string GetMapLoadPath(Il2CppQuantum.LevelID levelID)
    {
        return Path.Combine(ResourceManager.MCEBasePath, LoadedMaps.First().Manifest.Name); // TODO Implement
    }

    public struct MapWrapper
    {
        public MCEManifest Manifest;
        public MCEMap Map;
        public MCEMapConfig MapConfig;

        public AssetGuid MapRef;
        public AssetGuid MapConfigRef;
        public AssetBundle SceneBundle;
        public AssetBundle AssetsBundle;

    }

    public static List<MapWrapper> LoadedMaps = new();

    private static bool _hasStolenAirframeGame => _airframeGame != null;
    private static GameObject _airframeGame;
    private static Dictionary<Il2CppSystem.Type, bool> _originalEnabled = new();




    public static void Initalize()
    {
        if (Directory.Exists(CustomMapsInstallDirectory))
        {
            foreach (string filePath in Directory.EnumerateFiles(CustomMapsInstallDirectory))
            {
                if (Path.GetExtension(filePath) is not ".amf")
                    continue;

                ZipArchive archive = OpenZipArchive(filePath);
                ZipArchiveEntry manifestEntry = archive.GetEntry("manifest.json");
                ZipArchiveEntry mapEntry = archive.GetEntry("Map.json");
                ZipArchiveEntry mapConfigEntry = archive.GetEntry("MapConfig.json");
                ZipArchiveEntry sceneEntry = archive.GetEntry("scene");
                ZipArchiveEntry assetsEntry = archive.GetEntry("assets");


                string manifestJson = manifestEntry.OpenText();
                string mapJson = mapEntry.OpenText();
                string mapConfigJson = mapConfigEntry.OpenText();
                Stream sceneStream = sceneEntry.Open();
                Stream assetsStream = assetsEntry.Open();

                AssetBundle sceneBundle;
                using (var memoryStream = new MemoryStream())
                {
                    sceneStream.CopyTo(memoryStream);
                    sceneBundle = AssetBundle.LoadFromMemory(memoryStream.ToArray());
                }
                sceneStream.Close();

                AssetBundle assetsBundle;
                using (var memoryStream = new MemoryStream())
                {
                    assetsStream.CopyTo(memoryStream);
                    assetsBundle = AssetBundle.LoadFromMemory(memoryStream.ToArray());
                }
                assetsStream.Close();


                MCEManifest manifest = JsonConvert.DeserializeObject<MCEManifest>(manifestJson, settings: JsonUtils.SerializerSettings);

                MCEMap mapProxy = JsonConvert.DeserializeObject<MCEMap>(mapJson, settings: JsonUtils.SerializerSettings);
                MCEMapConfig mapConfigProxy = JsonConvert.DeserializeObject<MCEMapConfig>(mapConfigJson, settings: JsonUtils.SerializerSettings);

                Map mapQNative = mapProxy.ToQNative(); // ToQNative is generated at build time (comments here incase your lsp is bitching)
                MapConfig mapConfigQNative = mapConfigProxy.ToQNative(); // ToQNative is generated at build time (comments here incase your lsp is bitching)

                mapConfigQNative.levelID = LevelID.none; // TODO: REPLACE WITH SOME BETTER LOGIC!!!

                mapQNative.name = manifest.Name;
                mapConfigQNative.name = $"{manifest.Name}_Config";


                AssetGuid mapConfigGuid = ResourceManager.RegisterQuantumResource(Path.Combine(ResourceManager.MCEBasePath, $"{manifest.Name}_Config"), mapConfigQNative);
                mapQNative.UserAsset = mapConfigGuid;
                ResourceManager.RegisterQuantumResource(Path.Combine(ResourceManager.MCEBasePath, manifest.Name), mapQNative);


                ResourceManager.RegisterScene(mapQNative.ScenePath, name: mapQNative.Scene);



                MapWrapper wrapper = new()
                {
                    Manifest = manifest,
                    Map = mapProxy,
                    MapConfig = mapConfigProxy,

                    MapRef = mapQNative.Guid,
                    MapConfigRef = mapConfigQNative.Guid,
                    SceneBundle = sceneBundle,
                    AssetsBundle = assetsBundle,
                };

                LoadedMaps.Add(wrapper);
                archive.Dispose();

                MCEMain.Logger.Msg($"Loaded '{wrapper.Manifest.DisplayName}'");
            }
        }
        else
            Directory.CreateDirectory(CustomMapsInstallDirectory);
    }

    public static ZipArchive OpenZipArchive(string path)
    {
        Stream zipStream = File.Open(path, FileMode.Open);
        return new(zipStream);
    }

    public static string OpenText(this ZipArchiveEntry entry)
    {
        Stream stream = entry.Open();
        StreamReader reader = new(stream);
        string content = reader.ReadToEnd();

        reader.Close();

        return content;
    }



    public static void HandleCustomMapLoad(MapWrapper wrapper)
    {
        Map quantumMap = QuantumUnityDB.GetGlobalAsset<Map>(wrapper.MapRef);

        GameObject airframeGame = _airframeGame;
        ViewResources.instance = Resources.Load<ViewResources>("ViewResources");
        new LOD_Culling(); // its constructor sets LOD_Culling.instance, which alot of view stuff uses
        MCEMain.Logger.Msg(quantumMap);
        SceneManager.MoveGameObjectToScene(airframeGame, SceneManager.GetActiveScene());

        Il2CppQuantum.QuantumMapData mapData = airframeGame.GetComponent<Il2CppQuantum.QuantumMapData>();
        mapData.AssetRef = quantumMap;
        mapData.StaticCollider3DReferences.Clear(); // Unused at runtime

        mapData.MapEntityReferences.Clear(); // NOTE: Important!, Currently unclear to me if this sets the simulation or the simulation sets this!


        Il2Cpp.CUSTOM_QuantumEntityViewUpdater viewUpdater = airframeGame.GetComponent<Il2Cpp.CUSTOM_QuantumEntityViewUpdater>();
        viewUpdater.humanoidsDictionary.Clear();
        viewUpdater.ActiveEntities.Clear();
        viewUpdater.ActiveViews.Clear();

        Main_View mainView = airframeGame.GetComponent<Main_View>();
        mainView.viewResources = ViewResources.instance;

        foreach (MonoBehaviour comp in airframeGame.GetComponentsInChildren<MonoBehaviour>())
        {
            comp.enabled = _originalEnabled[comp.GetIl2CppType()];
        }

        airframeGame.active = true;
    }

    public static System.Collections.IEnumerator StealAirframeGameCoroutine()
    // TODO: figure out a better approach
    // Currently this breaks when the map loads for the second time and we cant just reload the warehouse again in the MainMenu :<
    // Could be worth it to just reconstruct from scratch...
    {
        if (_hasStolenAirframeGame)
            yield break;

        var loadOp = Addressables.LoadSceneAsync("Warehouse", UnityEngine.SceneManagement.LoadSceneMode.Additive);
        while (loadOp.IsDone == false)
            yield return null; // waits until its loaded

        _airframeGame = GameObject.Instantiate(loadOp.Result.Scene.GetRootGameObjects().First(obj => obj.name == "AirframeGame"));

        _airframeGame.GetComponentInChildren<CarRenderer>().enabled = false; // neeeds car data
        _airframeGame.GetComponentInChildren<CarCarriageRenderer>().enabled = false; // needs car data

        foreach (MonoBehaviour component in _airframeGame.GetComponentsInChildren<MonoBehaviour>(includeInactive: true))
        {
            _originalEnabled[component.GetIl2CppType()] = component.enabled;
            component.enabled = false;
        }

        _airframeGame.active = false;
        _airframeGame.name = "AirframeGame_MCELoader";

        GameObject.DontDestroyOnLoad(_airframeGame);
        Addressables.UnloadScene(loadOp.Result);
    }

}
