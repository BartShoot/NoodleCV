using CommunityToolkit.Mvvm.ComponentModel;
using NoodleCV.App.CustomControls.ViewModel;
using NoodleCV.App.Operations;

namespace NoodleCV.App.ViewModels;

public class ParameterViewModel : ObservableObject
{
    public BlurViewModel BlurViewModel { get; } = new();
    public PickImageViewModel PickImageViewModel { get; } = new();
    public CustomSliderViewModel CustomSliderViewModel { get; } = new(5, 100, "My Custom Slider");

    public CustomFilePickerViewModel CustomFilePickerViewModel { get; } = new("My Custom File Picker");

    public CustomDropDownViewModel CustomDropDownViewModel { get; } = new("My Custom DropDown",
        ["test1", "test2"]);
}