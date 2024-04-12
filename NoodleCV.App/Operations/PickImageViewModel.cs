using CommunityToolkit.Mvvm.ComponentModel;
using NoodleCV.App.CustomControls.ViewModel;

namespace NoodleCV.App.Operations;

public partial class PickImageViewModel(string title) : ObservableObject
{
    [ObservableProperty] private CustomFilePickerViewModel _customFilePickerViewModel = new(title);
}