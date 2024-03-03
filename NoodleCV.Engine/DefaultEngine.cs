using OpenCvSharp;

namespace NoodleCV.Engine;

public class DefaultEngine : IEngine
{
    private List<IOperation> _operations = new();


    public Mat GetImage(int id)
    {
        return _operations.Find(operation => operation.Id == id)?.GetImage() ?? throw new ImageNotFoundException();
    }
}