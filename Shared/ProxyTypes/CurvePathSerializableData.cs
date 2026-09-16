using UnityEngine;
namespace MCELoader.Shared.ProxyTypes;

public struct CurvePathSerializableData
{
    public Vector3[] allPoints; //Field offset: 0x0
    public float[] allCumulativeDistances; //Field offset: 0x8
    public float[] allRadii; //Field offset: 0x10
    public Vector3[] allTangents; //Field offset: 0x18
    public Vector3[] allNormals; //Field offset: 0x20
}

