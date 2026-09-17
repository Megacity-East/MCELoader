using UnityEngine;
using Il2CppQuantum;
using Il2CppPhoton.Deterministic;

namespace MCELoader.Extensions;

public static class Extensions
{
    public static bool IsCustomMap(this LevelID levelID) => (int)levelID >= 100;

    /// Quantum Types
    public static Transform3D ToQNative(this Transform transform) => new() { Position = transform.position.ToQNative(), Rotation = transform.rotation.ToQNative() };
    public static FP ToQNative(this float flt) => FP.FromFloat_UNSAFE(flt);
    public static FPVector2 ToQNative(this Vector2 vec) => new(vec.x.ToQNative(), vec.y.ToQNative());
    public static FPVector3 ToQNative(this Vector3 vec) => new(vec.x.ToQNative(), vec.y.ToQNative(), vec.z.ToQNative());
    public static FPQuaternion ToQNative(this Quaternion quat) => new(quat.x.ToQNative(), quat.y.ToQNative(), quat.z.ToQNative(), quat.w.ToQNative());

    /// this one exists purely because of Quantum.RoadData and me not wanting to refactor the code gen
    public static Il2CppSystem.Collections.Generic.List<int> ToQNative(this List<int> ints)
    {
        Il2CppSystem.Collections.Generic.List<int> list = new(capacity: ints.Count);
        foreach (int i in ints) list.Add(i);
        return list;
    }
}
