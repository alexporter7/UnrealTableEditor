namespace UTELib.Structs;

public class ProjectManifest {

    public Dictionary<string, ProjectGame> GameKeys { get; set; } = [];

}

public class ProjectGame {

    public List<ProjectEntry>  Projects  { get; set; } = [];
    public List<TemplateEntry> Templates { get; set; } = [];

}

public class ProjectEntry {

    public ProjectEntry(string name, string projectManifest) {
        Name            = name;
        ProjectManifest = projectManifest;
    }

    public string Name            { get; set; }
    public string ProjectManifest { get; set; }

}

public class TemplateEntry {

    public string Name    { get; set; }
    public bool   Enabled { get; set; }
    public string Path    { get; set; }

}