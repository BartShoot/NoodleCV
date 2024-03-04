using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NoodleCV.Engine.Operations;

public class OperationData : INotifyPropertyChanged
{
    private object _data;
    public Type Type { get; protected set; }
    public event PropertyChangedEventHandler? PropertyChanged;

    public T Get<T>()
    {
        if (typeof(T) != Type)
        {
            throw new Exception();
        }

        return (T)_data;
    }

    public void Set<T>(T data)
    {
        if (typeof(T) != Type)
        {
            throw new Exception();
        }

        _data = data;
        OnPropertyChanged(nameof(_data));
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}