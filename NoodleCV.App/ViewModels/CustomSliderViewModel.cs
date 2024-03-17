using CommunityToolkit.Mvvm.ComponentModel;

namespace NoodleCV.App.ViewModels;

public partial class CustomSliderViewModel : ObservableObject
{
    [ObservableProperty]
    private decimal _sliderValue;
    [ObservableProperty]
    private int _sliderNewMax;
    [ObservableProperty]
    private decimal _upDownValue;

    partial void OnSliderValueChanging(decimal value)
    {
        SliderNewMax = (int)value;
    }
}