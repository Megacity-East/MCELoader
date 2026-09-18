namespace MCELoader.Shared.ProxyTypes;

public class ComponentPrototype
{
    public struct TypeAndValue
    {
        public string Type;
        public object Value;
    }
    public string Type = "Unknown";
    public Dictionary<string, TypeAndValue> FieldToTypeAndValue = new();

#if MCELoader
    public Il2CppQuantum.ComponentPrototype ToQNative()
    {
        return new(); //TODO: Implement
    }
#endif
}
