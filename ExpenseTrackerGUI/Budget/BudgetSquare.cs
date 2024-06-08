using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class BudgetSquare : UserControl
    {
        public BudgetSquare()
        {
            InitializeComponent();
            progressBarUserControl.Value = 75;
            panel1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 5, 5));
            BackColor = progressBarUserControl.BackColor = GUIStyles.primaryColor;
            GUIStyles.ColorChanged += OnColorChnaged;
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public event EventHandler<int> BudgetSquareClicked;

        private int budgetId;

        public int Value
        {
            get => progressBarUserControl.Value;
            set
            {
                progressBarUserControl.Value = value;
            }
        }

        public void InitializeValues( int id ,int amount  , int amountSpent , string categoryName , string image )
        {
            budgetId = id;
            amountLbl.Text = $"{amountSpent}-{amount}";
            amountLbl.Location = new Point((Width/2) - (amountLbl.Width / 2), amountLbl.Location.Y);
            categoryLbl.Text = categoryName;
            float value = amountSpent;
            if (amount == 0 && amountSpent >= 0)
                value = 100;
            else
                value =  (value/ amount) * 100;
            if (value < 0)
            {
                value = 0;
            }
            if (value > 100)
            {
                value = 100;
            }
            progressBarUserControl.Value = (int)value;
            pictureBox.BackgroundImage = Image.FromFile(image);
        }
        
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                int size = Width;
                int radius = 12;
                
                int x = (this.ClientSize.Width - size) / 2;
                int y = (this.ClientSize.Height - size) / 2;
                
                Brush brush = new SolidBrush(GUIStyles.primaryColor);
                
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                g.FillRectangle(brush, x + radius, y, size - 2 * radius, size);
                g.FillRectangle(brush, x, y + radius, size, size - 2 * radius);
                g.FillEllipse(brush, x, y, 2 * radius, 2 * radius);
                g.FillEllipse(brush, x + size - 2 * radius, y, 2 * radius, 2 * radius);
                g.FillEllipse(brush, x, y + size - 2 * radius, 2 * radius, 2 * radius);
                g.FillEllipse(brush, x + size - 2 * radius, y + size - 2 * radius, 2 * radius, 2 * radius);

            }

        }

        private void OnColorChnaged(bool e)
        {
            BackColor = GUIStyles.terenaryColor;
            progressBarUserControl.BackColor = GUIStyles.primaryColor;
            Invalidate();
        }
        
        private void OnBudgetSquareClicked(object sender, EventArgs e)
        {
            BudgetSquareClicked?.Invoke(sender ,budgetId);
        }

        private void OnMouseEntered(object sender, EventArgs e)
        {
            Location = new Point(Location.X - 5, Location.Y - 5);
            this.Size = new Size(210, 210);
            Invalidate();
        }

        private void OnMouseLeaved(object sender, EventArgs e)
        {
            Location = new Point(Location.X + 5, Location.Y + 5);
            this.Size = new Size(200, 200);
            Invalidate();
        }

    }
}
