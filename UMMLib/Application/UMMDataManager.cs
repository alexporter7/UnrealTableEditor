using System.IO;
using System.Net;
using System.Text.Json;
using UMMLib.Structs;
using UMMLib.Utils;

namespace UMMLib.Application;

public class UMMDataManager {

    public UMMConfig  Config;
    public UMMAppData AppData;

    public UMMDataManager() {
        UMMInit.ValidateJsonFiles();
        Config      = JsonUtil.LoadJson<UMMConfig>(PathUtil.ConfigPath);
        AppData = JsonUtil.LoadJson<UMMAppData>(PathUtil.UMMDataPath);
    }

}

internal static class UMMInit {

    public static void ValidateJsonFiles() {
        if (!File.Exists(PathUtil.ConfigPath))
            JsonUtil.SaveJson(PathUtil.ConfigPath, new UMMConfig());

        if (!File.Exists(PathUtil.UMMDataPath))
            JsonUtil.SaveJson(PathUtil.UMMDataPath, new UMMAppData());
    }

}