#if false
//TODO need to implement this, probably?, i really have no fucking clue how though qwq
public class Map : AssetObject
{
    [InlineHelp]
    public AssetRef UserAsset; //Field offset: 0x28
    [InlineHelp]
    public string Scene; //Field offset: 0x30
    [InlineHelp]
    public string ScenePath; //Field offset: 0x38
    [InlineHelp]
    public string SceneGuid; //Field offset: 0x40
    [Header("Physics Settings")]
    [InlineHelp]
    public int WorldSize; //Field offset: 0x48
    [InlineHelp]
    public int BucketsCount; //Field offset: 0x4C
    [InlineHelp]
    public int BucketsSubdivisions; //Field offset: 0x50
    [InlineHelp]
    public BucketAxis BucketingAxis; //Field offset: 0x54
    [InlineHelp]
    public SortAxis SortingAxis; //Field offset: 0x55
    [DrawIf("TriangleMeshCellSize", 0, CompareOperator::LessOrEqual(3), DrawIfMode::Hide(1))]
    [InlineHelp]
    public FP SceneMeshCellSize; //Field offset: 0x58
    [DrawIf("TriangleMeshCellSize", 0, CompareOperator::Greater(5), DrawIfMode::Hide(1))]
    [Obsolete("Use SceneMeshCellSize instead for representing the cell size with an FP value.")]
    public int TriangleMeshCellSize; //Field offset: 0x60
    [InlineHelp]
    public AssetRef<BinaryData> StaticColliders3DTrianglesData; //Field offset: 0x68
    [InlineHelp]
    [Obsolete("No longer used. Triangle metadata is no longer (de)serialized, only recomputed upon de-serialization.")]
    public bool SerializeTrianglesMetadata; //Field offset: 0x70
    [Header("NavMesh Settings")]
    [InlineHelp]
    public int GridSizeX; //Field offset: 0x74
    [InlineHelp]
    public int GridSizeY; //Field offset: 0x78
    [InlineHelp]
    public int GridNodeSize; //Field offset: 0x7C
    [InlineHelp]
    [Space]
    public AssetRef<NavMesh>[] NavMeshLinks; //Field offset: 0x80
    [InlineHelp]
    public string[] Regions; //Field offset: 0x88
    [InlineHelp]
    public MapStaticCollider2D[] StaticColliders2D; //Field offset: 0x90
    [InlineHelp]
    public MapStaticCollider3D[] StaticColliders3D; //Field offset: 0x98
    [InlineHelp]
    public ComponentPrototypeSet[] MapEntities; //Field offset: 0xA0
    public int SerializedTriangleDataUncompressedSize; //Field offset: 0xA8
    public SortedDictionary<int, MeshTriangleVerticesCcw> CollidersManagedTriangles; //Field offset: 0xB0
    public SortedDictionary<int, MeshUnmanagedTrianglesRef> CollidersRuntimeTriangles; //Field offset: 0xB8
    public UnmanagedTriangleArray AllRuntimeTriangles; //Field offset: 0xC0
    public List<PolygonColliderRuntimeData> StaticPolygonColliderData; //Field offset: 0xC8
    public Dictionary<string, NavMesh> NavMeshes; //Field offset: 0xD0
    public Dictionary<string, int> RegionMap; //Field offset: 0xD8
}
#endif
