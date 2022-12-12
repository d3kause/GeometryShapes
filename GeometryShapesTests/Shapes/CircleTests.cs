using System;
using System.Collections.Generic;
using GeometryShapes.Common.Contracts;
using GeometryShapes.Shapes;
using GeometryShapesTests.Common;
using Xunit;

namespace GeometryShapesTests.Shapes;

public class CircleTests
{
    private static readonly IEqualityComparer<double> DoubleComparer = new DoubleNumberComparer();

    [Fact]
    public void ShouldCreateCorrectCircles()
    {
        var radius = double.Epsilon;

        var circle = new Circle(radius);

        Assert.NotNull(circle);
        Assert.Equal(circle.Radius, radius);
    }

    [Fact]
    public void ShouldNotCreateCircleWithZeroRadius()
    {
        Assert.Throws<ArgumentException>(() => new Circle(0));
    }

    [Fact]
    public void ShouldNotCreateNegativeCircle()
    {
        Assert.Throws<ArgumentException>(() => new Circle(-1));
    }

    [Fact]
    public void GetAreaReturnsCorrectValue()
    {
        var circle1 = new Circle(5);
        var circle2 = new Circle(0.01);
        var circle3 = new Circle(830.125);

        Assert.Equal(78.5398163397448300000, circle1.GetArea(), DoubleComparer);
        Assert.Equal(0.00031415926535897936, circle2.GetArea(), DoubleComparer);
        Assert.Equal(2164895.1086210134, circle3.GetArea(), DoubleComparer);
    }
}