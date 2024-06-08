using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseTrackerDS;
using ExpenseTracker;
using System.Drawing.Drawing2D;

namespace ExpenseTrackerGUI
{
    public partial class CreateTransaction : UserControl
    {
        public CreateTransaction()
        {
            InitializeComponent();
        }

        //Paint Operation

        private void OnPaddPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.backColor, padd.Width, padd.Height, 25, 50);
        }

        //Object Creation

        CategoryView categoryview = new CategoryView();
        WalletView walletview = new WalletView();

        //Input Data To Create Transaction

        Color bordercolor = GUIStyles.primaryColor;
        int categoryid = 0, walletid = 0,time=0;
        String description = "", categoryname = "", walletname = "";
        float amount;
        DateTime date;

        //Load Page

        private void OnCreateTransactionLoad(object sender, EventArgs e)
        {
            AddColor();
            pback.Controls.Add(categoryview);
            categoryview.Dock = DockStyle.Fill;
            pback.Controls.Add(walletview);
            walletview.Dock = DockStyle.Fill;
            categoryview.Visible = false;
            walletview.Visible = false;
            walletview.TotalShow = false;
            walletview.AddMode = false;
            AdjustSize();
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            AddColor();
        }

        private void AddColor()
        {
            Clearbt.BackColor = savebt.BackColor = GUIStyles.whiteColor;
            Clearbt.FlatAppearance.MouseOverBackColor = savebt.FlatAppearance.MouseOverBackColor = GUIStyles.cardColor;
            Clearbt.FlatAppearance.MouseDownBackColor = savebt.FlatAppearance.MouseDownBackColor = GUIStyles.backColor;
            paddtransaction.BackColor = GUIStyles.primaryColor;
            pborder.BackColor = GUIStyles.whiteColor;
            padd.BackColor = GUIStyles.primaryColor;
            amountlb.ForeColor = categorylb.ForeColor = datelb.ForeColor = walletlb.ForeColor = descriptionlb.ForeColor = GUIStyles.blackColor;
        }

        private void OnVisibilityChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                ClearData();
                padd.Visible = true;
                walletview.Visible = categoryview.Visible = false;
            }
        }

        //Resize Page

        private void OnCreateTransactionResize(object sender, EventArgs e)
        {
            AdjustSize();
        }

        private void AdjustSize()
        {
            pback.Width = paddtransaction.Width * 60 / 100;
            pback.Height = paddtransaction.Height * 70 / 100;
            padd.Width = paddtransaction.Width * 70 / 100;
            padd.Height = paddtransaction.Height * 70 / 100;
            pback.Location = new Point(pborder.Width / 2 - pback.Width / 2, pborder.Height / 2 - pback.Height / 2);
            padd.Location = new Point(pborder.Width / 2 - padd.Width / 2, pborder.Height / 2 - padd.Height / 2);
        }

        //Button Click Functions

        private void OnSaveBtClick(object sender, EventArgs e)
        {
            lresult.Text = "";
            if (CheckAmount() == true && CheckWallet() == true && CheckCategory() == true && CheckBudget() == true && CheckDescription() == true)
            {
                amount = float.Parse(amounttb.Text);
                date = datepicker.Value;
                description = descriptiontb.Text;
                Transaction transaction = new Transaction
                {
                    CategoryId = categoryid,
                    CategoryName = categoryname,
                    Amount = amount,
                    Date = date,
                    Description = description,
                    WalletId = walletid
                };
                bool res = Communicator.Manager.AddData(transaction); 
                if (res == true)
                {
                    ClearData();
                    lresult.Text = "Transaction Created ✔";
                    lresult.ForeColor = GUIStyles.incomeColor;
                    Timer.Start();
                }
                else
                {
                    lresult.Text = "Transaction Failed ✘";
                    lresult.ForeColor = GUIStyles.expenseColor;
                }
            }
        }

        private void OnClearBtClick(object sender, EventArgs e)
        {
            ClearData();
        }

        //Select Category

        private void OnCategoryBtSelect(object sender, EventArgs e)
        {
            if (walletbt.Text == "Select Wallet                          ➤")
            {
                ErrorProvider.SetError(categoryselectbt, "Choose Wallet");
            }
            else
            {
                ErrorProvider.SetError(categoryselectbt, "");
                categoryview.Visible = true;
                categoryview.WalletChange = new Wallet { WalletID = walletid };
                padd.Visible = false;
                categoryview.CategorySelect += OnCategorySelect;
                categoryview.CategoryClose += OnCategoryClose;
            }
        }

        private void OnCategoryClose(object sender, EventArgs e)
        {
            categoryview.Visible = false;
            padd.Visible = true;
            categoryview.CategoryClose -= OnCategoryClose;
        }

        private void OnCategorySelect(object sender, Category e)
        {
            categoryid = e.ID;
            categoryname = e.CategoryName;
            categoryview.Visible = false;
            padd.Visible = true;
            categoryselectbt.Text = categoryname;
            categoryselectbt.BackColor = GUIStyles.whiteColor;
            ErrorProvider.SetError(categoryselectbt, "");
            categoryview.CategorySelect -= OnCategorySelect;
        }

        //Select Wallet

        private void OnWalletBtSelect(object sender, EventArgs e)
        {            
            walletview.Visible = true;
            padd.Visible = false;
            walletview.WalletSelect += OnWalletSelect;
            walletview.WalletClose += OnWalletClose;
            walletview.ChangeWidth(pback.Width);
        }

        private void OnWalletClose(object sender, EventArgs e)
        {
            walletview.Visible = false;
            padd.Visible = true;
            walletview.WalletClose -= OnWalletClose;
        }

        private void OnWalletSelect(Image image, Wallet e)
        {
            walletid = e.WalletID;
            walletname = e.WalletName;
            walletview.Visible = false;
            padd.Visible = true;
            walletbt.Text = walletname;
            ErrorProvider.SetError(categoryselectbt, "");
            categoryselectbt.Text = "Select Category                     ➤";
            categoryselectbt.BackColor = Color.WhiteSmoke;
            walletbt.BackColor = GUIStyles.whiteColor;
            ErrorProvider.SetError(walletbt, "");
            walletview.WalletSelect -= OnWalletSelect;
        }

        //KeyPress Events

        private void OnAmountKeyPress(object sender, KeyPressEventArgs e)
        {
            ErrorProvider.SetError(amounttb, "");
            if (e.KeyChar == (char)13)
            {
                OnSaveBtClick(sender, EventArgs.Empty);
            }
            if (e.KeyChar == (char)46)
            {
                string str = amounttb.Text;
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '.')
                    {
                        e.Handled = true;
                        return;
                    }
                }
                e.Handled = false;
            }            
            else if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        //Validate Functions

        public void ClearData()
        {
            lresult.Text = "";
            amounttb.Text = "";
            descriptiontb.Text = "";
            ErrorProvider.SetError(amounttb, "");
            datepicker.Text = DateTime.Now.ToString();
            categoryselectbt.Text = "Select Category                     ➤";
            walletbt.Text = "Select Wallet                          ➤";
            categoryselectbt.BackColor = walletbt.BackColor = Color.WhiteSmoke;
        }

        public bool CheckAmount()
        {
            if (amounttb.Text == ".")
            {
                ErrorProvider.SetError(amounttb, "Invalid Amount");
                amounttb.Text = "";
                return false;
            }            
            else if(amounttb.Text.Length <= 0 || float.Parse(amounttb.Text) == 0)
            {
                ErrorProvider.SetError(amounttb, "Invalid Amount");
                amounttb.Text = "";
                return false;
            }
            else if (amounttb.TextLength > 0)
            {
                ErrorProvider.SetError(amounttb, "");
                return true;
            }
            ErrorProvider.SetError(amounttb, "Amount is required");
            return false;
        }

        public bool CheckCategory()
        {
            if (categoryselectbt.Text == "Select Category                     ➤")
            {
                ErrorProvider.SetError(categoryselectbt, "Choose Category");
                return false;
            }
            ErrorProvider.SetError(categoryselectbt, "");
            return true;
        }

        public bool CheckWallet()
        {
            if (walletbt.Text == "Select Wallet                          ➤")
            {
                ErrorProvider.SetError(walletbt, "Choose Wallet");
                return false;
            }
            ErrorProvider.SetError(walletbt, "");
            return true;
        }

        public bool CheckBudget()
        {
            string budgetamount = Communicator.Manager.FetchAmount(categoryid, datepicker.Value, walletid);
            if (budgetamount == "Not Found")
            {
                return true;
            }
            if (float.Parse(amounttb.Text) > float.Parse(budgetamount))
            {
                padd.Enabled = false;
                Notification n = new Notification
                {
                    Category_Name = categoryname,
                    borderColor = GUIStyles.secondaryColor,
                    outcolor = GUIStyles.secondaryColor
                };
                n.ShowDialog();
                padd.Enabled = true;
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

        public bool CheckDescription()
        {
            if (descriptiontb.TextLength > 0)
            {
                ErrorProvider.SetError(descriptiontb, "");
                return true;
            }
            ErrorProvider.SetError(descriptiontb, "Enter Description");
            return false;
        }

        //Timer Operation

        private void OnTimerStart(object sender, EventArgs e)
        {
            time++;
            if (time == 4)
            {
                time = 0;
                lresult.Text = "";
                Timer.Stop();
            }
        }
    }
}
