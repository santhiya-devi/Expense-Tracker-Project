﻿using System;
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
    public partial class ViewTransaction : UserControl
    {
        public ViewTransaction()
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

        //Variable Declarations

        Color borderColor = GUIStyles.primaryColor, backcolor = GUIStyles.whiteColor;
        List<Transaction> listdata;
        List<ViewTransactionName> liname = new List<ViewTransactionName>();
        bool controldeleted = false;
        int lx = 0, ly = 0;
        float incomeamt = 0, expenseamt = 0;
        DateTime date;
        string type, selectedcategory = "Gas Bill";

        //Properties

        public string Type
        {
            get => type;
            set
            {
                type = value;
            }
        }

        public string SelectedCategory
        {
            get => selectedcategory;
            set
            {
                selectedcategory = value;
                for (int i = 0; i < liname.Count; i++)
                {
                    if (selectedcategory.Length>0 && selectedcategory == liname[i].EditData.CategoryName)
                        liname[i].Backcolor = GUIStyles.terenaryColor;
                    else if (i % 2 != 0)
                        liname[i].Backcolor = GUIStyles.whiteColor;
                    else
                        liname[i].Backcolor = Color.WhiteSmoke;
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
                    for (int j = 0; j < liname.Count; j++)
                    {
                        liname[j].Dispose();
                    }
                    liname.Clear();
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
            }
        }            

        //View Transaction Load

        private void OnViewTransactionLoad(object sender, EventArgs e)
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
            datelb.ForeColor = daylb.ForeColor = monthlb.ForeColor = GUIStyles.blackColor;
            if (GUIStyles.colorName == "red")
                rupeelb.ForeColor = amountlb.ForeColor = Color.Black;
            else
                rupeelb.ForeColor = amountlb.ForeColor = GUIStyles.primaryColor;
        }

        //Main Operation

        private void AddDataInLabel()
        {
            if (listdata != null)
            {
                liname.Clear();
                padd.Controls.Clear();
                lx = 2; ly = 0; incomeamt = expenseamt = 0;
                for (int i = 0; i < listdata.Count; i++)
                {
                    ViewTransactionName nt = new ViewTransactionName
                    {
                        EditData = listdata[i],
                        Location = new Point(lx, ly)
                    };
                    if (i % 2 != 0)
                        nt.Backcolor = GUIStyles.whiteColor;
                    else
                        nt.Backcolor = Color.WhiteSmoke;
                    if (i >= 1)
                        this.Height = Height + 25 + 6;
                    nt.ControlChanged += OnNtControlChanged;
                    nt.ControlDisabled += OnNtControlDisabled;
                    padd.Controls.Add(nt);
                    liname.Add(nt);
                    ly += nt.Height + 6;
                    if ((Communicator.Manager.FetchCategoryName(listdata[i].CategoryId)).Type == true)
                        incomeamt += listdata[i].Amount;
                    else
                        expenseamt += listdata[i].Amount;
                    date = listdata[i].Date;
                }
                amountlb.Text = (incomeamt-expenseamt).ToString();
                if (type == "day")
                {
                    datelb.Text = "   " + date.ToString("dd");
                    daylb.Text = date.DayOfWeek.ToString();
                    monthlb.Text = " " + FindMonth(date.Month) + ",  " + date.Year.ToString();
                }
                else
                {
                    if (date.Month.ToString().Length == 1)
                        datelb.Text = "   0" + date.Month;
                    else
                        datelb.Text = "   " + date.Month;
                    daylb.Text = FindMonth(date.Month);
                    monthlb.Text = " " + date.Year.ToString();
                }
            }
        }

        private string FindMonth(int mon)
        {
            string month = "";
            if (mon == 1)
                month = "January";
            else if (mon == 2)
                month = "February";
            else if (mon == 3)
                month = "March";
            else if (mon == 4)
                month = "April";
            else if (mon == 5)
                month = "May";
            else if (mon == 6)
                month = "June";
            else if (mon == 7)
                month = "July";
            else if (mon == 8)
                month = "August";
            else if (mon == 9)
                month = "September";
            else if (mon == 10)
                month = "October";
            else if (mon == 11)
                month = "November";
            else if (mon == 12)
                month = "December";
            return month;
        }

        //Dc Events  

        private void OnNtControlDisabled(object sender, bool disabled)
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

        private void OnNtControlChanged(object sender, bool changed)
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
