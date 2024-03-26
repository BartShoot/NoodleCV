using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

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
            SliderNewMax = (int)(value * 1.5m);
        }
    }

    [RelayCommand]
    public void ResetToDefaultCommand()
    {
        SliderValue = 0;
        SliderNewMax = 100;
    }
}