#if MCELoader
using Il2CppQuantum;
#endif
namespace MCELoader.Shared.ProxyTypes;

#if MCEEditor
public enum MutableStaticColliderType
{
	Misc = 0,
	Podium = 1,
	ShopDoorClosed = 2,
}
#endif

public struct MutableStaticColliderEntry
{
    public int colliderIndex; //Field offset: 0x0
    public MutableStaticColliderType type; //Field offset: 0x4
    public int data; //Field offset: 0x8

}
