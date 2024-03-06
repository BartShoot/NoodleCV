using Avalonia.Controls;
using Avalonia.Interactivity;

namespace NoodleCV.App.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
    }
}