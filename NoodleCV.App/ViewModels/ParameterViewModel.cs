using CommunityToolkit.Mvvm.ComponentModel;

namespace NoodleCV.App.ViewModels;

public class ParameterViewModel : ObservableObject
{
    public CustomSliderViewModel CustomSliderViewModel { get; } = new();
}