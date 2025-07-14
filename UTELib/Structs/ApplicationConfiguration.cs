namespace UTELib.Structs;

public class ApplicationConfiguration {

    public ApplicationPaths              Paths { get; set; } = new ApplicationPaths();
    public Dictionary<string, GameEntry> Games { get; set; } = [];

}

public class ApplicationPaths {

    public string UAssetGuiPath { get; set; } = "";
    public string RepakPath     { get; set; } = "";
    public string BuildPath     { get; set; } = "";

}

public class GameEntry {

    public GameEntry(string key, string title, string version, string path) {
        Key     = key;
        Title   = title;
        Version = version;
        Path    = path;
    }

    public string Key     { get; set; }
    public string Title   { get; set; }
    public string Version { get; set; }
    public string Path    { get; set; }

}