using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class NodeViewModel : NodeViewModelBase
{
    [ObservableProperty] private Guid _id = Guid.NewGuid();
    [ObservableProperty] private ObservableCollection<ConnectorViewModel> _input = new();
    [ObservableProperty] private ObservableCollection<ConnectorViewModel> _output = new();

    public bool UnsetIsConnected(Guid id)
    {
        foreach (var connector in Input)
        {
            if (connector.Id == id)
            {
                connector.IsConnected = false;
                return true;
            }
        }

        foreach (var connector in Output)
        {
            if (connector.Id == id)
            {
                connector.IsConnected = false;
                return true;
            }
        }

        return false;
    }
}