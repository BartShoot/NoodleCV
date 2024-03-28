using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoodleCV.App.CustomControls.ViewModel;

public partial class CustomSliderViewModel : ObservableObject
{
    private static decimal _sliderDefaultValue;
    private static int _sliderDefaultMax;
    [ObservableProperty] private int _sliderCurrentMax;
    [ObservableProperty] private decimal _sliderValue;

    public CustomSliderViewModel(decimal sliderDefaultValue, int sliderDefaultMax)
    {
        _sliderDefaultValue = sliderDefaultValue;
        _sliderDefaultMax = sliderDefaultMax;
        SliderValue = _sliderDefaultValue;
        SliderCurrentMax = _sliderDefaultMax;
    }

    partial void OnSliderValueChanging(decimal value)
    {
        if (value > SliderCurrentMax)
        {
            SliderCurrentMax = (int)(value * 1.5m);
        }
    }

    [RelayCommand]
    public void ResetToDefaultCommand()
    {
        SliderValue = _sliderDefaultValue;
        SliderCurrentMax = _sliderDefaultMax;
    }
}