using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art
{
    class Point
    {
        public double X { get; }
        public double Y { get; }
        public HashSet<Triangle> AdjacentTriangles { get; } = new HashSet<Triangle>();

        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
