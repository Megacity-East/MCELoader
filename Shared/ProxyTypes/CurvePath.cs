namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.CurvePath))]
#endif
public struct CurvePath
{
    public int ID; //Field offset: 0x0
    public bool closedLoop; //Field offset: 0x4
    public int count; //Field offset: 0x8
    public float length; //Field offset: 0x10
    public float width; //Field offset: 0x18
    public int dataOffset; //Field offset: 0x20
    public int radiiOffset; //Field offset: 0x24
}
