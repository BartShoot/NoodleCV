using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class EditorViewModel : NodifyEditorViewModelBase
{
    [ObservableProperty] private Collection<NodeViewModel> _nodes;
    private NodeViewModel? _selectedNode;

    public EditorViewModel()
    {
        _selectedNode = new NodeViewModel();
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
        Nodes = new ObservableCollection<NodeViewModel>
        {
            new NodeViewModel
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
            new NodeViewModel
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

    public NodeViewModel? SelectedNode
    {
        get => _selectedNode;
        set
        {
            if (value is not null)
            {
                SetProperty(ref _selectedNode, value);
            }
        }
    }

    public ParameterViewModel ParameterViewModel { get; } = new();

    [RelayCommand]
    private void ChangeTheme()
    {
        Application.Current!.RequestedThemeVariant = Application.Current.ActualThemeVariant == ThemeVariant.Dark
            ? ThemeVariant.Light
            : ThemeVariant.Dark;
    }

    [RelayCommand]
    private void DeleteNodeCommand()
    {
        if (SelectedNode != null)
        {
            Nodes.Remove(Nodes.First(node => node.Id.Equals(SelectedNode.Id)));
        }
    }
}