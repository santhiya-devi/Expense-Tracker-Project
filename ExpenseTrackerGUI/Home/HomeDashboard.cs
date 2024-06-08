using ExpenseTracker;
using ExpenseTrackerGUI.Account;
using ExpenseTrackerGUI.Home;
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
	public partial class HomeDashboard : UserControl
	{
        #region Constructor

        public HomeDashboard()
		{
			InitializeComponent();

            this.DoubleBuffered = true;
            this.Size = new Size(1936, 1056);
            avgCardPanel.CardFlickerColor = Color.Transparent;
            transactionAddPicturebox.Hide();
            budgetAddPictureBox.Hide();
            walkthroghPanel.Hide();
            walletView1.Hide();
            noTransactionPanel.Hide();

            account1.DeleteAccount += OnAccount1_DeleteAccount;
            account1.AccountClick += OnAccount1_AccountClick;
            walkThrough1.walkthroughBackClick += OnWalkThrough1_walkthroughBackClick;     
            AddControls();
            HideControl();
            UpdateFunctions();
        }

        #endregion

        #region Variable & Controls creation

        private TransactionManager transactionManager = new TransactionManager();
        private BudgetPage budgetPage = new BudgetPage();
        private MainCategoryView mainCategoryView = new MainCategoryView();
        private CreateTransaction createTransaction = new CreateTransaction();
        private AddBudget addBudget = new AddBudget();
        private AccountTemplate accountTemplate = new AccountTemplate();
        private SeeReports seeReports = new SeeReports();
        private WalletView changeWallet = new WalletView();

        Dictionary<string, float> dict1 = new Dictionary<string, float>();
        List<Tuple<string, float>> result = new List<Tuple<string, float>>();

        static int countTrans = 0;
        bool type = false, flag = true;
        int cnt = 0;
        public int count = 0;
        public int walletId = 1;

        #endregion

        #region User defined Function

        private void SetUpChart()
        {
            List<Tuple<string, float>> result1 = new List<Tuple<string, float>>();
            chart1.Series.Clear();
            chart1.Series.Add("Series1");
            chart1.BorderlineWidth = 10;
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            chart1.Series["Series1"].Color = GUIStyles.primaryColor;
            chart1.Series["Series1"].ShadowColor = GUIStyles.terenaryColor;
            chart1.Series["Series1"].ShadowOffset = 10;
            chart1.Series["Series1"].BorderWidth = 7;
            chart1.Series["Series1"].ChartArea = "ChartArea1";
            chart1.ChartAreas[0].BackColor = GUIStyles.backColor;
            chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.Emboss;
            chart1.BorderSkin.BackColor = Color.Gray;
            if (walletId == 0)
            {
                result1.Clear();
                var r = Communicator.Manager.FetchWallet();
                foreach (var l in r)
                {
                    result = Communicator.Manager.FetchAmount(l.WalletID);
                    foreach (var l1 in result)
                    {
                        if (l1.Item2 != 0)
                        {
                            result1.Add(l1);
                        }
                    }
                }
            }
            else
            {
                result1.Clear();
                result = Communicator.Manager.FetchAmount(walletId);
                foreach (var t in result)
                {
                    if (t.Item2 != 0)
                    {
                        result1.Add(t);
                    }
                }
            }
            var sortedList = result1.OrderByDescending(t => t.Item1).ToList();

            if (sortedList.Count == 0)
            {
                noTransactionPanel.Show();
                noTransactionPanel.BackColor = GUIStyles.backColor;
            }
            else
            {
                noTransactionPanel.Hide();
            }

            foreach (Tuple<string, float> t1 in sortedList)
            {
                chart1.Series["Series1"].Points.AddXY(t1.Item1, t1.Item2);
            }
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
        }

        private List<ExpenseTrackerDS.Transaction> SortTransactions(List<ExpenseTrackerDS.Transaction> transactions)
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                for (int j = i + 1; j < transactions.Count; j++)
                {
                    if (transactions[i].Date < transactions[j].Date)
                    {
                        ExpenseTrackerDS.Transaction transaction = new ExpenseTrackerDS.Transaction();
                        transaction.TransactionId = transactions[i].TransactionId;
                        transaction.CategoryId = transactions[i].CategoryId;
                        transaction.CategoryName = transactions[i].CategoryName;
                        transaction.Date = transactions[i].Date;
                        transaction.Description = transactions[i].Description;
                        transaction.Amount = transactions[i].Amount;
                        transaction.WalletId = transactions[i].WalletId;

                        transactions[i] = transactions[j];
                        transactions[j] = transaction;
                    }
                }
            }
            return transactions;
        }

        private void ShowTransaction()
        {
            List<ExpenseTrackerDS.Transaction> transactions = Communicator.Manager.FetchTransactions<List<ExpenseTrackerDS.Transaction>>(walletId); 
            transactions = SortTransactions(transactions);
            dict1.Clear();

            for (int i = 0; i < transactions.Count; i++)
            {
                var d1 = Communicator.Manager.FetchCategoryName(transactions[i].CategoryId);
                if (d1.Type == true) continue;
                float amount = transactions[i].Amount, avg = 0, cnt = 1;

                foreach (var v in transactions)
                {
                    var d2 = Communicator.Manager.FetchCategoryName(v.CategoryId);
                    if (transactions[i].Date == v.Date && transactions[i].TransactionId != v.TransactionId && d1.Type == false && d2.Type == false)
                    {
                        amount += (v.Amount);
                        cnt++;
                    }
                }
                avg = amount / cnt;

                if (!dict1.ContainsKey(transactions[i].Date.ToString("dd.MM.yyyy")))
                {
                    dict1.Add(transactions[i].Date.ToString("dd.MM.yyyy"), avg);
                }
            }

            todayAvg.Text = "";
            todayLabel.Text = "";
            yesterdayLabel.Text = "";
            yesterdayAvg.Text = "";
            dayBeforeLabel.Text = "";
            dayBeforeAvg.Text = "";
            nextDayAvg.Text = "";
            nextDayLabel.Text = "";

            if (dict1.Count <= 4)
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next3.png");
                type = true;
            }
            else
            {
                type = false;
                SetStyles();
            }

            if (dict1.Count > 0)
            {
                if (dict1.Keys.ElementAt(0) == DateTime.Now.ToString("dd.MM.yyyy"))
                {
                    countTrans = 0;
                    todayLabel.Text = "Today, " + DateTime.Now.Day;
                    todayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans);
                }
                else
                {
                    countTrans = 0;
                    todayLabel.Text = dict1.Keys.ElementAt(countTrans);
                    todayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans);
                }
            }
            if (dict1.Count > 1)
            {
                countTrans = 1;
                yesterdayLabel.Text = dict1.Keys.ElementAt(countTrans);
                yesterdayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans);
            }
            if (dict1.Count > 2)
            {
                countTrans = 2;
                dayBeforeLabel.Text = dict1.Keys.ElementAt(countTrans);
                dayBeforeAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans);
            }
            if (dict1.Count > 3)
            {
                countTrans = 3;
                nextDayLabel.Text = dict1.Keys.ElementAt(countTrans);
                nextDayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans);
            }
        }

        private void ShowTotalAmount()
        {
            Dictionary<bool, List<ExpenseTrackerDS.Transaction>> dict = Communicator.Manager.FetchTransactionOnDates<Dictionary<bool, List<ExpenseTrackerDS.Transaction>>>(DateTime.Now, DateTime.Now, Manager.ViewType.Month, walletId);
            List<ExpenseTrackerDS.Transaction> dict1 = new List<ExpenseTrackerDS.Transaction>();
            Dictionary<int, List<ExpenseTrackerDS.Transaction>> dict2 = new Dictionary<int, List<ExpenseTrackerDS.Transaction>>();
            dict2 = new Dictionary<int, List<ExpenseTrackerDS.Transaction>>();
            float total = 0;
            foreach (var d in dict)
            {
                if (d.Key == false)
                {
                    dict1 = d.Value;
                }
            }
            for (int i = 0; i < dict1.Count; i++)
            {
                if (dict2.ContainsKey(dict1[i].CategoryId))
                {
                    dict2[dict1[i].CategoryId].Add(dict1[i]);
                }
                else
                {
                    dict2.Add(dict1[i].CategoryId, new List<ExpenseTrackerDS.Transaction>() { dict1[i] });
                }
                total += dict1[i].Amount;
            }

            if (total == 0)
            {
                totalLabel.Text = "No Transactions Yet.";
            }
            else
            {
                totalLabel.Text = "₹ " + total.ToString();
            }
        }

        private void ShowBiggestExpense()
        {
            Dictionary<bool, List<ExpenseTrackerDS.Transaction>> dict = Communicator.Manager.FetchTransactionOnDates<Dictionary<bool, List<ExpenseTrackerDS.Transaction>>>(DateTime.Now, DateTime.Now, Manager.ViewType.Month, walletId);
            List<ExpenseTrackerDS.Transaction> dict1 = new List<ExpenseTrackerDS.Transaction>();
            Dictionary<int, List<ExpenseTrackerDS.Transaction>> dict2 = new Dictionary<int, List<ExpenseTrackerDS.Transaction>>();
            dict2 = new Dictionary<int, List<ExpenseTrackerDS.Transaction>>();
            foreach (var d in dict)
            {
                if (d.Key == false)
                {
                    dict1 = d.Value;
                }
            }
            for (int i = 0; i < dict1.Count; i++)
            {
                if (dict2.ContainsKey(dict1[i].CategoryId))
                {
                    dict2[dict1[i].CategoryId].Add(dict1[i]);
                }
                else
                {
                    dict2.Add(dict1[i].CategoryId, new List<ExpenseTrackerDS.Transaction>() { dict1[i] });
                }
            }
            List<ExpenseTrackerDS.Transaction> transactions = Communicator.Manager.FetchTransactionOnDates<List<ExpenseTrackerDS.Transaction>>(DateTime.Now, DateTime.Now, ExpenseTracker.Manager.ViewType.Month, walletId);
            float total = 0;
            string name = "";
            string img = "";
            foreach (var t in dict2)
            {
                foreach (var l in t.Value)
                {
                    if (total < l.Amount)
                    {
                        total = l.Amount;
                        name = l.CategoryName;
                        ExpenseTrackerDS.Category category = Communicator.Manager.FetchCategoryName(l.CategoryId);
                        img = category.ImagePath;
                    }
                }
            }

            if (img != "")
            {
                biggestExpImg.Show();
                Bitmap bitmap = new Bitmap(img);
                biggestExpImg.Image = null;
                biggestExpImg.BackgroundImage = null;
                biggestExpImg.Image = bitmap;
                biggestExpImg.SizeMode = PictureBoxSizeMode.Zoom;
                expenseLabel.TextAlign = ContentAlignment.TopLeft;
            }
            else
            {
                biggestExpImg.Hide();
                expenseLabel.TextAlign = ContentAlignment.MiddleLeft;
            }

            if (total == 0)
            {
                expenseLabel.Text = "No Transactions Yet.";
            }
            else
            {
                expenseLabel.Text = name + "  \n      ₹ " + total.ToString();
            }

        }

        public void UpdateFunctions()
        {
            SetUpChart();
            ShowTransaction();
            ShowTotalAmount();
            ShowBiggestExpense();
            backPictureBox.Image = Image.FromFile(@".\Images\back3.png");
        }

        private void AddControls()
        {
            transactionManager.Dock = DockStyle.Fill;
            transactionTab.Controls.Add(transactionManager);

            budgetPage.Dock = DockStyle.Fill;
            budgetTab.Controls.Add(budgetPage);

            mainCategoryView.Dock = DockStyle.Fill;
            categoryTab.Controls.Add(mainCategoryView);

            changeWallet.Dock = DockStyle.Fill;
            changeWallet.EditMode = true;
            changeWallet.AddMode = true;
            changeWallet.TotalShow = true;
            changeWallet.ShowBorder = true;
            walletTab.Controls.Add(changeWallet);

            createTransaction.Dock = DockStyle.Fill;
            transactionAddTab.Controls.Add(createTransaction);

            addBudget.Dock = DockStyle.Fill;
            budgetAddTab.Controls.Add(addBudget);

            accountTemplate.Dock = DockStyle.Fill;
            accountTab.Controls.Add(accountTemplate);
            account1.OnNextPictureClick += OnAccount1_OnNextPictureClick;
            accountTemplate.walkthroughClick += OnAccountTemplate_walkthroughClick;
            accountTemplate.ChangeUserName += OnAccountTemplate_ChangeUserName;
            accountTemplate.ImageChange += OnAccountTemplate_ImageChange;
            seeReports.Dock = DockStyle.Fill;
            seeReportsTab.Controls.Add(seeReports);
        }

        private void HideControl()
        {
            accountPictureBox.Show();
            account1.Hide();
            account1.HideFunction();
        }

        private void SetStyles()
        {
            titleLabel.ForeColor = GUIStyles.primaryColor;
            homeLabel.ForeColor = GUIStyles.primaryColor;
            transactionLabel.ForeColor = GUIStyles.primaryColor;
            budgetLabel.ForeColor = GUIStyles.primaryColor;
            categoryLabel.ForeColor = GUIStyles.primaryColor;
            walletLabel.ForeColor = GUIStyles.primaryColor;
            exitLabel.ForeColor = GUIStyles.primaryColor;
            statLabel.ForeColor = GUIStyles.primaryColor;
            totalExpenseLabel.ForeColor = GUIStyles.primaryColor;
            biggestExpenseLbl.ForeColor = GUIStyles.primaryColor;
            avgLbl.ForeColor = GUIStyles.primaryColor;
            todayLabel.ForeColor = GUIStyles.primaryColor;
            yesterdayLabel.ForeColor = GUIStyles.primaryColor;
            dayBeforeLabel.ForeColor = GUIStyles.primaryColor;
            nextDayLabel.ForeColor = GUIStyles.primaryColor;

            todayAvg.ForeColor = GUIStyles.primaryColor;
            yesterdayAvg.ForeColor = GUIStyles.primaryColor;
            dayBeforeAvg.ForeColor = GUIStyles.primaryColor;
            nextDayAvg.ForeColor = GUIStyles.primaryColor;

            totalLabel.ForeColor = GUIStyles.primaryColor;
            expenseLabel.ForeColor = GUIStyles.primaryColor;
            walletShowPanel.CardBorderColor = GUIStyles.primaryColor;
            seeReportLinkLabel1.LinkColor = GUIStyles.primaryColor;

            titlePanel.BackColor = GUIStyles.backColor;
            menuShowPannel.BackColor = GUIStyles.backColor;
            tabControl1.BackColor = GUIStyles.backColor;
            todayPanel.BackColor = GUIStyles.backColor;
            yesterdayPanel.BackColor = GUIStyles.backColor;
            nextDayPanel.BackColor = GUIStyles.backColor;
            noTransactionPanel.BackColor = GUIStyles.backColor;
            dayBeforePanel.BackColor = GUIStyles.backColor;
            homeTab.BackColor = GUIStyles.backColor;
            transactionTab.BackColor = GUIStyles.backColor;
            budgetTab.BackColor = GUIStyles.backColor;
            categoryTab.BackColor = GUIStyles.backColor;
            walletTab.BackColor = GUIStyles.backColor;
            transactionAddTab.BackColor = GUIStyles.backColor;
            budgetAddTab.BackColor = GUIStyles.backColor;
            accountTab.BackColor = GUIStyles.backColor;
            seeReportsTab.BackColor = GUIStyles.backColor;
            chart1.BackColor = GUIStyles.backColor;

            space1.BackColor = GUIStyles.whiteColor;
            space20.BackColor = GUIStyles.whiteColor;
            space8.BackColor = GUIStyles.whiteColor;
            space7.BackColor = GUIStyles.whiteColor;
            space9.BackColor = GUIStyles.whiteColor;
            space6.BackColor = GUIStyles.whiteColor;
            space10.BackColor = GUIStyles.whiteColor;
            graphShowPanel.BackColor = GUIStyles.whiteColor;
            biggestExpensePanel.CardBackColor = GUIStyles.whiteColor;
            walletShowPanel.CardBackColor = GUIStyles.whiteColor;
            avgCardPanel.CardBackColor = GUIStyles.whiteColor;
            graphAndAddPanel.BackColor = GUIStyles.whiteColor;
            walletName.BackColor = GUIStyles.whiteColor;
            walletImage.BackColor = GUIStyles.whiteColor;
            totalExpensePanel.CardFlickerColor = GUIStyles.whiteColor;
            biggestExpensePanel.CardFlickerColor = GUIStyles.whiteColor;
            avgCardPanel.CardFlickerColor = GUIStyles.whiteColor;
            totalExpensePanel.CardFlickerColor = GUIStyles.whiteColor;
            biggestExpensePanel.CardFlickerColor = GUIStyles.whiteColor;
            avgCardPanel.CardFlickerColor = GUIStyles.whiteColor;
            walletShowPanel.CardFlickerColor = GUIStyles.whiteColor;
            dropDownWallet.BackColor = GUIStyles.whiteColor;

            if (GUIStyles.colorName == "black")
            {
                homePictureBox.Image = Image.FromFile(@".\Images\home4.png");
                transactionPictureBox.Image = Image.FromFile(@".\Images\wallet8.png");
                categoryPictureBox.Image = Image.FromFile(@".\Images\category7.png");
                budgetPictureBox.Image = Image.FromFile(@".\Images\budget5.png");
                walletPictureBox.Image = Image.FromFile(@".\Images\wallet11.png");
                logoutPictureBox.Image = Image.FromFile(@".\Images\rename6.png");
                addPictureBox.Image = Image.FromFile(@".\Images\add5.png");
                transactionAddPicturebox.Image = Image.FromFile(@".\Images\wallet8.png");
                budgetAddPictureBox.Image = Image.FromFile(@".\Images\budget5.png");
                if (Communicator.Manager.image != "")
                {
                    Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                    accountPictureBox.Image = null;
                    accountPictureBox.BackgroundImage = null;
                    accountPictureBox.Image = bitmap;
                    accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    accountPictureBox.Image = Image.FromFile(@".\Images\account2.png");
                }
                walletImage.Image = Image.FromFile(@".\Images\globe3.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri3.png");
                if (!type)
                {
                    backPictureBox.Image = Image.FromFile(@".\Images\back7.png");
                    nextPictureBox.Image = Image.FromFile(@".\Images\next6.png");
                }

            }
            else if (GUIStyles.colorName == "brown")
            {
                homePictureBox.Image = Image.FromFile(@".\Images\home6.png");
                transactionPictureBox.Image = Image.FromFile(@".\Images\wallet9.png");
                categoryPictureBox.Image = Image.FromFile(@".\Images\category8.png");
                budgetPictureBox.Image = Image.FromFile(@".\Images\budget4.png");
                walletPictureBox.Image = Image.FromFile(@".\Images\wallet10.png");
                logoutPictureBox.Image = Image.FromFile(@".\Images\rename7.png");
                addPictureBox.Image = Image.FromFile(@".\Images\add6.png");
                transactionAddPicturebox.Image = Image.FromFile(@".\Images\wallet9.png");
                budgetAddPictureBox.Image = Image.FromFile(@".\Images\budget4.png");
                if (Communicator.Manager.image != "")
                {
                    Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                    accountPictureBox.Image = null;
                    accountPictureBox.BackgroundImage = null;
                    accountPictureBox.Image = bitmap;
                    accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    accountPictureBox.Image = Image.FromFile(@".\Images\account3.png");
                }
                walletImage.Image = Image.FromFile(@".\Images\globe4.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri4.png");
                if (!type)
                {
                    backPictureBox.Image = Image.FromFile(@".\Images\back8.png");
                    nextPictureBox.Image = Image.FromFile(@".\Images\next7.png");
                }
            }
            else if (GUIStyles.colorName == "blue")
            {
                homePictureBox.Image = Image.FromFile(@".\Images\home1.png");
                transactionPictureBox.Image = Image.FromFile(@".\Images\wallet.png");
                categoryPictureBox.Image = Image.FromFile(@".\Images\category3.png");
                budgetPictureBox.Image = Image.FromFile(@".\Images\budget1.png");
                walletPictureBox.Image = Image.FromFile(@".\Images\wallet2.png");
                logoutPictureBox.Image = Image.FromFile(@".\Images\rename1.png");
                addPictureBox.Image = Image.FromFile(@".\Images\add.png");
                transactionAddPicturebox.Image = Image.FromFile(@".\Images\wallet.png");
                budgetAddPictureBox.Image = Image.FromFile(@".\Images\budget1.png");
                if (Communicator.Manager.image != "" && Communicator.Manager.image!="0")
                {
                    Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                    accountPictureBox.Image = null;
                    accountPictureBox.BackgroundImage = null;
                    accountPictureBox.Image = bitmap;
                    accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    accountPictureBox.Image = Image.FromFile(@".\Images\account.png");
                }

                walletImage.Image = Image.FromFile(@".\Images\globe.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri.png");
                if (!type)
                {
                    backPictureBox.Image = Image.FromFile(@".\Images\back4.png");
                    nextPictureBox.Image = Image.FromFile(@".\Images\next8.png");
                }
            }
            else if (GUIStyles.colorName == "red")
            {
                homePictureBox.Image = Image.FromFile(@".\Images\home5.png");
                transactionPictureBox.Image = Image.FromFile(@".\Images\wallet6.png");
                categoryPictureBox.Image = Image.FromFile(@".\Images\category5.png");
                budgetPictureBox.Image = Image.FromFile(@".\Images\budget7.png");
                walletPictureBox.Image = Image.FromFile(@".\Images\wallet13.png");
                logoutPictureBox.Image = Image.FromFile(@".\Images\rename4.png");
                addPictureBox.Image = Image.FromFile(@".\Images\add3.png");
                transactionAddPicturebox.Image = Image.FromFile(@".\Images\wallet6.png");
                budgetAddPictureBox.Image = Image.FromFile(@".\Images\budget7.png");
                if (Communicator.Manager.image != "")
                {
                    Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                    accountPictureBox.Image = null;
                    accountPictureBox.BackgroundImage = null;
                    accountPictureBox.Image = bitmap;
                    accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    accountPictureBox.Image = Image.FromFile(@".\Images\account4.png");
                }

                walletImage.Image = Image.FromFile(@".\Images\globe1.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri1.png");
                if (!type)
                {
                    backPictureBox.Image = Image.FromFile(@".\Images\back6.png");
                    nextPictureBox.Image = Image.FromFile(@".\Images\next4.png");
                }
            }
            else if (GUIStyles.colorName == "orange")
            {
                homePictureBox.Image = Image.FromFile(@".\Images\home7.png");
                transactionPictureBox.Image = Image.FromFile(@".\Images\wallet7.png");
                categoryPictureBox.Image = Image.FromFile(@".\Images\category6.png");
                budgetPictureBox.Image = Image.FromFile(@".\Images\budget6.png");
                walletPictureBox.Image = Image.FromFile(@".\Images\wallet12.png");
                logoutPictureBox.Image = Image.FromFile(@".\Images\rename5.png");
                addPictureBox.Image = Image.FromFile(@".\Images\add4.png");
                transactionAddPicturebox.Image = Image.FromFile(@".\Images\wallet7.png");
                budgetAddPictureBox.Image = Image.FromFile(@".\Images\budget6.png");

                if (Communicator.Manager.image != "")
                {
                    Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                    accountPictureBox.Image = null;
                    accountPictureBox.BackgroundImage = null;
                    accountPictureBox.Image = bitmap;
                    accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    accountPictureBox.Image = Image.FromFile(@".\Images\account5.png");
                }
                walletImage.Image = Image.FromFile(@".\Images\globe2.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri2.png");
                if (!type)
                {
                    backPictureBox.Image = Image.FromFile(@".\Images\back5.png");
                    nextPictureBox.Image = Image.FromFile(@".\Images\next5.png");
                }
            }
            else if (GUIStyles.colorName == "pink")
            {
                homePictureBox.Image = Image.FromFile(@".\Images\z17.png");
                transactionPictureBox.Image = Image.FromFile(@".\Images\z33.png");
                categoryPictureBox.Image = Image.FromFile(@".\Images\z10.png");
                budgetPictureBox.Image = Image.FromFile(@".\Images\z5.png");
                walletPictureBox.Image = Image.FromFile(@".\Images\z34.png");
                logoutPictureBox.Image = Image.FromFile(@".\Images\z14.png");
                addPictureBox.Image = Image.FromFile(@".\Images\z1.png");
                transactionAddPicturebox.Image = Image.FromFile(@".\Images\z33.png");
                budgetAddPictureBox.Image = Image.FromFile(@".\Images\z5.png");
                if (Communicator.Manager.image != "")
                {
                    Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                    accountPictureBox.Image = null;
                    accountPictureBox.BackgroundImage = null;
                    accountPictureBox.Image = bitmap;
                    accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    accountPictureBox.Image = Image.FromFile(@".\Images\z23.png");
                }
                walletImage.Image = Image.FromFile(@".\Images\z16.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\z32.png");
                if (!type)
                {
                    backPictureBox.Image = Image.FromFile(@".\Images\z2.png");
                    nextPictureBox.Image = Image.FromFile(@".\Images\z21.png");
                }
            }
            homePanel.BackColor = GUIStyles.backColor;
            transactionPanel.BackColor = GUIStyles.backColor;
            budgetPanel.BackColor = GUIStyles.backColor;
            categoryPanel.BackColor = GUIStyles.backColor;
            walletPanel.BackColor = GUIStyles.backColor;
            exitPanel.BackColor = GUIStyles.backColor;
        }

        public void OnNextBtnClick()
        {
            if (GUIStyles.colorName == "black")
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next6.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next7.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next8.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next4.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next5.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\z21.png");
            }
        }

        public void OnBackBtnClick()
        {
            if (GUIStyles.colorName == "black")
            {
                backPictureBox.Image = Image.FromFile(@".\Images\back7.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                backPictureBox.Image = Image.FromFile(@".\Images\back8.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                backPictureBox.Image = Image.FromFile(@".\Images\back4.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                backPictureBox.Image = Image.FromFile(@".\Images\back6.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                backPictureBox.Image = Image.FromFile(@".\Images\back5.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                backPictureBox.Image = Image.FromFile(@".\Images\z2.png");
            }
        }

        private void MouseEnterEvent(PictureBox control1, Label control2, Image hoverImage, Panel control3)
        {
            control1.Size = new Size(control1.Width + 5, control1.Height + 5);
            control1.Image = hoverImage;
            control1.Cursor = Cursors.Hand;

            control2.Font = new Font("Arial", 16, FontStyle.Bold);
            control2.ForeColor = GUIStyles.whiteColor;

            control3.BackColor = GUIStyles.primaryColor;
        }

        private void MouseLeaveEvent(PictureBox control1, Label control2, Image hoverImage, Panel control3)
        {
            control1.Size = new Size(control1.Width - 5, control1.Height - 5);
            control1.Image = hoverImage;
            control1.Cursor = Cursors.Hand;

            control2.Font = new Font("Arial", 14, FontStyle.Bold);
            control2.ForeColor = GUIStyles.primaryColor;

            control3.BackColor = GUIStyles.backColor;
        }

        private void MouseEnterEvent(PictureBox control1, Image hoverImage)
        {
            control1.Size = new Size(control1.Width + 5, control1.Height + 5);
            control1.Image = hoverImage;
            control1.Cursor = Cursors.Hand;
        }

        private void MouseLeaveEvent(PictureBox control1, Image hoverImage)
        {
            control1.Size = new Size(control1.Width - 5, control1.Height - 5);
            control1.Image = hoverImage;
            control1.Cursor = Cursors.Hand;
        }

        #endregion

        #region Event creation

        public event EventHandler HideHomeDashboard;
        public event EventHandler OnExitClick;

        private void OnAccount1_AccountClick(object sender, EventArgs e)
        {
            account1.Hide();
            accountPictureBox.Show();
        }

        private void OnWalkThrough1_walkthroughBackClick(object sender, EventArgs e)
        {
            walkthroghPanel.Hide();
            menuShowPannel.Enabled = true;
            titlePanel.Enabled = true;
            accountTemplate.Enabled = true;
        }

        #endregion

        #region Subscribed events

        private void OnAccount1_DeleteAccount(object sender, EventArgs e)
        {
            HideHomeDashboard?.Invoke(this, EventArgs.Empty);
        }               

        private void OnAccountTemplate_ImageChange(object sender, EventArgs e)
        {
            if (Communicator.Manager.image != "")
            {
                Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                accountPictureBox.Image = null;
                accountPictureBox.BackgroundImage = null;
                accountPictureBox.Image = bitmap;
                accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                SetStyles();
            }
        }

        private void OnGUIStyles_ColorChanged(bool e)
        {
            SetStyles();
            transactionShowControl1.SetStyles();
            seeReports.SetStyles();
        }

        private void OnAccountTemplate_ChangeUserName(object sender, EventArgs e)
        {
            account1.ShowUsername();            
        }
        
        private void OnAccountTemplate_walkthroughClick(object sender, EventArgs e)
        {
            menuShowPannel.Enabled = false;
            titlePanel.Enabled = false;
            accountTemplate.Enabled = false;
            walkthroghPanel.Location = accountTab.PointToScreen(new Point(0,0));

            walkthroghPanel.Show();
        }

        private void OnAccount1_OnNextPictureClick(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != accountTab)
            {
                tabControl1.SelectedTab = accountTab;
                walkthroghPanel.Hide();
                accountTemplate.Signout += OnAccountTemplate_Signout;
                HideControl();
            }            
        }

        private void OnAccountTemplate_Signout(object sender, EventArgs e)
        {
            OnAccount1_DeleteAccount(this, EventArgs.Empty);
        }               

        private void Form1_Resize(object sender, EventArgs e)
        {
            titlePanel.Invalidate();
            int x = Width - 90;
            int y = 4;
            accountPictureBox.Location = new Point(x, y);

            x = graphAndAddPanel.Width - addPictureBox.Width - 5;
            y = graphAndAddPanel.Height - addPictureBox.Height - 5;
            addPictureBox.Location = new Point(x, y);

            x = graphAndAddPanel.Width - budgetAddPictureBox.Width - 5;
            y = graphAndAddPanel.Height - budgetAddPictureBox.Height - 200;
            budgetAddPictureBox.Location = new Point(x, y);

            x = graphAndAddPanel.Width - transactionAddPicturebox.Width - 5;
            y = graphAndAddPanel.Height - transactionAddPicturebox.Height - 120;
            transactionAddPicturebox.Location = new Point(x, y);

            seeReportLinkLabel1.Location = new Point(homeTab.Width -seeReportLinkLabel1.Width- 15, seeReportLinkLabel1.Location.Y);            
        }        

        private void addPictureBox_Click(object sender, EventArgs e)
        {

            homePanel.BackColor = Color.Transparent;
            homeLabel.ForeColor = GUIStyles.primaryColor;
            transactionPanel.BackColor = Color.Transparent;
            transactionLabel.ForeColor = GUIStyles.primaryColor;
            budgetPanel.BackColor = Color.Transparent;
            budgetLabel.ForeColor = GUIStyles.primaryColor;
            categoryPanel.BackColor = Color.Transparent;
            categoryLabel.ForeColor = GUIStyles.primaryColor;
            walletPanel.BackColor = Color.Transparent;
            walletLabel.ForeColor = GUIStyles.primaryColor;

            HideControl();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            if (flag)
            {
                if (cnt == 1)
                {
                    transactionAddPicturebox.Show();
                }
                else if (cnt == 2)
                {
                    budgetAddPictureBox.Show();
                }
                else
                {
                    flag = false;
                    cnt = 0;
                    timer1.Stop();
                }
            }
            else
            {
                if (cnt == 1)
                {
                    budgetAddPictureBox.Hide();
                }
                else if (cnt == 2)
                {
                    transactionAddPicturebox.Hide();
                }
                else
                {
                    flag = true;
                    cnt = 0;
                    timer1.Stop();
                }
            }
        }

        private void toolTip1_Draw(object sender, DrawToolTipEventArgs e)
        {
            Font font = new Font("Arial", 14, FontStyle.Regular); 

            e.DrawBackground();
            e.DrawBorder();
            e.Graphics.DrawString(e.ToolTipText, font, Brushes.Black, new PointF(2, 2));
        }

        private void OnSeeReports_WalletView(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = walletTab;
        }

        public void HomeDashboard_Load(object sender, EventArgs e)
        {
            walletId = 0;
            tabControl1.SelectedTab = homeTab;
            seeReportLinkLabel1.Location = new Point(homeTab.Width - seeReportLinkLabel1.Width - 15, seeReportLinkLabel1.Location.Y);
            UpdateFunctions();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            SetStyles();
            account1.ChangeImage();
            accountTemplate.ShowUsername();
            accountTemplate.Reload();
            seeReports.Reload();
            account1.Reload();
            transactionAddPicturebox.Hide();
            budgetAddPictureBox.Hide();
            account1.Hide();
            walletView1.Hide();
            accountPictureBox.Show();
        }

        private void walletView1_WalletClose_1(object sender, EventArgs e)
        {
            walletView1.Hide();
            biggestExpImg.BringToFront();
        }

        private void walletView1_WalletSelect(Image image, ExpenseTrackerDS.Wallet e)
        {
            walletId = e.WalletID;
            walletName.Text = e.WalletName;
            transactionShowControl1.walletId = e.WalletID;
            transactionShowControl1.ShowTransaction();
            UpdateFunctions();
            walletView1.Hide();
            biggestExpImg.BringToFront();
        }

        #endregion

        #region Paint

        private void titlePanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics gh = e.Graphics)
            {
                using (Brush b = new SolidBrush(GUIStyles.backColor))
                {
                    gh.FillRectangle(b, 0, 0, Width, Height);
                    using(Pen pen= new Pen(GUIStyles.primaryColor, 5))
                    {
                        gh.DrawRectangle(pen, 0, 0, titlePanel.Width - 1, titlePanel.Height - 1);
                        gh.DrawRectangle(pen, 10, 76, menuShowPannel.Width - 1, menuShowPannel.Height - 1);
                    }                    
                }
            }
        }

        private void todayPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics gh = e.Graphics)
            {
                using (Pen colorPen = new Pen(GUIStyles.primaryColor, 5))
                {
                    gh.DrawRectangle(colorPen, 2, 2, todayPanel.Width - 5, todayPanel.Height - 5);
                }
            }
        }

        private void yesterdayPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics gh = e.Graphics)
            {
                using (Pen colorPen = new Pen(GUIStyles.primaryColor, 5))
                {
                    gh.DrawRectangle(colorPen, 2, 2, yesterdayPanel.Width - 5, yesterdayPanel.Height - 5);
                }
            }
        }

        private void dayBeforePanel_Paint(object sender, PaintEventArgs e)
        {
            using(Graphics gh = e.Graphics)
            {
                using(Pen colorPen=new Pen(GUIStyles.primaryColor, 5))
                {
                    gh.DrawRectangle(colorPen, 2, 2, dayBeforePanel.Width - 5, dayBeforePanel.Height - 5);
                }
            }            
        }

        private void nextDayPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Graphics gh = e.Graphics)
            {
                using (Pen colorPen = new Pen(GUIStyles.primaryColor, 5))
                {
                    gh.DrawRectangle(colorPen, 2, 2, nextDayPanel.Width - 5, nextDayPanel.Height - 5);
                }
            }
        }

        #endregion    

        #region Click Events

        private void accountPictureBox_Click(object sender, EventArgs e)
        {
            accountPictureBox.Hide();
            account1.ShowUsername();
            account1.Show();
            account1.ChangeImage();
        }

        private void dropDownWallet_Click(object sender, EventArgs e)
        {
            walletView1.Show();
            transactionShowControl1.ShowTransaction();
            biggestExpImg.SendToBack();
        }

        private void nextPictureBox_Click(object sender, EventArgs e)
        {
            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                todayLabel.Text = dict1.Keys.ElementAt(countTrans);
                todayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            else
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next3.png");
                return;
            }

            OnBackBtnClick();

            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                yesterdayLabel.Text = dict1.Keys.ElementAt(countTrans);
                yesterdayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            else
            {
                yesterdayLabel.Text = "";
                yesterdayAvg.Text = "";
                nextPictureBox.Image = Image.FromFile(@".\Images\next3.png");
            }

            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                dayBeforeLabel.Text = dict1.Keys.ElementAt(countTrans);
                dayBeforeAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            else
            {
                dayBeforeLabel.Text = "";
                dayBeforeAvg.Text = "";
                nextPictureBox.Image = Image.FromFile(@".\Images\next3.png");
            }

            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                nextDayLabel.Text = dict1.Keys.ElementAt(countTrans);
                nextDayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            else
            {
                nextDayLabel.Text = "";
                nextDayAvg.Text = "";
                nextPictureBox.Image = Image.FromFile(@".\Images\next3.png");
            }
            HideControl();
        }

        private void backPictureBox_Click(object sender, EventArgs e)
        {
            count = 1;
            if (count * 4 - 4 == 0 || count * 4 - 3 == 0 || count * 4 - 2 == 0 || count * 4 - 1 == 0)
            {
                backPictureBox.Image = Image.FromFile(@".\Images\back3.png");
            }

            if (dict1.Count <= 4)
            {
                nextPictureBox.Image = Image.FromFile(@".\Images\next3.png");
            }
            else
            {
                OnNextBtnClick();
            }

            for (int i = countTrans; i >= 0; i--)
            {
                if (i % 4 == 0)
                {
                    countTrans = i;
                    break;
                }
            }

            if (countTrans - 4 >= 0)
            {
                countTrans -= 4;
                if (dict1.Keys.ElementAt(countTrans) == DateTime.Now.ToString("dd.MM.yyyy"))
                {
                    todayLabel.Text = "Today, " + DateTime.Now.Day;
                }
                else
                {
                    todayLabel.Text = dict1.Keys.ElementAt(countTrans);
                }
                todayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }

            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                yesterdayLabel.Text = dict1.Keys.ElementAt(countTrans);
                yesterdayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                dayBeforeLabel.Text = dict1.Keys.ElementAt(countTrans);
                dayBeforeAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            if (countTrans + 1 < dict1.Count)
            {
                countTrans++;
                nextDayLabel.Text = dict1.Keys.ElementAt(countTrans);
                nextDayAvg.Text = "₹ " + dict1.Values.ElementAt(countTrans).ToString();
            }
            HideControl();
        }

        private void exitLabel_Click(object sender, EventArgs e)
        {
            OnExitClick?.Invoke(this, EventArgs.Empty);
            tabControl1.SelectedTab = homeTab;
            HideControl();
        }

        private void homeLabel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != homeTab)
            {
                tabControl1.SelectedTab = homeTab;
                homePanel.BackColor = GUIStyles.terenaryColor;
                homeLabel.ForeColor = GUIStyles.primaryColor;
                transactionPanel.BackColor = Color.Transparent;
                transactionLabel.ForeColor = GUIStyles.primaryColor;
                categoryPanel.BackColor = Color.Transparent;
                categoryLabel.ForeColor = GUIStyles.primaryColor;
                budgetPanel.BackColor = Color.Transparent;
                budgetLabel.ForeColor = GUIStyles.primaryColor;
                walletPanel.BackColor = Color.Transparent;
                walletLabel.ForeColor = GUIStyles.primaryColor;
                transactionShowControl1.ShowTransaction();
                UpdateFunctions();
                HideControl();
            }            
        }
        
        private void transactionLabel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != transactionTab)
            {
                walletView1.Hide();
                account1.Hide();
                accountPictureBox.Show();
                transactionAddPicturebox.Hide();
                budgetAddPictureBox.Hide();
                tabControl1.SelectedTab = transactionTab; 
                transactionPanel.BackColor = GUIStyles.terenaryColor;
                transactionLabel.ForeColor = GUIStyles.primaryColor;
                homePanel.BackColor = Color.Transparent;
                homeLabel.ForeColor = GUIStyles.primaryColor;
                categoryPanel.BackColor = Color.Transparent;
                categoryLabel.ForeColor = GUIStyles.primaryColor;
                budgetPanel.BackColor = Color.Transparent;
                budgetLabel.ForeColor = GUIStyles.primaryColor;
                walletPanel.BackColor = Color.Transparent;
                walletLabel.ForeColor = GUIStyles.primaryColor;
                HideControl();
            }
            
        }

        private void budgetLabel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != budgetTab)
            {
                walletView1.Hide();
                account1.Hide();
                accountPictureBox.Show();
                transactionAddPicturebox.Hide();
                budgetAddPictureBox.Hide();
                budgetPage.InitializeWallets();
                budgetPage.InitializeBudgetPage();
                tabControl1.SelectedTab = budgetTab;
                budgetPanel.BackColor = GUIStyles.terenaryColor;
                budgetLabel.ForeColor = GUIStyles.primaryColor;
                homePanel.BackColor = Color.Transparent;
                homeLabel.ForeColor = GUIStyles.primaryColor;
                categoryPanel.BackColor = Color.Transparent;
                categoryLabel.ForeColor = GUIStyles.primaryColor;
                transactionPanel.BackColor = Color.Transparent;
                transactionLabel.ForeColor = GUIStyles.primaryColor;
                walletPanel.BackColor = Color.Transparent;
                walletLabel.ForeColor = GUIStyles.primaryColor;
                HideControl();
            }
            
        }

        private void categoryLabel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != categoryTab)
            {
                walletView1.Hide();
                account1.Hide();
                accountPictureBox.Show();
                transactionAddPicturebox.Hide();
                budgetAddPictureBox.Hide();
                tabControl1.SelectedTab = categoryTab;
                categoryPanel.BackColor = GUIStyles.terenaryColor;
                categoryLabel.ForeColor = GUIStyles.primaryColor;
                homePanel.BackColor = Color.Transparent;
                homeLabel.ForeColor = GUIStyles.primaryColor;
                budgetPanel.BackColor = Color.Transparent;
                budgetLabel.ForeColor = GUIStyles.primaryColor;
                transactionPanel.BackColor = Color.Transparent;
                transactionLabel.ForeColor = GUIStyles.primaryColor;
                walletPanel.BackColor = Color.Transparent;
                walletLabel.ForeColor = GUIStyles.primaryColor;
                HideControl();
            }            
        }

        private void walletLabel_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab != walletTab)
            {
                walletView1.Hide();
                account1.Hide();
                accountPictureBox.Show();
                transactionAddPicturebox.Hide();
                budgetAddPictureBox.Hide();
                tabControl1.SelectedTab = walletTab;
                walletPanel.BackColor = GUIStyles.terenaryColor;
                walletLabel.ForeColor = GUIStyles.primaryColor;
                homePanel.BackColor = Color.Transparent;
                homeLabel.ForeColor = GUIStyles.primaryColor;
                budgetPanel.BackColor = Color.Transparent;
                budgetLabel.ForeColor = GUIStyles.primaryColor;
                transactionPanel.BackColor = Color.Transparent;
                transactionLabel.ForeColor = GUIStyles.primaryColor;
                categoryPanel.BackColor = Color.Transparent;
                categoryLabel.ForeColor = GUIStyles.primaryColor;
                HideControl();
            }

        }

        private void transactionAddPicturebox_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (tabControl1.SelectedTab != transactionAddTab)
            {
                tabControl1.SelectedTab = transactionAddTab;
            }
            HideControl();
        }

        private void budgetAddPictureBox_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (tabControl1.SelectedTab != budgetAddTab)
            {
                tabControl1.SelectedTab = budgetAddTab;
            }
            HideControl();
        }

        private void seeReportLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            walletView1.Hide();
            account1.Hide();
            accountPictureBox.Show();
            transactionAddPicturebox.Hide();
            budgetAddPictureBox.Hide();
            tabControl1.SelectedTab = seeReportsTab;
            account1.Hide();
            accountPictureBox.Show();
            seeReports.Reload();
            seeReports.WalletView += OnSeeReports_WalletView;
        }

        #endregion

        #region MouseEnter events

        private void accountPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (Communicator.Manager.image != "")
            {
                Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                accountPictureBox.Image = null;
                accountPictureBox.BackgroundImage = null;
                accountPictureBox.Image = bitmap;
                accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                if (GUIStyles.colorName == "black")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account7.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "brown")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account6.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "blue")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account1.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "red")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account8.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "orange")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account9.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "pink")
                {
                    Image hoverImage = Image.FromFile(@".\Images\z23.png");
                    accountPictureBox.Image = hoverImage;
                }
            }
            accountPictureBox.Cursor = Cursors.Hand;
        }

        private void addPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\add9.png");
                MouseEnterEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\add10.png");
                MouseEnterEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\add2.png");
                MouseEnterEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\add8.png");
                MouseEnterEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\add9.png");
                MouseEnterEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z.png");
                MouseEnterEvent(addPictureBox, hoverImage);
            }
        }

        private void budgetAddPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget11.png");
                MouseEnterEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget10.png");
                MouseEnterEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget3.png");
                MouseEnterEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget8.png");
                MouseEnterEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget9.png");
                MouseEnterEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z38.png");
                MouseEnterEvent(budgetAddPictureBox, hoverImage);
            }
        }

        private void budgetPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Image hoverImage = Image.FromFile(@".\Images\budget2.png");
            MouseEnterEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
        }

        private void categoryPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Image hoverImage = Image.FromFile(@".\Images\category4.png");
            MouseEnterEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
        }

        private void dayBeforeAvg_MouseEnter(object sender, EventArgs e)
        {
            dayBeforePanel.BackColor = GUIStyles.primaryColor;
            dayBeforeLabel.ForeColor = GUIStyles.whiteColor;
            dayBeforeAvg.ForeColor = GUIStyles.whiteColor;
        }

        private void homePictureBox_MouseEnter(object sender, EventArgs e)
        {
            Image hoverImage = Image.FromFile(@".\Images\home3.png");
            MouseEnterEvent(homePictureBox, homeLabel, hoverImage, homePanel);
        }

        private void logoutPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Image hoverImage = Image.FromFile(@".\Images\rename3.png");
            MouseEnterEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
        }

        private void nextDayPanel_MouseEnter(object sender, EventArgs e)
        {
            nextDayPanel.BackColor = GUIStyles.primaryColor;
            nextDayLabel.ForeColor = GUIStyles.whiteColor;
            nextDayAvg.ForeColor = GUIStyles.whiteColor;
        }

        private void transactionAddPicturebox_MouseEnter(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet17.png");
                MouseEnterEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet14.png");
                MouseEnterEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet1.png");
                MouseEnterEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet16.png");
                MouseEnterEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet15.png");
                MouseEnterEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z39.png");
                MouseEnterEvent(transactionAddPicturebox, hoverImage);
            }
        }

        private void transactionPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Image hoverImage = Image.FromFile(@".\Images\wallet4.png");
            MouseEnterEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
        }

        private void todayPanel_MouseEnter(object sender, EventArgs e)
        {
            todayPanel.BackColor = GUIStyles.primaryColor;
            todayLabel.ForeColor = GUIStyles.whiteColor;
            todayAvg.ForeColor = GUIStyles.whiteColor;
        }

        private void walletImage_MouseEnter(object sender, EventArgs e)
        {
            walletShowPanel.CardFlickerColor = GUIStyles.whiteColor;
            walletShowPanel.CardBackColor = GUIStyles.whiteColor;
        }

        private void walletPictureBox_MouseEnter(object sender, EventArgs e)
        {
            Image hoverImage = Image.FromFile(@".\Images\wallet5.png");
            MouseEnterEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
        }

        private void yesterdayPanel_MouseEnter(object sender, EventArgs e)
        {
            yesterdayPanel.BackColor = GUIStyles.primaryColor;
            yesterdayLabel.ForeColor = GUIStyles.whiteColor;
            yesterdayAvg.ForeColor = GUIStyles.whiteColor;
        }

        #endregion

        #region MouseLeave events

        private void accountPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (Communicator.Manager.image != "")
            {
                Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                accountPictureBox.Image = null;
                accountPictureBox.BackgroundImage = null;
                accountPictureBox.Image = bitmap;
                accountPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                if (GUIStyles.colorName == "black")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account2.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "brown")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account3.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "blue")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "red")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account4.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "orange")
                {
                    Image hoverImage = Image.FromFile(@".\Images\account5.png");
                    accountPictureBox.Image = hoverImage;
                }
                else if (GUIStyles.colorName == "pink")
                {
                    Image hoverImage = Image.FromFile(@".\Images\z23.png");
                    accountPictureBox.Image = hoverImage;
                }
            }
            accountPictureBox.Cursor = Cursors.Hand;
        }

        private void addPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\add5.png");
                MouseLeaveEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\add6.png");
                MouseLeaveEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\add.png");
                MouseLeaveEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\add3.png");
                MouseLeaveEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\add4.png");
                MouseLeaveEvent(addPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z1.png");
                MouseLeaveEvent(addPictureBox, hoverImage);
            }
        }

        private void budgetAddPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget5.png");
                MouseLeaveEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget4.png");
                MouseLeaveEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget1.png");
                MouseLeaveEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget7.png");
                MouseLeaveEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget6.png");
                MouseLeaveEvent(budgetAddPictureBox, hoverImage);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z5.png");
                MouseLeaveEvent(budgetAddPictureBox, hoverImage);
            }
        }

        private void budgetPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget5.png");
                MouseLeaveEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget4.png");
                MouseLeaveEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget1.png");
                MouseLeaveEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget7.png");
                MouseLeaveEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\budget6.png");
                MouseLeaveEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z5.png");
                MouseLeaveEvent(budgetPictureBox, budgetLabel, hoverImage, budgetPanel);
            }
        }

        private void categoryPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\category7.png");
                MouseLeaveEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\category8.png");
                MouseLeaveEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\category3.png");
                MouseLeaveEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\category5.png");
                MouseLeaveEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\category6.png");
                MouseLeaveEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z10.png");
                MouseLeaveEvent(categoryPictureBox, categoryLabel, hoverImage, categoryPanel);
            }
        }

        private void dayBeforeAvg_MouseLeave(object sender, EventArgs e)
        {
            dayBeforePanel.BackColor = GUIStyles.backColor;
            dayBeforeLabel.ForeColor = GUIStyles.primaryColor;
            dayBeforeAvg.ForeColor = GUIStyles.primaryColor;
        }

        private void homePictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\home4.png");
                MouseLeaveEvent(homePictureBox, homeLabel, hoverImage, homePanel);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\home6.png");
                MouseLeaveEvent(homePictureBox, homeLabel, hoverImage, homePanel);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\home1.png");
                MouseLeaveEvent(homePictureBox, homeLabel, hoverImage, homePanel);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\home5.png");
                MouseLeaveEvent(homePictureBox, homeLabel, hoverImage, homePanel);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\home7.png");
                MouseLeaveEvent(homePictureBox, homeLabel, hoverImage, homePanel);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z17.png");
                MouseLeaveEvent(homePictureBox, homeLabel, hoverImage, homePanel);
            }
        }

        private void logoutPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\rename6.png");
                MouseLeaveEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\rename7.png");
                MouseLeaveEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\rename1.png");
                MouseLeaveEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\rename4.png");
                MouseLeaveEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\rename5.png");
                MouseLeaveEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z14.png");
                MouseLeaveEvent(logoutPictureBox, exitLabel, hoverImage, exitPanel);
            }
        }

        private void nextDayPanel_MouseLeave(object sender, EventArgs e)
        {
            nextDayPanel.BackColor = GUIStyles.backColor;
            nextDayLabel.ForeColor = GUIStyles.primaryColor;
            nextDayAvg.ForeColor = GUIStyles.primaryColor;
        }

        private void transactionAddPicturebox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet8.png");
                MouseLeaveEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet9.png");
                MouseLeaveEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet.png");
                MouseLeaveEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet6.png");
                MouseLeaveEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet7.png");
                MouseLeaveEvent(transactionAddPicturebox, hoverImage);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z33.png");
                MouseLeaveEvent(transactionAddPicturebox, hoverImage);
            }
        }

        private void transactionPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet8.png");
                MouseLeaveEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet9.png");
                MouseLeaveEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet.png");
                MouseLeaveEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet6.png");
                MouseLeaveEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet7.png");
                MouseLeaveEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z33.png");
                MouseLeaveEvent(transactionPictureBox, transactionLabel, hoverImage, transactionPanel);
            }
        }

        private void todayPanel_MouseLeave(object sender, EventArgs e)
        {
            todayPanel.BackColor = GUIStyles.backColor;
            todayLabel.ForeColor = GUIStyles.primaryColor;
            todayAvg.ForeColor = GUIStyles.primaryColor;
        }

        private void walletPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (GUIStyles.colorName == "black")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet11.png");
                MouseLeaveEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
            }
            else if (GUIStyles.colorName == "brown")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet10.png");
                MouseLeaveEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
            }
            else if (GUIStyles.colorName == "blue")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet2.png");
                MouseLeaveEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
            }
            else if (GUIStyles.colorName == "red")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet13.png");
                MouseLeaveEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
            }
            else if (GUIStyles.colorName == "orange")
            {
                Image hoverImage = Image.FromFile(@".\Images\wallet12.png");
                MouseLeaveEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
            }
            else if (GUIStyles.colorName == "pink")
            {
                Image hoverImage = Image.FromFile(@".\Images\z34.png");
                MouseLeaveEvent(walletPictureBox, walletLabel, hoverImage, walletPanel);
            }
        }

        private void yesterdayPanel_MouseLeave(object sender, EventArgs e)
        {
            yesterdayPanel.BackColor = GUIStyles.backColor;
            yesterdayLabel.ForeColor = GUIStyles.primaryColor;
            yesterdayAvg.ForeColor = GUIStyles.primaryColor;
        }       

        #endregion
    }
}