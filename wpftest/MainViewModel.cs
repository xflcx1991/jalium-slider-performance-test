using System.Collections.ObjectModel;
using System.ComponentModel;

namespace wpftest;

public class MainViewModel : INotifyPropertyChanged
{
    private double _sharedValue = 50;

    public double SharedValue
    {
        get => _sharedValue;
        set
        {
            if (_sharedValue != value)
            {
                _sharedValue = value;
                OnPropertyChanged(nameof(SharedValue));
            }
        }
    }

    public ObservableCollection<SliderItem> SliderItems { get; }

    public MainViewModel()
    {
        SliderItems = new ObservableCollection<SliderItem>();
        for (int i = 1; i <= 100; i++)
        {
            SliderItems.Add(new SliderItem { Num = i });
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
