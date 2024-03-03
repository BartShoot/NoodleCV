using OpenCvSharp;

namespace NoodleCV.Engine;

public interface IOperation
{
    int Id { get; set; }
    Mat GetImage();
}