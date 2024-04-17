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
}