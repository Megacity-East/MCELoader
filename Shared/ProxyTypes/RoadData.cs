using UnityEngine;

namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.RoadData))]
#endif
public struct RoadData
{

#if MCEEditor
    public enum RoadType
    {
        Standard = 0,
        BackStreet = 1,
        Highway = 2,
        HighwayRamp = 3,
    }
#endif

    public float widthInMeters; //Field offset: 0x0
    public float spawnRateFac; //Field offset: 0x8
    public bool continueAtStart; //Field offset: 0x10
    public bool continueAtEnd; //Field offset: 0x11

#if MCEEditor
    public RoadType roadType; //Field offset: 0x14
#else
    public Il2CppQuantum.RoadData.RoadType roadType;
#endif
    public bool startWithConnection; //Field offset: 0x18
    public bool endWithConnection; //Field offset: 0x19
    public Vector3 generalDirection; //Field offset: 0x20
    public int pathIndex; //Field offset: 0x38
    public RoadConnection[] connections; //Field offset: 0x40
    public RoadInstruction[] instructions; //Field offset: 0x48
    public List<int> bannedMergeNodes; //Field offset: 0x50
    public int lanesCount; //Field offset: 0x58
}
