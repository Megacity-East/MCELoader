using MelonLoader.Utils;
using MelonLoader;

using Il2CppQuantum;

namespace MCELoader;

public static class Loader
{
    public static readonly string CustomMapsInstallDirectory = Path.Combine(MelonEnvironment.UserDataDirectory, "MCEMaps");

    public static string GetMapName(Guid mapId)
    {
        return "Warehouse"; // TODO Implement
    }

    public static string GetMapLoadPath(LevelID levelID)
    {
        return "Maps/Warehouse"; // TODO Implement
    }



    public static void UpdateInstalledMaps()
    {
        if (Directory.Exists(CustomMapsInstallDirectory))
        {
            foreach (string mapArchivePath in Directory.EnumerateFiles(CustomMapsInstallDirectory))
            {
                // TODO Implement map loading
            }
        }
    }
}
