using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Extensions.Configuration;
using UTELib.States;
using UTELib.Structs;
using UTELib.Utils;

namespace UnrealTableEditor;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {

    public static MainWindow Instance;

    public ApplicationDataManager AppManager = new ApplicationDataManager();

    public MainWindow() {
        Instance = this;
        
        AppManager.Start();
        InitializeComponent();

        ProjectComboBox.IsEnabled  = false;
        AddEntryButton.IsEnabled   = false;
        TemplateComboBox.IsEnabled = false;
        PathTextBox.IsEnabled      = false;
    }

    private void OnWindowClose(object? sender, CancelEventArgs eventArgs) => AppManager.Exit();

    private void CloseUTEEditor(object sender, RoutedEventArgs eventArgs) => Instance.Close();
    
    private void PopulateProjectComboBox(object sender, RoutedEventArgs e) {
        foreach (var (key, value) in AppManager.UTEConfig.Games)
            GameComboBox.Items.Add(key);
    }

    /*
     * Toolbar
     */

    /* File */
    private void NewProject(object sender, RoutedEventArgs eventArgs) {
        NewProjectWindow newProjectWindow = new NewProjectWindow();
        newProjectWindow.Show();
    }

    private void OpenProject(object sender, RoutedEventArgs eventArgs) {
    }

    private void SaveProject(object sender, RoutedEventArgs eventArgs) {
    }

    private void SaveProjectAs(object sender, RoutedEventArgs eventArgs) {
    }

    /* Edit */

    //TODO: make it so settings menu doesn't open if its already opened
    private void OpenSettings(object sender, RoutedEventArgs eventArgs) {
        SettingsMenu settingsMenu = new SettingsMenu();
        settingsMenu.Show();
    }

    private void EditGames(object sender, RoutedEventArgs e) {
        GameEditor gameEditor = new GameEditor();
        gameEditor.Show();
    }

    /* Project */
    private void ImportAsset(object sender, RoutedEventArgs eventArgs) {
    }

    /*
     * Controls Logic
     */

    private void PopulateGameList() {
    }

    private void OnGameSelected(object sender, RoutedEventArgs eventArgs) {
        GameEntry selectedGame = AppManager.UTEConfig.Games[GameComboBox.Text];
        if (!AppManager.UTEProjectManifest.GameKeys.ContainsKey(selectedGame.Key)) {
            MessageBox.Show("No projects exist for that game", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            NewProject(sender, eventArgs);
            return;
        }

        ProjectComboBox.IsEnabled = true;
        foreach (var (key, value) in AppManager.UTEProjectManifest.GameKeys)
            ProjectComboBox.Items.Add(key);
    }

    private void OnProjectSelected(object sender, SelectionChangedEventArgs e) {
    }

    private void PopulateTreeView() {
    }
    

}