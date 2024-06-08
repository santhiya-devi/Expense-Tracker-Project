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
    public partial class TreeControl : UserControl
    {
        public TreeControl()
        {
            InitializeComponent();
        }

        private Color outLineColor = GUIStyles.backColor, treeBackColor = GUIStyles.whiteColor;

        public int Radius { get; set; } = 20;

        public Color TreeBackColor
        {
            get => treeBackColor;
            set => this.BackColor = treeBackColor = value;
        }

        public Color OutLineColor
        {
            get => outLineColor;
            set
            {
                outLineColor = value;
                Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            
            Rectangle bounds = new Rectangle(0, 0, Width - 1, Height - 1);
            
            path.AddArc(bounds.X, bounds.Y, Radius * 2, Radius * 2, 180, 90); // Top left arc
            path.AddArc(bounds.Right - (Radius * 2), bounds.Y, Radius * 2, Radius * 2, 270, 90); // Top right arc
            path.AddArc(bounds.Right - (Radius * 2), bounds.Bottom - (Radius * 2), Radius * 2, Radius * 2, 0, 90); // Bottom right arc
            path.AddArc(bounds.X, bounds.Bottom - (Radius * 2), Radius * 2, Radius * 2, 90, 90); // Bottom left arc
            
            path.CloseFigure();
            
            Region = new Region(path);

            DoubleBuffered = true;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            
            using (SolidBrush brush = new SolidBrush(BackColor))
            {
                e.Graphics.FillPath(brush, path);
            }

            using (Pen pen= new Pen(OutLineColor, 3))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
    }
}
