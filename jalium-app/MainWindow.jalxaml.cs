using Jalium.UI.Controls;

namespace Jalium.UI.Gallery;

/// <summary>
/// MainWindow with 100 sliders bound to a shared ViewModel property.
/// </summary>
public partial class MainWindow : Window
{

    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
}