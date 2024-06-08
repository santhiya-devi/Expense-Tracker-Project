using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseTracker;

namespace ExpenseTrackerGUI.Home
{
    public partial class TransactionShowControl : UserControl
    {
        #region Constructor and Load events

        public TransactionShowControl()
        {
            InitializeComponent();

            SetDoubleBuffered(trans1);
            SetDoubleBuffered(trans2);
            SetDoubleBuffered(trans3);
            SetDoubleBuffered(trans4);
        }
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                ShowTransaction();
                if (transactions.Count > 4)
                {
                    timer1.Start();
                }
                borderPen = new Pen(GUIStyles.primaryColor, 5);
            }            
        }

        #endregion

        #region Variable creation

        static int index = 0;
        private Pen borderPen;
        List<ExpenseTrackerDS.Transaction> transactions = new List<ExpenseTrackerDS.Transaction>();
        public int walletId = 0;

        #endregion

        #region User defined Functions

        private void MouseEnterEvent(Panel panel, Label label)
        {
            panel.Invalidate();
            panel.Location = new Point(panel.Location.X - 7, panel.Location.Y - 7);
            panel.Size = new Size(panel.Width + 15, panel.Height + 15);
            panel.Focus();
            label.Font = new Font("Arial", 13, FontStyle.Bold);
        }

        private void MouseLeaveEvent(Panel panel, Label label)
        {
            panel.Invalidate();
            panel.Location = new Point(panel.Location.X + 7, panel.Location.Y + 7);
            panel.Size = new Size(panel.Width - 15, panel.Height - 15);
            label.Font = new Font("Arial", 11, FontStyle.Bold);
        }

        public void SetStyles()
        {
            trans1.BackColor = GUIStyles.backColor;
            trans2.BackColor = GUIStyles.backColor;
            trans3.BackColor = GUIStyles.backColor;
            trans4.BackColor = GUIStyles.backColor;

            trans1Label.ForeColor = GUIStyles.primaryColor;
            trans2Label.ForeColor = GUIStyles.primaryColor;
            trans3Label.ForeColor = GUIStyles.primaryColor;
            trans4Label.ForeColor = GUIStyles.primaryColor;

            des1.ForeColor = GUIStyles.primaryColor;
            des2.ForeColor = GUIStyles.primaryColor;
            des3.ForeColor = GUIStyles.primaryColor;
            des4.ForeColor = GUIStyles.primaryColor;

            amount1.ForeColor = GUIStyles.primaryColor;
            amount2.ForeColor = GUIStyles.primaryColor;
            amount3.ForeColor = GUIStyles.primaryColor;
            amount4.ForeColor = GUIStyles.primaryColor;

            date1.ForeColor = GUIStyles.primaryColor;
            date2.ForeColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.primaryColor;
            date4.ForeColor = GUIStyles.primaryColor;

            borderPen = new Pen(GUIStyles.primaryColor, 5);
            trans1.Invalidate();
            trans2.Invalidate();
            trans3.Invalidate();
            trans4.Invalidate();

            transShowCardPanel.CardFlickerColor = GUIStyles.whiteColor;
            transShowCardPanel.CardBackColor = GUIStyles.whiteColor;
        }

        private void SetDoubleBuffered(Control control)
        {
            typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                .SetValue(control, true, null);
        }

        public void ShowTransaction()
        {
            SetStyles();
            trans1Label.Text = "";
            trans2Label.Text = "";
            trans3Label.Text = "";
            trans4Label.Text = "";

            des1.Text = "";
            des2.Text = "";
            des3.Text = "";
            des4.Text = "";

            date1.Text = "";
            date2.Text = "";
            date3.Text = "";
            date4.Text = "";

            amount1.Text = "";
            amount2.Text = "";
            amount3.Text = "";
            amount4.Text = "";

            trans2PictureBox.Hide();
            trans1PictureBox.Hide();
            trans3PictureBox.Hide();
            trans4PictureBox.Hide();

            index = 0;
            transactions = Communicator.Manager.FetchTransactions<List<ExpenseTrackerDS.Transaction>>(walletId);
            label1.Show();
            label2.Show();
            label3.Show();
            label4.Show();
            label5.Show();
            label6.Show();
            label7.Show();
            label8.Show();

            if (index >= transactions.Count)
            {
                index = 0;
            }
            if (transactions.Count > 0)
            {
                label7.Hide();
                label8.Hide();
                trans2PictureBox.Hide();
                trans3PictureBox.Hide();
                trans4PictureBox.Hide();
                trans1PictureBox.Show();
                trans1Label.Text = "";
                des1.Text = "";
                amount1.Text = "";
                trans1Label.Text = transactions[index].CategoryName;
                date1.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                des1.Text = "\n" + transactions[index].Description;
                amount1.Text = "₹ " + transactions[index].Amount.ToString();
                ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                if (category.ImagePath != "" && category.ImagePath!=null)
                {
                    Bitmap bitmap = new Bitmap(category.ImagePath);
                    trans2PictureBox.Image = null;
                    trans2PictureBox.BackgroundImage = null;
                    trans2PictureBox.Image = bitmap;
                    trans2PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                index++;
            }
            if (transactions.Count > 1)
            {
                label1.Hide();
                label2.Hide();
                trans1PictureBox.Show();
                trans2PictureBox.Show();
                trans3PictureBox.Hide();
                trans4PictureBox.Hide();

                trans2Label.Text = "";
                des2.Text = "";
                amount2.Text = "";
                trans2Label.Text = transactions[index].CategoryName;
                date2.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                des2.Text = "\n" + transactions[index].Description;
                amount2.Text = "₹ " + transactions[index].Amount.ToString();
                ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                if (category.ImagePath != "" && category.ImagePath!=null)
                {
                    Bitmap bitmap = new Bitmap(category.ImagePath);
                    trans1PictureBox.Image = null;
                    trans1PictureBox.BackgroundImage = null;
                    trans1PictureBox.Image = bitmap;
                    trans1PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                index++;
            }
            if (transactions.Count > 2)
            {
                label3.Hide();
                label4.Hide();
                trans1PictureBox.Show();
                trans2PictureBox.Show();
                trans3PictureBox.Show();
                trans4PictureBox.Hide();
                trans3Label.Text = "";
                des3.Text = "";
                amount3.Text = "";
                trans3Label.Text = transactions[index].CategoryName;
                date3.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                des3.Text = "\n" + transactions[index].Description;
                amount3.Text = "₹ " + transactions[index].Amount.ToString();
                ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                if (category.ImagePath != "")
                {
                    Bitmap bitmap = new Bitmap(category.ImagePath);
                    trans3PictureBox.Image = null;
                    trans3PictureBox.BackgroundImage = null;
                    trans3PictureBox.Image = bitmap;
                    trans3PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                index++;
            }
            if (transactions.Count > 3)
            {
                label5.Hide();
                label6.Hide();
                trans1PictureBox.Show();
                trans2PictureBox.Show();
                trans3PictureBox.Show();
                trans4PictureBox.Show();
                trans4Label.Text = "";
                des4.Text = "";
                amount4.Text = "";
                trans4Label.Text = transactions[index].CategoryName;
                date4.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                des4.Text = "\n" + transactions[index].Description;
                amount4.Text = "₹ " + transactions[index].Amount.ToString();
                ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                if (category.ImagePath != "")
                {
                    Bitmap bitmap = new Bitmap(category.ImagePath);
                    trans4PictureBox.Image = null;
                    trans4PictureBox.BackgroundImage = null;
                    trans4PictureBox.Image = bitmap;
                    trans4PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                index++;
            }
        }

        #endregion

        #region Timer tick

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (transactions.Count > 4)
            {
                if (index >= transactions.Count)
                {
                    index = 0;
                }
                if (transactions.Count > 0)
                {
                    if (trans1.Bottom <= 0)
                    {
                        trans1.Top = this.Location.Y + Height - trans1.Height + 30;
                        trans1Label.Text = "  "+transactions[index].CategoryName;
                        date1.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                        des1.Text = "\n"+transactions[index].Description;
                        amount1.Text = "₹ " + transactions[index].Amount.ToString();
                        ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                        if (category.CategoryName != null && category.ImagePath != "")
                        {
                            Bitmap bitmap = new Bitmap(category.ImagePath);
                            trans1PictureBox.Image = null;
                            trans1PictureBox.BackgroundImage = null;
                            trans1PictureBox.Image = bitmap;
                            trans1PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        index++;
                        if (index == transactions.Count)
                        {
                            index = 0;
                        }
                    }
                    if (trans2.Bottom <= 0)
                    {
                        trans2.Top = this.Location.Y + Height - trans1.Height + 30;
                        trans2Label.Text = "  " + transactions[index].CategoryName;
                        date2.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                        des2.Text = "\n" + transactions[index].Description;
                        amount2.Text = "₹ " + transactions[index].Amount.ToString();
                        ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                        if (category.CategoryName != null && category.ImagePath != "")
                        {
                            Bitmap bitmap = new Bitmap(category.ImagePath);
                            trans2PictureBox.Image = null;
                            trans2PictureBox.BackgroundImage = null;
                            trans2PictureBox.Image = bitmap;
                            trans2PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        index++;
                        if (index == transactions.Count)
                        {
                            index = 0;
                        }
                    }
                    if (trans3.Bottom <= 0)
                    {
                        trans3.Top = this.Location.Y + Height - trans1.Height + 30;
                        trans3Label.Text = "  " + transactions[index].CategoryName;
                        date3.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                        des3.Text = "\n" + transactions[index].Description;
                        amount3.Text = "₹ " + transactions[index].Amount.ToString();
                        ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);
                        if (category.CategoryName != null && category.ImagePath != "")
                        {
                            Bitmap bitmap = new Bitmap(category.ImagePath);
                            trans3PictureBox.Image = null;
                            trans3PictureBox.BackgroundImage = null;
                            trans3PictureBox.Image = bitmap;
                            trans3PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        index++;
                        if (index == transactions.Count)
                        {
                            index = 0;
                        }
                    }
                    if (trans4.Bottom <= 0)
                    {
                        trans4.Top = this.Location.Y + Height - trans1.Height + 30;
                        trans4Label.Text = "  " + transactions[index].CategoryName;
                        date4.Text = transactions[index].Date.ToString("dd/MM/yyyy");
                        des4.Text = "\n" + transactions[index].Description;
                        amount4.Text = "₹ " + transactions[index].Amount.ToString();
                        ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(transactions[index].CategoryId);

                        if (category.CategoryName != null && category.ImagePath != "")
                        {
                            Bitmap bitmap = new Bitmap(category.ImagePath);
                            trans4PictureBox.Image = null;
                            trans4PictureBox.BackgroundImage = null;
                            trans4PictureBox.Image = bitmap;
                            trans4PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                        }
                        index++;
                        if (index == transactions.Count)
                        {
                            index = 0;
                        }
                    }
                    trans1.Top -= 10;
                    trans2.Top -= 10;
                    trans3.Top -= 10;
                    trans4.Top -= 10;
                }
                else
                {
                    timer1.Stop();
                }
            }
        }

        #endregion

        #region MouseEnter & MouseLeave

        private void trans1_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            MouseEnterEvent(trans1, trans1Label);
        }

        private void trans1_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(trans1, trans1Label);
            timer1.Start();
        }

        private void trans2_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            MouseEnterEvent(trans2, trans2Label);
        }

        private void trans2_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(trans2, trans2Label);
            timer1.Start();
        }

        private void trans3_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            MouseEnterEvent(trans3, trans3Label);
        }

        private void trans3_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(trans3, trans3Label);
            timer1.Start();
        }

        private void trans4_MouseEnter(object sender, EventArgs e)
        {
            timer1.Stop();
            MouseEnterEvent(trans4, trans4Label);
        }

        private void trans4_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(trans4, trans4Label);
            timer1.Start();
        }

        #endregion

        #region Paint

        private void trans1_Paint(object sender, PaintEventArgs e)
        {
            if (borderPen == null) return;
            if (sender is Panel panel)
                e.Graphics.DrawRectangle(borderPen, 2, 2, panel.Width-5, panel.Height-5);
        }

        #endregion        
    }
}
