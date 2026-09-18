#if MCELoader
using Il2CppQuantum;
using MCELoader.Extensions;
#endif

namespace MCELoader.Shared.ProxyTypes;

public struct AssetRef<SourceType> where SourceType : IAssetObject
{
    public SourceType Referenced;
    public long Guid = 0;

    public AssetRef()
    {

    }
}
