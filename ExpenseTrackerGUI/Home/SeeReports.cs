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
using LiveCharts.Wpf;
using LiveCharts;
using ExpenseTrackerGUI.Account;
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI.Home
{
    public partial class SeeReports : UserControl
    {
        public SeeReports()
        {
            InitializeComponent();

            date2.BackColor = GUIStyles.primaryColor;
            ShowFunction();
            date3Panel.BackColor = GUIStyles.primaryColor;
            date1Panel.BackColor = GUIStyles.whiteColor;
            date2Panel.BackColor = GUIStyles.whiteColor;
            SpendingReport(DateTime.Now, Manager.ViewType.Month);
            IncomeReport(DateTime.Now, DateTime.Now, Manager.ViewType.Month);
            ExpenseReport(DateTime.Now, Manager.ViewType.Month);
            seletedType = monthLabel.Text;
            Controls.Add(categoryReport);
            walletView1.Hide();
            categoryReport.Reload();
            ShowBalanceAmt();
            SetStyles();
        }

        float incomeRupeeFloat = 0, expenseRupeeFloat = 0, totalRupeeFloat = 0, incomeAmt = 0, expenseAmt = 0;
        int incomeCountFloat = 0, expenseCountFloat = 0, daycount = 0, walletId = 0, presentmonth = 0, presentyear = 0, presentday = 0, presentquarter = 0, switchCnt = 0, presentweek;
        static bool isAll = false;
        static string seletedType = "";
        List<string> viewday = new List<string>();
        List<string> viewweek = new List<string>();
        List<string> viewmonth = new List<string>();
        List<string> viewquarter = new List<string>();
        List<string> viewyear = new List<string>();
        DateTime dt, startDate, endDate;
        CategoryReport categoryReport = new CategoryReport();

        public void SetStyles()
        {
            cashflowLbl.ForeColor = GUIStyles.primaryColor;
            dividePanel.ForeColor = GUIStyles.blackColor;
            side1.BackColor = GUIStyles.primaryColor;
            side2.BackColor = GUIStyles.primaryColor;
            side3.BackColor = GUIStyles.primaryColor;
            side4.BackColor = GUIStyles.primaryColor;
            side5.BackColor = GUIStyles.primaryColor;
            side6.BackColor = GUIStyles.primaryColor;
            side7.BackColor = GUIStyles.primaryColor;
            side8.BackColor = GUIStyles.primaryColor;
            side9.BackColor = GUIStyles.primaryColor;
            side10.BackColor = GUIStyles.primaryColor;
            side11.BackColor = GUIStyles.primaryColor;
            side12.BackColor = GUIStyles.primaryColor;
            side13.BackColor = GUIStyles.primaryColor;
            side14.BackColor = GUIStyles.primaryColor;
            side15.BackColor = GUIStyles.primaryColor;
            side16.BackColor = GUIStyles.primaryColor;
            side17.BackColor = GUIStyles.primaryColor;
            side18.BackColor = GUIStyles.primaryColor;
            side19.BackColor = GUIStyles.primaryColor;
            side20.BackColor = GUIStyles.primaryColor;
            cardPanel3.CardBorderColor = GUIStyles.primaryColor;
            dayLabel.ForeColor = GUIStyles.primaryColor;
            weekLabel.ForeColor = GUIStyles.primaryColor;
            monthLabel.ForeColor = GUIStyles.primaryColor;
            quarterLabel.ForeColor = GUIStyles.primaryColor;
            yearLabel.ForeColor = GUIStyles.primaryColor;
            customLabel.ForeColor = GUIStyles.primaryColor;
            allLabel.ForeColor = GUIStyles.primaryColor;
            seeReportsByCategory.FlatAppearance.BorderColor = GUIStyles.primaryColor;
            cntIncome.ForeColor = GUIStyles.incomeColor;
            aveIncomeDay.ForeColor = GUIStyles.incomeColor;
            aveIncomeRecord.ForeColor = GUIStyles.incomeColor;
            totalIncome.ForeColor = GUIStyles.incomeColor;
            incomeAmtLbl.ForeColor = GUIStyles.incomeColor;
            incomeRupee.ForeColor = GUIStyles.incomeColor;
            expenseRupee.ForeColor = Color.Red;
            totalRupee.ForeColor = Color.Black;
            walletImage.BackColor = GUIStyles.whiteColor;
            cardPanel3.CardBackColor = GUIStyles.whiteColor;
            dropDownWallet.BackColor = GUIStyles.whiteColor;
            cardPanel3.CardFlickerColor = GUIStyles.whiteColor;
            incomePanel.BackColor = GUIStyles.whiteColor;
            expensePanel.BackColor = GUIStyles.whiteColor;
            walletPanel.BackColor = GUIStyles.whiteColor;
            quickOverviewPanel.BackColor = GUIStyles.whiteColor;
            spendingReportPanel.BackColor = GUIStyles.whiteColor;
            seeReportsByCategory.BackColor = GUIStyles.whiteColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            date3.BackColor = GUIStyles.whiteColor;
            walletName.BackColor = GUIStyles.whiteColor;
            date3.ForeColor = GUIStyles.whiteColor;
            date3.BackColor = GUIStyles.primaryColor;
            incomeAmtLbl.ForeColor = GUIStyles.incomeColor;
            seeReportPicture.BackColor = GUIStyles.whiteColor;
            seeReportsByCategory.FlatAppearance.MouseOverBackColor = GUIStyles.whiteColor;

            if (GUIStyles.colorName == "black")
            {
                walletImage.Image = Image.FromFile(@".\Images\globe3.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal2.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri3.png");
                seeReportPicture.Image = Image.FromFile(@".\Images\category7.png");
                dayPicture.Image = Image.FromFile(@".\Images\d1_2.png");
                weekPicture.Image = Image.FromFile(@".\Images\d7_2.png");
                monthPicture.Image = Image.FromFile(@".\Images\d31_3.png");
                quarterPicture.Image = Image.FromFile(@".\Images\q2.png");
                yearPicture.Image = Image.FromFile(@".\Images\cal2.png");
                customPicture.Image = Image.FromFile(@".\Images\pen2.png");
                allPicture.Image = Image.FromFile(@".\Images\i2.png");
                dayTick.Image = Image.FromFile(@".\Images\t3.png");
                weekTick.Image = Image.FromFile(@".\Images\t3.png");
                monthTick.Image = Image.FromFile(@".\Images\t3.png");
                quarterTick.Image = Image.FromFile(@".\Images\t3.png");
                allTick.Image = Image.FromFile(@".\Images\t3.png");
                customTick.Image = Image.FromFile(@".\Images\t3.png");
                yearTick.Image = Image.FromFile(@".\Images\t3.png");
                switchGraph.Image = Image.FromFile(@".\Images\dot3.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                walletImage.Image = Image.FromFile(@".\Images\globe4.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal3.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri4.png");
                seeReportPicture.Image = Image.FromFile(@".\Images\category8.png");
                dayPicture.Image = Image.FromFile(@".\Images\d1_1.png");
                weekPicture.Image = Image.FromFile(@".\Images\d7_1.png");
                monthPicture.Image = Image.FromFile(@".\Images\d31_2.png");
                quarterPicture.Image = Image.FromFile(@".\Images\q5.png");
                yearPicture.Image = Image.FromFile(@".\Images\cal3.png");
                customPicture.Image = Image.FromFile(@".\Images\pen1.png");
                allPicture.Image = Image.FromFile(@".\Images\i1.png");
                dayTick.Image = Image.FromFile(@".\Images\t4.png");
                weekTick.Image = Image.FromFile(@".\Images\t4.png");
                monthTick.Image = Image.FromFile(@".\Images\t4.png");
                quarterTick.Image = Image.FromFile(@".\Images\t4.png");
                allTick.Image = Image.FromFile(@".\Images\t4.png");
                customTick.Image = Image.FromFile(@".\Images\t4.png");
                yearTick.Image = Image.FromFile(@".\Images\t4.png");
                switchGraph.Image = Image.FromFile(@".\Images\dot4.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                walletImage.Image = Image.FromFile(@".\Images\globe.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri.png");
                seeReportPicture.Image = Image.FromFile(@".\Images\category3.png");
                dayPicture.Image = Image.FromFile(@".\Images\d1_5.png");
                weekPicture.Image = Image.FromFile(@".\Images\d7_5.png");
                monthPicture.Image = Image.FromFile(@".\Images\d31_1.png");
                quarterPicture.Image = Image.FromFile(@".\Images\q1.png");
                yearPicture.Image = Image.FromFile(@".\Images\cal.png");
                customPicture.Image = Image.FromFile(@".\Images\pen5.png");
                allPicture.Image = Image.FromFile(@".\Images\i5.png");
                dayTick.Image = Image.FromFile(@".\Images\t5.png");
                weekTick.Image = Image.FromFile(@".\Images\t5.png");
                monthTick.Image = Image.FromFile(@".\Images\t5.png");
                quarterTick.Image = Image.FromFile(@".\Images\t5.png");
                allTick.Image = Image.FromFile(@".\Images\t5.png");
                customTick.Image = Image.FromFile(@".\Images\t5.png");
                yearTick.Image = Image.FromFile(@".\Images\t5.png");
                switchGraph.Image = Image.FromFile(@".\Images\dot.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                walletImage.Image = Image.FromFile(@".\Images\globe1.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal1.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri1.png");
                seeReportPicture.Image = Image.FromFile(@".\Images\category5.png");
                dayPicture.Image = Image.FromFile(@".\Images\d1_4.png");
                weekPicture.Image = Image.FromFile(@".\Images\d7_4.png");
                monthPicture.Image = Image.FromFile(@".\Images\d31_5.png");
                quarterPicture.Image = Image.FromFile(@".\Images\q4.png");
                yearPicture.Image = Image.FromFile(@".\Images\cal1.png");
                customPicture.Image = Image.FromFile(@".\Images\pen4.png");
                allPicture.Image = Image.FromFile(@".\Images\i4.png");
                dayTick.Image = Image.FromFile(@".\Images\t1.png");
                weekTick.Image = Image.FromFile(@".\Images\t1.png");
                monthTick.Image = Image.FromFile(@".\Images\t1.png");
                quarterTick.Image = Image.FromFile(@".\Images\t1.png");
                allTick.Image = Image.FromFile(@".\Images\t1.png");
                customTick.Image = Image.FromFile(@".\Images\t1.png");
                yearTick.Image = Image.FromFile(@".\Images\t1.png");
                switchGraph.Image = Image.FromFile(@".\Images\dot1.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                walletImage.Image = Image.FromFile(@".\Images\globe2.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal4.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\tri2.png");
                seeReportPicture.Image = Image.FromFile(@".\Images\category6.png");
                dayPicture.Image = Image.FromFile(@".\Images\d1_3.png");
                weekPicture.Image = Image.FromFile(@".\Images\d7_3.png");
                monthPicture.Image = Image.FromFile(@".\Images\d31_4.png");
                quarterPicture.Image = Image.FromFile(@".\Images\q3.png");
                yearPicture.Image = Image.FromFile(@".\Images\cal4.png");
                customPicture.Image = Image.FromFile(@".\Images\pen3.png");
                allPicture.Image = Image.FromFile(@".\Images\i3.png");
                dayTick.Image = Image.FromFile(@".\Images\t2.png");
                weekTick.Image = Image.FromFile(@".\Images\t2.png");
                monthTick.Image = Image.FromFile(@".\Images\t2.png");
                quarterTick.Image = Image.FromFile(@".\Images\t2.png");
                allTick.Image = Image.FromFile(@".\Images\t2.png");
                customTick.Image = Image.FromFile(@".\Images\t2.png");
                yearTick.Image = Image.FromFile(@".\Images\t2.png");
                switchGraph.Image = Image.FromFile(@".\Images\dot2.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                walletImage.Image = Image.FromFile(@".\Images\z16.png");
                choicePicture.Image = Image.FromFile(@".\Images\z9.png");
                dropDownWallet.Image = Image.FromFile(@".\Images\z32.png");
                seeReportPicture.Image = Image.FromFile(@".\Images\z10.png");
                dayPicture.Image = Image.FromFile(@".\Images\z6.png");
                weekPicture.Image = Image.FromFile(@".\Images\z7.png");
                monthPicture.Image = Image.FromFile(@".\Images\z8.png");
                quarterPicture.Image = Image.FromFile(@".\Images\z26.png");
                yearPicture.Image = Image.FromFile(@".\Images\z9.png");
                customPicture.Image = Image.FromFile(@".\Images\z24.png");
                allPicture.Image = Image.FromFile(@".\Images\z18.png");
                dayTick.Image = Image.FromFile(@".\Images\z30.png");
                weekTick.Image = Image.FromFile(@".\Images\z30.png");
                monthTick.Image = Image.FromFile(@".\Images\z30.png");
                quarterTick.Image = Image.FromFile(@".\Images\z30.png");
                allTick.Image = Image.FromFile(@".\Images\z30.png");
                customTick.Image = Image.FromFile(@".\Images\z30.png");
                yearTick.Image = Image.FromFile(@".\Images\z30.png");
                switchGraph.Image = Image.FromFile(@".\Images\z20.png");
            }
        }

        public void ShowBalanceAmt()
        {
            float amount = 0, amount1 = 0;
            var res = Communicator.Manager.FetchWallet();
            foreach (var t in res)
            {
                amount += t.Amount;
                amount1 += t.OpeningBalance;
            }
            balanceAmtLbl.Text = "₹ " + amount;
            openingBalanceAmt.Text =": "+ amount1.ToString();
            endingBalanceAmt.Text =": "+ amount.ToString();
            walletName.Text = "Total";
        }

        private void IncomeReport(DateTime startDate, DateTime endDate, Manager.ViewType view)
        {
            incomeAmt = 0;
            SeriesCollection pieSeries = new SeriesCollection();
            incomeChart.InnerRadius = 20;
            Dictionary<bool, List<ExpenseTrackerDS.Transaction>> dict = new Dictionary<bool, List<Transaction>>();
            List<ExpenseTrackerDS.Transaction> dict1 = new List<ExpenseTrackerDS.Transaction>();
            Dictionary<int, List<ExpenseTrackerDS.Transaction>> dict2 = new Dictionary<int, List<ExpenseTrackerDS.Transaction>>();

            if (isAll)
            {
                List<Transaction> transactions = Communicator.Manager.FetchTransactions<List<Transaction>>(walletId);
                foreach (Transaction transaction in transactions)
                {
                    var category = Communicator.Manager.FetchCategoryName(transaction.CategoryId);
                    if (category.Type == true)
                    {
                        dict1.Add(transaction);
                    }
                }
            }
            else
            {
                dict = Communicator.Manager.FetchTransactionOnDates<Dictionary<bool, List<ExpenseTrackerDS.Transaction>>>(startDate, endDate, view, walletId);

                foreach (var d in dict)
                {
                    if (d.Key == true)
                    {
                        dict1 = d.Value;
                    }
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
                incomeAmt +=  dict1[i].Amount;
            }

            incomeAmtLbl.ForeColor = Color.Green;
            incomeAmtLbl.Text = "₹ " + incomeAmt.ToString();
            incomeRupeeFloat = incomeAmt;
            incomeCountFloat = dict2.Count;

            for (int i = 0; i < dict1.Count; i++)
            {
                PieSeries ser = new PieSeries();
                ser.Values = new ChartValues<int> { (int)((dict1[i].Amount / incomeAmt) * 100) };
                ser.Title = dict1[i].CategoryName + " " + dict1[i].Amount;
                ser.DataLabels = true;
                pieSeries.Add(ser);
            }
            incomeChart.Series = pieSeries;
        }

        private void ExpenseReport(DateTime dt, Manager.ViewType view)
        {
            expenseAmt = 0;
            SeriesCollection pieSeries = new SeriesCollection();
            expenseChart.InnerRadius = 20;
            Dictionary<bool, List<ExpenseTrackerDS.Transaction>> dict = new Dictionary<bool, List<Transaction>>();
            if (seletedType == "Custom")
            {
                dict = Communicator.Manager.FetchTransactionOnDates<Dictionary<bool, List<ExpenseTrackerDS.Transaction>>>(startDate, endDate, view, walletId);
            }
            else
            {
                dict = Communicator.Manager.FetchTransactionOnDates<Dictionary<bool, List<ExpenseTrackerDS.Transaction>>>(dt, dt, view, walletId);
            }
            List<ExpenseTrackerDS.Transaction> dict1 = new List<ExpenseTrackerDS.Transaction>();
            Dictionary<int, List<ExpenseTrackerDS.Transaction>> dict2 = new Dictionary<int, List<Transaction>>();
            if (isAll)
            {
                List<Transaction> transactions = Communicator.Manager.FetchTransactions<List<Transaction>>(walletId);
                foreach (Transaction transaction in transactions)
                {
                    var category = Communicator.Manager.FetchCategoryName(transaction.CategoryId);
                    if (category.Type == false)
                    {
                        dict1.Add(transaction);
                    }
                }
            }
            else
            {
                dict2 = new Dictionary<int, List<ExpenseTrackerDS.Transaction>>();

                foreach (var d in dict)
                {
                    if (d.Key == false)
                    {
                        dict1 = d.Value;
                    }
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
                expenseAmt += dict1[i].Amount;
            }

            expenseAmtLbl.ForeColor = Color.Red;
            expenseAmtLbl.Text = "-₹ " + expenseAmt.ToString();
            expenseRupeeFloat = expenseAmt;
            expenseCountFloat = dict2.Count;

            for (int i = 0; i < dict1.Count; i++)
            {
                PieSeries ser = new PieSeries();
                ser.Values = new ChartValues<double> { (int)((dict1[i].Amount / expenseAmt) * 100) };
                ser.Title = dict1[i].CategoryName + " " + dict1[i].Amount;
                ser.DataLabels = true;
                pieSeries.Add(ser);
            }

            expenseChart.Series = pieSeries;
            if (view == Manager.ViewType.Day)
            {
                daycount = 1;
            }
            else if (view == Manager.ViewType.Week)
            {
                daycount = 7;
            }
            else if (view == Manager.ViewType.Month)
            {
                daycount = 31;
            }
            else if (view == Manager.ViewType.Quarter)
            {
                daycount = 91;
            }
            else if (view == Manager.ViewType.Year)
            {
                daycount = 365;
            }
            else if (view == Manager.ViewType.Custom)
            {
                if (isAll)
                {
                    QuickOverView();
                    return;
                }

                DateTime st = new DateTime(startDate.Year, startDate.Month, startDate.Day);
                DateTime ed = new DateTime(endDate.Year, endDate.Month, endDate.Day);
                TimeSpan difference = ed - st;
                daycount = (int)difference.TotalDays;
            }
            else
            {
                daycount = 0;
            }

            QuickOverView();
        }

        private void SpendingReport(DateTime dt, Manager.ViewType view)
        {
            monthSpendingReportChart.Series.Clear();
            monthSpendingReportChart.AxisX.Clear();
            monthSpendingReportChart.AxisY.Clear();

            weekSpendingReportChart.Series.Clear();
            weekSpendingReportChart.AxisX.Clear();
            weekSpendingReportChart.AxisY.Clear();

            ColumnSeries columnSeries = new ColumnSeries();
            Axis axisX = new Axis();
            Axis axisY = new Axis();

            List<ExpenseTrackerDS.Transaction> currentTransactions = Communicator.Manager.FetchTransactionOnDates<List<ExpenseTrackerDS.Transaction>>(dt, dt, Manager.ViewType.Month, walletId);

            float cur_total = 0;
            foreach (ExpenseTrackerDS.Transaction transaction in currentTransactions)
            {
                cur_total += transaction.Amount;
            }

            List<ExpenseTrackerDS.Transaction> previousTransactions = Communicator.Manager.FetchTransactionOnDates<List<ExpenseTrackerDS.Transaction>>(dt.AddMonths(-1), dt.AddMonths(-1), Manager.ViewType.Month, walletId);

            float pre_total = 0;
            foreach (ExpenseTrackerDS.Transaction transaction in previousTransactions)
            {
                pre_total += transaction.Amount;
            }

            columnSeries = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<float>(),
                LabelPoint = point => point.Y.ToString(),
                Fill = System.Windows.Media.Brushes.Red
            };

            axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };

            axisY = new Axis()
            {
                LabelFormatter = y => y.ToString(),
                Separator = new Separator()
            };

            monthSpendingReportChart.Series.Add(columnSeries);
            monthSpendingReportChart.AxisX.Add(axisX);
            monthSpendingReportChart.AxisY.Add(axisY);

            columnSeries.Values.Add(pre_total);
            axisX.Labels.Add("Last month");

            columnSeries.Values.Add(cur_total);
            axisX.Labels.Add("This month");

            monthSpendingReportChart.BringToFront();

            currentTransactions.Clear();
            previousTransactions.Clear();

            currentTransactions = Communicator.Manager.FetchTransactionOnDates<List<ExpenseTrackerDS.Transaction>>(dt, dt, Manager.ViewType.Week, walletId);

            cur_total = 0;
            foreach (ExpenseTrackerDS.Transaction transaction in currentTransactions)
            {
                cur_total += transaction.Amount;
            }

            previousTransactions = Communicator.Manager.FetchTransactionOnDates<List<ExpenseTrackerDS.Transaction>>(dt.AddDays(-7), dt.AddDays(-7), Manager.ViewType.Week, walletId);

            pre_total = 0;
            foreach (ExpenseTrackerDS.Transaction transaction in previousTransactions)
            {
                pre_total += transaction.Amount;
            }

            columnSeries = new ColumnSeries()
            {
                DataLabels = true,
                Values = new ChartValues<float>(),
                LabelPoint = point => point.Y.ToString(),
                Fill = System.Windows.Media.Brushes.Orange
            };

            axisX = new Axis()
            {
                Separator = new Separator() { Step = 1, IsEnabled = false },
                Labels = new List<string>()
            };

            axisY = new Axis()
            {
                LabelFormatter = y => y.ToString(),
                Separator = new Separator()
            };
            weekSpendingReportChart.Series.Add(columnSeries);
            weekSpendingReportChart.AxisX.Add(axisX);
            weekSpendingReportChart.AxisY.Add(axisY);

            columnSeries.Values.Add(pre_total);
            axisX.Labels.Add("Last week");

            columnSeries.Values.Add(cur_total);
            axisX.Labels.Add("This week");

        }

        private void QuickOverView()
        {
            incomeRupee.Text = "₹ " + incomeRupeeFloat.ToString();
            expenseRupee.Text = "-₹ " + expenseRupeeFloat.ToString();
            float ans = incomeRupeeFloat - expenseRupeeFloat;
            totalRupee.Text = ans.ToString();
            cntIncome.Text = incomeCountFloat.ToString();
            cntExpense.Text = expenseCountFloat.ToString();
            float avgIncome = incomeRupeeFloat / incomeCountFloat;
            aveIncomeRecord.Text = "₹ " + avgIncome.ToString();
            float avgExpense = expenseRupeeFloat / expenseCountFloat;
            avgExpenseRecord.Text = "-₹ " + avgExpense.ToString();
            totalIncome.Text = "₹ " + incomeRupeeFloat.ToString();
            TotalExpense.Text = "-₹ " + expenseRupeeFloat.ToString();
            float avgDayIncomeFloat = avgIncome / daycount;
            aveIncomeDay.Text = "₹ " + avgDayIncomeFloat.ToString();
            float avgDayExpenseFloat = avgExpense / daycount;
            avgExpenseDay.Text = "-₹ " + avgDayExpenseFloat.ToString();
            cashflowAmt.Text = totalRupee.Text;
        }


        private void ShowFunction()
        {
            this.BackColor = GUIStyles.backColor;
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;
            incomeLbl.ForeColor = GUIStyles.primaryColor;
            expenseLbl.ForeColor = GUIStyles.primaryColor;
            walletLbl.ForeColor = GUIStyles.primaryColor;
            quickOverviewLbl.ForeColor = GUIStyles.primaryColor;
            compareLbl.ForeColor = GUIStyles.primaryColor;
            seeReportsByCategory.ForeColor = GUIStyles.primaryColor;
            seeWalletLbl.ForeColor = GUIStyles.primaryColor;
            switchLabel.ForeColor = GUIStyles.primaryColor;
            date1Panel.BackColor = GUIStyles.primaryColor;
            date2Panel.BackColor = GUIStyles.primaryColor;
            date3Panel.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            date3.BackColor = GUIStyles.primaryColor;
            date1.FlatAppearance.BorderColor = GUIStyles.primaryColor;
            date2.FlatAppearance.BorderColor = GUIStyles.primaryColor;
            date3.FlatAppearance.BorderColor = GUIStyles.primaryColor;
            date1.FlatAppearance.BorderSize = 2;
            date2.FlatAppearance.BorderSize = 2;
            date3.FlatAppearance.BorderSize = 2;
            date1.ForeColor = GUIStyles.primaryColor;
            date2.ForeColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.whiteColor;
            borderPanel.BackColor = GUIStyles.primaryColor;
            timeSelectPanel.BackColor = GUIStyles.backColor;
            border1.BackColor = GUIStyles.primaryColor;
            borderPanel.Location = new Point(445, 397);
            borderPanel.BringToFront();

            date1Panel.Hide();
            date2Panel.Hide();
            switchLabel.Hide();
            date3Panel.Hide();
            dayTick.Hide();
            weekTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Hide();
            timeSelectPanel.Hide();
            borderPanel.Hide();
            categoryReport.Hide();
        }

        private void AddOptions()
        {
            if (viewday.Count == 0 && viewweek.Count == 0 && viewmonth.Count == 0 && viewquarter.Count == 0 && viewyear.Count == 0)
            {
                TransactionEditor.AddDay();
                TransactionEditor.AddWeek();
                TransactionEditor.AddMonth();
                TransactionEditor.AddQuarter();
                TransactionEditor.AddYear();
                viewday = new List<string>(TransactionEditor.viewday);
                viewweek = new List<string>(TransactionEditor.viewweek);
                viewmonth = new List<string>(TransactionEditor.viewmonth);
                viewquarter = new List<string>(TransactionEditor.viewquarter);
                viewyear = new List<string>(TransactionEditor.viewyear);
                viewday.RemoveAt(TransactionEditor.viewday.Count - 1);
                viewweek.RemoveAt(TransactionEditor.viewweek.Count - 1);
                viewmonth.RemoveAt(TransactionEditor.viewmonth.Count - 1);
                viewquarter.RemoveAt(TransactionEditor.viewquarter.Count - 1);
                viewyear.RemoveAt(TransactionEditor.viewyear.Count - 1);
            }
        }

        private void FindData()
        {
            string str = "";

            if (date1.BackColor == GUIStyles.primaryColor)
                str = date1.Text;
            else if (date2.BackColor == GUIStyles.primaryColor)
                str = date2.Text;
            else if (date3.BackColor == GUIStyles.primaryColor)
                str = date3.Text;

            if (seletedType == "Day")
            {
                dt = TransactionEditor.FindDay(str);
                IncomeReport(dt, dt, Manager.ViewType.Day);
                ExpenseReport(dt, Manager.ViewType.Day);
                SpendingReport(DateTime.Now, Manager.ViewType.Day);
            }
            else if (seletedType == "Week")
            {
                dt = TransactionEditor.FindWeek(str);
                IncomeReport(dt, dt, Manager.ViewType.Week);
                ExpenseReport(dt, Manager.ViewType.Week);
                SpendingReport(DateTime.Now, Manager.ViewType.Week);
            }
            else if (seletedType == "Month")
            {
                dt = TransactionEditor.FindMonth(str);
                IncomeReport(dt, dt, Manager.ViewType.Month);
                ExpenseReport(dt, Manager.ViewType.Month);
                SpendingReport(DateTime.Now, Manager.ViewType.Month);
            }
            else if (seletedType == "Quarter")
            {
                dt = TransactionEditor.FindQuarter(str);
                IncomeReport(dt, dt, Manager.ViewType.Quarter);
                ExpenseReport(dt, Manager.ViewType.Quarter);
                SpendingReport(DateTime.Now, Manager.ViewType.Quarter);
            }
            else if (seletedType == "Year")
            {
                dt = TransactionEditor.FindYear(str);
                IncomeReport(dt, dt, Manager.ViewType.Year);
                ExpenseReport(dt, Manager.ViewType.Year);
                SpendingReport(DateTime.Now, Manager.ViewType.Year);
            }
            else if (seletedType == "custom")
            {
                IncomeReport(dt, dt, Manager.ViewType.Custom);
                ExpenseReport(dt, Manager.ViewType.Custom);
                SpendingReport(DateTime.Now, Manager.ViewType.Custom);
            }
        }

        private void ViewByDateIndexChanged()
        {
            if (seletedType == "Day")
            {
                presentday = viewday.Count - 3;
                date1.Text = viewday[presentday];
                date2.Text = viewday[presentday + 1];
                date3.Text = viewday[presentday + 2];
            }
            else if (seletedType == "Week")
            {
                presentweek = viewweek.Count - 3;
                date1.Text = viewweek[presentweek];
                date2.Text = viewweek[presentweek + 1];
                date3.Text = viewweek[presentweek + 2];
            }
            else if (seletedType == "Month")
            {
                presentmonth = viewmonth.Count - 3;
                date1.Text = viewmonth[presentmonth];
                date2.Text = viewmonth[presentmonth + 1];
                date3.Text = viewmonth[presentmonth + 2];
            }
            else if (seletedType == "Quarter")
            {
                presentquarter = viewquarter.Count - 3;
                date1.Text = viewquarter[presentquarter];
                date2.Text = viewquarter[presentquarter + 1];
                date3.Text = viewquarter[presentquarter + 2];
            }
            else if (seletedType == "Year")
            {
                presentyear = viewyear.Count - 3;
                date1.Text = viewyear[presentyear];
                date2.Text = viewyear[presentyear + 1];
                date3.Text = viewyear[presentyear + 2];
            }
            FindData();
        }

        public void Reload()
        {
            SeeReports_Load(this, EventArgs.Empty);
            categoryReport.Reload();
            walletView1.Hide();
            choiceShowPanel.Hide();
        }

        private void SeeReports_Load(object sender, EventArgs e)
        {
            AddOptions();
            isAll = false;
            choicePicture.Location = new Point(this.Width - rightPanel.Width - choicePicture.Width - 50, choicePicture.Location.Y);
            border1.Width = this.Width;
            borderPanel.Location = new Point(445, 397);
            borderPanel.BringToFront();

            ShowFunction();
            date3.BackColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.whiteColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            SpendingReport(DateTime.Now, Manager.ViewType.Month);
            IncomeReport(DateTime.Now, DateTime.Now, Manager.ViewType.Month);
            ExpenseReport(DateTime.Now, Manager.ViewType.Month);
            seletedType = monthLabel.Text;
            categoryReport.Hide();
            categoryReport.Reload();

            customDatePanel.Hide();

            categoryReport.BackClick += OnCategoryReport2_BackClick;
            MonthPanel_Click(this, EventArgs.Empty);
            ViewByDateIndexChanged();
            UpdateWallet();

            startDateCalendar.Hide();
            endDateCalendar.Hide();
            ShowBalanceAmt();
            SetStyles();
        }

        private void UpdateWallet()
        {
            List<Wallet> result = Communicator.Manager.FetchWallet();
            if (result.Count > 0)
            {
                wallet1Lbl.Text = result[result.Count - 1].WalletName;
                walletAmount1.Text = "₹ " + result[result.Count - 1].Amount;
                if (result.Count > 1)
                {
                    wallet2Lbl.Text = result[result.Count - 2].WalletName;
                    walletAmount2.Text = "₹ " + result[result.Count - 2].Amount;

                    if (result.Count > 2)
                    {
                        wallet3Lbl.Text = result[result.Count - 3].WalletName;
                        walletAmount3.Text = "₹ " + result[result.Count - 3].Amount;
                    }
                    else
                    {
                        wallet3Lbl.Text = "";
                        walletAmount3.Text = "";
                        wallet3.Hide();
                    }
                }
                else
                {
                    wallet2Lbl.Text = "";
                    walletAmount2.Text = "";
                    wallet3Lbl.Text = "";
                    walletAmount3.Text = "";

                    wallet2.Hide();
                    wallet3.Hide();
                }
            }
            else
            {
                wallet1Lbl.Text = "";
                walletAmount1.Text = "";
                wallet2Lbl.Text = "";
                walletAmount2.Text = "";
                wallet3Lbl.Text = "";
                walletAmount3.Text = "";

                wallet1.Hide();
                wallet2.Hide();
                wallet3.Hide();
            }
        }

        private void OnCategoryReport2_BackClick(object sender, EventArgs e)
        {
            categoryReport.Hide();
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
        }

        private void date1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            date2.BackColor = GUIStyles.primaryColor;
            date2.ForeColor = GUIStyles.whiteColor;
            date3.ForeColor = GUIStyles.primaryColor;
            date3.BackColor = GUIStyles.whiteColor;
            if (btn == date1)
            {
                date2.BackColor = GUIStyles.whiteColor;
                date3.BackColor = GUIStyles.whiteColor;
                date2.ForeColor = GUIStyles.primaryColor;
                date3.ForeColor = GUIStyles.primaryColor;

                if (seletedType == "Day")
                {
                    if (presentday - 1 >= 0)
                    {
                        presentday--;
                        date1.Text = viewday[presentday];
                        date2.Text = viewday[presentday + 1];
                        date3.Text = viewday[presentday + 2];
                        Button2Color();
                    }
                    else
                    {
                        Button1Color();
                        if (date1.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                    }
                }
                else if (seletedType == "Week")
                {
                    if (presentweek - 1 >= 0)
                    {
                        presentweek--;
                        date1.Text = viewweek[presentweek];
                        date2.Text = viewweek[presentweek + 1];
                        date3.Text = viewweek[presentweek + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date1.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button1Color();
                    }
                }
                else if (seletedType == "Month")
                {
                    if (presentmonth - 1 >= 0)
                    {
                        presentmonth--;
                        date1.Text = viewmonth[presentmonth];
                        date2.Text = viewmonth[presentmonth + 1];
                        date3.Text = viewmonth[presentmonth + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date1.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button1Color();
                    }
                }
                else if (seletedType == "Quarter")
                {
                    if (presentquarter - 1 >= 0)
                    {
                        presentquarter--;
                        date1.Text = viewquarter[presentquarter];
                        date2.Text = viewquarter[presentquarter + 1];
                        date3.Text = viewquarter[presentquarter + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date1.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button1Color();
                    }
                }
                else if (seletedType == "Year")
                {
                    if (presentyear - 1 >= 0)
                    {
                        presentyear--;
                        date1.Text = viewyear[presentyear];
                        date2.Text = viewyear[presentyear + 1];
                        date3.Text = viewyear[presentyear + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date1.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button1Color();
                    }
                }
                FindData();
            }
            else if (btn == date2)
            {
                date1.BackColor = GUIStyles.whiteColor;
                date3.BackColor = GUIStyles.whiteColor;
                date1.ForeColor = GUIStyles.primaryColor;
                date3.ForeColor = GUIStyles.primaryColor;
                Button2Color();
                FindData();
            }
            else if (btn == date3)
            {
                date2.BackColor = GUIStyles.whiteColor;
                date1.BackColor = GUIStyles.whiteColor;
                date2.ForeColor = GUIStyles.primaryColor;
                date1.ForeColor = GUIStyles.primaryColor;
                if (seletedType == "Day")
                {
                    if (presentday + 1 <= viewday.Count - 3)
                    {
                        presentday++;
                        date1.Text = viewday[presentday];
                        date2.Text = viewday[presentday + 1];
                        date3.Text = viewday[presentday + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date3.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button3Color();
                    }
                }
                else if (seletedType == "Week")
                {
                    if (presentweek + 1 <= viewweek.Count - 3)
                    {
                        presentweek++;
                        date1.Text = viewweek[presentweek];
                        date2.Text = viewweek[presentweek + 1];
                        date3.Text = viewweek[presentweek + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date3.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button3Color();
                    }
                }
                else if (seletedType == "Month")
                {
                    if (presentmonth + 1 <= viewmonth.Count - 3)
                    {
                        presentmonth++;
                        date1.Text = viewmonth[presentmonth];
                        date2.Text = viewmonth[presentmonth + 1];
                        date3.Text = viewmonth[presentmonth + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date3.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button3Color();
                    }
                }
                else if (seletedType == "Quarter")
                {
                    if (presentquarter + 1 <= viewquarter.Count - 3)
                    {
                        presentquarter++;
                        date1.Text = viewquarter[presentquarter];
                        date2.Text = viewquarter[presentquarter + 1];
                        date3.Text = viewquarter[presentquarter + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date3.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button3Color();
                    }
                }
                else if (seletedType == "Year")
                {
                    if (presentyear + 1 <= viewyear.Count - 3)
                    {
                        presentyear++;
                        date1.Text = viewyear[presentyear];
                        date2.Text = viewyear[presentyear + 1];
                        date3.Text = viewyear[presentyear + 2];
                        Button2Color();
                    }
                    else
                    {
                        if (date3.BackColor == GUIStyles.primaryColor)
                        {
                            return;
                        }
                        Button3Color();
                    }
                }
                FindData();
            }
        }

        private void Button1Color()
        {
            ActiveControl = date1;
            date1.BackColor = GUIStyles.primaryColor;
            date2.BackColor = GUIStyles.whiteColor;
            date3.BackColor = GUIStyles.whiteColor;
            date1.ForeColor = GUIStyles.whiteColor;
            date2.ForeColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.primaryColor;
        }

        private void Button2Color()
        {
            ActiveControl = date2;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.primaryColor;
            date3.BackColor = GUIStyles.whiteColor;
            date2.ForeColor = GUIStyles.whiteColor;
            date1.ForeColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.primaryColor;
        }

        private void Button3Color()
        {
            ActiveControl = date3;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = Color.White;
            date3.BackColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.whiteColor;
            date2.ForeColor = GUIStyles.primaryColor;
            date1.ForeColor = GUIStyles.primaryColor;
        }

        private void date1_MouseEnter(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //btn.BackColor = GUIStyles.primaryColor;
            //btn.ForeColor = GUIStyles.whiteColor;
        }

        private void date1_MouseLeave(object sender, EventArgs e)
        {
            //Button btn = (Button)sender;
            //btn.BackColor = GUIStyles.whiteColor;
            //btn.ForeColor = GUIStyles.primaryColor;
        }

        private void choicePicture_Click(object sender, EventArgs e)
        {
            date3.BackColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.whiteColor;
            date2.ForeColor = GUIStyles.primaryColor;
            date2.BackColor = GUIStyles.whiteColor;
            date1.ForeColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            balanceAndFetchPanel.Enabled = false;
            choiceShowPanel.Enabled = false;
            openingAndEndingBalance.Enabled = false;
            seeReportsByCategory.Enabled = false;
            walletPanel.Enabled = false;
            expensePanel.Enabled = false;
            incomePanel.Enabled = false;
            quickOverviewPanel.Enabled = false;
            borderPanel.Show();
            timeSelectPanel.Show();
            timeSelectPanel.BringToFront();
        }

        private void dayPanel_Click(object sender, EventArgs e)
        {
            isAll = false;
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            dayTick.Show();
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Hide();
            seletedType = "Day";
            borderPanel.Hide();
            timeSelectPanel.Hide();
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void weekPanel_Click(object sender, EventArgs e)
        {
            isAll = false;
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            dayTick.Hide();
            weekTick.Show();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Hide();
            seletedType = "Week";
            borderPanel.Hide();
            timeSelectPanel.Hide();
            date3Panel.BackColor = GUIStyles.primaryColor;
            date1Panel.BackColor = GUIStyles.whiteColor;
            date2Panel.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void MonthPanel_Click(object sender, EventArgs e)
        {
            isAll = false;
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            dayTick.Hide();
            weekTick.Hide();
            monthTick.Show();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Hide();
            seletedType = "Month";
            borderPanel.Hide();
            timeSelectPanel.Hide();
            date3Panel.BackColor = GUIStyles.primaryColor;
            date1Panel.BackColor = GUIStyles.whiteColor;
            date2Panel.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void quarterPanel_Click(object sender, EventArgs e)
        {
            isAll = false;
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            dayTick.Hide();
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Show();
            yearTick.Hide();
            allTick.Hide();
            customTick.Hide();
            seletedType = "Quarter";
            borderPanel.Hide();
            timeSelectPanel.Hide();
            date3Panel.BackColor = GUIStyles.primaryColor;
            date1Panel.BackColor = GUIStyles.whiteColor;
            date2Panel.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void yearPanel_Click(object sender, EventArgs e)
        {
            isAll = false;
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            dayTick.Hide();
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Show();
            allTick.Hide();
            customTick.Hide();
            seletedType = "Year";
            borderPanel.Hide();
            timeSelectPanel.Hide();
            date3Panel.BackColor = GUIStyles.primaryColor;
            date1Panel.BackColor = GUIStyles.whiteColor;
            date2Panel.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void allPanel_Click(object sender, EventArgs e)
        {
            dayTick.Hide();
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Show();
            customTick.Hide();
            seletedType = "All";
            isAll = true;
            borderPanel.Hide();
            timeSelectPanel.Hide();
            date1.Hide();
            date2.Hide();
            date3.Hide();
            IncomeReport(DateTime.Now, DateTime.Now, Manager.ViewType.Custom);
            ExpenseReport(DateTime.Now, Manager.ViewType.Custom);
        }

        private void customPanel_Click(object sender, EventArgs e)
        {
            isAll = false;
            balanceAndFetchPanel.Enabled = false;
            choiceShowPanel.Enabled = false;
            openingAndEndingBalance.Enabled = false;
            seeReportsByCategory.Enabled = false;
            walletPanel.Enabled = false;
            expensePanel.Enabled = false;
            incomePanel.Enabled = false;
            quickOverviewPanel.Enabled = false;
            dayTick.Hide();
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Show();
            seletedType = "Custom";
            customDatePanel.BackColor = GUIStyles.primaryColor;
            cancelBtn.BackColor = GUIStyles.primaryColor;
            cancelBtn.ForeColor = GUIStyles.whiteColor;
            cancelBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            selectBtn.BackColor = GUIStyles.primaryColor;
            selectBtn.ForeColor = GUIStyles.whiteColor;
            selectBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            customDatePanel.Location = new Point(540, 520);
            customDatePanel.Show();
            borderPanel.Enabled = false;
            customDatePanel.BringToFront();
            betweenTime.BackColor = GUIStyles.backColor;
            betweenTime.BringToFront();
            ViewByDateIndexChanged();
            date1.Hide();
            date2.Hide();
            date3.Hide();
        }

        private void seeReportsByCategory_Click(object sender, EventArgs e)
        {
            categoryReport.wallet_Id = walletId;
            categoryReport.Location = new Point(270, 140);
            balanceAndFetchPanel.Enabled = false;
            choiceShowPanel.Enabled = false;
            openingAndEndingBalance.Enabled = false;
            seeReportsByCategory.Enabled = false;
            walletPanel.Enabled = false;
            expensePanel.Enabled = false;
            incomePanel.Enabled = false;
            quickOverviewPanel.Enabled = false;
            categoryReport.Show();
            categoryReport.BringToFront();
        }

        private void dropDownWallet_Click(object sender, EventArgs e)
        {
            walletView1.Show();
            balanceAndFetchPanel.Enabled = false;
            choiceShowPanel.Enabled = false;
            openingAndEndingBalance.Enabled = false;
            seeWalletLbl.Enabled = false;
            switchGraph.Enabled = false;
            seeReportsByCategory.Enabled = false;
        }

        //private void ChangeWallet_WalletClose(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        public event EventHandler WalletView;

        private void seeWalletLbl_Click(object sender, EventArgs e)
        {
            WalletView?.Invoke(this, EventArgs.Empty);
        }

        private void date1Lbl_Click_1(object sender, EventArgs e)
        {
            startDateCalendar.BringToFront();
            startDateCalendar.Show();
        }

        private void walletView1_WalletClose(object sender, EventArgs e)
        {
            walletView1.Hide();
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeWalletLbl.Enabled = true;
            switchGraph.Enabled = true;
            seeReportsByCategory.Enabled = true;
        }

        private void walletView1_WalletSelect(Image image, Wallet e)
        {
            balanceAmtLbl.Text = "₹ " + e.Amount.ToString();
            walletName.Text = e.WalletName;
            walletId = e.WalletID;
            categoryReport.wallet_Id = walletId;
            SpendingReport(DateTime.Now, Manager.ViewType.Month);
            IncomeReport(DateTime.Now, DateTime.Now, Manager.ViewType.Month);
            ExpenseReport(DateTime.Now, Manager.ViewType.Month);
            seletedType = monthLabel.Text;
            openingBalanceAmt.Text = e.OpeningBalance.ToString();
            endingBalanceAmt.Text = e.Amount.ToString();
            walletView1.Hide();
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeWalletLbl.Enabled = true;
            switchGraph.Enabled = true;
            seeReportsByCategory.Enabled = true;
        }

        private void date2Label_Click_1(object sender, EventArgs e)
        {
            endDateCalendar.BringToFront();
            endDateCalendar.Show();
        }

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            borderPanel.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            borderPanel.Hide();
            timeSelectPanel.Hide();
            customDatePanel.Hide();
        }

        private void selectBtn_Click_1(object sender, EventArgs e)
        {
            IncomeReport(startDate, endDate, Manager.ViewType.Custom);
            ExpenseReport(startDate, Manager.ViewType.Custom);
            balanceAndFetchPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            openingAndEndingBalance.Enabled = true;
            seeReportsByCategory.Enabled = true;
            borderPanel.Enabled = true;
            walletPanel.Enabled = true;
            expensePanel.Enabled = true;
            incomePanel.Enabled = true;
            quickOverviewPanel.Enabled = true;
            borderPanel.Hide();
            timeSelectPanel.Hide();
            customDatePanel.Hide();
            if (date1Lbl.Text == "Yesterday")
            {
                startDate = DateTime.Now.AddDays(-1);
            }
            if (date2Label.Text == "Today")
            {
                endDate = DateTime.Now;
            }
            date1.Text = startDate.ToString("dd/MM/yyyy") + " - " + endDate.ToString("dd/MM/yyyy");
            date1.Enabled = false;
            date1.Show();
            date2.Hide();
            date3.Hide();
        }

        private void endDateCalendar_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            endDate = endDateCalendar.SelectionRange.Start;
            if (startDate > endDate)
            {
                MessageBox.Show("Select valid date.");
            }
            else
            {
                endDateCalendar.Hide();
                date2Label.Text = endDate.ToString("dd/MM/yyyy");
            }
        }

        private void startDateCalendar_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            startDate = startDateCalendar.SelectionRange.Start;
            if (startDate > endDate)
            {
                endDate = startDate;
                date2Label.Text = endDate.ToString("dd/MM/yyyy");
            }
            startDateCalendar.Hide();
            date1Lbl.Text = startDate.ToString("dd/MM/yyyy");
            endDateCalendar.MinDate = startDate;
        }

        private void switchGraph_Click(object sender, EventArgs e)
        {
            switchCnt++;
            if (switchCnt % 2 != 0)
            {
                switchLabel.Show();
            }
            else
            {
                switchLabel.Hide();
            }
        }

        private void switchLabel_Click(object sender, EventArgs e)
        {
            if (switchLabel.Text == "Week")
            {
                weekSpendingReportChart.BringToFront();
                switchLabel.Text = "Month";
            }
            else
            {
                monthSpendingReportChart.Update();
                monthSpendingReportChart.BringToFront();
                switchLabel.Text = "Week";
            }
            switchLabel.Hide();
            switchCnt = 0;
        }

        private void switchLabel_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = GUIStyles.primaryColor;
            label.ForeColor = GUIStyles.whiteColor;
        }

        private void switchLabel_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            label.BackColor = GUIStyles.whiteColor;
            label.ForeColor = GUIStyles.primaryColor;
        }
    }
}