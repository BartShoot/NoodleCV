using OpenCvSharp;

namespace NoodleCV.Engine;

public class DefaultEngine : IEngine
{
    private List<IOperation> _operations = new();

    public void AddNode(IOperation operation)
    {
        throw new NotImplementedException();
    }

    public void RemoveNode(int id)
    {
        throw new NotImplementedException();
    }

    public void UpdateNode(IOperation operation)
    {
        throw new NotImplementedException();
    }

    public Mat GetImage(int id)
    {
        return _operations.Find(operation => operation.Id == id)?.GetImage() ?? throw new ImageNotFoundException();
    }

    private void RecalculateChildNodes(IOperation changedOperation)
    {
        throw new NotImplementedException();
    }
}