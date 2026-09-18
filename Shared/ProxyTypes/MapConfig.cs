using UnityEngine;
#if MCELoader
using Il2CppQuantum;
#endif
namespace MCELoader.Shared.ProxyTypes;

[SourceType(typeof(Il2CppQuantum.MapConfig))]
public class MapConfig : IAssetObject
{
#if MCEEditor
    public enum PoliceSpawn
    {
        NO_POLICE = -1,
        TwoThirdsScore = 0,
        TwoThirdsScoreAndTrigger = 1,
        HalfScore = 2,
    }
#endif
    public SpawnPointWithOrientation devSpawn; //Field offset: 0x28
    public SpawnPointWithOrientation[] spawnPoints; //Field offset: 0x48
    public SpawnPointWithDistance[] checkPoints; //Field offset: 0x50
    public Vector3[] itemSpawnPoints; //Field offset: 0x58
    public ConsumablePoint[] consumables; //Field offset: 0x60
    public Vector3[] stragglerBoostPoints; //Field offset: 0x68
    public SpecialEquipmentSpawnPoint[] specialEquipmentSpawnPoints; //Field offset: 0x70
    public EventTriggerEntry[] eventTriggerEntries; //Field offset: 0x78
    public MutableStaticColliderEntry[] mutableStaticColliderEntries; //Field offset: 0x80
    public PathConnectedCollider[] pathConnectedColliders; //Field offset: 0x88
    public Arena[] arenas; //Field offset: 0x90
    public NoBikesZone[] noBikesZones; //Field offset: 0x98
    public CurvePath mainPath; //Field offset: 0xA0
    public CurvePath[] miscPaths; //Field offset: 0xC8
    public int[] variableWaterLevelColliders; //Field offset: 0xD0
    public int[] variableWaterfallColliders; //Field offset: 0xD8
    public int[] variableWaterSprayColliders; //Field offset: 0xE0
    public DestructibleTerrainData[] destructibleTerrain; //Field offset: 0xE8
    public int[] destructibleTerrainColliders; //Field offset: 0xF0
    public HeliPathConnection[] heliPathConnections; //Field offset: 0xF8
    public RoadData[] roads; //Field offset: 0x100
    public LevelID levelID; // HACK/TODO inbound, im probably gonna reuse the map manifest guids but as fucky ints?
#if MCEEditor 
    public PoliceSpawn policeSpawnbehaviour; //Field offset: 0x10C
#else
    public Il2CppQuantum.MapConfig.PoliceSpawn policeSpawnbehaviour;
#endif
    public float carSpawnRateFactor; //Field offset: 0x110
    public float trucksPercent; //Field offset: 0x118
    public float checkpointSpawnRateFactor; //Field offset: 0x120
    public CurvePathSerializableData pathDataSerializable; //Field offset: 0x128 //HACK/TODO this is private in the proxied type!!!!!!!!, should probably use bepinex publizier??
    // public CurvePathData pathData; //Field offset: 0x150 // NOTE: CurvePathData has a constructor that takes in CurvePathSerializableData,
}
