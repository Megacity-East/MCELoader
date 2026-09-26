using System.Runtime.InteropServices;
using Il2CppInterop.Runtime.Runtime;
using MelonLoader.NativeUtils;
using Il2CppInterop.Runtime;
using Il2CppInterop.Common;
using UnityEngine;

namespace MCELoader.Patches;

public static class ResourcesAPI_Load_NativeHook
{
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate IntPtr LoadDelegate(
        IntPtr instancePtr,
        IntPtr pathPtr,
        IntPtr systemTypeInstancePtr,
        IntPtr methodInfoPtr
        );

    private static NativeHook<LoadDelegate> _hook;
    private static LoadDelegate _loadDelegate = Load;


    public static unsafe IntPtr Load(IntPtr instancePtr, IntPtr pathPtr, IntPtr systemTypeInstancePtr, IntPtr methodInfoPtr)
    {
        string path = IL2CPP.Il2CppStringToManaged(pathPtr);
        if (MCELoader.ResourceManager.TryGetResource(path, out var asset))
        {
            MCEMain.Logger.Msg("Sending replacement asset");
            return ((Il2CppSystem.Object)asset).Pointer;
        }
        else
        {
            return _hook.Trampoline(instancePtr, pathPtr, systemTypeInstancePtr, methodInfoPtr); // Original Method
        }
    }


    public static void Initalize()
    {
        unsafe
        {
            var fieldInfo = Il2CppInteropUtils.GetIl2CppMethodInfoPointerFieldForGeneratedMethod(typeof(ResourcesAPI).GetMethod(nameof(ResourcesAPI.Load)));
            IntPtr methodInfoPtr = (IntPtr)fieldInfo.GetValue(null);
            IntPtr nativeFunctionPtr = UnityVersionHandler.Wrap((Il2CppMethodInfo*)methodInfoPtr).MethodPointer;

            _hook = new(nativeFunctionPtr, Marshal.GetFunctionPointerForDelegate(_loadDelegate));
            _hook.Attach();
        }
    }

}
