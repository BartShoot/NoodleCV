using CommunityToolkit.Mvvm.ComponentModel;
using NodifyM.Avalonia.ViewModelBase;

namespace NoodleCV.App.ViewModels;

public partial class ConnectionViewModel : ConnectionViewModelBase
{
    [ObservableProperty] private ConnectorViewModel _source;
    [ObservableProperty] private ConnectorViewModel _target;

    public ConnectionViewModel(NodifyEditorViewModelBase nodifyEditor, ConnectorViewModel source,
        ConnectorViewModel target) : base(nodifyEditor, source, target)
    {
    }

    public ConnectionViewModel(NodifyEditorViewModelBase nodifyEditor, ConnectorViewModel source,
        ConnectorViewModel target, string text) : base(nodifyEditor, source, target, text)
    {
    }
}