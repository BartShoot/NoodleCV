using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoodleCV.App.CustomControls.ViewModel;

public partial class CustomSliderViewModel : ObservableObject
{
    private readonly int _sliderDefaultMax;
    private readonly decimal _sliderDefaultValue;
    [ObservableProperty] private int _sliderCurrentMax;
    [ObservableProperty] private decimal _sliderValue;
    [ObservableProperty] private string _title;

    public CustomSliderViewModel(decimal sliderDefaultValue, int sliderDefaultMax, string title)
    {
        _sliderDefaultValue = sliderDefaultValue;
        _sliderDefaultMax = sliderDefaultMax;
        _title = title;
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