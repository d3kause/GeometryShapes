using GeometryShapes.Common;
using GeometryShapes.Common.Exceptions;

namespace GeometryShapes.Shapes;

public class Triangle : BaseShape
{
    private double _area;
    private double _perimeter;

    public Triangle(double side1, double side2, double side3)
    {
        Validate(side1, side2, side3);

        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public double Side1 { get; }

    public double Side2 { get; }

    public double Side3 { get; }

    public override double GetArea()
    {
        if (_area == 0)
        {
            var halfPerimeter = GetPerimeter() / 2;

            _area = Math.Sqrt(halfPerimeter
                              * (halfPerimeter - Side1)
                              * (halfPerimeter - Side2)
                              * (halfPerimeter - Side3));
        }

        return _area;
    }

    public double GetPerimeter()
    {
        if (_perimeter == 0)
        {
            _perimeter = Side1 + Side2 + Side3;
        }

        return _perimeter;
    }

    public bool IsRightAngled()
    {
        double maxSquaredSide, otherFirstSquaredSide, otherSecondSquaredSide;

        if (Side1 > Side2 || Side1 > Side3)
        {
            maxSquaredSide = Math.Pow(Side1, 2);
            otherFirstSquaredSide = Math.Pow(Side2, 2);
            otherSecondSquaredSide = Math.Pow(Side3, 2);
        }
        else if (Side2 > Side3)
        {
            maxSquaredSide = Math.Pow(Side2, 2);
            otherFirstSquaredSide = Math.Pow(Side1, 2);
            otherSecondSquaredSide = Math.Pow(Side3, 2);
        }
        else
        {
            maxSquaredSide = Math.Pow(Side3, 2);
            otherFirstSquaredSide = Math.Pow(Side1, 2);
            otherSecondSquaredSide = Math.Pow(Side2, 2);
        }

        if (otherFirstSquaredSide < Constants.Precision || otherSecondSquaredSide < Constants.Precision)
        {
            throw new MathException("Unable to calculate, get value less then precision");
        }

        return Math.Abs(maxSquaredSide - otherFirstSquaredSide - otherSecondSquaredSide) < Constants.Precision;
    }

    private static void Validate(double side1, double side2, double side3)
    {
        if (side1 <= 0
            || side2 <= 0
            || side3 <= 0)
        {
            throw new ArgumentException("The sides of a triangle cannot be less than or equal to zero");
        }

        if (side1 >= side2 + side3
            || side2 >= side1 + side3
            || side3 >= side1 + side2)
        {
            throw new ArgumentException(
                "One of the sides of the triangle cannot be greater than the sum of the others");
        }
    }
}