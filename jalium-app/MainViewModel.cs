using System.ComponentModel;

namespace Jalium.UI.Gallery;

/// <summary>
/// ViewModel for MainWindow with a shared slider value.
/// </summary>
public class MainViewModel : INotifyPropertyChanged
{
    private double _sliderValue = 50;

    /// <summary>
    /// Shared slider value (0-100).
    /// </summary>
    public double SliderValue
    {
        get => _sliderValue;
        set
        {
            if (_sliderValue != value)
            {
                _sliderValue = value;
                OnPropertyChanged(nameof(SliderValue));
            }
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
