using Jalium.UI.Controls;

namespace Jalium.UI.Gallery;

/// <summary>
/// Entry point for the Jalium.UI Gallery application.
/// </summary>
class Program
{
    [STAThread]
    static void Main()
    {
        // Create and run the application
        var app = new Application();

        // Create the main window
        var window = new MainWindow();

        // Run the application with the main window
        app.Run(window);
    }
}