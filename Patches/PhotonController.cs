using HarmonyLib;

using MCELoader.Extensions;

using Il2Cpp;
using Il2CppQuantum;

namespace MCELoader.Patches;

[HarmonyPatch(typeof(PhotonController))]
public static class PhotonController__patches
{
    [HarmonyPrefix]
    [HarmonyPatch(nameof(PhotonController.TryGetMapPath))]
    public static bool TryGetMapPath__prefix(PhotonController __instance, bool __result, LevelID levelID, ref String mapPath)
    {
        MCEMain.Logger.Msg("TryGetMapPath__prefix");
        if (levelID.IsCustomMap())
        {
            mapPath = Loader.GetMapLoadPath(levelID);
            __result = true;
            return false;
        }

        return true;
    }
}
