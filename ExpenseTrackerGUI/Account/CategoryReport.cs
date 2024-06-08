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
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI.Account
{
    public partial class CategoryReport : UserControl
    {
        #region Constructor & Events

        public CategoryReport()
        {
            InitializeComponent();
            if (DesignMode) return;
            Reload();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
        }

        private void OnGUIStyles_ColorChanged(bool e)
        {
            Reload();
        }

        public event EventHandler BackClick;

        #endregion

        #region Variable creation & User defined functions

        List<string> viewday = new List<string>();
        List<string> viewweek = new List<string>();
        List<string> viewmonth = new List<string>();
        List<string> viewquarter = new List<string>();
        List<string> viewyear = new List<string>();

        DateTime dt;
        DateTime startDate, endDate;
        Category category = new Category();
        static string seletedType = "";
        int presentmonth = 0, presentyear = 0, presentday = 0, presentquarter = 0, presentweek;
        bool isAll = false;
        public int wallet_Id = 0;
        public string category_Name = "Internet Bill";

        public void Reload()
        {
            SetStyles();
            ShowFunction();
            AddOptions();
            date3.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            seletedType = monthLabel.Text;
            dayLabel.ForeColor = GUIStyles.primaryColor;
            weekLabel.ForeColor = GUIStyles.primaryColor;
            monthLabel.ForeColor = GUIStyles.primaryColor;
            quarterLabel.ForeColor = GUIStyles.primaryColor;
            yearLabel.ForeColor = GUIStyles.primaryColor;
            customLabel.ForeColor = GUIStyles.primaryColor;
            allLabel.ForeColor = GUIStyles.primaryColor;
            ShowChart(dt, Manager.ViewType.Month);
            MonthPanel_Click_1(this, EventArgs.Empty);
            ViewByDateIndexChanged();
            noTransactionPanel.Hide();
            customDatePanel.Hide();
            customDatePanel.BackColor = GUIStyles.primaryColor;
            betweenTime.BackColor = GUIStyles.whiteColor;
            CategoryReport_Load(this, EventArgs.Empty);
        }

        private void ShowChart(DateTime dt, Manager.ViewType view)
        {
            Dictionary<string, List<ExpenseTrackerDS.Transaction>> res = new Dictionary<string, List<ExpenseTrackerDS.Transaction>>();
            if (isAll)
            {
                var result = Communicator.Manager.FetchTransactions<List<Transaction>>(0);
                for (int i = 0; i < result.Count; i++)
                {
                    if (res.ContainsKey(result[i].CategoryName))
                    {
                        res[result[i].CategoryName].Add(result[i]);
                    }
                    else
                    {
                        res.Add(result[i].CategoryName, new List<ExpenseTrackerDS.Transaction>() { result[i] });
                    }
                }
            }
            else
            {
                if (view == Manager.ViewType.Custom)
                {
                    res = Communicator.Manager.FetchTransactionOnDates<Dictionary<string, List<ExpenseTrackerDS.Transaction>>>(startDate, endDate, view, wallet_Id);
                }
                else
                {
                    res = Communicator.Manager.FetchTransactionOnDates<Dictionary<string, List<ExpenseTrackerDS.Transaction>>>(dt, dt, view, wallet_Id);
                }
            }

            barChart.Series.Clear();
            barChart.AxisX.Clear();
            barChart.AxisY.Clear();
            ColumnSeries columnSeries = new ColumnSeries();
            Axis axisX = new Axis();
            Axis axisY = new Axis();
            if (res != null && res.Count > 0)
            {
                noTransactionPanel.Hide();
                chartPanel.Show();
                columnSeries = new ColumnSeries()
                {
                    DataLabels = true,
                    Values = new ChartValues<float>(),
                    LabelPoint = point => point.Y.ToString(),
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

                barChart.Series.Add(columnSeries);
                barChart.AxisX.Add(axisX);
                barChart.AxisY.Add(axisY);
                float total = 0;

                foreach (var d in res)
                {
                    foreach (ExpenseTrackerDS.Transaction t in d.Value)
                    {
                        total += t.Amount;
                    }
                }

                if (total == 0)
                {
                    noTransactionPanel.Show();
                }
                else
                {
                    noTransactionPanel.Hide();
                }

                foreach (var d in res)
                {
                    float t = 0;
                    foreach (ExpenseTrackerDS.Transaction t1 in d.Value)
                    {
                        t += t1.Amount;
                    }
                    float amount = (int)(t / total * 100);
                    columnSeries.Values.Add(amount);
                    axisX.Labels.Add(d.Key);
                }
            }
            else
            {
                chartPanel.Hide();
                noTransactionPanel.Location = new Point(150, 400);
                noTransactionPanel.Show();
                noTransactionPanel.BringToFront();
            }
        }

        private void ShowFunction()
        {
            borderPanel.Location = new Point(112, 272);
            borderPanel.BringToFront();
            this.BackColor = GUIStyles.backColor;
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;
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
            dayTick.Hide();
            weekTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Hide();
            timeSelectPanel.Hide();
            borderPanel.Hide();
            borderPanel.BackColor = GUIStyles.primaryColor;
            timeSelectPanel.BackColor = GUIStyles.backColor;
            border1.BackColor = GUIStyles.primaryColor;
            borderPanel.BringToFront();
        }

        private void CategoryReport_Load(object sender, EventArgs e)
        {
            ShowChart(dt, Manager.ViewType.Month);
            choicePicture.Location = new Point(this.Width - rightPanel.Width - choicePicture.Width - 50, choicePicture.Location.Y);
            categoryReportLabel.ForeColor = GUIStyles.primaryColor;
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            borderPanel.BackColor = GUIStyles.primaryColor;
            timeSelectPanel.BackColor = GUIStyles.backColor;
            borderPanel.Hide();
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
                ShowChart(dt, Manager.ViewType.Day);
            }
            else if (seletedType == "Week")
            {
                dt = TransactionEditor.FindWeek(str);
                ShowChart(dt, Manager.ViewType.Week);
            }
            else if (seletedType == "Month")
            {
                dt = TransactionEditor.FindMonth(str);
                ShowChart(dt, Manager.ViewType.Month);
            }
            else if (seletedType == "Quarter")
            {
                dt = TransactionEditor.FindQuarter(str);
                ShowChart(dt, Manager.ViewType.Quarter);
            }
            else if (seletedType == "Year")
            {
                dt = TransactionEditor.FindYear(str);
                ShowChart(dt, Manager.ViewType.Year);
            }
            else if (seletedType == "Custom")
            {
                ShowChart(dt, Manager.ViewType.Custom);
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

        private void SetStyles()
        {
            if (GUIStyles.colorName == "black")
            {
                showBar.Image = Image.FromFile(@".\Images\bar3.png");
                backPicture.Image = Image.FromFile(@".\Images\a3.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal2.png");
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
                nodataPicture.Image = Image.FromFile(@".\Images\o2.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                showBar.Image = Image.FromFile(@".\Images\bar2.png");
                backPicture.Image = Image.FromFile(@".\Images\a4.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal3.png");
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
                nodataPicture.Image = Image.FromFile(@".\Images\o5.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                showBar.Image = Image.FromFile(@".\Images\bar1.png");
                backPicture.Image = Image.FromFile(@".\Images\a5.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal.png");
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
                nodataPicture.Image = Image.FromFile(@".\Images\o1.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                showBar.Image = Image.FromFile(@".\Images\bar5.png");
                backPicture.Image = Image.FromFile(@".\Images\a1.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal1.png");
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
                nodataPicture.Image = Image.FromFile(@".\Images\o4.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                showBar.Image = Image.FromFile(@".\Images\bar4.png");
                backPicture.Image = Image.FromFile(@".\Images\a2.png");
                choicePicture.Image = Image.FromFile(@".\Images\cal4.png");
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
                nodataPicture.Image = Image.FromFile(@".\Images\o3.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                showBar.Image = Image.FromFile(@".\Images\z3.png");
                backPicture.Image = Image.FromFile(@".\Images\z35.png");
                choicePicture.Image = Image.FromFile(@".\Images\z9.png");
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
                nodataPicture.Image = Image.FromFile(@".\Images\z22.png");
            }
        }

        #endregion

        #region Click events

        private void date3_Click(object sender, EventArgs e)
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

        private void backPicture_Click(object sender, EventArgs e)
        {
            BackClick?.Invoke(this, EventArgs.Empty);
        }

        private void choicePicture_Click_1(object sender, EventArgs e)
        {            
            noTransactionPanel.Hide();
            noTransactionPanel.SendToBack();
            date3.BackColor = GUIStyles.primaryColor;
            date3.ForeColor = GUIStyles.whiteColor;
            date2.ForeColor = GUIStyles.primaryColor;
            date2.BackColor = GUIStyles.whiteColor;
            date1.ForeColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            borderPanel.BringToFront();
            borderPanel.Show();
            categoryReportPanel.Enabled = false;
            choiceShowPanel.Enabled = false;
            chartPanel.Enabled = false;
            timeSelectPanel.Show();
            timeSelectPanel.BringToFront();            
        }

        private void dayPanel_Click_1(object sender, EventArgs e)
        {
            isAll = false;
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
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
            date3.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void weekPanel_Click_1(object sender, EventArgs e)
        {
            isAll = false;
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
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
            date3.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void MonthPanel_Click_1(object sender, EventArgs e)
        {
            isAll = false;
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
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
            date3.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void date1Lbl_Click_1(object sender, EventArgs e)
        {
            startDateCalendar.BringToFront();
            startDateCalendar.Show();
        }

        private void date2Label_Click_1(object sender, EventArgs e)
        {
            endDateCalendar.BringToFront();
            endDateCalendar.Show();
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

        private void cancelBtn_Click_1(object sender, EventArgs e)
        {
            choiceShowPanel.Enabled = true;
            categoryReportPanel.Enabled = true;
            borderPanel.Enabled = true;
            chartPanel.Enabled = true;
            borderPanel.Hide();
            timeSelectPanel.Hide();
            customDatePanel.Hide();
            isAll = false;
            customDatePanel.Hide();
            seletedType = "Custom";
            if (date1Lbl.Text == "Yesterday")
            {
                startDate = DateTime.Now.AddDays(-1);
            }
            if (date2Label.Text == "Today")
            {
                endDate = DateTime.Now;
            }
            ViewByDateIndexChanged();
            date1.Enabled=true;
            date2.Hide();
            date3.Hide();
        }
        
        private void selectBtn_Click_1(object sender, EventArgs e)
        {
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
            borderPanel.Enabled = true;
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
            ShowChart(startDate, Manager.ViewType.Custom);
        }

        private void quarterPanel_Click_1(object sender, EventArgs e)
        {
            isAll = false;
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
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
            date3.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void yearPanel_Click_1(object sender, EventArgs e)
        {
            isAll = false;
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
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
            date3.BackColor = GUIStyles.primaryColor;
            date1.BackColor = GUIStyles.whiteColor;
            date2.BackColor = GUIStyles.whiteColor;
            ViewByDateIndexChanged();
            date1.Show();
            date2.Show();
            date3.Show();
            date1.Enabled = true;
        }

        private void allPanel_Click_1(object sender, EventArgs e)
        {
            isAll = true;
            categoryReportPanel.Enabled = true;
            choiceShowPanel.Enabled = true;
            chartPanel.Enabled = true;
            dayTick.Hide();
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Show();
            customTick.Hide();
            seletedType = "All";
            borderPanel.Hide();
            timeSelectPanel.Hide();
            ViewByDateIndexChanged();
            date1.Hide();
            date2.Hide();
            date3.Hide();
            ShowChart(DateTime.Now, Manager.ViewType.Custom);
        }

        private void customPanel_Click_1(object sender, EventArgs e)
        {
            isAll = false;
            categoryReportPanel.Enabled = false;
            choiceShowPanel.Enabled = false;
            chartPanel.Enabled = false;
            borderPanel.Enabled = false;
            dayTick.Hide();
            weekTick.Hide();
            monthTick.Hide();
            quarterTick.Hide();
            yearTick.Hide();
            allTick.Hide();
            customTick.Show();
            customDatePanel.BackColor = GUIStyles.primaryColor;
            cancelBtn.BackColor = GUIStyles.primaryColor;
            cancelBtn.ForeColor = GUIStyles.whiteColor;
            cancelBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            selectBtn.BackColor = GUIStyles.primaryColor;
            selectBtn.ForeColor = GUIStyles.whiteColor;
            selectBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            customDatePanel.Show();
            borderPanel.Enabled = false;
            customDatePanel.BringToFront();
            betweenTime.BackColor = GUIStyles.backColor;
            betweenTime.BringToFront();
            seletedType = "Custom";
            customDatePanel.BringToFront();
            customDatePanel.Show();
            startDateCalendar.Hide();
            endDateCalendar.Hide();
            ViewByDateIndexChanged();
            noTransactionPanel.Hide();
        }

        #endregion
    }
}
