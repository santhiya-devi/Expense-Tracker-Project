using ExpenseTracker;
using ExpenseTrackerDS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class EditTransaction : Form
    {
        public EditTransaction()
        {
            InitializeComponent();
        }

        //Paint Operation

        private void OnPdesignPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.backColor, GUIStyles.backColor, pdesign.Width, pdesign.Height, 0, 30);
        }

        private void OnPbottomPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.whiteColor, pbottom.Width, pbottom.Height, 25, 30);
        }

        // Object Creation

        Calculator calc = new Calculator();
        CategoryView categoryview = new CategoryView();  // WalletView walletview = new WalletView();
        Transaction editdata;

        // Edit Property

        public Transaction EditData
        {
            get => editdata;
            set
            {
                editdata = value;
                ChangeData();
                categorybt.Text = editdata.CategoryName;
                tempamount = editdata.Amount;
                amountbt.Text = editdata.Amount.ToString();
                datepicker.Text = editdata.Date.ToLongDateString();
                olddate = editdata.Date;
                descriptiontb.Text = editdata.Description;
                walletbt.Text=(Communicator.Manager.FetchWallet(editdata.WalletId)).WalletName;
                CalculateDate();
            }
        }

        public bool done = false;
        float tempamount = 0;
        DateTime startdate = DateTime.Now, enddate = DateTime.Now,newdate=DateTime.Now,olddate;

        // Load  and Resize EditTransaction

        private void LoadTransaction()
        {
            AddColor();
            pdesign.Location = new Point(pbottom.Width / 2 - pdesign.Width / 2, (pbottom.Height - pdown.Height) / 2 - pdesign.Height / 2);
            pback.Location = new Point(pdesign.Width / 2 - pback.Width / 2, pdesign.Height / 2 - pback.Height / 2);
            pcalculator.Size = new Size(272, 261);
            pcalculator.Location = new Point(pdesign.Location.X-1, pback.Location.Y);
        }

        private void AddColor()
        {
            categoryview.ColorChange();
            cancelbt.BackColor = donebt.BackColor = GUIStyles.whiteColor;
            cancelbt.FlatAppearance.MouseOverBackColor = donebt.FlatAppearance.MouseOverBackColor = GUIStyles.cardColor;
            cancelbt.FlatAppearance.MouseDownBackColor = donebt.FlatAppearance.MouseDownBackColor = GUIStyles.backColor;
            this.BackColor = GUIStyles.primaryColor;
            if (GUIStyles.colorName == "blue")
            {
                walletimg.BackgroundImage = Image.FromFile(@".\Images\walletblue.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                walletimg.BackgroundImage = Image.FromFile(@".\Images\walletred.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                walletimg.BackgroundImage = Image.FromFile(@".\Images\walletorange.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                walletimg.BackgroundImage = Image.FromFile(@".\Images\walletpink.png");
            }
            else
            {
                walletimg.BackgroundImage = Image.FromFile(@".\Images\walletblack.png");
            }
        }

        private void OnEditTransactionLoad(object sender, EventArgs e)
        {
            LoadTransaction();
            ActiveControl = donebt;
            calc.Dock = DockStyle.Fill;
            pcalculator.Controls.Add(calc);
            categoryview.Dock = DockStyle.Fill;
            pbackground.Controls.Add(categoryview);
            categoryview.Visible = false;
            //walletview.Dock = DockStyle.Fill;
            //pbackground.Controls.Add(walletview);
            //walletview.Visible = false;
        }

        private void OnEditTransactionResize(object sender, EventArgs e)
        {
            LoadTransaction();
        }

        // Category Select

        private void OnCategoryBtClick(object sender, EventArgs e)
        {
            pbottom.Visible = false;
            categoryview.WalletChange = new Wallet() { WalletID = editdata.WalletId };
            categoryview.Visible = true;
            categoryview.CategorySelect += CategoryviewCategorySelect;
            categoryview.CategoryClose += CategoryviewCategoryClose;
        }

        private void CategoryviewCategoryClose(object sender, EventArgs e)
        {
            pbottom.Visible = true;
            categoryview.Visible = false;
            categoryview.CategoryClose -= CategoryviewCategoryClose;
        }

        private void CategoryviewCategorySelect(object sender, Category e)
        {
            editdata.CategoryId = e.ID;
            editdata.CategoryName = e.CategoryName;
            categorybt.Text = editdata.CategoryName;
            ChangeData();
            pbottom.Visible = true;
            categoryview.Visible = false;
            categoryview.CategorySelect -= CategoryviewCategorySelect;
        }

        // Button Click Events

        private void OnDoneBtClick(object sender, EventArgs e)
        {
            if (amountbt.Text.Length > 0 && CheckAmount()==true && pbottom.Visible == true)
            {
                done = true;
                editdata.Amount = float.Parse(amountbt.Text);
                editdata.Description = descriptiontb.Text;
               // editdata.Date = datepicker.Value;
                EditTransactionData();
                calc.Dispose(); categoryview.Dispose();
                this.Close();
            }
            if (amountbt.Text.Length <= 0)
            {
                ErrorProvider.SetError(pback, "Enter Amount");
                ErrorProvider.SetIconAlignment(pback, ErrorIconAlignment.TopRight);
            }
        }

        private void OnCancelBtClick(object sender, EventArgs e)
        {
            calc.Dispose(); categoryview.Dispose();
            done = false;
            this.Close();
        }

        private void OnAmountBtClick(object sender, EventArgs e)
        {
            pback.Enabled = false; pbutton.Enabled = false;
            calc.Answer = float.Parse(amountbt.Text);
            pcalculator.BringToFront();
            pcalculator.Visible = true;
            calc.CalculatorClosed += OnCalculatorClosed;
        }

        private void OnCalculatorClosed(object sender, bool closed)
        {
            amountbt.Text = calc.Answer.ToString();
            pcalculator.Visible = false;
            pback.Enabled = true; pbutton.Enabled = true;
        }

        //Validate Function

        private bool CheckAmount()
        {
            string budgetamount = Communicator.Manager.FetchAmount(editdata.CategoryId, datepicker.Value, editdata.WalletId);
            if (budgetamount == "Not Found")
            {
                return true;
            }
            if ((float.Parse(amountbt.Text) - tempamount) > float.Parse(budgetamount))
            {
                Notification n = new Notification
                {
                    Category_Name = editdata.CategoryName,
                    borderColor = GUIStyles.secondaryColor,
                    outcolor = GUIStyles.secondaryColor
                };
                n.ShowDialog();
                if (n.yes == true)
                {
                    n.Dispose();
                    return true;
                }
                n.Dispose();
                return false;
            }
            return true;
        }

        private void EditTransactionData()
        {
            newdate = datepicker.Value;
            if (CheckDateTime())
            {
                bool result = Communicator.Manager.EditData(editdata);
            }
        }

        private void CalculateDate()
        {
            startdate = DateTime.Parse("01/" + editdata.Date.ToString("MM/yyyy"));
            enddate = editdata.Date.AddMonths(1);
            enddate = DateTime.Parse("01/" + enddate.ToString("MM/yyyy"));
            enddate = enddate.AddDays(-1);
        }

        private bool CheckDateTime()
        {
            if (newdate >= startdate && newdate <= enddate)
            {
                editdata.Date = datepicker.Value;
                return true;
            }
            bool iscreated = CreateTransaction();
            if (iscreated == true)
            {
                DeleteTransaction();
            }
            return false;
        }

        private void DeleteTransaction()
        {
            editdata.Date = olddate;
            bool result = Communicator.Manager.RemoveData(editdata);
        }

        private bool CreateTransaction()
        {
            editdata.Date = datepicker.Value;
            bool result = Communicator.Manager.AddData(editdata);
            if (result == true)
            {
                return true;
            }
            return false;
        }

        private void ChangeData()
        {
            categoryimg.BackgroundImage = new Bitmap((Communicator.Manager.FetchCategoryName(editdata.CategoryId)).ImagePath);
            if ((Communicator.Manager.FetchCategoryName(editdata.CategoryId)).Type == true)
            {
                amountbt.ForeColor = rupeelb.ForeColor = GUIStyles.incomeColor;
            }
            else
            {
                amountbt.ForeColor = rupeelb.ForeColor = GUIStyles.expenseColor;
            }
        }

        //Mouse Enter Events

        private void OnAmountMouseEnter(object sender, EventArgs e)
        {
            amountbt.BackColor = rupeelb.BackColor = Color.Gainsboro;
        }

        private void OnAmountMouseLeave(object sender, EventArgs e)
        {
            amountbt.BackColor = rupeelb.BackColor = Color.White;
        }

        private void OnCategoryMouseEnter(object sender, EventArgs e)
        {
            categorybt.BackColor = categoryimg.BackColor = Color.Gainsboro;
        }

        private void OnCategoryMouseLeave(object sender, EventArgs e)
        {
            categorybt.BackColor = categoryimg.BackColor = Color.White;
        }

        //private void OnWalletBtClick(object sender, EventArgs e)
        //{
        //    pbottom.Visible = false;
        //    walletview.Visible = true;
        //    walletview.WalletSelect += OnWalletviewWalletSelect;
        //    walletview.WalletClose += OnWalletviewWalletClose;
        //}

        //private void OnWalletviewWalletClose(object sender, EventArgs e)
        //{
        //    pbottom.Visible = true;
        //    walletview.Visible = false;
        //    walletview.WalletClose -= OnWalletviewWalletClose;
        //}

        //private void OnWalletviewWalletSelect(Image image, Wallet e)
        //{
        //    editdata.WalletId = e.WalletID;
        //    walletbt.Text = e.WalletName;
        //    pbottom.Visible = true;
        //    walletview.Visible = false;
        //    walletview.WalletSelect -= OnWalletviewWalletSelect;
        //}
    }
}
