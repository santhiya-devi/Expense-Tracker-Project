using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace ExpenseTrackerGUI
{
    public partial class ExpenseTrackerLogo : UserControl
    {
        public ExpenseTrackerLogo()
        {
            InitializeComponent();
        }

        int time = 0;
        bool text1 = false, text2 = false;
        Point[] pointe, pointt;
        Color backcolor = Color.FromArgb(104, 210, 232), textcolor = Color.White, bordercolor = Color.FromArgb(253, 222, 85);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DoubleBuffered = true;
            GraphicsPath gp = new GraphicsPath();
            e.Graphics.DrawPolygon(new Pen(new SolidBrush(backcolor)), pointe);
            e.Graphics.FillPolygon(new SolidBrush(backcolor), pointe);
            e.Graphics.DrawPolygon(new Pen(new SolidBrush(backcolor)), pointt);
            e.Graphics.FillPolygon(new SolidBrush(backcolor), pointt);
            if (text1 == true)
                e.Graphics.DrawString("Expense", new Font("Arial", 25), new SolidBrush(textcolor), new Point(40, 20));
            if (text2 == true)
                e.Graphics.DrawString("Tracker", new Font("Arial", 25), new SolidBrush(textcolor), new Point(100, 60));
            if (time >= 15)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor),3), new Point(10, 62), new Point(10, 13));
            if (time >= 16)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(10, 14), new Point(200, 14));
            if (time >= 17)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(200, 13), new Point(200, 55));
            if (time >= 18)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(200, 53), new Point(252, 53));
            if (time >= 19)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(250, 54), new Point(250, 109));
            if (time >= 20)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(250, 107), new Point(70, 107));
            if (time >= 21)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(70, 109), new Point(70, 61));
            if (time >= 22)
                e.Graphics.DrawLine(new Pen(new SolidBrush(bordercolor), 3), new Point(71, 62), new Point(9, 62));
        }

        private void Draw0()
        {
            text1 = text2 = false;
            Point p1 = new Point(10, 15);
            Point p2 = new Point(11, 15);
            Point p3 = new Point(11, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
            Point p5 = new Point(250, 65);
            Point p6 = new Point(250, 65);
            Point p7 = new Point(250, 65);
            Point p8 = new Point(250, 65);
            pointt = new Point[] { p5, p6, p7, p8 };
        }

        private void Draw1()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(30, 15);
            Point p3 = new Point(30, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw2()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(60, 15);
            Point p3 = new Point(60, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw3()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(90, 15);
            Point p3 = new Point(90, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw4()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(120, 15);
            Point p3 = new Point(120, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw5()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(150, 15);
            Point p3 = new Point(150, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw6()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(180, 15);
            Point p3 = new Point(180, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw7()
        {
            Point p1 = new Point(10, 15);
            Point p2 = new Point(200, 15);
            Point p3 = new Point(200, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 }; text1 = true;
        }

        private void Draw8()
        {
            Point p1 = new Point(230, 105);
            Point p2 = new Point(230, 55);
            Point p3 = new Point(200, 55);
            Point p4 = new Point(200, 105);
            pointt = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw9()
        {
            Point p1 = new Point(250, 105);
            Point p2 = new Point(250, 55);
            Point p3 = new Point(170, 55);
            Point p4 = new Point(170, 105);
            pointt = new Point[] { p1, p2, p3, p4 };
        }

        private void OnExpenseTrackerLoad(object sender, EventArgs e)
        {
            Point p1 = new Point(10, 10);
            Point p2 = new Point(11, 10);
            Point p3 = new Point(11, 60);
            Point p4 = new Point(10, 60);
            pointe = new Point[] { p1, p2, p3, p4 };
            Point p5 = new Point(250, 65);
            Point p6 = new Point(250, 65);
            Point p7 = new Point(250, 65);
            Point p8 = new Point(250, 65);
            pointt = new Point[] { p5, p6, p7, p8 };
        }

        private void Draw10()
        {
            Point p1 = new Point(250, 105);
            Point p2 = new Point(250, 55);
            Point p3 = new Point(140, 55);
            Point p4 = new Point(140, 105);
            pointt = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw11()
        {
            Point p1 = new Point(250, 105);
            Point p2 = new Point(250, 55);
            Point p3 = new Point(110, 55);
            Point p4 = new Point(110, 105);
            pointt = new Point[] { p1, p2, p3, p4 };
        }

        private void Draw12()
        {
            Point p1 = new Point(250, 105);
            Point p2 = new Point(250, 55);
            Point p3 = new Point(70, 55);
            Point p4 = new Point(70, 105);
            pointt = new Point[] { p1, p2, p3, p4 }; text2 = true;
        }

        private void OnExpenseTrackerTimer(object sender, EventArgs e)
        {
            time++;
            if (time == 1)
                Draw1();
            else if (time == 2)
                Draw2();
            else if (time == 3)
                Draw3();
            else if (time == 4)
                Draw4();
            else if (time == 5)
                Draw5();
            else if (time == 6)
                Draw6();
            else if (time == 7)
                Draw7();
            else if (time == 8)
                Draw8();
            else if (time == 9)
                Draw9();
            else if (time == 10)
                Draw10();
            else if (time == 11)
                Draw11();
            else if (time == 12)
                Draw12();
            else if (time == 23)
            {
                //bordercolor = Color.FromArgb(135, 76, 204);
                //backcolor = Color.FromArgb(242, 123, 189);
                //textcolor = Color.Black;
            }
            else if (time == 24)
            {
                logopb.Visible = true;
            }
            else if (time == 50)
            {
                logopb.Visible = false;
                bordercolor = Color.FromArgb(253, 222, 85);
                backcolor = Color.FromArgb(104, 210, 232);
                textcolor = Color.White;
                Draw0(); time = 0;
            }
            DoubleBuffered = true;
            Invalidate();
        }
    }
}
