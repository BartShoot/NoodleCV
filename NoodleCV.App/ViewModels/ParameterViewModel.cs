using CommunityToolkit.Mvvm.ComponentModel;
using NoodleCV.App.CustomControls.ViewModel;

namespace NoodleCV.App.ViewModels;

public class ParameterViewModel : ObservableObject
{
    public CustomSliderViewModel CustomSliderViewModel { get; } = new(5, 100);
    public CustomFilePickerViewModel CustomFilePickerViewModel { get; } = new();
}