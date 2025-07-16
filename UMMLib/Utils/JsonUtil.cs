using System.IO;
using System.Net;
using System.Text.Json;

namespace UMMLib.Utils;

public static class JsonUtil {

    public static T LoadJson<T>(string path) {
        return JsonSerializer.Deserialize<T>(File.ReadAllText(path));
    }

    public static void SaveJson<T>(string path, T json) {
        File.WriteAllText(path, JsonSerializer.Serialize(json));
    }

}