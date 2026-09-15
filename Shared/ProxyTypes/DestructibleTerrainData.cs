
namespace MCELoader.Shared.ProxyTypes;

public struct DestructibleTerrainData
{
    //    public enum Type
    //    {
    //        CosmeticPhysicsObject = 0,
    //    }

    public int firstColliderIndex; //Field offset: 0x0
    public int colliderCount; //Field offset: 0x4
    public float mass; //Field offset: 0x8
    public float breakForceSq; //Field offset: 0x10
    public int type; //Field offset: 0x18 HACK/TODO currently were just gonna make this an int, as its unused but this may not be true in versions post v42

}

