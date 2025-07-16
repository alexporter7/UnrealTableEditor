using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UMMLib.Application;

namespace UnrealModManager;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {

    public UMMDataManager   DataManager;
    public GameEditorWindow GameEditor;

    public MainWindow() {
        DataManager = new UMMDataManager();
        InitializeComponent();
        InitializeApplicationWindows();
    }

    private void InitializeApplicationWindows() {
        GameEditor = new GameEditorWindow(DataManager);
    }

    //TODO: fix this, make it so we can only open one
    private void OpenGameEditor(object sender, RoutedEventArgs eventArgs) {
        GameEditor.Show();
    }

}