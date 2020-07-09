using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Art
{
    public partial class Form1 : Form
    {
        private DelaunayTriangulator delaunay = new DelaunayTriangulator();
        private Voronoi voronoi = new Voronoi();

        public Form1()
        {
            InitializeComponent();
        }

        const int INSIDE = 0; // 0000 
        const int LEFT = 1; // 0001 
        const int RIGHT = 2; // 0010 
        const int BOTTOM = 4; // 0100 
        const int TOP = 8; // 1000 


        int computeCode(double x, double y, Point2[] box)
        {
            // initialized as being inside 
            int code = INSIDE;

            if (x < box[0].x)   // to the left of rectangle 
                code |= LEFT;
            else if (x > box[1].x) // to the right of rectangle 
                code |= RIGHT;
            if (y < box[0].y)   // below the rectangle 
                code |= BOTTOM;
            else if (y > box[1].y) // above the rectangle 
                code |= TOP;

            return code;
        }

        // Implementing Cohen-Sutherland algorithm 
        // Clipping a line from P1 = (x2, y2) to P2 = (x2, y2) 
        bool cohenSutherlandClip(ref double x1, ref double y1,
                                ref double x2, ref double y2,
                                Point2[] box)
        {
            // Compute region codes for P1, P2 
            int code1 = computeCode(x1, y1, box);
            int code2 = computeCode(x2, y2, box);

            // Initialize line as outside the rectangular window 
            bool accept = false;

            while (true)
            {
                if ((code1 == 0) && (code2 == 0))
                {
                    // If both endpoints lie within rectangle 
                    accept = true;
                    break;
                }
                else if ((code1 & code2) != 0)
                {
                    // If both endpoints are outside rectangle, 
                    // in same region 
                    break;
                }
                else
                {
                    // Some segment of line lies within the 
                    // rectangle 
                    int code_out;
                    double x = -999, y = -999;

                    // At least one endpoint is outside the 
                    // rectangle, pick it. 
                    if (code1 != 0)
                        code_out = code1;
                    else
                        code_out = code2;

                    // Find intersection point; 
                    // using formulas y = y1 + slope * (x - x1), 
                    // x = x1 + (1 / slope) * (y - y1) 
                    if ((code_out & TOP) != 0)
                    {
                        // point is above the clip rectangle 
                        x = x1 + (x2 - x1) * (box[1].y - y1) / (y2 - y1);
                        y = box[1].y;
                    }
                    else if ((code_out & BOTTOM) != 0)
                    {
                        // point is below the rectangle 
                        x = x1 + (x2 - x1) * (box[0].y - y1) / (y2 - y1);
                        y = box[0].y;
                    }
                    else if ((code_out & RIGHT) != 0)
                    {
                        // point is to the right of rectangle 
                        y = y1 + (y2 - y1) * (box[1].x - x1) / (x2 - x1);
                        x = box[1].x;
                    }
                    else if ((code_out & LEFT) != 0)
                    {
                        // point is to the left of rectangle 
                        y = y1 + (y2 - y1) * (box[0].x - x1) / (x2 - x1);
                        x = box[0].x;
                    }

                    // Now intersection point x,y is found 
                    // We replace point outside rectangle 
                    // by intersection point 
                    if (code_out == code1)
                    {
                        x1 = x;
                        y1 = y;
                        code1 = computeCode(x1, y1, box);
                    }
                    else
                    {
                        x2 = x;
                        y2 = y;
                        code2 = computeCode(x2, y2, box);
                    }
                }
            }

            return accept;
        }


        public List<List<Point2>> clipPolylineToBox(List<Point2> polyline, Point2[] box)
        {
            List<List<Point2>> result = new List<List<Point2>>();

            var polyline_a = polyline.ToArray<Point2>();
            int n = polyline_a.Length;

            var polyline_c = new List<Point2>();

            int i = 0;
            var a = polyline_a[i];
            Point2 b_new = polyline_a[i + 1];
            bool new_b = false;
            while (i < (n-1))
            {
                var b = polyline_a[i + 1];

                double x1 = a.x;
                double y1 = a.y;
                double x2 = b.x;
                double y2 = b.y;
                bool r = cohenSutherlandClip(ref x1, ref y1, ref x2, ref y2, box);
                var a_new = new Point2(x1, y1);
                b_new = new Point2(x2, y2);
                bool new_a = a != a_new;
                new_b = b != b_new;
                if (r)
                {
                    polyline_c.Add(a_new);
                    if (new_b)
                    {
                        polyline_c.Add(b_new);
                        List<Point2> lp = new List<Point2>(polyline_c);
                        if (lp.Count() > 1) // ignore 1 point
                        {
                            result.Add(lp);
                        }
                        polyline_c.Clear();
                    }
                }
                a = b;
                i++;
            }
            if (!new_b)
            {
                polyline_c.Add(b_new);
            }

            if (polyline_c.Count > 1) // ignore 1 point
            {
                result.Add(polyline_c);
            }

            return result;
        }

        public List<List<Point2>> clipPolylinesToBox(List<List<Point2>> lines, Point2[] box)
        {
            List<List<Point2>> result = new List<List<Point2>>();

            foreach (var l in lines)
            {
                List<List<Point2>> r = clipPolylineToBox(l, box);
                if (r.Count() > 0)
                {
                    result.AddRange(r);
                }
            }

            return result;
        }


        public void DrawPath(Graphics g, List<Point2> p)
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
        public void OpenCnC(out System.IO.StreamWriter file)
        {
            // create new cnc file
            file = new System.IO.StreamWriter(@"..\..\art.cnc");
        }

        public void CloseCnc(System.IO.StreamWriter file)
        {
            // close cnc file
            file.Close();
        }
        public void PenUpCnc(System.IO.StreamWriter file, int up)
        {
            file.WriteLine("M1 {0}", up);
        }
        public void DrawCnc(Graphics g, List<Point2> p, System.IO.StreamWriter file, float scale, int up, int down, double offsetX, double offsetY)
        {
            bool lFirstPoint = true;
            bool lSecondPoint = true;
            // draw remaining points
            foreach (var point in p)
            {
                point.x = point.x * 10 / scale;
                point.y = point.y * 10 / scale;

                point.x += offsetX;
                point.y += offsetY;

                if (lFirstPoint)
                {
                    file.WriteLine("M1 {0}", up);
                    lFirstPoint = false;
                }
                else if (lSecondPoint)
                {
                    file.WriteLine("M1 {0}", down);
                    lSecondPoint = false;
                }
                string cmd = string.Format("G0 X{0} Y{1}", point.x.ToString("0.00", new System.Globalization.CultureInfo("en-US")), point.y.ToString("0.00", new System.Globalization.CultureInfo("en-US")));
                file.WriteLine(cmd);
            }
        }

        public void CreateDrawing1(Graphics g, Size dimensions, Point2[] box, float scale)
        {
            var cx = dimensions.width / 2;
            var cy = dimensions.height / 2;

            List<List<Point2>> lines = new List<List<Point2>>();

            for (int i = 0; i<15; i++)
            {
                double size = i + 1; // cm
                size *= scale;
                var margin = 0.25; // cm
                margin *= scale;
                lines.Add(Square.createPolyline(cx, cy, size));
                lines.Add(Square.createPolyline(cx, cy, size + margin));
            }

            lines = clipPolylinesToBox(lines, box);

            lines.ForEach(p => DrawPath(g,p));
        }
        public void CreateDrawing2(Graphics g, Size dimensions, Point2[] box, float scale)
        {
            int steps = 7;
            int count = 20;
            double spacing = 1; // cm
            double radius = 2; // cm

            spacing *= scale;
            radius *= scale;

            List<List<Point2>> lines = new List<List<Point2>>();

            for (int j = 0; j < count; j++)
            {
                double r = radius + j * spacing;
                List<Point2> circle = new List<Point2>();
                for (int i = 0; i < steps; i++)
                {
                    double t = (double) i / Math.Max(1, steps - 1);
                    double angle = Math.PI * 2 * t;
                    circle.Add( new Point2(dimensions.width / 2 + Math.Cos(angle) * r,
                      dimensions.height / 2 + Math.Sin(angle) * r));
                }
                lines.Add(circle);
            }

            lines = clipPolylinesToBox(lines, box);

            lines.ForEach(p => DrawPath(g, p));
        }

        static Random random = new Random();

        public double randomDouble(double from, double to)
        {
            return random.NextDouble() * (to - from) + from;
        }
        public void CreateDrawing3(Graphics g, Size dimensions, Point2[] box, float scale, int up, int down, double offsetX, double offsetY)
        {
            var points = delaunay.GeneratePoints(25, box[1].x, box[1].y);
            var triangulation = delaunay.BowyerWatson(points);

            var voronoiEdges = voronoi.GenerateEdgesFromDelaunay(triangulation);

            List<List<Point2>> lines = new List<List<Point2>>();
            foreach (var point in points)
            {
                List<Point2> new_circle = Circle.createPolyline(point.X, point.Y, 0.1 * scale /* cm */ );
                lines.Add(new_circle);
            }
            foreach(var triangle in triangulation)
            {
                List<Point2> polyline = new List<Point2>();
                foreach(var point in triangle.Vertices)
                {
                    polyline.Add(new Point2(point.X, point.Y));
                }
                polyline.Add(new Point2(triangle.Vertices.First().X, triangle.Vertices.First().Y));
                //lines.Add(polyline);
            }
            foreach(var edge in voronoiEdges)
            {
                List<Point2> polyline = new List<Point2>();
                polyline.Add(new Point2(edge.Point1.X, edge.Point1.Y));
                polyline.Add(new Point2(edge.Point2.X, edge.Point2.Y));
                lines.Add(polyline);
            }

            /*
            List<Point2> circle = new List<Point2>();
            for (int i = 0; i < 200; i++)
            {
                List<Point2> new_circle = Circle.createPolyline(randomDouble(box[0].x, box[1].x), randomDouble(box[0].y, box[1].y), 0.3 * scale );
                lines.Add(new_circle);
            }
            */

            lines = clipPolylinesToBox(lines, box);

            lines.ForEach(p => DrawPath(g, p));

            System.IO.StreamWriter file;
            OpenCnC(out file);
            lines.ForEach(p => DrawCnc(g, p, file, scale, up, down, offsetX, offsetY));
            PenUpCnc(file, up);
            CloseCnc(file);
        }
        private void ivBtnDraw_Click(object sender, EventArgs e)
        {
            int lImageWidth = ivPbImage.Size.Width;
            int lImageHeight = ivPbImage.Size.Height;

            float scale = 45; // cm -> graphics   0.2 cm * scale = units graphics (ivPbImage)
                              // width 545 height 526   12 cm 11,5 cm

            var lUp = int.Parse(ivTbUp.Text);
            var lDown = int.Parse(ivTbDown.Text);

            var lOffsetX = double.Parse(ivTbOffsetX.Text, new CultureInfo("en-US"));
            var lOffsetY = double.Parse(ivTbOffsetY.Text, new CultureInfo("en-US"));

            Size dimensions = new Size { width = lImageWidth, height = lImageHeight };

            double margin = 0; // cm
            margin *= scale;

            Point2[] box = { new Point2(margin, margin), new Point2(dimensions.width - margin-1, dimensions.height - margin-1) };


            var newImage = new Bitmap(lImageWidth, lImageHeight);

            Graphics lGraphic = Graphics.FromImage(newImage);

            lGraphic.FillRectangle(Brushes.AliceBlue, 0, 0, (int) dimensions.width, (int) dimensions.height);
            lGraphic.DrawRectangle(Pens.Blue, (int) box[0].x, (int) box[0].y, (int) (box[1].x - box[0].x), (int) (box[1].y - box[0].y));

            CreateDrawing3(lGraphic, dimensions, box, scale, lUp, lDown, lOffsetX, lOffsetY);

            ivPbImage.Image = newImage;
        }
    }
}
