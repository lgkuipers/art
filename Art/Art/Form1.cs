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
        public static List<Point> create(double x, double y, double size)
        {
            List<Point> path = new List<Point>() {
                new Point( x - size, y - size ),
                new Point( x + size, y - size ),
                new Point( x + size, y + size ),
                new Point( x - size, y + size )
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

            g.DrawPolygon(pen, pfa);
        }

        public void CreateDrawing(Graphics g, Size dimensions)
        {
            float scale = 15;

            var cx = dimensions.width / 2;
            var cy = dimensions.height / 2;

            List<List<Point>> lines = new List<List<Point>>();

            for (int i = 0; i<12; i++)
            {
                double size = i + 1; // cm
                size *= scale;
                var margin = 0.25; // cm
                margin *= scale;
                lines.Add(Square.create(cx, cy, size));
                lines.Add(Square.create(cx, cy, size + margin));
            }

            lines.ForEach(p => DrawPath(g,p));
        }
        private void ivBtnDraw_Click(object sender, EventArgs e)
        {
            int lImageWidth = ivPbImage.Size.Width;
            int lImageHeight = ivPbImage.Size.Height;

            Size dimensions = new Size { width = lImageWidth, height = lImageHeight };

            var newImage = new Bitmap(lImageWidth, lImageHeight);

            Graphics lGraphic = Graphics.FromImage(newImage);

            lGraphic.FillRectangle(Brushes.AliceBlue, 0, 0, newImage.Width, newImage.Height);

            CreateDrawing(lGraphic, dimensions);

            ivPbImage.Image = newImage;
        }
    }
}
