namespace UMMLib.Structs;

public class UMMAppData {

    public Dictionary<string, UMMGame> Games { get; set; } = [];

}

public class UMMGame {

    public GameInfo                       Info     { get; set; }
    public Dictionary<string, GameMod>    Mods     { get; set; } = [];
    public Dictionary<string, UMMProfile> Profiles { get; set; } = [];

}

public class UMMProfile {

    public string       Name        { get; set; }
    public List<string> EnabledMods { get; set; } = [];

}

public class GameInfo(string title = "New Game", string version = "N/A", string path = "") {

    public string Title   { get; set; }
    public string Version { get; set; }
    public string Path    { get; set; }

}

public class GameMod {

    public string Name    { get; set; }
    public string Version { get; set; }
    public string URL     { get; set; }

}
