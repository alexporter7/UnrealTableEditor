namespace UTELib.Structs;

public class Project {

    public ProjectInfo  Info  { get; set; }
    public ProjectFiles Files { get; set; }
    

}

public class ProjectInfo {

    public ProjectInfo(string projectName = "N/A", string game = "N/A", string version = "N/A", string author = "N/A", string website = "N/A") {
        ProjectName = projectName;
        Game        = game;
        Version     = version;
        Author      = author;
        Website     = website;
    }

    public string   ProjectName { get; set; }
    public string   Game        { get; set; }
    public string   Version     { get; set; }
    public string   Author      { get; set; }
    public string   Website     { get; set; }

}

public class ProjectFiles {

    public List<AssetFile> Assets  { get; set; } = [];
    public List<EntryFile> Entries { get; set; } = [];

}

public class AssetFile {

    public string Name    { get; set; }
    public bool   Enabled { get; set; }
    public string Path    { get; set; }

}

public class EntryFile {

    public string    Name    { get; set; }
    public bool      Enabled { get; set; }
    public string    Path    { get; set; }
    public AssetFile Asset   { get; set; }

}