using System.Collections.ObjectModel;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.Input;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class EditorViewModel : NodifyEditorViewModelBase
{
    public EditorViewModel()
    {
        var input1 = new ConnectorViewModelBase
        {
            Title = "AS 1",
            Flow = ConnectorViewModelBase.ConnectorFlow.Input
        };
        var output1 = new ConnectorViewModelBase
        {
            Title = "B 1",
            Flow = ConnectorViewModelBase.ConnectorFlow.Output
        };
        Connections.Add(new ConnectionViewModelBase(this, output1, input1));
        Connections.Add(new ConnectionViewModelBase(this, output1, input1));
        Nodes = new ObservableCollection<object?>
        {
            new NodeViewModelBase
            {
                Location = new Point(400, 500),
                Title = "Node 1",
                Input = new ObservableCollection<ConnectorViewModelBase>
                {
                    input1
                },
                Output = new ObservableCollection<ConnectorViewModelBase>
                {
                    new()
                    {
                        Title = "Output 2",
                        Flow = ConnectorViewModelBase.ConnectorFlow.Output
                    }
                }
            },
            new NodeViewModelBase
            {
                Title = "Node 2",
                Location = new Point(-100, -100),
                Input = new ObservableCollection<ConnectorViewModelBase>
                {
                    new()
                    {
                        Title = "Input 1",
                        Flow = ConnectorViewModelBase.ConnectorFlow.Input
                    },
                    new()
                    {
                        Flow = ConnectorViewModelBase.ConnectorFlow.Input,
                        Title = "Input 2"
                    }
                },
                Output = new ObservableCollection<ConnectorViewModelBase>
                {
                    output1,
                    new()
                    {
                        Flow = ConnectorViewModelBase.ConnectorFlow.Output,
                        Title = "Output 1"
                    },
                    new()
                    {
                        Flow = ConnectorViewModelBase.ConnectorFlow.Output,
                        Title = "Output 2"
                    }
                }
            }
        };
        output1.IsConnected = true;
        input1.IsConnected = true;
    }

    public ParameterViewModel ParameterViewModel { get; } = new();

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