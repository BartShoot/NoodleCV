using System;
using CommunityToolkit.Mvvm.ComponentModel;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class NodeViewModel : NodeViewModelBase
{
    [ObservableProperty] private Guid _id;
}