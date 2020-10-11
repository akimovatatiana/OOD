using System;
using System.Collections.Generic;
using System.Text;

namespace Painter.Shapes
{
    public class Point
    {
        public double X { get; }
        public double Y { get; }

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
