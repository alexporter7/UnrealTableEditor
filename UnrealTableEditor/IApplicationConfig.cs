namespace UnrealTableEditor;

public interface IApplicationConfig {
    
    string UAssetGuiPath { get; }
    string RepakPath     { get; }
    string BuildPath     { get; }

}