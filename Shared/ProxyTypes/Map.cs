namespace MCELoader.Shared.ProxyTypes;

// TODO need to implement this, probably?, i really have no fucking clue how though qwq
// NOTE: look into DynamicMap, it inherits from Map, so it could be interesting...
#if MCELoader
[SourceType(typeof(Il2CppQuantum.Map))]
#endif
public class Map : IAssetObject
{
#if MCEEditor
    public enum BucketAxis
    {
        X = 0,
        Y = 1,
    }
    public enum SortAxis
    {
        X = 0,
        Y = 1,
    }
#endif
    // public AssetRef UserAsset; //Field offset: 0x28 
    public string Scene; //Field offset: 0x30
    public string ScenePath; //Field offset: 0x38
    public string SceneGuid; //Field offset: 0x40

    public int WorldSize; //Field offset: 0x48 // TODO figure out, probably bounding box?, importance is unclear!
    public int BucketsCount; //Field offset: 0x4C
    public int BucketsSubdivisions; //Field offset: 0x50
#if MCEEditor
    public Map.BucketAxis BucketingAxis; //Field offset: 0x54 // TODO figure out what this is used for, leaning navmesh
    public Map.SortAxis SortingAxis; //Field offset: 0x55 // TODO figure out what this is used for, leaning navmesh
#else 
    public Il2CppQuantum.PhysicsCommon.BucketAxis BucketingAxis; //Field offset: 0x54 // TODO figure out what this is used for, leaning navmesh
    public Il2CppQuantum.PhysicsCommon.SortAxis SortingAxis; //Field offset: 0x55 // TODO figure out what this is used for, leaning navmesh
#endif
    public float SceneMeshCellSize; //Field offset: 0x58
    public int TriangleMeshCellSize; //Field offset: 0x60

    //    public AssetRef<BinaryData> StaticColliders3DTrianglesData; //Field offset: 0x68

    public bool SerializeTrianglesMetadata; //Field offset: 0x70
    public int GridSizeX; //Field offset: 0x74 // NOTE: seems to be irelevant to fill, only used for navmeshes which as of build 42 is unused
    public int GridSizeY; //Field offset: 0x78 //NOTE: navmesh related
    public int GridNodeSize; //Field offset: 0x7C //NOTE: navmesh related

    //    public AssetRef<NavMesh>[] NavMeshLinks; //Field offset: 0x80 //NOTE: navmesh related
    // public string[] Regions; //Field offset: 0x88 // NOTE: also always empty

    //    public MapStaticCollider2D[] StaticColliders2D; //Field offset: 0x90 // NOTE: Always Empty 
    public MapStaticCollider3D[] StaticColliders3D; //Field offset: 0x98 // NOTE/TODO: High prot, colliders are thankfully pretty simple
    public ComponentPrototypeSet[] MapEntities; //Field offset: 0xA0 //NOTE: Exciting, daring, playful, could this be it?
    public int SerializedTriangleDataUncompressedSize; //Field offset: 0xA8

    //    public SortedDictionary<int, MeshTriangleVerticesCcw> CollidersManagedTriangles; //Field offset: 0xB0 // NOTE: I think this is set by the collider mesh loading
    //    public SortedDictionary<int, MeshUnmanagedTrianglesRef> CollidersRuntimeTriangles; //Field offset: 0xB8

    // public UnmanagedTriangleArray AllRuntimeTriangles; //Field offset: 0xC0 // NOTE: ABSOLUTELY ZERO CLUE HOW TO WORK WITH THIS

    //    public List<PolygonColliderRuntimeData> StaticPolygonColliderData; //Field offset: 0xC8
    //    public Dictionary<string, NavMesh> NavMeshes; //Field offset: 0xD0 //NOTE: navmesh related
    //    public Dictionary<string, int> RegionMap; //Field offset: 0xD8 //NOTE: unused so :3
}
