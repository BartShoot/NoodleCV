using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class EditorViewModel : NodifyEditorViewModelBase
{
    [ObservableProperty] private Collection<ConnectionViewModel> _connections;
    [ObservableProperty] private Collection<NodeViewModel> _nodes;
    private NodeViewModel? _selectedNode;

    public EditorViewModel()
    {
        _selectedNode = new NodeViewModel();
        var input1 = new ConnectorViewModel
        {
            Title = "Image",
            Flow = ConnectorViewModelBase.ConnectorFlow.Input
        };
        var output1 = new ConnectorViewModel
        {
            Title = "Image",
            Flow = ConnectorViewModelBase.ConnectorFlow.Output
        };
        Connections = new ObservableCollection<ConnectionViewModel>
        {
            new ConnectionViewModel(this, output1, input1)
        };
        Nodes = new ObservableCollection<NodeViewModel>
        {
            new NodeViewModel
            {
                Location = new Point(400, 500),
                Title = "Crop",
                Input = new ObservableCollection<ConnectorViewModel>
                {
                    input1
                },
                Output = new ObservableCollection<ConnectorViewModel>
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
                Input = new ObservableCollection<ConnectorViewModel>
                {
                    new()
                    {
                        Title = "Image",
                        Flow = ConnectorViewModelBase.ConnectorFlow.Input
                    }
                },
                Output = new ObservableCollection<ConnectorViewModel>
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
    private void DeleteNode()
    {
        if (SelectedNode != null)
        {
            var toDelete = Nodes.First(node => node.Id.Equals(SelectedNode.Id));
            IEnumerable<ConnectionViewModel>? inputConnections = GetConnectionsFromConnectors(toDelete.Input);
            IEnumerable<ConnectionViewModel>? outputConnections = GetConnectionsFromConnectors(toDelete.Output);

            var targets = Connections.Select(con => con.GetTargetId()).ToList();

            var sources = Connections.Select(con => con.GetSourceId()).ToList();

            IEnumerable<ConnectionViewModel> connectionsToDelete =
                (inputConnections ?? Enumerable.Empty<ConnectionViewModel>()).Concat(
                    outputConnections ?? Enumerable.Empty<ConnectionViewModel>());

            Connections.RemoveMany(connectionsToDelete);


            var targetsAfter = Connections.Select(con => con.GetTargetId()).ToList();

            var sourcesAfter = Connections.Select(con => con.GetSourceId()).ToList();

            Nodes.Remove(toDelete);

            var targetsDifference = targets.Except(targetsAfter);
            var sourcesDifference = sources.Except(sourcesAfter);

            foreach (var id in targetsDifference.Concat(sourcesDifference))
            {
                foreach (var node in Nodes)
                {
                    node.UnsetIsConnected(id);
                }
            }
        }
    }

    private IEnumerable<ConnectionViewModel>? GetConnectionsFromConnectors(
        ObservableCollection<ConnectorViewModel> connectors)
    {
        IEnumerable<ConnectionViewModel>? connections = null;
        foreach (var connector in connectors)
        {
            connections = Connections.Where(con => con.Source == connector || con.Target == connector);
        }

        return connections;
    }
}