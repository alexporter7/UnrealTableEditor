using System.IO;
using System.Text.Json;
using UTELib.Structs;
using UTELib.Utils;


namespace UTELib.States;

public class ApplicationDataManager {

    public ApplicationConfiguration UTEConfig;
    public ProjectManifest          UTEProjectManifest;

    public Project CurrentProject;

    private AppInitManager UTEInitManager = new();
    private AppExitManager UTEExitManager = new();

    public void Start() {
        UTEInitManager.ValidateAll();

        UTEConfig = JsonSerializer
            .Deserialize<ApplicationConfiguration>(File.ReadAllText(DirectoryUtil.GetConfigFilePath()));
        UTEProjectManifest = JsonSerializer
            .Deserialize<ProjectManifest>(File.ReadAllText(DirectoryUtil.GetProjectManifestPath()));
    }

    public void Exit() {
        UTEExitManager.HandleExit(this);
    }

}

internal class AppInitManager {

    public void ValidateAll() {
        ValidateApplicationConfig();
        ValidateApplicationManifest();
    }

    public void ValidateApplicationConfig() {
        if (File.Exists(DirectoryUtil.GetConfigFilePath()))
            return;
        var applicationConfiguration = new ApplicationConfiguration();
        File.WriteAllText(
            DirectoryUtil.GetConfigFilePath(),
            JsonSerializer.Serialize(applicationConfiguration));
    }

    public void ValidateApplicationManifest() {
        if (File.Exists(DirectoryUtil.GetProjectManifestPath()))
            return;
        var projectManifest = new ProjectManifest();
        File.WriteAllText(
            DirectoryUtil.GetProjectManifestPath(),
            JsonSerializer.Serialize(projectManifest));
    }

    public bool ValidateProjects() {
        return true;
    }

}

internal class AppExitManager {

    public void HandleExit(ApplicationDataManager dataManager) {
        SerializeConfig(dataManager.UTEConfig);
        SerializeProjectManifest(dataManager.UTEProjectManifest);
    }

    private void SerializeConfig(ApplicationConfiguration appConfig) {
        File.WriteAllText(
            DirectoryUtil.GetConfigFilePath(),
            JsonSerializer.Serialize(appConfig));
    }

    private void SerializeProjectManifest(ProjectManifest projectManifest) {
        File.WriteAllText(
            DirectoryUtil.GetProjectManifestPath(),
            JsonSerializer.Serialize(projectManifest));
    }

}