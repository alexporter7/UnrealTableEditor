using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Extensions.Configuration;
using UTELib.Structs;
using UTELib.Utils;

namespace UnrealTableEditor;

public partial class NewProjectWindow : Window {

    public NewProjectWindow() {
        InitializeComponent();
    }

    private void PopulateGameComboBox(object sender, RoutedEventArgs eventArgs) {
        foreach (var (key, value) in MainWindow.Instance.AppManager.UTEConfig.Games)
            GameComboBox.Items.Add(key);
    }

    private void CreateProject(object sender, RoutedEventArgs e) {
        var projectName     = ProjectNameTextbox.Text;
        var selectedGame    = GameComboBox.SelectionBoxItem.ToString();
        var projectPath     = DirectoryUtil.GetProjectPath(selectedGame, projectName);
        var newProjectEntry = new ProjectEntry(projectName, $"{projectPath}\\{selectedGame}");
        
        if(!MainWindow.Instance.AppManager.UTEProjectManifest.GameKeys.ContainsKey(selectedGame))
            MainWindow.Instance.AppManager.UTEProjectManifest.GameKeys.Add(selectedGame, new ProjectGame());

        //TODO: add some check to make sure project names don't get duped
        MainWindow.Instance.AppManager.UTEProjectManifest.GameKeys[selectedGame].Projects.Add(newProjectEntry);

        if (!Directory.Exists(projectPath))
            Directory.CreateDirectory(projectPath);
        
        Project project = new() { Info = new ProjectInfo(
            projectName, selectedGame, VersionTextbox.Text, AuthorTextbox.Text, WebsiteTextbox.Text)};
        File.WriteAllText(
            $"{projectPath}\\{newProjectEntry.Name}.json",
            JsonSerializer.Serialize(project));
        
        Close();

    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e) {
        Close();
    }

}