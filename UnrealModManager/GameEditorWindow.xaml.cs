using System.Windows;
using UMMLib.Application;
using UMMLib.Structs;

namespace UnrealModManager;

public partial class GameEditorWindow : Window {

    public UMMDataManager DataManager;

    public GameEditorWindow(UMMDataManager dataManager) {
        DataManager = dataManager;
        InitializeComponent();
    }

    private void RefreshGameListBox() {
        GameListBox.Items.Clear();
        foreach (var (key, value) in DataManager.AppData.Games)
            GameListBox.Items.Add(key);
    }

    private void CreateNewGameEntry(object sender, RoutedEventArgs eventArgs) {
        DataManager.AppData.Games.Add($"newGame{DateTime.Now.ToShortTimeString()}", new UMMGame());
        RefreshGameListBox();
    }

    private void EditGameEntry(object sender, RoutedEventArgs eventArgs) {
        
    }

}