
#if MCELoader
using Il2CppQuantum;
#endif
namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.RoadInstruction))]
#endif
public struct RoadInstruction
{
    public RoadInstructionType type; //Field offset: 0x0
    public PathDistance pathDistance; //Field offset: 0x8
    public uint lane; //Field offset: 0x18
    public int data; //Field offset: 0x1C
    public float myLinearSplineDist; //Field offset: 0x20
}
