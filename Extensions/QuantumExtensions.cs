
using UnityEngine;
using Il2CppQuantum;
using Il2CppPhoton.Deterministic;

namespace MCELoader.Extensions;

public static class QuantumExtensions
{
    public static QBoolean ToQNative(this bool boolean) => new() { Value = Convert.ToInt32(boolean) };

    public static FP ToQNative(this float flt) => FP.FromFloat_UNSAFE(flt);
    public static FPVector2 ToQNative(this Vector2 vec) => vec.ToFPVector2();
    public static FPVector3 ToQNative(this Vector3 vec) => vec.ToFPVector3();
    public static FPQuaternion ToQNative(this Quaternion quat) => quat.ToFPQuaternion();
    public static Transform3D ToQNative(this Transform transform) => new() { Position = transform.position.ToQNative(), Rotation = transform.rotation.ToQNative() };


    public static NullableFP ToQNative(this float? flt)
    {
        if (flt != null)
        {
            return FP.FromFloat_UNSAFE(flt.Value);
        }
        return new();
    }

    /// this one exists purely because of Quantum.RoadData and me not wanting to refactor the code gen
    public static Il2CppSystem.Collections.Generic.List<T> ToQNative<T>(this List<T> items)
    {
        Il2CppSystem.Collections.Generic.List<T> list = new(capacity: items.Count);
        foreach (var i in items) list.Add(i);
        return list;
    }
}
