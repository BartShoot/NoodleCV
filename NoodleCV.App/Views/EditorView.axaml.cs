using Avalonia.Controls;
using Avalonia.Interactivity;

namespace NoodleCV.App.Views;

public partial class EditorView : UserControl
{
    public EditorView()
    {
        InitializeComponent();
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        new MainWindow().Show();
    }
}