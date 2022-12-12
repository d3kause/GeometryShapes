using GeometryShapes.Common.Contracts;

namespace GeometryShapes.Shapes;

public abstract class BaseShape : IAreaCalculable
{
    public abstract double GetArea();
}