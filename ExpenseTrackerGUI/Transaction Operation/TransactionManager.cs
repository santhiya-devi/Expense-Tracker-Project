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
    public partial class TransactionManager : UserControl
    {
        public TransactionManager()
        {
            InitializeComponent();
            CreateView();
        }

        #region Panel Paint Events 

        private void OnPresultPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, bordercolor, GUIStyles.backColor, presult.Width, presult.Height, 10, 10);
        }

        private void OnPnchoosePaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, bordercolor, GUIStyles.cardColor, pnchoose.Width, pnchoose.Height, 10, 10);
        }

        private void OnPselectbtPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.whiteColor, sbackcolor, selectbt.Width, selectbt.Height, 8, 10);
        }

        private void OnCategoryNamePaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.whiteColor, GUIStyles.backColor, pcategoryname.Width, pcategoryname.Height, 8, 10);
        }

        #endregion

        #region Button Paint Events

        private void OnbtPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintButtonOperation(sender, e, bt1.Width, bt1.Height);
        }

        private void OnCustomPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintButtonOperation(sender, e, pcustom.Width, pcustom.Height);
        }

        #endregion

        #region Object Creation

        WalletView wallet = new WalletView();
        SelectDate selectdate = new SelectDate();
        SelectCategory selectcategory = new SelectCategory();

        #endregion

        #region Input Data to View Transaction

        Color incomebackcolor = GUIStyles.backColor, expensebackcolor = GUIStyles.backColor, sbackcolor = GUIStyles.cardColor, bordercolor = GUIStyles.primaryColor;
        int presentdate = 5, locy = 20, locx = 0, lcy = 10, lcx = 0, index = 0, vtWidth, vtheight, walletid = 0, time = 0, timescroll = 0;
        bool isload = false;
        DateTime startdate, enddate;
        float tincome = 0, texpense = 0;
        string selecttype;
        List<ViewIndividualTransaction> liviewIndividual = new List<ViewIndividualTransaction>();
        List<ViewTransaction> liviewtransac = new List<ViewTransaction>();
        List<ViewCategory> liviewcat = new List<ViewCategory>();
        List<Transaction> liall = new List<Transaction>();
        List<int> cattransloc = new List<int>();
        Dictionary<String, int> expenseli = new Dictionary<string, int>();
        Dictionary<String, int> incomeli = new Dictionary<string, int>();

        #endregion

        #region ViewIndividualTransaction

        public void CreateView()
        {
            for (int i = 0; i < 5; i++)
            {
                ViewIndividualTransaction vt = new ViewIndividualTransaction
                {
                    Location = new Point(locx, locy)
                };
                vt.ControlDisabled += OnControlDisabled;
                vt.ControlChanged += OnControlChanged;
                Pview.Controls.Add(vt);
                liviewIndividual.Add(vt);
                locy += vt.Height + 18;
                vtWidth = vt.Width; vtheight = vt.Height;
            }
        }

        public void ShowIndividualTransaction(List<Transaction> li)
        {
            pscroll.Visible = true;
            DisposeControl();
            liviewcat.Clear(); liviewtransac.Clear();
            pviewcategory.Visible = Pview.Visible = padown.Visible = paup.Visible = false;
            pnodata.Visible = true;
            liall.Clear(); index = 0;
            liall = new List<Transaction>(li);
            expenseli.Clear(); incomeli.Clear();
            tincome = 0; texpense = 0; index = 0;
            CheckIncomeExpense(li);
            for (int i = 0; i < liviewIndividual.Count; i++)
            {
                liviewIndividual[i].Visible = false;
            }
            if (liall.Count <= 5 && liall.Count > 0)
            {
                Pview.Visible = true;
                for (int i = 0; i < liall.Count; i++)
                {
                    liviewIndividual[i].Visible = true;
                    liviewIndividual[i].SelectedColor = GUIStyles.whiteColor;
                    liviewIndividual[i].ViewData = liall[i];
                }
            }
            else if (liall.Count > 5)
            {
                Pview.Visible = padown.Visible = true;
                ShowDataIndividualTransac();
                pshow.MouseWheel += OnPviewMouseWheel;
            }
            IncomeExpenseDetails();
        }

        private void ShowDataIndividualTransac()
        {
            int i = 0;
            for (int j = index; j < index + 5; j++)
            {
                liviewIndividual[i].Visible = true;
                liviewIndividual[i].SelectedColor = GUIStyles.whiteColor;
                liviewIndividual[i].ViewData = liall[j];
                i++;
            }
            if (index == 0)
            {
                padown.Visible = true;
                paup.Visible = false;
            }
            else if (index > 0 || index < liall.Count - 5)
            {
                padown.Visible = true;
                paup.Visible = true;
            }
            else if (index == liall.Count - 5)
            {
                padown.Visible = false;
                paup.Visible = true;
            }
            else
            {
                padown.Visible = true;
                paup.Visible = false;
            }
        }

        #endregion

        #region ViewCategory

        private void ShowCategory(Dictionary<String, List<Transaction>> dicat)
        {
            padown.Visible = paup.Visible = false;
            DisposeControl();
            cattransloc.Clear(); liviewtransac.Clear(); liviewcat.Clear();
            expenseli.Clear(); incomeli.Clear();
            tincome = 0; texpense = 0; lcy = 10; index = 0;
            Pview.Visible = padown.Visible = paup.Visible = pnodata.Visible = false;
            if (dicat.Count == 0)
            {
                pnodata.Visible = true;
            }
            else
            {
                pviewcategory.Visible = true; pnodata.Visible = false;
                for (int i = 0; i < dicat.Count; i++)
                {
                    CheckIncomeExpense(dicat.ElementAt(i).Value);
                    AssignValueCat(i, dicat);
                }
            }
            IncomeExpenseDetails();
        }

        private void AssignValueCat(int j, Dictionary<String, List<Transaction>> dicat)
        {
            if (dicat.ElementAt(j).Value.Count > 0)
            {
                ViewCategory vc = new ViewCategory
                {
                    ListData = dicat.ElementAt(j).Value,
                    Location = new Point(lcx, lcy)
                };
                vc.ControlChanged += OnControlChanged;
                vc.ControlDisabled += OnControlDisabled;
                pviewcategory.Controls.Add(vc);
                cattransloc.Add(vc.Location.Y);
                liviewcat.Add(vc);
                lcy += vc.Height + 10;
            }
        }

        #endregion

        #region ViewTransaction

        private void ShowTransaction(Dictionary<DateTime, List<Transaction>> ditransac)
        {
            if (!(selecttype == "View by Day" || selecttype == "View by Week" || selecttype == "View by Month"))
            {
                Dictionary<string, List<Transaction>> ditransacnew = CheckTransaction(ditransac);
                ditransac.Clear();
                for (int i = 0; i < ditransacnew.Count; i++)
                {
                    DateTime dt = DateTime.Parse("01-" + ditransacnew.ElementAt(i).Key);
                    ditransac.Add(dt, ditransacnew.ElementAt(i).Value);
                }
            }
            padown.Visible = paup.Visible = false;
            DisposeControl();
            cattransloc.Clear(); liviewcat.Clear(); liviewtransac.Clear();
            expenseli.Clear(); incomeli.Clear();
            tincome = 0; texpense = 0; lcy = 10; index = 0;
            Pview.Visible = padown.Visible = paup.Visible = false;
            if (ditransac.Count == 0)
            {
                pnodata.Visible = true;
            }
            else
            {
                pviewcategory.Visible = true; pnodata.Visible = false;
                for (int i = 0; i < ditransac.Count; i++)
                {
                    CheckIncomeExpense(ditransac.ElementAt(i).Value);
                    AssignValueTransac(i, ditransac);
                }
            }
            IncomeExpenseDetails();
        }

        private Dictionary<string, List<Transaction>> CheckTransaction(Dictionary<DateTime, List<Transaction>> ditransac)
        {
            Dictionary<string, List<Transaction>> ditransacnew = new Dictionary<string, List<Transaction>>();
            for (int i = 0; i < ditransac.Count; i++)
            {
                string date = ditransac.ElementAt(i).Key.ToString("MM/yyyy");
                if (ditransacnew.ContainsKey(date))
                {
                    List<Transaction> linew = new List<Transaction>(ditransacnew[date]);

                    for (int j = 0; j < ditransac.ElementAt(i).Value.Count; j++)
                    {
                        linew.Add(ditransac.ElementAt(i).Value[j]);
                    }
                    ditransacnew[date] = linew;
                }
                else
                {
                    ditransacnew.Add(date, ditransac.ElementAt(i).Value);
                }
            }
            return ditransacnew;
        }

        private void AssignValueTransac(int j, Dictionary<DateTime, List<Transaction>> ditransac)
        {
            if (ditransac.ElementAt(j).Value.Count > 0)
            {
                ViewTransaction vt = new ViewTransaction
                {
                    Location = new Point(lcx, lcy)
                };
                if (selecttype == "View by Day" || selecttype == "View by Week" || selecttype == "View by Month")
                {
                    vt.Type = "day";
                    vt.ListData = ditransac.ElementAt(j).Value;
                }
                else
                {
                    vt.Type = "month";
                    vt.ListData = ditransac.ElementAt(j).Value;
                }
                vt.ControlChanged += OnControlChanged;
                vt.ControlDisabled += OnControlDisabled;
                pviewcategory.Controls.Add(vt);
                cattransloc.Add(vt.Location.Y);
                liviewtransac.Add(vt);
                lcy += vt.Height + 10;
            }
        }

        #endregion

        #region Mouse Scroll Events

        private void OnTimerScrollStart(object sender, EventArgs e)
        {
            timescroll++;
            if (timescroll == 1)
            {
                timescroll = 0;
                TimerScroll.Stop();
            }
        }

        private void OnPviewMouseWheel(object sender, MouseEventArgs e)
        {
            if (timescroll == 0)
            {
                TimerScroll.Start();
                if (pviewcategory.Visible == false && liall.Count > 5)
                {
                    if (e.Delta > 0)
                    {
                        UpClick();
                    }
                    else
                    {
                        DownClick();
                    }
                }

            }
            return;
        }

        private void UpClick()
        {
            if (index - 1 > 0)
            {
                index--;
                ShowDataIndividualTransac();
                padown.Visible = true;
                paup.Visible = true;
            }
            else if (index - 1 == 0)
            {
                index--;
                ShowDataIndividualTransac();
                padown.Visible = true;
                paup.Visible = false;
            }
            else
            {
                padown.Visible = true;
                paup.Visible = false;
            }
        }

        private void DownClick()
        {
            if (index + 1 < liall.Count - 5)
            {
                index++;
                ShowDataIndividualTransac();
                padown.Visible = true;
                paup.Visible = true;
            }
            else if (index + 1 == liall.Count - 5)
            {
                index++;
                ShowDataIndividualTransac();
                padown.Visible = false;
                paup.Visible = true;
            }
            else
            {
                padown.Visible = false;
                paup.Visible = true;
            }
        }

        private void OnPbUpClick(object sender, EventArgs e)
        {
            UpClick();
        }

        private void OnPbDownClick(object sender, EventArgs e)
        {
            DownClick();
        }

        #endregion

        #region Common Functions for transaction and category        

        private void OnControlDisabled(object sender, bool disabled)
        {
            if (disabled == true)
            {
                loadprocess.Visible = false;
                pload.Visible = true; pback.Visible = false;
                pback.Enabled = false;
            }
            else
            {
                pback.Enabled = true;
                pback.Visible = true; pload.Visible = false;
                loadprocess.Visible = true;
            }
        }

        private void OnControlChanged(object sender, bool changed)
        {
            RefreshTransactionManager();
        }

        private void DisposeControl()
        {
            for (int i = 0; i < liviewtransac.Count; i++)
            {
                liviewtransac[i].ControlDeleted = true;
                liviewtransac[i].Dispose();
            }
            for (int i = 0; i < liviewcat.Count; i++)
            {
                liviewcat[i].ControlDeleted = true;
                liviewcat[i].Dispose();
            }
        }

        private void IncomeExpenseDetails()
        {
            ExpenseBox.Dic = expenseli;
            IncomeBox.Dic = incomeli;
            incomeamt.Text = "₹  " + tincome.ToString();
            expenseamt.Text = "₹  " + texpense.ToString();
            totalamt.Text = "₹  " + (tincome - texpense).ToString();
        }

        private void OnIncomeIndexSelected(object sender, string e)
        {
            ExpenseBox.IndexDeselect = true;
            if (pviewcategory.Visible == false)
            {
                IndividualSelect(e);
            }
            else if (liviewcat.Count > 0)
            {
                CategorySelect(e);
            }
            else if (liviewtransac.Count > 0)
            {
                TransactionSelect(e);
            }
        }

        private void OnExpenseIndexSelected(object sender, string e)
        {
            IncomeBox.IndexDeselect = true;
            if (pviewcategory.Visible == false)
            {
                IndividualSelect(e);
            }
            else if (liviewcat.Count > 0)
            {
                CategorySelect(e);
            }
            else if (liviewtransac.Count > 0)
            {
                TransactionSelect(e);
            }
        }

        private void IndividualSelect(string val)
        {
            bool find = false;
            for (int j = 0; j < liall.Count; j++)
            {
                if (liall[j].CategoryName == val)
                {
                    if (liall.Count <= 5)
                    {
                        ;
                    }
                    else if (j < liall.Count - 5)
                    {
                        index = j;
                        ShowDataIndividualTransac();
                    }
                    else
                    {
                        index = liall.Count - 5;
                        ShowDataIndividualTransac();
                    }
                    for (int k = 0; k < liviewIndividual.Count; k++)
                    {
                        if (liviewIndividual[k].Visible == true && liviewIndividual[k].ViewData.CategoryName == val)
                        {
                            liviewIndividual[k].SelectedColor = GUIStyles.terenaryColor;
                            find = true;
                        }
                        else if (liviewIndividual[k].Visible == true)
                            liviewIndividual[k].SelectedColor = GUIStyles.whiteColor;
                    }
                }
                if (find == true) break;
            }
        }

        private void CategorySelect(string val)
        {
            int ly = 0;
            for (int j = 0; j < liviewcat.Count; j++)
            {
                ly = liviewcat[liviewcat.Count - 1].Location.Y + liviewcat[liviewcat.Count - 1].Height;
                if (liviewcat[j].ListData[0].CategoryName == val)
                {
                    int ab = cattransloc[j];
                    liviewcat[j].SelectedColor = GUIStyles.terenaryColor;
                    if (liviewcat[j].Location.Y >= ly - 640)
                    {
                        pviewcategory.VerticalScroll.Value = pviewcategory.VerticalScroll.Maximum;
                    }
                    else
                    {
                        pviewcategory.AutoScrollPosition = new Point(liviewcat[j].Location.X, ab);
                    }
                }
                else
                    liviewcat[j].SelectedColor = GUIStyles.whiteColor;
            }
        }

        private void TransactionSelect(string val)
        {
            int ly = 0;
            for (int j = 0; j < liviewtransac.Count; j++)
            {
                for (int k = 0; k < liviewtransac[j].ListData.Count; k++)
                {
                    ly = liviewtransac[liviewtransac.Count - 1].Location.Y + liviewtransac[liviewtransac.Count - 1].Height;
                    if (liviewtransac[j].ListData[k].CategoryName == val)
                    {
                        int ab = cattransloc[j];
                        liviewtransac[j].SelectedCategory = val;
                        if (liviewtransac[j].Location.Y >= ly - 640)
                        {
                            pviewcategory.VerticalScroll.Value = pviewcategory.VerticalScroll.Maximum;
                        }
                        else
                        {
                            pviewcategory.AutoScrollPosition = new Point(liviewtransac[j].Location.X, ab);
                        }
                        break;
                    }
                    else
                        liviewtransac[j].SelectedCategory = "";
                }
            }
        }

        private void CheckIncomeExpense(List<Transaction> transac)
        {
            for (int i = 0; i < transac.Count; i++)
            {
                if (Communicator.Manager.FetchCategoryName(transac[i].CategoryId).Type == false)
                {
                    if (expenseli.ContainsKey(transac[i].CategoryName))
                    {
                        expenseli[transac[i].CategoryName]++;
                    }
                    else
                    {
                        expenseli.Add(transac[i].CategoryName, 1);
                    }
                    texpense += transac[i].Amount;
                }
                else
                {
                    if (incomeli.ContainsKey(transac[i].CategoryName))
                    {
                        incomeli[transac[i].CategoryName]++;
                    }
                    else
                    {
                        incomeli.Add(transac[i].CategoryName, 1);
                    }
                    tincome += transac[i].Amount;
                }
            }
        }

        #endregion

        #region Transaction Manager Load

        private void OnTransactionManagerLoad(object sender, EventArgs e)
        {
            selectcategory.Dock = DockStyle.Fill;
            pselectcategorytransaction.Controls.Add(selectcategory);
            pselectcategorytransaction.Visible = false;
            selectdate.Dock = DockStyle.Fill;
            pselectviewtype.Controls.Add(selectdate);
            pselectviewtype.Visible = false;
            pload.Dock = DockStyle.Fill;
            Plast.Controls.Add(pload);
            pload.Visible = true;
            wallet.AddMode = false;
            pselectwallet.Controls.Add(wallet);
            wallet.Dock = DockStyle.Fill;
            pselectwallet.Visible = false;
            walletnamelb.Text = "Total";
            pcustom.BringToFront();
            AddOptions();
            presentdate = TransactionEditor.viewday.Count - 3;
            bt1.BackColor = bt3.BackColor = GUIStyles.whiteColor; bt1.ForeColor = bt3.ForeColor = GUIStyles.blackColor;
            bt2.BackColor = GUIStyles.secondaryColor; bt2.ForeColor = GUIStyles.whiteColor;
            OnSelectcategoryTypeSelected(this, "View Individual Transaction");
            isload = true;
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
            if (!DesignMode)
            {
                ExpenseBox.Hname = "Expense";
                IncomeBox.Hname = "Income";
                ExpenseBox.IndexSelected += OnExpenseIndexSelected;
                IncomeBox.IndexSelected += OnIncomeIndexSelected;
            }
        }

        private void OnLoadTimer(object sender, EventArgs e)
        {
            ActiveControl = null;
            time++;
            if (time == 1)
            {
                pback.Visible = true;
                pload.Visible = false;
                loadprocess.Timerload = false;
                time = 0;
                TimerLoad.Stop();
            }
        }

        private void RefreshTransactionManager()
        {
            if (cdaylb.Text == "View All")
            {
                OnSelectdateDaySelected(this, "View All");
            }
            else if (cdaylb.Text == "Custom")
            {
                OnDoneBtClick(this, EventArgs.Empty);
            }
            else
            {
                FindData();
            }
        }

        private void OnTransactionHistoryVisibilityChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                return;
            }
            if (!DesignMode)
            {
                pload.Visible = true;
                if (isload == true)
                {
                    pselectcategorytransaction.Visible = pselectviewtype.Visible = pselectwallet.Visible = false;
                    pcday.Enabled = pcindividual.Enabled = true;
                    pnchoose.Enabled = pshow.Enabled = poption.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = true;
                    pcategoryname.Visible = false;
                    AddColor();
                    walletid = 0;
                    walletnamelb.Text = "Total";
                    presentdate = TransactionEditor.viewday.Count - 3;
                    bt1.BackColor = bt3.BackColor = bt2.ForeColor = GUIStyles.whiteColor;
                    bt2.BackColor = GUIStyles.secondaryColor;
                    bt1.ForeColor = bt3.ForeColor = GUIStyles.blackColor; 
                    cdaylb.Text = "View by Day";
                    cindividuallb.Text = "View Individual Transaction";
                    OnSelectdateDaySelected(sender, "View by Day");
                }
            }
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            selectcategory.ColorChanged = selectdate.ColorChanged = true;
            IncomeBox.ColorChanged = ExpenseBox.ColorChanged = true;
            AddColor(); ChangeImage();
        }

        private void AddColor()
        {
            incomebackcolor = expensebackcolor = GUIStyles.backColor; sbackcolor = GUIStyles.cardColor; 
            presult.Invalidate(); bt1.Invalidate(); bt2.Invalidate(); bt3.Invalidate(); pcustom.Invalidate();
            pcategoryname.Invalidate(); pnchoose.Invalidate(); pselectbt.Invalidate();
            categorynamelb.ForeColor = bordercolor = prevenuehead.BackColor = GUIStyles.primaryColor;
            pback.BackColor = pload.BackColor = donebt.BackColor = GUIStyles.whiteColor;
            donebt.FlatAppearance.MouseOverBackColor = selectwalletbt.BackColor = cselectdatebt.BackColor = cselecttypebt.BackColor = GUIStyles.cardColor;
            bt2.BackColor = selectwalletbt.FlatAppearance.MouseOverBackColor = cselecttypebt.FlatAppearance.MouseOverBackColor = cselectdatebt.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            donebt.FlatAppearance.MouseDownBackColor = selectwalletbt.FlatAppearance.MouseDownBackColor = cselecttypebt.FlatAppearance.MouseDownBackColor = cselectdatebt.FlatAppearance.MouseDownBackColor = GUIStyles.backColor;
            pwalletup.BackColor = pcindividual.BackColor = pcday.BackColor = GUIStyles.cardColor;
            pselectviewtype.BackColor = pselectcategorytransaction.BackColor = pcustom.BackColor = GUIStyles.backColor;
            backbt.ForeColor = prevenue.BackColor = pviewtransaction.BackColor = GUIStyles.primaryColor;
            cindividuallb.ForeColor = cdaylb.ForeColor = incomelb.ForeColor = expenselb.ForeColor = totalamt.ForeColor = GUIStyles.blackColor;
            startdatelb.ForeColor = enddatelb.ForeColor = Messagelb.ForeColor = walletnamelb.ForeColor = GUIStyles.blackColor;
        }

        private void ChangeImage()
        {
            if (GUIStyles.colorName == "blue")
            {
                walletpb.BackgroundImage = Image.FromFile(@".\Images\walletblue.png");
                cindividualpb.BackgroundImage = Image.FromFile(@".\Images\categoryblue.png");
                cdaypb.BackgroundImage = Image.FromFile(@".\Images\dayblue.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                walletpb.BackgroundImage = Image.FromFile(@".\Images\walletred.png");
                cindividualpb.BackgroundImage = Image.FromFile(@".\Images\categoryred.png");
                cdaypb.BackgroundImage = Image.FromFile(@".\Images\dayred.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                walletpb.BackgroundImage = Image.FromFile(@".\Images\walletorange.png");
                cindividualpb.BackgroundImage = Image.FromFile(@".\Images\categoryorange.png");
                cdaypb.BackgroundImage = Image.FromFile(@".\Images\dayorange.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                walletpb.BackgroundImage = Image.FromFile(@".\Images\walletpink.png");
                cindividualpb.BackgroundImage = Image.FromFile(@".\Images\categorypink.png");
                cdaypb.BackgroundImage = Image.FromFile(@".\Images\daypink.png");
            }
            else
            {
                walletpb.BackgroundImage = Image.FromFile(@".\Images\walletblack.png");
                cindividualpb.BackgroundImage = Image.FromFile(@".\Images\categoryblack.png");
                cdaypb.BackgroundImage = Image.FromFile(@".\Images\dayblack.png");
            }
        }

        private void AddOptions()
        {
            TransactionEditor.AddDay();
            TransactionEditor.AddWeek();
            TransactionEditor.AddMonth();
            TransactionEditor.AddQuarter();
            TransactionEditor.AddYear();
        }

        #endregion

        #region Transaction Manager Resize

        private void OnTRansactionManagerResize(object sender, EventArgs e)
        {
            AdjustSize();
        }

        private void AdjustSize()
        {
            pbutton.Width = poption.Width * 50 / 100;
            bt3.Width = pbutton.Width * 30 / 100;
            bt1.Width = pbutton.Width * 30 / 100; pm1.Width = pbutton.Width * 5 / 100;
            bt2.Width = pbutton.Width * 30 / 100; pm2.Width = pbutton.Width * 5 / 100;
            pshow.Width = vtWidth + 50;
            pshow.Height = vtheight * 5 + 140;
            pbutton.Location = new Point((poption.Width / 2 - pbutton.Width / 2) + 80);
            pnchoose.Location = new Point(pback.Width - pnchoose.Width - 10, 10);
            pselectcategorytransaction.Size = new Size(273, 107);
            pselectcategorytransaction.Location = new Point(pback.Width - pselectcategorytransaction.Width - 20, pnchoose.Height - 32);
            pselectviewtype.Size = new Size(273, 247);
            pselectviewtype.Location = new Point(pback.Width - pselectviewtype.Width - 20, pnchoose.Height + 5);
            pcustom.Location = new Point(pback.Width - pcustom.Width - 4, pnchoose.Location.Y + pnchoose.Height + 10);
            prevenue.Location = new Point(presult.Width / 5, 80);
            ExpenseBox.Location = new Point(presult.Width / 5, prevenue.Location.Y + prevenue.Height + 50);
            IncomeBox.Location = new Point(presult.Width / 5, ExpenseBox.Location.Y + ExpenseBox.Height + 50);
            pshow.Location = new Point(pbutton.Location.X + 5, pdown.Height / 2 - pshow.Height / 2 + 30);
            pcategoryname.Location = new Point((pshow.Location.X) + pshow.Width / 2 - pcategoryname.Width / 2, pshow.Location.Y - pcategoryname.Height - 30);
            pselectwallet.Size = new Size(475, 502);
            pselectwallet.Location = new Point(34, 5);
            nodatalb1.Height = pshow.Height / 2;
            nodatalb2.Height = pshow.Height / 2;
        }

        #endregion

        #region Date Changed & Visibility Change

        private void OnStartDateValueChanged(object sender, EventArgs e)
        {
            if (startpicker.Value > endpicker.Value)
            {
                endpicker.Value = startpicker.Value.AddDays(1);
            }
        }

        private void OnEndDateValueChanged(object sender, EventArgs e)
        {
            if (startpicker.Value > endpicker.Value)
            {
                startpicker.Value = endpicker.Value.AddDays(-1);
            }
        }

        #endregion

        #region Wallet , Custom and Category Selection

        private void OnSelectWalletbtClick(object sender, EventArgs e)
        {
            Pview.Visible = pviewcategory.Visible = false;
            pnodata.Visible = true;
            pnchoose.Enabled = pshow.Enabled = poption.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = false;
            pselectwallet.BringToFront();
            pselectwallet.Visible = true;
            wallet.WalletSelect += OnWalletSelect;
            wallet.WalletClose += OnWalletClose;
        }

        private void OnWalletSelect(Image image, Wallet e)
        {
            loadprocess.Timerload = true;
            pload.Visible = true; pback.Visible = false;
            TimerLoad.Start();
            walletnamelb.Text = e.WalletName;
            if (walletid != e.WalletID)
            {
                walletid = e.WalletID;
            }
            RefreshTransactionManager();
            pselectwallet.Visible = false;
            pnchoose.Enabled = pshow.Enabled = poption.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = true;
            wallet.WalletSelect -= OnWalletSelect;
        }

        private void OnWalletClose(object sender, EventArgs e)
        {
            loadprocess.Timerload = true;
            pload.Visible = true; pback.Visible = false;
            TimerLoad.Start();
            pselectwallet.Visible = false;
            pnchoose.Enabled = pshow.Enabled = poption.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = true;
            RefreshTransactionManager();
            wallet.WalletClose -= OnWalletClose;
        }

        private void OnSelectCLick(object sender, EventArgs e)
        {
            if (pnchoose.Visible == true)
            {
                lpchoose.Visible = pnchoose.Visible = false;
            }
            else
            {
                lpchoose.Visible = pnchoose.Visible = true;
            }
        }

        private void OnDoneBtClick(object sender, EventArgs e)
        {
            loadprocess.Timerload = true;
            pload.Visible = true; pback.Visible = false;
            TimerLoad.Start();
            Pview.Visible = pviewcategory.Visible = true;
            pbutton.Enabled = false;
            pcindividual.Enabled = poption.Enabled = pshow.Enabled = true;
            pselectviewtype.Visible = false;
            pcday.Enabled = pcindividual.Enabled = true;
            startdate = startpicker.Value;
            enddate = endpicker.Value;
            if (enddate >= startdate)
            {
                pcategoryname.Visible = true;
                categorynamelb.Text = startdate.ToString("dd") + "/" + startdate.ToString("MM") + "/" + startdate.ToString("yyyy") + " - " + enddate.ToString("dd") + "/" + enddate.ToString("MM") + "/" + enddate.ToString("yyyy");
                pcustom.Visible = false;
                pshow.Enabled = poption.Enabled = pnchoose.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = true;
                if (cindividuallb.Text == "View by Category")
                {
                    Dictionary<string, List<Transaction>> licustom = Communicator.Manager.FetchTransactionOnDates<Dictionary<string, List<Transaction>>>(startdate, enddate, Manager.ViewType.Custom, walletid);
                    ShowCategory(licustom);
                }
                else if (cindividuallb.Text == "View Individual Transaction")
                {
                    List<Transaction> licustom = Communicator.Manager.FetchTransactionOnDates<List<Transaction>>(startdate, enddate, Manager.ViewType.Custom, walletid);
                    ShowIndividualTransaction(licustom);
                }
                else
                {
                    Dictionary<DateTime, List<Transaction>> licustom = Communicator.Manager.FetchTransactionOnDates<Dictionary<DateTime, List<Transaction>>>(startdate, enddate, Manager.ViewType.Custom, walletid);
                    ShowTransaction(licustom);
                }
            }
            else
            {
                Messagelb.Visible = true;
            }
        }

        private void OnBackBtClick(object sender, EventArgs e)
        {
            RefreshTransactionManager();
            pcustom.Visible = false;
            pcday.Enabled = pcindividual.Enabled = pshow.Enabled = poption.Enabled = pnchoose.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = true;
        }
        #endregion

        #region Button select (view by date)

        private void OnSelectDatebtClick(object sender, EventArgs e)
        {
            if (pselectviewtype.Visible == false)
            {
                pscroll.Visible = Pview.Visible = pviewcategory.Visible = false;
                pnodata.Visible = true;
                prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = false;
                pbutton.Enabled = pcindividual.Enabled = pcustom.Visible = poption.Enabled = pshow.Enabled = pcategoryname.Visible = false;
                pselectviewtype.BringToFront();
                pselectviewtype.Visible = true;
                selectdate.DaySelected += OnSelectdateDaySelected;
            }
            else
            {
                pscroll.Visible = prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = true;
                pbutton.Enabled = pcindividual.Enabled = poption.Enabled = pshow.Enabled = true;
                pselectviewtype.Visible = false;
                RefreshTransactionManager();
            }
        }

        private void OnSelectdateDaySelected(object sender, string e)
        {
            selecttype = e;
            if (e == "Custom")
            {
                bt1.BackColor = bt2.BackColor = bt3.BackColor = GUIStyles.whiteColor;
                bt1.ForeColor = bt2.ForeColor = bt3.ForeColor = GUIStyles.blackColor;
                cdaylb.Text = e;
                startpicker.Value = DateTime.Now.AddDays(-1);
                pshow.Enabled = poption.Enabled = pnchoose.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = prevenue.Enabled = pselectviewtype.Visible = false;
                pcustom.Visible = true;
            }
            else if (e == "View All")
            {
                bt1.BackColor = bt2.BackColor = bt3.BackColor = GUIStyles.whiteColor;
                bt1.ForeColor = bt2.ForeColor = bt3.ForeColor = GUIStyles.blackColor;
                loadprocess.Timerload = true;
                pload.Visible = true; pback.Visible = false;
                TimerLoad.Start();
                cdaylb.Text = e;
                prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = true;
                pcategoryname.Visible = true;
                categorynamelb.Text = "All Transactions";
                Pview.Visible = pviewcategory.Visible = true;
                pbutton.Enabled = false;
                pcindividual.Enabled = poption.Enabled = pshow.Enabled = true;
                pselectviewtype.Visible = false;
                if (cindividuallb.Text == "View by Category")
                {
                    Dictionary<string, List<Transaction>> liall = Communicator.Manager.FetchTransactions<Dictionary<string, List<Transaction>>>(walletid);
                    ShowCategory(liall);
                }
                else if (cindividuallb.Text == "View Individual Transaction")
                {
                    List<Transaction> liall = Communicator.Manager.FetchTransactions<List<Transaction>>(walletid);
                    ShowIndividualTransaction(liall);
                }
                else
                {
                    Dictionary<DateTime, List<Transaction>> liall = Communicator.Manager.FetchTransactions<Dictionary<DateTime, List<Transaction>>>(walletid);
                    ShowTransaction(liall);
                }
            }
            else
            {
                loadprocess.Timerload = true;
                pload.Visible = true; pback.Visible = false;
                TimerLoad.Start();
                cdaylb.Text = e;
                prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = true;
                Pview.Visible = pviewcategory.Visible = true;
                pbutton.Enabled = pcindividual.Enabled = poption.Enabled = pshow.Enabled = true;
                pselectviewtype.Visible = false;
                if (e == "View by Day")
                {
                    presentdate = TransactionEditor.viewday.Count - 3;
                    DaybtData();
                }
                else if (e == "View by Week")
                {
                    presentdate = TransactionEditor.viewweek.Count - 3;
                    WeekbtData();
                }
                else if (e == "View by Month")
                {
                    presentdate = TransactionEditor.viewmonth.Count - 3;
                    MonthbtData();
                }
                else if (e == "View by Quarter")
                {
                    presentdate = TransactionEditor.viewquarter.Count - 3;
                    QuarterbtData();
                }
                else if (e == "View by Year")
                {
                    presentdate = TransactionEditor.viewyear.Count - 3;
                    YearbtData();
                }
                Button2Color();
                FindData();
            }
        }

        #endregion

        #region Button select (view by category)

        private void OnSelectTypeBtClick(object sender, EventArgs e)
        {
            if (pselectcategorytransaction.Visible == false)
            {
                pscroll.Visible = Pview.Visible = pviewcategory.Visible = false;
                pnodata.Visible = true;
                prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = false;
                pbutton.Enabled = pcday.Enabled = poption.Enabled = pshow.Enabled = Pview.Enabled = false;
                pselectcategorytransaction.BringToFront();
                pselectcategorytransaction.Visible = true;
                selectcategory.TypeSelected += OnSelectcategoryTypeSelected;
            }
            else
            {
                pscroll.Visible = prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = true;
                pbutton.Enabled = pcday.Enabled = poption.Enabled = pshow.Enabled = Pview.Enabled = true;
                pselectcategorytransaction.Visible = false;
                RefreshTransactionManager();
            }
        }

        private void OnSelectcategoryTypeSelected(object sender, string e)
        {
            loadprocess.Timerload = true;
            pload.Visible = true; pback.Visible = false;
            TimerLoad.Start();
            prevenue.Enabled = IncomeBox.ControlEnabled = ExpenseBox.ControlEnabled = true;
            cindividuallb.Text = e;
            if (e == "View Individual Transaction")
            {
                pbutton.Enabled = pcday.Enabled = poption.Enabled = pshow.Enabled = Pview.Enabled = Pview.Visible = true;
                pselectcategorytransaction.Visible = false;
                Pview.BringToFront();
            }
            else
            {
                pbutton.Enabled = pcday.Enabled = poption.Enabled = pshow.Enabled = Pview.Enabled = pviewcategory.Visible = true;
                pselectcategorytransaction.Visible = Pview.Visible = false;
            }
            RefreshTransactionManager();
        }

        #endregion

        #region Button text change functions

        private void DaybtData()
        {
            bt1.Text = TransactionEditor.viewday[presentdate];
            bt2.Text = TransactionEditor.viewday[presentdate + 1];
            bt3.Text = TransactionEditor.viewday[presentdate + 2];
        }

        private void WeekbtData()
        {
            bt1.Text = TransactionEditor.viewweek[presentdate];
            bt2.Text = TransactionEditor.viewweek[presentdate + 1];
            bt3.Text = TransactionEditor.viewweek[presentdate + 2];
        }

        private void MonthbtData()
        {
            bt1.Text = TransactionEditor.viewmonth[presentdate];
            bt2.Text = TransactionEditor.viewmonth[presentdate + 1];
            bt3.Text = TransactionEditor.viewmonth[presentdate + 2];
        }

        private void QuarterbtData()
        {
            bt1.Text = TransactionEditor.viewquarter[presentdate];
            bt2.Text = TransactionEditor.viewquarter[presentdate + 1];
            bt3.Text = TransactionEditor.viewquarter[presentdate + 2];
        }

        private void YearbtData()
        {
            bt1.Text = TransactionEditor.viewyear[presentdate];
            bt2.Text = TransactionEditor.viewyear[presentdate + 1];
            bt3.Text = TransactionEditor.viewyear[presentdate + 2];
        }

        #endregion

        #region  Button Click Events

        private void OnBt1Click(object sender, EventArgs e)
        {
            if (bt1.BackColor == GUIStyles.secondaryColor)
            {
                return;
            }
            if (presentdate - 1 >= 0)
            {
                presentdate--;
                if (cdaylb.Text == "View by Day")
                {
                    DaybtData();
                }
                else if (cdaylb.Text == "View by Week")
                {
                    WeekbtData();
                }
                else if (cdaylb.Text == "View by Month")
                {
                    MonthbtData();
                }
                else if (cdaylb.Text == "View by Quarter")
                {
                    QuarterbtData();
                }
                else if (cdaylb.Text == "View by Year")
                {
                    YearbtData();
                }
                Button2Color();
            }
            else
                Button1Color();
            FindData();
        }

        private void OnBt2Click(object sender, EventArgs e)
        {
            if (bt2.BackColor == GUIStyles.secondaryColor)
            {
                return;
            }
            Button2Color();
            FindData();
        }

        private void OnBt3Click(object sender, EventArgs e)
        {
            if (bt3.BackColor == GUIStyles.secondaryColor)
            {
                return;
            }
            if (cdaylb.Text == "View by Day")
            {
                if (presentdate + 1 <= TransactionEditor.viewday.Count - 3)
                {
                    presentdate++;
                    DaybtData();
                    Button2Color();
                }
                else
                    Button3Color();
            }
            else if (cdaylb.Text == "View by Week")
            {
                if (presentdate + 1 <= TransactionEditor.viewweek.Count - 3)
                {
                    presentdate++;
                    WeekbtData();
                    Button2Color();
                }
                else
                    Button3Color();
            }
            else if (cdaylb.Text == "View by Month")
            {
                if (presentdate + 1 <= TransactionEditor.viewmonth.Count - 3)
                {
                    presentdate++;
                    MonthbtData();
                    Button2Color();
                }
                else
                    Button3Color();
            }
            else if (cdaylb.Text == "View by Quarter")
            {
                if (presentdate + 1 <= TransactionEditor.viewquarter.Count - 3)
                {
                    presentdate++;
                    QuarterbtData();
                    Button2Color();
                }
                else
                    Button3Color();
            }
            else if (cdaylb.Text == "View by Year")
            {
                if (presentdate + 1 <= TransactionEditor.viewyear.Count - 3)
                {
                    presentdate++;
                    YearbtData();
                    Button2Color();
                }
                else
                    Button3Color();
            }
            FindData();
        }

        private void Button1Color()
        {
            ActiveControl = bt1;
            bt1.BackColor = GUIStyles.secondaryColor;
            bt2.BackColor = bt3.BackColor = GUIStyles.whiteColor;
            bt2.ForeColor = bt3.ForeColor = GUIStyles.blackColor; bt1.ForeColor = GUIStyles.whiteColor;
        }

        private void Button2Color()
        {
            ActiveControl = bt2;
            bt1.BackColor = bt3.BackColor = GUIStyles.whiteColor;
            bt2.BackColor = GUIStyles.secondaryColor;
            bt1.ForeColor = bt3.ForeColor = GUIStyles.blackColor; bt2.ForeColor = GUIStyles.whiteColor;
        }

        private void Button3Color()
        {
            ActiveControl = bt3;
            bt1.BackColor = bt2.BackColor = GUIStyles.whiteColor;
            bt3.BackColor = GUIStyles.secondaryColor;
            bt1.ForeColor = bt2.ForeColor = GUIStyles.blackColor; bt3.ForeColor = GUIStyles.whiteColor;
        }
        #endregion

        #region Find Data To View Transaction

        private void FindData()
        {
            String str = "";
            if (bt1.BackColor == GUIStyles.secondaryColor)
                str = bt1.Text;
            else if (bt2.BackColor == GUIStyles.secondaryColor)
                str = bt2.Text;
            else if (bt3.BackColor == GUIStyles.secondaryColor)
                str = bt3.Text;

            if (str == "Future")
            {
                FindFuture(DateTime.Now);
                return;
            }

            if (cdaylb.Text == "View by Day")
                FindExactDay(str);
            else if (cdaylb.Text == "View by Week")
                FindExactWeek(str);
            else if (cdaylb.Text == "View by Month")
                FindExactMonth(str);
            else if (cdaylb.Text == "View by Quarter")
                FindExactQuarter(str);
            else if (cdaylb.Text == "View by Year")
                FindExactYear(str);
        }

        private void FindExactDay(String str)
        {
            DateTime dt = TransactionEditor.FindDay(str);
            List<String> datetime = new List<string>
            {
                dt.ToString(),
                dt.ToString()
            };
            FetchData(datetime, Manager.ViewType.Day);
        }

        private void FindExactWeek(String str)
        {
            DateTime dt = TransactionEditor.FindWeek(str);
            List<String> datetime = Communicator.Manager.FindWeek(dt);
            FetchData(datetime, Manager.ViewType.Week);
        }

        private void FindExactMonth(String str)
        {
            DateTime dt = TransactionEditor.FindMonth(str);
            List<String> datetime = Communicator.Manager.FindMonth(dt);
            FetchData(datetime, Manager.ViewType.Month);
        }

        private void FindExactQuarter(String str)
        {
            DateTime dt = TransactionEditor.FindQuarter(str);
            List<String> datetime = Communicator.Manager.FindQuartar(dt);
            FetchData(datetime, Manager.ViewType.Quarter);
        }

        private void FindExactYear(String str)
        {
            DateTime dt = TransactionEditor.FindYear(str);
            List<String> datetime = Communicator.Manager.FindYear(dt);
            FetchData(datetime, Manager.ViewType.Year);
        }

        private void FindFuture(DateTime dt)
        {
            List<String> datetime = new List<string>
            {
                dt.ToString(),
                dt.ToString()
            };
            FetchData(datetime, Manager.ViewType.Future);
        }

        private void FetchData(List<String> datetime, Manager.ViewType type)
        {
            DateTime sdate = DateTime.Parse(datetime[0]);
            DateTime edate = DateTime.Parse(datetime[1]);
            if (cindividuallb.Text == "View by Category")
            {
                Dictionary<string, List<Transaction>> lidata = Communicator.Manager.FetchTransactionOnDates<Dictionary<string, List<Transaction>>>(sdate, edate, type, walletid);
                ShowCategory(lidata);
            }
            else if (cindividuallb.Text == "View Individual Transaction")
            {
                List<Transaction> lidata = Communicator.Manager.FetchTransactionOnDates<List<Transaction>>(sdate, edate, type, walletid);
                ShowIndividualTransaction(lidata);
            }
            else
            {
                Dictionary<DateTime, List<Transaction>> lidata = Communicator.Manager.FetchTransactionOnDates<Dictionary<DateTime, List<Transaction>>>(sdate, edate, type, walletid);
                ShowTransaction(lidata);
            }
        }

        #endregion

        #region MouseEnterEvents

        private void OnSelectBtMouseEnter(object sender, EventArgs e)
        {
            sbackcolor = GUIStyles.terenaryColor; selectbt.Invalidate();
        }

        private void OnSelectBtMouseLeave(object sender, EventArgs e)
        {
            sbackcolor = GUIStyles.cardColor; selectbt.Invalidate();

        }

        private void OnBackBtMouseEnter(object sender, EventArgs e)
        {
            backbt.ForeColor = GUIStyles.terenaryColor;
        }

        private void OnBackBtMouseLeave(object sender, EventArgs e)
        {
            backbt.ForeColor = GUIStyles.primaryColor;
        }

        private void OnCdayMouseEnter(object sender, EventArgs e)
        {
            cselectdatebt.BackColor = pcday.BackColor = GUIStyles.terenaryColor;
            cdaylb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnCdayMouseLeave(object sender, EventArgs e)
        {
            cselectdatebt.BackColor = pcday.BackColor = GUIStyles.cardColor;
            cdaylb.ForeColor = GUIStyles.blackColor;
        }

        private void OnCindividualMouseEnter(object sender, EventArgs e)
        {
            cselecttypebt.BackColor = pcindividual.BackColor = GUIStyles.terenaryColor;
            cindividuallb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnCindividualMouseLeave(object sender, EventArgs e)
        {
            cselecttypebt.BackColor = pcindividual.BackColor = GUIStyles.cardColor;
            cindividuallb.ForeColor = GUIStyles.blackColor;
        }

        #endregion
    }
}