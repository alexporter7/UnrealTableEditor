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
        var selectedGame    = GameComboBox.SelectionBoxItem.ToString();
        var projectPath     = DirectoryUtil.GetProjectPath(selectedGame);
        var newProjectEntry = new ProjectEntry(ProjectNameTextbox.Text, $"{projectPath}\\{selectedGame}");

        //TODO: add some check to make sure project names don't get duped
        MainWindow.Instance.AppManager.UTEProjectManifest.GameKeys[selectedGame].Projects.Add(newProjectEntry);
        
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e) {
        this.Close();
    }

}