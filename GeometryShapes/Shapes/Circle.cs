namespace GeometryShapes.Shapes;

public class Circle : BaseShape
{
    private double _area;

    public Circle(double radius)
    {
        if (radius <= 0)
        {
            throw new ArgumentException("The radius cannot be less or equivalent than 0");
        }

        Radius = radius;
    }

    public double Radius { get; }

    public override double GetArea()
    {
        if (_area == 0)
        {
            _area = Math.PI * Radius * Radius;
        }

        return _area;
    }
}