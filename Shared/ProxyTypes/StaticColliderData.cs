namespace MCELoader.Shared.ProxyTypes;

#if MCELoader
[SourceType(typeof(Il2CppQuantum.StaticColliderData))]
#endif 
public struct StaticColliderData
{
#if MCEEditor
	public enum StaticColliderMutableMode
	{
		Immutable = 0,
		ToggleableStartOn = 1,
		ToggleableStartOff = 2,
	}
#endif
    public string Name; //Field offset: 0x0
    public string Tag; //Field offset: 0x8
    public int Layer; //Field offset: 0x10

    //    public AssetRef Asset; //Field offset: 0x18 //NOTE: thank the fucking lord this is unused

    public bool IsTrigger; //Field offset: 0x20
    public int ColliderIndex; //Field offset: 0x24
#if MCELoader
    public Il2CppQuantum.PhysicsCommon.StaticColliderMutableMode MutableMode; //Field offset: 0x28
#else
    public StaticColliderData.StaticColliderMutableMode MutableMode; //Field offset: 0x28
#endif

}
