using UnityEngine;
namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.NoBikesZone))]
#endif
public struct NoBikesZone
{
    public Transform transform; //Field offset: 0x0
    public Vector3 boxExtents; //Field offset: 0x40
    public Vector3 bikeSpawnPos; //Field offset: 0x58
    public float bikeSpawnRad; //Field offset: 0x70
    public float bikeSpawnDir; //Field offset: 0x78

}
