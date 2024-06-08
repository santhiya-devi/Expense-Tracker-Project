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
    public partial class ViewCategory : UserControl
    {
        public ViewCategory()
        {
            InitializeComponent();
        }

        //Paint Operation

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(this, e, borderColor, backcolor, this.Width, this.Height, 7, 30);
        }

        //Event Creation

        public delegate void ControlDisable(object sender, bool disabled);
        public event ControlDisable ControlDisabled;
        public delegate void ControlChange(object sender, bool changed);
        public event ControlChange ControlChanged;

        //Variable Creation

        int lx = 0, ly = 0;
        float incomeamt = 0, expenseamt = 0;
        string catname;
        Color borderColor = GUIStyles.primaryColor;
        Color backcolor = GUIStyles.whiteColor;

        List<Transaction> listdata;
        List<ViewCategoryDate> lidate = new List<ViewCategoryDate>();
        bool controldeleted = false;
        Color selectedcolor = GUIStyles.whiteColor;

        //Propeties

        public Color SelectedColor
        {
            get => selectedcolor;
            set
            {
                selectedcolor = value;
                for (int i = 0; i < lidate.Count; i++)
                {
                    if (selectedcolor == GUIStyles.terenaryColor)
                        lidate[i].Backcolor = GUIStyles.terenaryColor;
                    else if (i % 2 != 0)
                        lidate[i].Backcolor = GUIStyles.whiteColor;
                    else
                        lidate[i].Backcolor = Color.WhiteSmoke;
                }
            }
        }

        public bool ControlDeleted
        {
            get => controldeleted;
            set
            {
                controldeleted = value;
                if (controldeleted == true)
                {
                    for (int j = 0; j < lidate.Count; j++)
                    {
                        lidate[j].Dispose();
                    }
                    lidate.Clear();
                }
            }
        }

        public List<Transaction> ListData
        {
            get => listdata;
            set
            {
                listdata = value;
                AddDataInLabel();
                categoryicon.BackgroundImage = new Bitmap((Communicator.Manager.FetchCategoryName(listdata[0].CategoryId)).ImagePath);
            }
        }

        //Load Operation

        private void OnViewCategoryLoad(object sender, EventArgs e)
        {
            AddColor();
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
            padd.Width = pbottom.Width * 90 / 100;
            padd.Height = pbottom.Height * 75 / 100;
            padd.Location = new Point(pbottom.Width / 2 - padd.Width / 2, pbottom.Height / 2 - padd.Height / 2);
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            AddColor();
        }

        private void AddColor()
        {
            Categorynamelb.ForeColor = GUIStyles.blackColor;
            transactioncountlb.ForeColor = Color.DimGray;
            if (GUIStyles.colorName == "red")
                rupeelb.ForeColor = amountlb.ForeColor = Color.Black; 
            else
                rupeelb.ForeColor = amountlb.ForeColor = GUIStyles.primaryColor;
        }

        private void OnPbottomScroll(object sender, ScrollEventArgs e)
        {
            Invalidate();
        }

        //Create Operation

        private void AddDataInLabel()
        {
            if (listdata != null)
            {
                lidate.Clear();
                padd.Controls.Clear();
                lx = 2; ly = 0; incomeamt = expenseamt = 0;
                for (int i = 0; i < listdata.Count; i++)
                {
                    ViewCategoryDate dc = new ViewCategoryDate
                    {
                        EditData = listdata[i],
                        Location = new Point(lx, ly)
                    };
                    if (i % 2 != 0)
                        dc.Backcolor = GUIStyles.whiteColor;
                    else
                        dc.Backcolor = Color.WhiteSmoke;
                    if (i >= 1)
                        this.Height = Height + 25 + 6;
                    dc.ControlChanged += OnDcControlChanged;
                    dc.ControlDisabled += OnDcControlDisabled;
                    padd.Controls.Add(dc);
                    lidate.Add(dc);
                    ly += dc.Height + 6;
                    if ((Communicator.Manager.FetchCategoryName(listdata[i].CategoryId)).Type == true)
                        incomeamt += listdata[i].Amount;
                    else
                        expenseamt += listdata[i].Amount;
                    catname = listdata[i].CategoryName;
                }
                amountlb.Text = (incomeamt - expenseamt).ToString();
                Categorynamelb.Text = "   " + catname.ToString();
                transactioncountlb.Text = "        (" + listdata.Count() + " Transactions)";
            }
        }

        //Dc Events

        private void OnDcControlDisabled(object sender, bool disabled)
        {
            if (disabled == true)
            {
                ControlDisabled?.Invoke(this, true);
            }
            else
            {
                ControlDisabled?.Invoke(this, false);
            }
        }

        private void OnDcControlChanged(object sender, bool changed)
        {
            if (changed == true)
            {
                ControlChanged?.Invoke(this, true);
            }
            else
            {
                ControlChanged?.Invoke(this, false);
            }
        }
    }
}
