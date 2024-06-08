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
    public partial class ViewIndividualTransaction : UserControl
    {
        public ViewIndividualTransaction()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        //Paint Events

        Color backcolor = GUIStyles.whiteColor;

        private void OnPaint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            TransactionEditor.PaintOperation(this, e, GUIStyles.primaryColor, backcolor, this.Width, this.Height, 7, 30);
        }


        //Event Creation

        public delegate void ControlDisable(object sender, bool disabled);
        public event ControlDisable ControlDisabled;
        public delegate void ControlChange(object sender, bool changed);
        public event ControlChange ControlChanged;

        // View Transaction Properties

        Transaction viewdata;

        public Color SelectedColor
        {
            get => backcolor;
            set
            {
                backcolor = value;
                if (backcolor == GUIStyles.whiteColor)
                {
                    editlb.ForeColor = deletelb.ForeColor = Categorynamelb.ForeColor = datelb.ForeColor = GUIStyles.blackColor; Descriptionlb.ForeColor = Color.DimGray;
                }
                else
                    editlb.ForeColor = deletelb.ForeColor = Categorynamelb.ForeColor = datelb.ForeColor = Descriptionlb.ForeColor = GUIStyles.whiteColor;
                Invalidate();
            }
        }

        public Transaction ViewData
        {
            get => viewdata;
            set
            {
                viewdata = value;
                Categorynamelb.Text = viewdata.CategoryName;
                Amountlb.Text = viewdata.Amount.ToString();
                datelb.Text = "   "+ viewdata.Date.ToLongDateString();
                Descriptionlb.Text = "   " + viewdata.Description;
                if ((Communicator.Manager.FetchCategoryName(viewdata.CategoryId)).Type == true)
                    rupeelb.ForeColor = Amountlb.ForeColor = GUIStyles.incomeColor;
                else
                    rupeelb.ForeColor = Amountlb.ForeColor = GUIStyles.expenseColor;
                categoryicon.BackgroundImage = new Bitmap((Communicator.Manager.FetchCategoryName(viewdata.CategoryId)).ImagePath);
            }
        }    

        //button Click Functions   

        private void OnEditBtClick(object sender, EventArgs e)
        {
            ControlDisabled?.Invoke(this, true);
            EditTransaction et = new EditTransaction
            {
                EditData=viewdata,
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

        // Delete Function

        private void DeleteTransaction()
        {
            bool result = Communicator.Manager.RemoveData(viewdata);
            if (result == true)
            {
                ControlChanged?.Invoke(this, true);
            }
        }

        //Load Operation

        private void OnViewIndividualLoad(object sender, EventArgs e)
        {
            Categorynamelb.ForeColor = editlb.ForeColor = deletelb.ForeColor = datelb.ForeColor = GUIStyles.blackColor; Descriptionlb.ForeColor = Color.DimGray;
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            Categorynamelb.ForeColor = editlb.ForeColor = deletelb.ForeColor = datelb.ForeColor = GUIStyles.blackColor; Descriptionlb.ForeColor = Color.DimGray;
        }

        //Mouse Enter Events

        private void OnEditBtMouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent();
            Editbt.BackgroundImage = Image.FromFile(@".\Images\editwhite.png");
        }

        private void OnEditBtMouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent();
            Editbt.BackgroundImage = Image.FromFile(@".\Images\editblack.png");
        }

        private void OnDeleteBtMouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent();
            Deletebt.BackgroundImage = Image.FromFile(@".\Images\deletewhite.png");
        }

        private void OnDeleteBtMouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent();
            Deletebt.BackgroundImage = Image.FromFile(@".\Images\deleteblack.png");
        }

        private void OnViewIndividualMouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent();
        }

        private void OnViewIndividualMouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent();
        }

        private void MouseEnterEvent()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            backcolor = GUIStyles.terenaryColor;
            editlb.ForeColor = deletelb.ForeColor = Categorynamelb.ForeColor = datelb.ForeColor = Descriptionlb.ForeColor = GUIStyles.whiteColor;
            Invalidate();
        }

        private void MouseLeaveEvent()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            backcolor = GUIStyles.whiteColor;
            editlb.ForeColor = deletelb.ForeColor = Categorynamelb.ForeColor = datelb.ForeColor = GUIStyles.blackColor; Descriptionlb.ForeColor = Color.DimGray;
            Invalidate();
        }
    }
}
