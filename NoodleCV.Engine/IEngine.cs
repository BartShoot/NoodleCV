using OpenCvSharp;

namespace NoodleCV.Engine;

public interface IEngine
{
    void AddNode(IOperation operation);
    void RemoveNode(int id);
    void UpdateNode(IOperation operation);
    Mat GetImage(int id);
}