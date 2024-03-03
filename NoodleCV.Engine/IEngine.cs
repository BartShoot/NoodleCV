using OpenCvSharp;

namespace NoodleCV.Engine;

public interface IEngine
{
    Mat GetImage(int id);
}