using System.IO;
using System.Net;
using Microsoft.VisualBasic;

namespace UMMLib.Mods;

public class ModPakFile(string name, string path, string fileName, bool enabled) {

    public string Name      = name;
    public string Directory = path;
    public string FileName  = fileName;
    public bool   Enabled   = enabled;

    public bool Validate() {
        return File.Exists(GetFilePath());
    }

    private string GetFilePath() {
        return (Enabled) ? $"{Directory}\\{FileName}" : $"{Directory}\\{FileName}.disabled";
    }

    public void EnableMod() {
        if (Enabled)
            throw new InvalidDataException($"Mod {Name} is already enabled");
        FileSystem.Rename(GetFilePath(), $"{Directory}\\{FileName}");
        Enabled = true;
    }
    
    public void DisableMod() {
        if (!Enabled)
            throw new InvalidDataException($"Mod {Name} is already disabled");
        FileSystem.Rename($"GetFilePath", $"{Directory}\\{FileName}.disabled");
        Enabled = false;
    }

}