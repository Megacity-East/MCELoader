using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

#if MCELoader 
using Il2CppQuantum;
#endif

namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.ConsumablePoint))]
#endif

public struct ConsumablePoint
{
    public Vector3 position;

    [JsonConverter(typeof(StringEnumConverter))]
    public PickupType consumableType;
}
