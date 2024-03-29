using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoodleCV.App.CustomControls.ViewModel;

public partial class CustomDropDownViewModel : ObservableObject
{
    private readonly int? _defaultSelected;
    [ObservableProperty] private ObservableCollection<string> _dropDownItems;
    [ObservableProperty] private int? _selectedId;
    [ObservableProperty] private string _title;

    public CustomDropDownViewModel(string title, ObservableCollection<string> dropDownItems)
    {
        _defaultSelected = null;
        _title = title;
        _dropDownItems = dropDownItems;
        SelectedId = _defaultSelected;
    }

    public CustomDropDownViewModel(int? defaultSelected, string title, ObservableCollection<string> dropDownItems)
    {
        _defaultSelected = defaultSelected;
        _title = title;
        _dropDownItems = dropDownItems;
        SelectedId = _defaultSelected;
    }

    [RelayCommand]
    public void ResetToDefaultCommand()
    {
        SelectedId = _defaultSelected;
    }
}