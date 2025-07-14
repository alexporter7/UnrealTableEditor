using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;

namespace UnrealTableEditor;

public partial class SettingsMenu : Window {

    public SettingsMenu() {
        InitializeComponent();
        
        //I know this is dirty but i'm just trying to get this PoC running
        
    }

    private void UAssetBrowseButton_Click(object sender, RoutedEventArgs e) {
        HandleBrowseSelection(UAssetGUIPath);
    }

    private void RepakBrowseButton_Click(object sender, RoutedEventArgs e) {
        HandleBrowseSelection(RepakPath);
    }

    private void BuildBrowseButton_Click(object sender, RoutedEventArgs e) {
        HandleBrowseSelection(BuildPath);
    }

    private void HandleBrowseSelection(TextBox pathControl) {
        var directoryDialog = new OpenFolderDialog();
        if (directoryDialog.ShowDialog() == true) {
            pathControl.Text = directoryDialog.FolderName;
        }
    }

}