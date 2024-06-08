using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class LoginLoad : UserControl
    {
        public LoginLoad()
        {
            InitializeComponent();
            height = Height;
            width = Width;
        }

        private Point[] point;

        private int height, width;

        private int time = 0, pause = 0;

        private bool l1 = true, l2 = true, l3 = true, l4 = true, l5 = true, l6 = true, l7 = true, l8 = true;

        private Direction direct = Direction.ClockWise;

        public Direction RotateDirection
        {
            get => direct;
            set
            {
                direct = value;
                time = 0;
            }
        }

        public Color LoadColor { get; set; } = Color.RoyalBlue;

        public void Draw1()
        {
            Point p1 = new Point((width / 2) + (width / 8), (height / 6)  +1);
            Point p2 = new Point((width / 2) + (width / 8), (height / 4) + (height / 8));
            Point p3 = new Point((width / 2) + (width / 5) + (width / 50), (height / 4) + (height / 40));
            point = new Point[] { p1, p2, p3 };
        }

        public void Draw2()
        {
            Point p1 = new Point((width / 2) + (width / 5) + (width / 20), (height / 4) + (height / 15));
            Point p2 = new Point((width / 2) + (width / 7) + (height / 90), (height / 4) + (height / 6) - (height / 90));
            Point p3 = new Point((width / 2) + (width / 4) + (width / 11), (height / 4) + (height / 6) - (height / 100));
            point = new Point[] { p1, p2, p3 };
        }

        public void Draw3()
        {
            Point p1 = new Point((width / 2) + (width / 6), (height / 4) + (height / 7) + (height / 17));
            Point p2 = new Point((width / 2) + (width / 4) + (width / 8)+1, (height / 4) + (height / 7) + (height / 17));
            Point p3 = new Point(width - (width / 20) - (width / 100), height / 2);
            Point p4 = new Point((width / 2) + (width / 4) + (width / 11) - (width / 50), (height / 2) + (height / 12) + (height / 100));
            point = new Point[] { p1, p2, p3, p4 };
        }

        public void Draw4()
        {
            Point p1 = new Point((width / 2) + (width / 8), (height / 2) + (height / 4) + (height / 30));
            Point p2 = new Point((width / 2) + (width / 8), (height / 2) - (height / 30));
            Point p3 = new Point((width / 2) + (width / 4) + (width / 30) - (width / 200), (height / 2) + (height / 8));
            Point p4 = new Point((width / 2) + (width / 5) + (width / 50)-6, (height / 2) + (height / 6) + (height / 80)+6);
            point = new Point[] { p1, p2, p3 , p4 };
        }

        public void Draw5()
        {
            Point p1 = new Point((width / 2) + (width / 12), (height / 2) - (height / 30));
            Point p2 = new Point((width / 2) + (width / 12), (height / 2) + (height / 4) + (height / 13));
            Point p3 = new Point((width / 2) + (width / 40), (height / 2) + (height / 4) + (height / 10) + (height / 15));
            Point p4 = new Point(width / 2, height - (height / 20));
            Point p5 = new Point((width / 4) + (width / 5) - (width / 40), (height / 2) + (height / 4) + (height / 10));
            Point p6 = new Point((width / 4) + (width / 14), (height / 2) + (height / 5) + (height / 30));
            point = new Point[] { p1, p2, p3, p4, p5, p6 };
        }

        public void Draw6()
        {
            Point p1 = new Point((width / 2) + (width / 23), (height / 4) + (height / 7) + (height / 20));
            Point p2 = new Point(width / 8, (height / 4) + (height / 7) + (height / 20));
            Point p3 = new Point(width / 17, height / 2);
            Point p4 = new Point((width / 4) + (width / 29), (height / 2) + (height / 5));
            Point p5 = new Point((width / 4) + (width / 24), (height / 2) + (height / 5) + (height / 25));
            point = new Point[] { p1, p2, p3, p4 };
        }

        public void Draw7()
        {
            Point p1 = new Point((width / 4) + (width / 11), (height / 4) - (height / 30));
            Point p2 = new Point((width / 7) + (width / 50), (height / 4) + (height / 6) - (height / 100));
            Point p3 = new Point((width / 2) + (width / 24), (height / 4) + (height / 6) - (height / 100));
            point = new Point[] { p1, p2, p3 };
        }

        public void Draw8()
        {
            Point p1 = new Point(width / 2, height / 20);
            Point p2 = new Point((width / 2) + (width / 12), (height / 8)+1);
            Point p3 = new Point((width / 2) + (width / 12), (height / 4) + (height / 8));
            Point p4 = new Point((width / 4) + (width / 8), (height / 7) + (height / 21));
            point = new Point[] { p1, p2, p3, p4 };
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            if (pause % 2 == 0)
            {
                Timer.Stop();
                pause++;
            }
            else
            {
                Timer.Start();
                pause++;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            Pen p = new Pen(LoadColor, 3);
            SolidBrush sb = new SolidBrush(LoadColor);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DoubleBuffered = true;
            if (l1 == true)
            {
                Draw1();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l2 == true)
            {
                Draw2();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l3 == true)
            {
                Draw3();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l4 == true)
            {
                Draw4();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l5 == true)
            {
                Draw5();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l6 == true)
            {
                Draw6();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l7 == true)
            {
                Draw7();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
            if (l8 == true)
            {
                Draw8();
                g.DrawPolygon(p, point);
                g.FillPolygon(sb, point);
            }
        }
        
        private void LogoResize(object sender, EventArgs e)
        {
            width = Width;
            height = Height;
        }

        private void TimerTicked(object sender, EventArgs e)
        {
            if (direct == Direction.ClockWise)
            {
                time++;
                if (time > 10)
                {
                    time = 0;
                }
                else if (time == 10)
                {
                    l1 = false; l2 = false; l3 = false; l4 = false; l5 = false; l6 = false; l7 = false; l8 = false;
                }
                else if (time == 8)
                {
                    l8 = true; 
                }
                else if (time == 7)
                {
                    l7 = true;
                }
                else if (time == 6)
                {
                    l6 = true; 
                }
                else if (time == 5)
                {
                    l5 = true; 
                }
                else if (time == 4)
                {
                    l4 = true; 
                }
                else if (time == 3)
                {
                    l3 = true; 
                }
                else if (time == 2)
                {
                    l2 = true; 
                }
                else if (time == 1)
                {
                    l1 = true; 
                }
                Invalidate();
            }
            else
            {
                time++;
                if (time > 10)
                {
                    time = 0;
                }
                else if (time == 10)
                {
                    l1 = false; l2 = false; l3 = false; l4 = false; l5 = false; l6 = false; l7 = false; l8 = false;
                }
                else if (time == 8)
                {
                    l1 = true;
                }
                else if (time == 7)
                {
                    l2 = true;
                }
                else if (time == 6)
                {
                    l3 = true; 
                }
                else if (time == 5)
                {
                    l4 = true; 
                }
                else if (time == 4)
                {
                    l5 = true;
                }
                else if (time == 3)
                {
                    l6 = true; 
                }
                else if (time == 2)
                {
                    l7 = true; 
                }
                else if (time == 1)
                {
                    l8 = true; 
                }
                Invalidate();
            }
        }
        
        public enum Direction
        {
            ClockWise,
            AntiClockWise
        }
    }
}
