using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class EditorViewModel : NodifyEditorViewModelBase
{
    [ObservableProperty] private NodeViewModelBase _selectedNode;

    public EditorViewModel()
    {
        SelectedNode = new NodeViewModelBase();
        var input1 = new ConnectorViewModelBase
        {
            Title = "Image",
            Flow = ConnectorViewModelBase.ConnectorFlow.Input
        };
        var output1 = new ConnectorViewModelBase
        {
            Title = "Image",
            Flow = ConnectorViewModelBase.ConnectorFlow.Output
        };
        Connections.Add(new ConnectionViewModelBase(this, output1, input1));
        Nodes = new ObservableCollection<object?>
        {
            new NodeViewModelBase
            {
                Location = new Point(400, 500),
                Title = "Crop",
                Input = new ObservableCollection<ConnectorViewModelBase>
                {
                    input1
                },
                Output = new ObservableCollection<ConnectorViewModelBase>
                {
                    new()
                    {
                        Title = "Image",
                        Flow = ConnectorViewModelBase.ConnectorFlow.Output
                    }
                },
                Footer = "1920x1080@8bpc"
            },
            new NodeViewModelBase
            {
                Title = "Blur",
                Location = new Point(-100, -100),
                Input = new ObservableCollection<ConnectorViewModelBase>
                {
                    new()
                    {
                        Title = "Image",
                        Flow = ConnectorViewModelBase.ConnectorFlow.Input
                    }
                },
                Output = new ObservableCollection<ConnectorViewModelBase>
                {
                    output1,
                }
            }
        };
        output1.IsConnected = true;
        input1.IsConnected = true;
    }

    public ParameterViewModel ParameterViewModel { get; } = new();

    partial void OnSelectedNodeChanged(NodeViewModelBase value)
    {
        //throw new();
    }

    public override void Connect(ConnectorViewModelBase source, ConnectorViewModelBase target)
    {
        base.Connect(source, target);
    }

    public override void DisconnectConnector(ConnectorViewModelBase connector)
    {
        base.DisconnectConnector(connector);
    }

    [RelayCommand]
    private void ChangeTheme()
    {
        if (Application.Current.ActualThemeVariant == ThemeVariant.Dark)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        }
        else
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        }
    }
}