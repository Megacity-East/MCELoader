
#if MCELoader
using Il2CppQuantum;
#endif
namespace MCELoader.Shared.ProxyTypes;

#if MCEEditor
public enum EventTriggerType
{
    None = 0,
    Kill = 1,
    PushOutBikes = 2,
    FinishLine = 3,
    Tutorial = 4,
    KillIfOffVehicle = 5,
    Waterfall = 6,
    Vegetation = 7,
    BarbedWire = 8,
    ActivatePolice = 9,
    MapVote = 10,
    BigScreenController = 11,
}
#endif

#if MCELoader
[SourceType(typeof(Il2CppQuantum.EventTriggerEntry))]
#endif
public struct EventTriggerEntry
{
    public int colliderIndex; //Field offset: 0x0
    public EventTriggerType type; //Field offset: 0x4
    public int data; //Field offset: 0x8

}
