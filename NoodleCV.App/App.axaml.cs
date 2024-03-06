using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using NoodleCV.App.ViewModels;
using NoodleCV.App.Views;

namespace NoodleCV.App;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        BindingPlugins.DataValidators.RemoveAt(0);

        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel()
            };
        }
        // else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        // {
        //     singleViewPlatform.MainView = new MainView
        //     {
        //         DataContext = new MainViewModel()
        //     };
        // } //TODO: refactor Editor to get EditorView here 

        base.OnFrameworkInitializationCompleted();
    }
}