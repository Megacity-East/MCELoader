using UnityEngine;

namespace MCELoader.Shared.ProxyTypes;


#if MCELoader
[SourceType(typeof(Il2CppQuantum.SpawnPointWithDistance))]
#endif
public struct SpawnPointWithDistance
{
    public Vector3 position;
    public float distanceAlongPath;
}
