using UnityEngine;
using System.IO.Compression;
using Il2CppQuantum;
using Il2CppPhoton.Deterministic;

namespace MCELoader.Extensions;

public static class Extensions
{
    public static bool IsCustomMap(this LevelID levelID) => (int)levelID >= 100;

    //  public static Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<T> ToArray<T>(this IEnumerable<T> enumerable) where T : unmanaged
    //  {
    //      int length = enumerable.Count();
    //      Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<T> array = new(length);
    //
    //      int index = 0;
    //      foreach (T element in enumerable)
    //      {
    //          array[index] = element;
    //          index++;
    //      }
    //      return array;
    //  }

#nullable enable

    public static Il2CppSystem.Collections.Generic.List<T> ToIl2CppList<T>(this IEnumerable<T> enumerable)
    {
        int length = enumerable.Count();
        Il2CppSystem.Collections.Generic.List<T> list = new(capacity: length);

        foreach (T element in enumerable)
            list.Add(element);

        return list;
    }

    public static Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<T> ToStructArray<T>(this IEnumerable<T> enumerable) where T : unmanaged
    {
        int length = enumerable.Count();
        Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppStructArray<T> array = new(length);

        int index = 0;
        foreach (T element in enumerable)
        {
            array[index] = element;
            index++;
        }
        return array;
    }

    public static Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<T> ToReferenceArray<T>(this IEnumerable<T> enumerable) where T : Il2CppInterop.Runtime.InteropTypes.Il2CppObjectBase?
    {
        int length = enumerable.Count();
        Il2CppInterop.Runtime.InteropTypes.Arrays.Il2CppReferenceArray<T> array = new(length);

        int index = 0;
        foreach (T element in enumerable)
        {
            array[index] = element;
            index++;
        }
        return array;
    }
}
