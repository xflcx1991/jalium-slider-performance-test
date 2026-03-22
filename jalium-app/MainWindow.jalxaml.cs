using Jalium.UI.Controls;

namespace Jalium.UI.Gallery;

/// <summary>
/// MainWindow with 100 sliders bound to a shared ViewModel property.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// ViewModel with shared slider value.
    /// </summary>
    public MainViewModel ViewModel { get; } = new MainViewModel();

    public MainWindow()
    {
        InitializeComponent();
        DataContext = ViewModel;
    }
}