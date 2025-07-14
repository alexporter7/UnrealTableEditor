using System.Windows;
using UTELib.Structs;

namespace UnrealTableEditor;

public partial class NewGameWindow : Window {

    public NewGameWindow() {
        InitializeComponent();
    }

    private void CancelNewGame(object sender, RoutedEventArgs e) {
        Close();
    }

    private void AddNewGame(object sender, RoutedEventArgs e) {
        var gameKey = GameTitleTextBox.Text.Replace(" ", "");
        var gameEntry = new GameEntry(
            gameKey,
            GameTitleTextBox.Text,
            GameVersionTextBox.Text,
            GamePathTextBox.Text);
        MainWindow.Instance.AppManager.UTEConfig.Games[gameKey] = gameEntry;
        Close();
    }

}