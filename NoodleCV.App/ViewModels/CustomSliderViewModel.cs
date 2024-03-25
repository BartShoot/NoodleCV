using CommunityToolkit.Mvvm.ComponentModel;

namespace NoodleCV.App.ViewModels;

public partial class CustomSliderViewModel : ObservableObject
{
    [ObservableProperty] private int _sliderNewMax;
    [ObservableProperty] private decimal _sliderValue;
    [ObservableProperty] private decimal _upDownValue;

    public CustomSliderViewModel()
    {
        SliderNewMax = 100;
    }

    partial void OnSliderValueChanging(decimal value)
    {
        if (value > SliderNewMax)
        {
            SliderNewMax = (int)value;
        }
    }
}