using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI.Rating
{
    public partial class Rating : UserControl
    {
        public Rating()
        {
            InitializeComponent();
            this.Size = new Size(150, 150);
        }

        #region Variables and properties

        string sizeType = "";
        public int X = 0, Y = 0;
        float ans = 0;
        public float finalAns = 0;
        public Pen pen = new Pen(GUIStyles.primaryColor,2);
        private Color color = GUIStyles.primaryColor;

        public Color BorderColor
        {
            get => color;
            set
            {
                color = value;
            }
        }

        #endregion

        #region Paint

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            pen = new Pen(color, 2);
            List<Point> l1 = new List<Point>();
            l1.Add(new Point(star1.Width / 2, 0));
            l1.Add(new Point((int)(star1.Width / 1.53), (int)(star1.Height / 2.85)));
            l1.Add(new Point(star1.Width, (int)(star1.Height / 2.85)));
            l1.Add(new Point((int)(star1.Width / 1.33), (int)(star1.Height / 1.66)));
            l1.Add(new Point((int)(star1.Width / 1.111), star1.Height));
            l1.Add(new Point(star1.Width / 2, (int)(star1.Height / 1.33)));
            l1.Add(new Point(star1.Width / 10, star1.Height));
            l1.Add(new Point(star1.Width / 4, (int)(star1.Height / 1.66)));
            l1.Add(new Point(0, (int)(star1.Height / 2.85)));
            l1.Add(new Point((int)(star1.Width / 2.85), (int)(star1.Height / 2.85)));

            Point[] point=l1.ToArray();
            
            Graphics gh = star1.CreateGraphics();
            gh.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            gh.DrawPolygon(pen, point.ToArray());

            gh = star2.CreateGraphics();
            gh.DrawPolygon(pen, point.ToArray());

            gh = star3.CreateGraphics();
            gh.DrawPolygon(pen, point.ToArray());

            gh = star4.CreateGraphics();
            gh.DrawPolygon(pen, point.ToArray());

            gh = star5.CreateGraphics();
            gh.DrawPolygon(pen, point.ToArray());

            gh.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            if (sizeType == "star1")
            {
                List<Point> newList = new List<Point>();
                newList = findFillPosition(star1, point.ToList());

                gh = star1.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());
                gh.FillPolygon(new SolidBrush(color), newList.ToArray());

                List<Point> starPoints = new List<Point>();
                starPoints.Add(new Point(star1.Width / 2, 0));
                starPoints.Add(new Point((int)(star1.Width / 1.53), (int)(star1.Height / 2.85)));
                starPoints.Add(new Point(star1.Width, (int)(star1.Height / 2.85)));
                starPoints.Add(new Point((int)(star1.Width / 1.33), (int)(star1.Height / 1.66)));
                starPoints.Add(new Point((int)(star1.Width / 1.111), star1.Height));
                starPoints.Add(new Point(star1.Width / 2, (int)(star1.Height / 1.33)));
                starPoints.Add(new Point(star1.Width / 10, star1.Height));
                starPoints.Add(new Point(star1.Width / 4, (int)(star1.Height / 1.66)));
                starPoints.Add(new Point(0, (int)(star1.Height / 2.85)));
                starPoints.Add(new Point((int)(star1.Width / 2.85), (int)(star1.Height / 2.85)));

                gh = star2.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                gh = star3.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                gh = star4.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                gh = star5.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                finalAns = 0 + ans;
            }
            else if (sizeType == "star2")
            {
                List<Point> newList = new List<Point>();
                newList = findFillPosition(star1, point.ToList());

                gh = star1.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star2.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());
                gh.FillPolygon(new SolidBrush(color), newList.ToArray());

                gh = star3.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                gh = star4.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                gh = star5.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                finalAns = 1 + ans;
            }

            else if (sizeType == "star3")
            {
                List<Point> newList = new List<Point>();
                newList = findFillPosition(star1, point.ToList());

                gh = star1.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star2.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star3.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());
                gh.FillPolygon(new SolidBrush(color), newList.ToArray());

                gh = star4.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                gh = star5.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                //label2.Text = (2 + ans) + "/5";
                finalAns = 2 + ans;
            }

            else if (sizeType == "star4")
            {
                List<Point> newList = new List<Point>();
                newList = findFillPosition(star1, point.ToList());

                gh = star1.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star2.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star3.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star4.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());
                gh.FillPolygon(new SolidBrush(color), newList.ToArray());

                gh = star5.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());

                //label2.Text = (3 + ans) + "/5";
                finalAns = 3 + ans;
            }

            else if (sizeType == "star5")
            {
                List<Point> newList = new List<Point>();
                newList = findFillPosition(star1, point.ToList());

                gh = star1.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star2.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star3.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star4.CreateGraphics();
                gh.FillPolygon(new SolidBrush(Color.Transparent), point.ToArray());
                gh.FillPolygon(new SolidBrush(color), point.ToArray());

                gh = star5.CreateGraphics();
                gh.FillPolygon(new SolidBrush(color), newList.ToArray());

                //label2.Text = (4 + ans) + "/5";
                finalAns = 4 + ans;
            }
        }

        #endregion

        #region User defined function

        public List<Point> findFillPosition(Panel panel1, List<Point> starPoints)
        {
            List<Point> newList = new List<Point>();
            int x1 = panel1.Width / 3;
            int x2 = panel1.Width / 2;
            int x3 = (int)(panel1.Width / 1.333);
            int x4 = panel1.Width;

            if (X < x1)
            {
                newList.Add(new Point(0, (int)(panel1.Height / 2.85)));
                newList.Add(new Point(x1, (int)(panel1.Height / 2.85)));
                newList.Add(new Point(x1, (int)(panel1.Height / 1.111)));
                newList.Add(new Point(panel1.Width / 10, panel1.Height));
                newList.Add(new Point(panel1.Width / 4, (int)(panel1.Height / 1.66)));

                ans = 0.25f;
            }
            else if (X < x2)
            {
                newList.Add(new Point(0, (int)(panel1.Height / 2.85)));
                newList.Add(new Point((int)(panel1.Width / 2.85), (int)(panel1.Height / 2.85)));
                newList.Add(new Point(panel1.Width / 2, 0));
                newList.Add(new Point(panel1.Width / 2, (int)(panel1.Height / 1.33)));
                newList.Add(new Point(panel1.Width / 10, panel1.Height));
                newList.Add(new Point(panel1.Width / 4, (int)(panel1.Height / 1.66)));

                ans = 0.5f;
            }
            else if (X < x3)
            {
                newList.Add(new Point(0, (int)(panel1.Height / 2.85)));
                newList.Add(new Point((int)(panel1.Width / 2.85), (int)(panel1.Height / 2.85)));
                newList.Add(new Point(panel1.Width / 2, 0));
                newList.Add(new Point((int)(panel1.Width / 1.53), (int)(panel1.Height / 2.85)));
                newList.Add(new Point((int)(panel1.Width / 1.53), (int)(panel1.Height / 1.111)));
                newList.Add(new Point(panel1.Width / 2, (int)(panel1.Height / 1.33)));
                newList.Add(new Point(panel1.Width / 10, panel1.Height));
                newList.Add(new Point(panel1.Width / 4, (int)(panel1.Height / 1.66)));

                ans = 0.75f;
            }
            else
            {
                newList = starPoints;
                ans = 1f;
            }
            return newList;
        }

        #endregion

        #region Events

        private void star1_MouseClick(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            sizeType = "star1";
            Invalidate();
        }

        private void star2_MouseClick(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            sizeType = "star2";
            this.Invalidate();
        }

        private void star3_MouseClick(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            sizeType = "star3";
            this.Invalidate();
        }

        private void star4_MouseClick(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            sizeType = "star4";
            this.Invalidate();
        }

        private void star5_MouseClick(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            sizeType = "star5";
            this.Invalidate();
        }

        private void StarRating_Resize(object sender, EventArgs e)
        {
            int widthsize = (int)(Width - 60 - 85 - 116) / 5;
            star1.Width = widthsize;
            star2.Width = widthsize;
            star3.Width = widthsize;
            star4.Width = widthsize;
            star5.Width = widthsize;
        }

        #endregion
    }
}
