using System.Windows;
using UTELib.Structs;

namespace UnrealTableEditor;

public partial class GameEditor : Window {

    private GameEntry SelectedGame;

    public GameEditor() {
        InitializeComponent();
        PopulateTreeView();
    }

    private void PopulateTreeView() {
        foreach ((string key, GameEntry entry) in MainWindow.Instance.AppManager.UTEConfig.Games)
            GameListTreeView.Items.Add(key);
    }

    /*
     * Button Click Handlers
     */

    private void CreateNewGameEntry(object sender, RoutedEventArgs e) {
        NewGameWindow newGameWindow = new();
        newGameWindow.Show();
    }

    private void ExitGameWindow(object sender, RoutedEventArgs e) {
        Close();
    }

    private void SaveGameEntry(object sender, RoutedEventArgs e) {
        var gameKey = GameTitleTextBox.Text.Replace(" ", "");
        var gameEntry = new GameEntry(
            gameKey,
            GameTitleTextBox.Text,
            GameVersionTextBox.Text,
            GamePathTextBox.Text);

        if (!SelectedGame.Key.Equals(gameKey)) {
            MainWindow.Instance.AppManager.UTEConfig.Games.Add(gameKey, gameEntry);
            MainWindow.Instance.AppManager.UTEConfig.Games.Remove(SelectedGame.Key);
            SelectedGame = MainWindow.Instance.AppManager.UTEConfig.Games[gameKey];
            RefreshTreeView();
            return;
        }

        MainWindow.Instance.AppManager.UTEConfig.Games[gameKey] = gameEntry;
        RefreshTreeView();
    }

    private void DeleteGameEntry(object sender, RoutedEventArgs e) {
        MainWindow.Instance.AppManager.UTEConfig.Games.Remove(SelectedGame.Key);
        RefreshTreeView();
    }

    /*
     * Tree View Logic
     */

    private void OnGameSelection(object sender, RoutedEventArgs eventArgs) {
        if (GameListTreeView.SelectedItem is null)
            return;
        
        var selectedGameKey = GameListTreeView.SelectedItem.ToString() ?? throw new InvalidOperationException();
        SelectedGame = MainWindow.Instance.AppManager.UTEConfig.Games[selectedGameKey];

        GameTitleTextBox.Text   = SelectedGame.Title;
        GameVersionTextBox.Text = SelectedGame.Version;
        GamePathTextBox.Text    = SelectedGame.Path;
    }

    private void RefreshTreeView() {
        GameListTreeView.Items.Clear();
        PopulateTreeView();
    }

}