using System;
using GeometryShapes.Common;
using GeometryShapes.Common.Exceptions;
using GeometryShapes.Shapes;
using Xunit;

namespace GeometryShapesTests.Shapes;

public class TrianlgeTests
{
    [Fact]
    public void ShouldCreateCorrectTriangle()
    {
        var side1 = 7;
        var side2 = 5;
        var side3 = 4;
        var triangle = new Triangle(side1, side2, side3);

        Assert.NotNull(triangle);
        Assert.Equal(triangle.Side1, side1);
        Assert.Equal(triangle.Side2, side2);
        Assert.Equal(triangle.Side3, side3);
    }

    [Fact]
    public void ShouldNotCreateTriangleWithZeroSides()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(0, 0, 0));
    }

    [Fact]
    public void ShouldNotCreateLineTriangle()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(1, 2, 3));
    }

    [Fact]
    public void ShouldNotCreateTriangleWithBiggestSide()
    {
        Assert.Throws<ArgumentException>(() => new Triangle(10, 2, 3));
    }

    [Fact]
    public void GetAreaReturnsCorrectValue()
    {
        var triangle1 = new Triangle(2, 8, 7);
        var triangle2 = new Triangle(0.01, 0.02, 0.015);
        var triangle3 = new Triangle(10000, 10000, 10000);

        Assert.Equal(6.437196594791867, triangle1.GetArea(), 5);
        Assert.Equal(0.000072618437741, triangle2.GetArea(), 5);
        Assert.Equal(43301270.18922193, triangle3.GetArea(), 5);
    }

    [Fact]
    public void GetPerimeterReturnsCorrectValue()
    {
        var triangle1 = new Triangle(2, 8, 7);
        var triangle2 = new Triangle(0.01, 0.02, 0.015);
        var triangle3 = new Triangle(10000, 10000, 10000);

        Assert.Equal(17, triangle1.GetPerimeter());
        Assert.Equal(0.045, triangle2.GetPerimeter());
        Assert.Equal(30000, triangle3.GetPerimeter());
    }

    [Fact]
    public void IsRightAngledReturnsTrueForRightAngled()
    {
        var triangle1 = new Triangle(5, 5, 7.071);
        var triangle2 = new Triangle(5, 10, 11.1803398875);
        var triangle3 = new Triangle(3,4,5);

        Assert.True(triangle1.IsRightAngled());
        Assert.True(triangle2.IsRightAngled());
        Assert.True(triangle3.IsRightAngled());
    }

    [Fact]
    public void IsRightAngledReturnsFalseForNotRightAngled()
    {
        var triangle1 = new Triangle(2, 2, 2);
        var triangle2 = new Triangle(4, 5, 6.12);

        Assert.False(triangle1.IsRightAngled());
        Assert.False(triangle2.IsRightAngled());
    }
    
    [Fact]
    public void IsRightAngledThrowForLessValues()
    {
        var smallestSide = Constants.Precision;
        
        var triangle = new Triangle(2, 2, smallestSide);
        
        Assert.Throws<MathException>(() => triangle.IsRightAngled());
    }
}