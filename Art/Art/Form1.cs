using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art
{
    public class Size
    {
        public double width { get; set; }
        public double height { get; set; }
    }
    public class Point
    {
        public double x { get; set; }
        public double y { get; set; }

        public Point(double aX, double aY)
        {
            x = aX;
            y = aY;
        }
    }
    public static class Square
    {
        public static List<Point> createPolyline(double x, double y, double size)
        {
            List<Point> path = new List<Point>() {
                new Point( x - size, y - size ),
                new Point( x + size, y - size ),
                new Point( x + size, y + size ),
                new Point( x - size, y + size ),
                new Point( x - size, y - size )
            };
            return path;
        }

    }


    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public List<List<Point>> clipPolylineToBox(List<Point> line, Point[] box)
        {
            List<List<Point>> result = new List<List<Point>>();

            result.Add(line);

            return result;
        }

        public List<List<Point>> clipPolylinesToBox(List<List<Point>> lines, Point[] box)
        {
            List<List<Point>> result = new List<List<Point>>();

            foreach (var l in lines)
            {
                List<List<Point>> r = clipPolylineToBox(l, box);
                result.AddRange(r);
            }

            return result;
        }


        public void DrawPath(Graphics g, List<Point> p)
        {
            Pen pen = new Pen(Color.Red);
            PointF[] pfa = new PointF[p.Count];

            var el = p.ToArray();
            for(int i = 0; i<p.Count; i++)
            {
                pfa[i].X = (float)el[i].x;
                pfa[i].Y = (float)el[i].y;
            }

            g.DrawLines(pen, pfa);
        }

        public void CreateDrawing1(Graphics g, Size dimensions, Point[] box, float scale)
        {
            var cx = dimensions.width / 2;
            var cy = dimensions.height / 2;

            List<List<Point>> lines = new List<List<Point>>();

            for (int i = 0; i<12; i++)
            {
                double size = i + 1; // cm
                size *= scale;
                var margin = 0.25; // cm
                margin *= scale;
                lines.Add(Square.createPolyline(cx, cy, size));
                lines.Add(Square.createPolyline(cx, cy, size + margin));
            }

            lines.ForEach(p => DrawPath(g,p));
        }
        public void CreateDrawing2(Graphics g, Size dimensions, Point[] box, float scale)
        {
            var cx = dimensions.width / 2;
            var cy = dimensions.height / 2;

            int steps = 5;
            int count = 20;
            double spacing = 1;
            double radius = 2;

            spacing *= scale;
            radius *= scale;

            List<List<Point>> lines = new List<List<Point>>();

            for (int j = 0; j < count; j++)
            {
                double r = radius + j * spacing;
                List<Point> circle = new List<Point>();
                for (int i = 0; i < steps; i++)
                {
                    double t = (double) i / Math.Max(1, steps - 1);
                    double angle = Math.PI * 2 * t;
                    circle.Add( new Point(dimensions.width / 2 + Math.Cos(angle) * r,
                      dimensions.height / 2 + Math.Sin(angle) * r));
                }
                lines.Add(circle);
            }

            lines = clipPolylinesToBox(lines, box);

            lines.ForEach(p => DrawPath(g, p));
        }
        private void ivBtnDraw_Click(object sender, EventArgs e)
        {
            int lImageWidth = ivPbImage.Size.Width;
            int lImageHeight = ivPbImage.Size.Height;

            float scale = 15;

            Size dimensions = new Size { width = lImageWidth, height = lImageHeight };

            double margin = 1.5;
            margin *= scale;

            Point[] box = { new Point(margin, margin), new Point(dimensions.width - margin, dimensions.height - margin) };


            var newImage = new Bitmap(lImageWidth, lImageHeight);

            Graphics lGraphic = Graphics.FromImage(newImage);

            lGraphic.FillRectangle(Brushes.AliceBlue, 0, 0, (int) dimensions.width, (int) dimensions.height);
            lGraphic.DrawRectangle(Pens.Blue, (int) box[0].x, (int) box[0].y, (int) (box[1].x - box[0].x), (int) (box[1].y - box[0].y));

            CreateDrawing2(lGraphic, dimensions, box, scale);

            ivPbImage.Image = newImage;
        }
    }
}
