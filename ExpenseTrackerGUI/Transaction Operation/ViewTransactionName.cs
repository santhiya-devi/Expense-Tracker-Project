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

namespace ExpenseTrackerGUI
{
    public partial class ViewTransactionName : UserControl
    {
        public ViewTransactionName()
        {
            InitializeComponent();
        } 
        
        //Event Creation

        public delegate void ControlDisable(object sender, bool disabled);
        public event ControlDisable ControlDisabled;
        public delegate void ControlChange(object sender, bool changed);
        public event ControlChange ControlChanged;

        //Property Creation

        Transaction editdata;
        Color backcolor;

        public Color Backcolor
        {
            get => backcolor;
            set
            {
                backcolor = value;
                if (backcolor == GUIStyles.terenaryColor)
                {
                    Editlb.ForeColor = Deletelb.ForeColor = categorynamelb.ForeColor = GUIStyles.whiteColor;
                }
                else
                {
                    Editlb.ForeColor = Deletelb.ForeColor = categorynamelb.ForeColor = GUIStyles.blackColor;
                }
                imglb.BackColor = categorynamelb.BackColor = rupeelb.BackColor = amountlb.BackColor = Editlb.BackColor = Deletelb.BackColor = editbt.BackColor = deletebt.BackColor = pback.BackColor = backcolor;
            }
        }

        public Transaction EditData
        {
            get => editdata;
            set
            {
                editdata = value;
                categorynamelb.Text = editdata.CategoryName;
                amountlb.Text = editdata.Amount.ToString();
                if ((Communicator.Manager.FetchCategoryName(editdata.CategoryId)).Type == true)
                {
                    rupeelb.ForeColor = amountlb.ForeColor = GUIStyles.incomeColor;
                }
                else
                {
                    rupeelb.ForeColor = amountlb.ForeColor = GUIStyles.expenseColor;
                }
                imglb.BackgroundImage = new Bitmap((Communicator.Manager.FetchCategoryName(EditData.CategoryId)).ImagePath);
            }
        }

        //Load Operation

        private void OnNameTransactionLoad(object sender, EventArgs e)
        {
            GUIStyles.ColorChanged += GUIStyles_ColorChanged;
        }

        private void GUIStyles_ColorChanged(bool e)
        {
            AddColor();
        }

        private void AddColor()
        {
            categorynamelb.ForeColor = GUIStyles.primaryColor;
        }

        //Button Click Events

        private void OnEditBtClick(object sender, EventArgs e)
        {
            ControlDisabled?.Invoke(this, true);
            EditTransaction et = new EditTransaction
            {
                EditData = editdata,
            };
            et.ShowDialog();
            if (et.done == true)
            {
                ControlChanged?.Invoke(this, true);
            }
            et.Dispose();
            ControlDisabled?.Invoke(this, false);
        }

        private void OnDeleteBtClick(object sender, EventArgs e)
        {
            ControlDisabled?.Invoke(this, true);
            Notification dv = new Notification();
            dv.ShowDialog();
            if (dv.yes == true)
            {
                DeleteTransaction();
            }
            dv.Dispose();
            ControlDisabled?.Invoke(this, false);
        }

        private void DeleteTransaction()
        {
            Transaction transaction = editdata;
            bool result = Communicator.Manager.RemoveData(transaction);//TransactionEditor.DeleteTransaction(transaction);
            if (result == true)
            {
                ControlChanged?.Invoke(this, true);
            }
        }

        //Mouse Enter Events
        
        private void OnEditBtMouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent();
            editbt.BackgroundImage = Image.FromFile(@".\Images\editwhite.png");
        }

        private void OnEditBtMouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent();
            editbt.BackgroundImage = Image.FromFile(@".\Images\editblack.png");
        }

        private void OnDeleteBtMouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent();
            deletebt.BackgroundImage = Image.FromFile(@".\Images\deletewhite.png");
        }

        private void OnDeleteBtMouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent();
            deletebt.BackgroundImage = Image.FromFile(@".\Images\deleteblack.png");
        }

        private void OnNameTransactionMouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent();
        }

        private void OnNameTransactionMouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent();
        }

        private void MouseEnterEvent()
        {
            Editlb.ForeColor = Deletelb.ForeColor = categorynamelb.ForeColor = GUIStyles.whiteColor;
            imglb.BackColor = categorynamelb.BackColor = rupeelb.BackColor = amountlb.BackColor = Editlb.BackColor = Deletelb.BackColor = editbt.BackColor = deletebt.BackColor = pback.BackColor = GUIStyles.terenaryColor;
        }

        private void MouseLeaveEvent()
        {
            if (backcolor != GUIStyles.terenaryColor)
            {
                Editlb.ForeColor = Deletelb.ForeColor = categorynamelb.ForeColor = GUIStyles.blackColor;
            }
            imglb.BackColor = categorynamelb.BackColor = rupeelb.BackColor = amountlb.BackColor = Editlb.BackColor = Deletelb.BackColor = editbt.BackColor = deletebt.BackColor = pback.BackColor = backcolor;
        }
    }
}
