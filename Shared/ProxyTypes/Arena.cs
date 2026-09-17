using UnityEngine;
#if MCELoader
using Il2CppQuantum;
#endif

namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.Arena))]
#endif
public struct Arena
{
    public Transform transform; //Field offset: 0x0
    public Vector3 boxExtents; //Field offset: 0x40
    public Transform extensionBox_Transform; //Field offset: 0x58
    public Vector3 extensionBox_extents; //Field offset: 0x98
    public ArenaType arenaType; //Field offset: 0xB0
    public ArenaFlags flags; //Field offset: 0xB4
    public SpecialArenaBehaviorID specialArenaBehaviorID; //Field offset: 0xB8
    public CollectableShopID collectableShopID; //Field offset: 0xBC
    public float quickStopChance; //Field offset: 0xC0
    public int closestPathPointIndex; //Field offset: 0xC8
    public int finishlineCheckpointIndex; //Field offset: 0xCC
    public int spawnPointsStart; //Field offset: 0xD0
    public int spawnPointsEnd; //Field offset: 0xD4
    public int checkPointsStart; //Field offset: 0xD8
    public int checkPointsEnd; //Field offset: 0xDC
    public int itemSpawnPointsStart; //Field offset: 0xE0
    public int itemSpawnPointsEnd; //Field offset: 0xE4
    public int consumablesStart; //Field offset: 0xE8
    public int consumablesEnd; //Field offset: 0xEC
    public int startLineColliderIndex; //Field offset: 0xF0
    public Vector3 startLinePos; //Field offset: 0xF8
    public Vector3 startLineDirection; //Field offset: 0x110
}

