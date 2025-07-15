using System.Text.Json;
using UTELib.Structs;

namespace UTELib.Utils;

public static class DirectoryUtil {

    public static string GetConfigFilePath() {
        return $"{Directory.GetCurrentDirectory()}\\config.json";
    }

    public static string GetProjectManifestPath() {
        return $"{Directory.GetCurrentDirectory()}\\Data\\Projects\\manifest.json";
    }

    public static string GetProjectPath(string gameTitle, string projectName) {
        return $"{Directory.GetCurrentDirectory()}\\Data\\Projects\\{gameTitle}\\{projectName}";
    }

}