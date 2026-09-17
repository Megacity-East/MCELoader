using UnityEngine;
namespace MCELoader.Shared.ProxyTypes;

#if MCELoader 
using Il2CppQuantum;
#endif

#if MCELoader
[SourceType(typeof(Il2CppQuantum.SpecialEquipmentSpawnPoint))]
#endif
public struct SpecialEquipmentSpawnPoint
{
    public Vector3 position; //Field offset: 0x0
    public EquipmentID eqID; //Field offset: 0x18
    public EquipmentID altEqID; //Field offset: 0x1C
    public bool ignoreShopTags; //Field offset: 0x20
    public ItemPricingType pricingType; //Field offset: 0x24
    public int arena; //Field offset: 0x28

}
