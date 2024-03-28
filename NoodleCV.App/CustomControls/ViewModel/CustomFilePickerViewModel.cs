using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace NoodleCV.App.CustomControls.ViewModel;

public partial class CustomFilePickerViewModel : ObservableObject
{
    [ObservableProperty] private string _filePath = "";
    [ObservableProperty] private bool _isEnabled = true;
    [ObservableProperty] private string _title;

    public CustomFilePickerViewModel(string title)
    {
        _title = title;
    }


    [RelayCommand]
    public void ResetToDefaultCommand()
    {
        FilePath = "";
        IsEnabled = true;
    }

    [RelayCommand]
    public async Task PickImagePathCommand()
    {
        if (Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions
        {
            Title = "Pick image",
            AllowMultiple = false,
            FileTypeFilter = new[] { FilePickerFileTypes.ImageAll }
        });
        IsEnabled = false;
        FilePath = files[0].Path.AbsolutePath;
    }
}