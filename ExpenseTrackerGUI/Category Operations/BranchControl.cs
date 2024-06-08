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
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI
{
    public partial class BranchControl : UserControl
    {
        public BranchControl()
        {
            InitializeComponent();
        }
        
        public int Radius { get; set; } = 20;
        
        private Color backcolor = GUIStyles.whiteColor, forecolor= GUIStyles.blackColor, outlineColor= GUIStyles.whiteColor;
        private Category category = new Category();
        private int height = 40, id=-1;
        private string imagePath = "";

        public int ID
        {
            get => id;
            set => id = value;
        }

        public string ImagePath
        {
            get => imagePath;
            set
            {
                imagePath = value;
                if (imagePath != null && imagePath!="")
                {
                    pbImage.Image = Image.FromFile(imagePath);
                }
            }
        }

        public string BranchText
        {
            get => lblName.Text;
            set => lblName.Text = value;
        }

        public string BranchName
        {
            get => lblName.Name;
            set
            {
                this.Name = pbImage.Name = lblName.Name = value;
            }
        }

        public Color BranchBackColor
        {
            get => backcolor;
            set
            {
                backcolor = value;
                this.BackColor = backcolor;
            }
        }

        public Color BranchForeColor
        {
            get => forecolor;
            set
            {
                forecolor = value;
                lblName.ForeColor = forecolor;
            }
        }
        
        public override Font Font
        {
            get => lblName.Font;
            set => lblName.Font = value;
        }
        
        public int BranchHeight
        {
            get => height;
            set
            {
                height = value;
                this.Height = lblName.Height = height;
            }
        }

        public Category Category
        {
            get => category;
            set => category = value;
        }

        public Color OutLineColor
        {
            get => outlineColor;
            set
            {
                outlineColor = value;
                Invalidate();
            }
        }
        
        public bool BranchResize
        {
            get => true;
            set
            {
                pbImage.Location = new Point(pbImage.Location.X, (int)((Height / 100.0) * 25));
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            lblName.Width = this.Width - 13;
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

            using (Pen pen = new Pen(OutLineColor, 3))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
        
        private void OnMouseEntered(object sender, EventArgs e)
        {
            this.BackColor = GUIStyles.secondaryColor;
            lblName.ForeColor = GUIStyles.whiteColor;

            this.Cursor = Cursors.Hand;

            Invalidate();
        }

        private void OnClickTrigged(object sender, EventArgs e)
        {
            OnClick(e);
        }

        private void OnMouseLeaved(object sender, EventArgs e)
        {
            this.BackColor = BranchBackColor;
            lblName.ForeColor = GUIStyles.blackColor;

            this.Cursor = Cursors.Arrow;
        }

    }
}