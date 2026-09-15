#if MCELoader
using Il2CppQuantum;
#endif

namespace MCELoader.Shared.ProxyTypes;

public struct RoadConnection
{
    public static readonly RoadConnection None; //Field offset: 0x0
    public int connectionIndex; //Field offset: 0x0
    public int otherRoad; //Field offset: 0x4
    public PathDistance myPathDistance; //Field offset: 0x8
    public PathDistance otherPathDistance; //Field offset: 0x18
    public uint myLane; //Field offset: 0x28
    public uint otherLane; //Field offset: 0x2C
    public RoadConnectionFlags flags; //Field offset: 0x30
    public float dirDot; //Field offset: 0x38
    public float myLinearSplineDist; //Field offset: 0x40
    public bool trucksAllowed; //Field offset: 0x48
}
