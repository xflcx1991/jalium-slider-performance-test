using Jalium.UI.Controls;
using Jalium.UI.Media;
using System.Collections.Generic;

namespace Jalium.UI.Gallery;

public partial class MainWindow : Window
{
    private List<Slider> _sliders = new List<Slider>();
    private bool _isUpdating = false;

    public MainWindow()
    {
        InitializeComponent();
        Loaded += OnWindowLoaded;
    }

    private void OnWindowLoaded(object? sender, System.EventArgs e)
    {
        CreateSliders();
    }

    private void CreateSliders()
    {
        int rows = 10;
        int cols = 10;

        // Clear existing definitions
        SliderGrid.RowDefinitions.Clear();
        SliderGrid.ColumnDefinitions.Clear();
        SliderGrid.Children.Clear();

        // Create row definitions
        for (int r = 0; r < rows; r++)
        {
            SliderGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        }

        // Create column definitions
        for (int c = 0; c < cols; c++)
        {
            SliderGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        }

        // Create 100 sliders in 10x10 grid
        for (int i = 0; i < 100; i++)
        {
            int row = i / cols;
            int col = i % cols;

            var sliderContainer = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x2D, 0x2D, 0x2D)),
                BorderBrush = new SolidColorBrush(Color.FromRgb(0x3D, 0x3D, 0x3D)),
                BorderThickness = new Thickness(1),
                CornerRadius = new CornerRadius(4),
                Padding = new Thickness(12),
                Margin = new Thickness(6),
                Width = 120,
                Height = 80
            };

            var panel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Center
            };

            var headerText = new TextBlock
            {
                Text = $"#{i + 1:D3}",
                Foreground = new SolidColorBrush(Color.FromRgb(0x88, 0x88, 0x88)),
                FontSize = 11,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 0, 0, 4)
            };

            var slider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = 50,
                Width = 100,
                Height = 20,
                VerticalAlignment = VerticalAlignment.Center
            };

            var valueText = new TextBlock
            {
                Text = "50",
                Foreground = new SolidColorBrush(Color.FromRgb(0x00, 0x78, 0xD4)),
                FontSize = 12,
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 4, 0, 0)
            };

            // Store references for later update
            slider.Tag = new SliderInfo { Index = i, ValueText = valueText };

            // Subscribe to value changed event
            slider.ValueChanged += OnSliderValueChanged;

            _sliders.Add(slider);

            panel.Children.Add(headerText);
            panel.Children.Add(slider);
            panel.Children.Add(valueText);
            sliderContainer.Child = panel;

            // Set grid position
            Grid.SetRow(sliderContainer, row);
            Grid.SetColumn(sliderContainer, col);
            SliderGrid.Children.Add(sliderContainer);
        }
    }

    private class SliderInfo
    {
        public int Index { get; set; }
        public TextBlock ValueText { get; set; } = null!;
    }

    private void OnSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (_isUpdating) return;

        _isUpdating = true;

        try
        {
            var sourceSlider = sender as Slider;
            if (sourceSlider == null) return;

            double newValue = e.NewValue;

            // Update current value display
            if (CurrentValueText != null)
            {
                CurrentValueText.Text = $"{(int)newValue}";
            }

            // Update source slider's value text
            if (sourceSlider.Tag is SliderInfo sourceInfo)
            {
                sourceInfo.ValueText.Text = $"{(int)newValue}";
            }

            // Sync all other sliders
            foreach (var slider in _sliders)
            {
                if (slider != sourceSlider && slider.Value != newValue)
                {
                    slider.Value = newValue;
                    if (slider.Tag is SliderInfo info)
                    {
                        info.ValueText.Text = $"{(int)newValue}";
                    }
                }
            }
        }
        finally
        {
            _isUpdating = false;
        }
    }
}