using System.Windows;
using UMMLib.Application;

namespace UnrealModManager;

public partial class GameEditorWindow : Window {

    public UMMDataManager DataManager;

    public GameEditorWindow(UMMDataManager dataManager) {
        DataManager = dataManager;
        InitializeComponent();
    }

}