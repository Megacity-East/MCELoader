using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine;

#if MCELoader 
using MCELoader.Extensions;
using Il2CppQuantum;
#endif

namespace MCELoader.Shared.ProxyTypes;

[Serializable]
public struct ConsumablePoint
{
    public Vector3 position;

    [JsonConverter(typeof(StringEnumConverter))]
    public PickupType consumableType;

#if MCELoader 
    public Il2CppQuantum.ConsumablePoint ToQNative()
    {
        return new()
        {
            position = this.position.ToQNative(),
            consumableType = this.consumableType,
        };
    }
#endif
}
