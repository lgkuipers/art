using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Art
{
    public class Size
    {
        public double width { get; set; }
        public double height { get; set; }
    }
    public class Point2
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point2(double aX, double aY)
        {
            x = aX;
            y = aY;
        }

        public static bool operator ==(Point2 a, Point2 b)
        {
            return ((a.x == b.x) && (a.y == b.y));
        }
        public static bool operator !=(Point2 a, Point2 b)
        {
            return ((a.x != b.x) || (a.y != b.y));
        }
    }
    public static class Square
    {
        public static List<Point2> createPolyline(double x, double y, double size)
        {
            List<Point2> path = new List<Point2>() {
                new Point2( x - size, y - size ),
                new Point2( x + size, y - size ),
                new Point2( x + size, y + size ),
                new Point2( x - size, y + size ),
                new Point2( x - size, y - size )
            };
            return path;
        }

    }

    public static class Circle
    {
        public static List<Point2> createPolyline(double x, double y, double size)
        {
            int step = 20;
            List<Point2> circle = new List<Point2>();
            for (int i = 0; i < step; i++)
            {
                double r = size;
                double t = (double)i / (step - 1);
                double angle = Math.PI * 2 * t;
                circle.Add(new Point2(x + Math.Cos(angle) * r, y + Math.Sin(angle) * r));
            }
            return circle;
        }

    }

}
