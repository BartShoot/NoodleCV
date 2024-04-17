using System;
using CommunityToolkit.Mvvm.ComponentModel;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class ConnectorViewModel : ConnectorViewModelBase
{
    [ObservableProperty] private Guid _id = Guid.NewGuid();
}