namespace UTELib.Structs;

public class Project {

    public ProjectInfo  Info  { get; set; }
    public ProjectFiles Files { get; set; }
    

}

public class ProjectInfo {

    public string   ProjectName { get; set; } = "N/A";
    public string   Game        { get; set; } = "N/A";
    public string   Version     { get; set; } = "N/A";
    public string   Author      { get; set; } = "N/A";
    public string   Website     { get; set; } = "N/A";
    public string[] Files       { get; set; } = [];

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