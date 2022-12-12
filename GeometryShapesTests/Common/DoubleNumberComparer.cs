using System.Collections.Generic;
using GeometryShapes.Common;

namespace GeometryShapesTests.Common;

public class DoubleNumberComparer : IEqualityComparer<double>
{
    public bool Equals(double x, double y)
    {
        return x - y < Constants.Precision;
    }

    public int GetHashCode(double obj)
    {
        return obj.GetHashCode();
    }
}