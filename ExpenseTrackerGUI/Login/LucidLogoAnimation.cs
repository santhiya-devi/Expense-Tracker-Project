using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseTrackerGUI;

namespace WindowsFormsDraft
{
    class LucidLogoAnimation : UserControl
    {
        public LogoRotation animationRotation;

        public LogoRotation AnimationRotation
        {
            get
            {
                return animationRotation;
            }

            set
            {
                animationRotation = value;
                isDelayOccuring = false;
                animationCompletedPolygons.Clear();
                polygons.Clear();
                GeneratePolygons();
                

                if (animationRotation == LogoRotation.Clockwise)
                {
                    Iter = 0;
                }
                else
                {
                    Iter = 7;
                }
            }
        }

        public int Interval
        {
            get
            {
                return t.Interval;
            }

            set
            {
                t.Interval = value;
                isIntervalSetted = true;
            }
        }

        public bool Started
        {
            get => started;
            set
            {
                started = value;
                if (started)
                    t.Start();
                else
                    t.Stop();
            }
        }

        public Color LogoColor { get; set; } = GUIStyles.primaryColor;

        private Timer t = new Timer();

        private List<Point[]> polygons = new List<Point[]>();

        private List<Point[]> animationCompletedPolygons = new List<Point[]>();
        
        private int startLogoX = 0, startLogoY = 0 , Counter = 0, Iter = 0, delayCount = 0, logoSize;

        private bool isDelayOccuring = false, isIntervalSetted = false, started = false;
        
        protected override void OnPaint(PaintEventArgs e)
        {
            if (logoSize <= 0)
                return;
            DoubleBuffered = true;
            Brush b1 = new SolidBrush(LogoColor);
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            foreach (var Iter in animationCompletedPolygons)
            {
                e.Graphics.FillPolygon(b1, Iter);
            }

            if (Iter < polygons.Count && Iter >= 0)
                e.Graphics.FillPolygon(b1, polygons[Iter]);

            b1.Dispose();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Height * 4 <= Width)
            {
                logoSize = Height;
                startLogoX = (Width - Height * 4) / 2;
                startLogoY = 0;
            }
            else
            {
                logoSize = Width / 4;
                startLogoX = 0;
                startLogoY = (Height - logoSize) / 2;
            }
            startLogoX = startLogoX + logoSize / 4;
            //t = new Timer();
            if(!isIntervalSetted)
            t.Interval = 10;
            t.Tick += OnLogoMovement;
            //t.Start();
            GeneratePolygons();
        }
        
        protected override void OnResize(EventArgs e)
        {
            if(Height*4<=Width)
            {
                logoSize = Height;
                startLogoX = (Width - Height*4) / 2;
                startLogoY = 0;
            }
            else
            {
                logoSize = Width/4;
                startLogoX = 0;
                startLogoY = (Height - logoSize) / 2;
            }
            startLogoX = startLogoX + logoSize / 4;
        }

        private void GeneratePolygons()
        {
            Point[] p = new Point[3]
            {
                new Point(logoSize * 173 / 300 + startLogoX, logoSize * 48 / 300 - 20 + startLogoY),
                new Point(logoSize * 176 / 300 + startLogoX, logoSize * 117 / 300 - 20 + startLogoY),
                new Point(logoSize * 211 / 300 + startLogoX, logoSize * 85 / 300 - 20 + startLogoY)
            };
            polygons.Add(p);

            p = new Point[3]
            {
                new Point(logoSize * 213 / 300 + 20 + startLogoX, logoSize * 88 / 300 - 20 + startLogoY),
                new Point(logoSize * 181 / 300 + 20 + startLogoX, logoSize * 122 / 300 - 20 + startLogoY),
                new Point(logoSize * 250 / 300 + 20 + startLogoX, logoSize * 124 / 300 - 20 + startLogoY)
            };
            polygons.Add(p);
            p = new Point[8]
            {
                new Point(logoSize * 180 / 300 + 20 + startLogoX, logoSize * 129 / 300 + startLogoY),
                new Point(logoSize * 252 / 300 + 20 + startLogoX, logoSize * 127 / 300 + startLogoY),
                new Point(logoSize * 277 / 300 + 20 + startLogoX, logoSize * 153 / 300 + startLogoY),
                new Point(logoSize * 266 / 300 + 20 + startLogoX, logoSize * 158 / 300 + startLogoY),
                new Point(logoSize * 256 / 300 + 20 + startLogoX, logoSize * 163 / 300 + startLogoY),
                new Point(logoSize * 247 / 300 + 20 + startLogoX, logoSize * 168 / 300 + startLogoY),
                new Point(logoSize * 236 / 300 + 20 + startLogoX, logoSize * 175 / 300 + startLogoY),
                new Point(logoSize * 229 / 300 + 20 + startLogoX, logoSize * 179 / 300 + startLogoY)
            };

            polygons.Add(p);

            p = new Point[8]
            {
                new Point(logoSize * 176 / 300 + 20 + startLogoX, logoSize * 134 / 300 + 20 + startLogoY),
                new Point(logoSize * 174 / 300 + 20 + startLogoX, logoSize * 237 / 300 + 20 + startLogoY),
                new Point(logoSize * 184 / 300 + 20 + startLogoX, logoSize * 223 / 300 + 20 + startLogoY),
                new Point(logoSize * 191 / 300 + 20 + startLogoX, logoSize * 214 / 300 + 20 + startLogoY),
                new Point(logoSize * 200 / 300 + 20 + startLogoX, logoSize * 204 / 300 + 20 + startLogoY),
                new Point(logoSize * 207 / 300 + 20 + startLogoX, logoSize * 197 / 300 + 20 + startLogoY),
                new Point(logoSize * 217 / 300 + 20 + startLogoX, logoSize * 188 / 300 + 20 + startLogoY),
                new Point(logoSize * 227 / 300 + 20 + startLogoX, logoSize * 181 / 300 + 20 + startLogoY)
            };

            polygons.Add(p);

            p = new Point[11]
            {
                new Point(logoSize * 169 / 300 + startLogoX,logoSize* 135 / 300 + 20 + startLogoY),
                new Point(logoSize * 171 / 300 + startLogoX,logoSize* 241 / 300 + 20 + startLogoY),
                new Point(logoSize * 163 / 300 + startLogoX,logoSize* 254 / 300 + 20 + startLogoY),
                new Point(logoSize * 155 / 300 + startLogoX,logoSize* 269 / 300 + 20 + startLogoY),
                new Point(logoSize * 150 / 300 + startLogoX,logoSize* 279 / 300 + 20 + startLogoY),
                new Point(logoSize * 144 / 300 + startLogoX,logoSize* 266 / 300 + 20 + startLogoY),
                new Point(logoSize * 138 / 300 + startLogoX,logoSize* 252 / 300 + 20 + startLogoY),
                new Point(logoSize * 129 / 300 + startLogoX,logoSize* 237 / 300 + 20 + startLogoY),
                new Point(logoSize * 121 / 300 + startLogoX,logoSize* 225 / 300 + 20 + startLogoY),
                new Point(logoSize * 109 / 300 + startLogoX,logoSize* 210 / 300 + 20 + startLogoY),
                new Point(logoSize * 100 / 300 + startLogoX,logoSize* 200 / 300 + 20 + startLogoY)
            };

            polygons.Add(p);

            p = new Point[9]
            {
                new Point(logoSize * 47 / 300 - 20 + startLogoX, logoSize * 127 / 300 + 20 + startLogoY),
                new Point(logoSize * 164 / 300 - 20 + startLogoX, logoSize * 129 / 300 + 20 + startLogoY),
                new Point(logoSize * 98 / 300 - 20 + startLogoX, logoSize * 198 / 300 + 20 + startLogoY),
                new Point(logoSize * 88 / 300 - 20 + startLogoX, logoSize * 190 / 300 + 20 + startLogoY),
                new Point(logoSize * 76 / 300 - 20 + startLogoX, logoSize * 180 / 300 + 20 + startLogoY),
                new Point(logoSize * 62 / 300 - 20 + startLogoX, logoSize * 171 / 300 + 20 + startLogoY),
                new Point(logoSize * 51 / 300 - 20 + startLogoX, logoSize * 165 / 300 + 20 + startLogoY),
                new Point(logoSize * 39 / 300 - 20 + startLogoX, logoSize * 159 / 300 + 20 + startLogoY),
                new Point(logoSize * 23 / 300 - 20 + startLogoX, logoSize * 152 / 300 + 20 + startLogoY)
            };

            polygons.Add(p);

            p = new Point[3]
            {
                new Point(logoSize * 109 / 300  - 20 + startLogoX, logoSize * 66 / 300 + startLogoY),
                new Point(logoSize * 163 / 300 - 20 + startLogoX, logoSize * 123 / 300 + startLogoY),
                new Point(logoSize * 49 / 300 - 20 + startLogoX, logoSize * 126 / 300 + startLogoY)
            };
            polygons.Add(p);

            p = new Point[4]
            {
                new Point(logoSize * 150 / 300 - 20 + startLogoX, logoSize * 25 / 300 - 20 + startLogoY),
                new Point(logoSize * 171 / 300 - 20 + startLogoX, logoSize * 45 / 300 - 20 + startLogoY),
                new Point(logoSize * 168 / 300 - 20 + startLogoX, logoSize * 117 / 300 - 20 + startLogoY),
                new Point(logoSize * 111 / 300 - 20 + startLogoX, logoSize * 64 / 300 - 20 + startLogoY)
            };
            polygons.Add(p);
        }

        private void OnLogoMovement(object sender, EventArgs e)
        {
            if (isDelayOccuring)
            {
                if (delayCount <= 20)
                {
                    delayCount += 1;
                }
                else
                {
                    delayCount = 0;
                    isDelayOccuring = false;
                    polygons.Clear();
                    GeneratePolygons();
                    animationCompletedPolygons.Clear();
                    if(animationRotation == LogoRotation.Clockwise)
                    {
                        Iter = 0;
                    }
                    else
                    {
                        Iter = 7;
                    }
                }
                this.Invalidate();
                return;
            }

            Counter += 4;
            for (int ctr = 0; ctr < polygons[Iter].Length; ctr++)
            {
                if (Iter == 0)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X, polygons[Iter][ctr].Y + 4);
                else if (Iter == 1)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X - 4, polygons[Iter][ctr].Y + 4);
                else if (Iter == 2)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X - 4, polygons[Iter][ctr].Y);
                else if (Iter == 3)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X - 4, polygons[Iter][ctr].Y - 4);
                else if (Iter == 4)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X, polygons[Iter][ctr].Y - 4);
                else if (Iter == 5)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X + 4, polygons[Iter][ctr].Y - 4);
                else if (Iter == 6)
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X + 4, polygons[Iter][ctr].Y);
                else
                    polygons[Iter][ctr] = new Point(polygons[Iter][ctr].X + 4, polygons[Iter][ctr].Y + 4);
            }
            this.Invalidate();

            if (Counter >= 20)
            {
                Counter = 0;
                animationCompletedPolygons.Add(polygons[Iter]);

                if(animationRotation== LogoRotation.Clockwise)
                {
                    Iter++;
                }
                else
                {
                    Iter--;
                }
            }

            if (animationRotation == LogoRotation.Clockwise)
            {
                if (Iter == polygons.Count)
                {
                    isDelayOccuring = true;
                }
            }
            else
            {
                if (Iter == -1)
                {
                    isDelayOccuring = true;
                }
            }
        }

        public enum LogoRotation
        {
            Clockwise,
            AntiClockwise,
        }
    }
}

