using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace ExpenseTrackerGUI.Account
{
    public partial class WalkThrough : UserControl
    {
        public WalkThrough()
        {
            InitializeComponent();            
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!DesignMode)
            {
                label18.Text = "Food & Beverage";
                tabControl1.SelectedTab = transactionPage;
                dark1.BringToFront();
                dark2.SendToBack();
                dark3.SendToBack();
                dark4.SendToBack();

                topPanel.BackColor = GUIStyles.primaryColor;
                bottomPanel.BackColor = GUIStyles.primaryColor;
                rightPanel.BackColor = GUIStyles.primaryColor;
                leftPanel.BackColor = GUIStyles.primaryColor;
                transactionPage.BackColor = GUIStyles.backColor;
                reportPage.BackColor = GUIStyles.backColor;
                budgetPage.BackColor = GUIStyles.backColor;
                calculationsPage.BackColor = GUIStyles.backColor;
                transactionLbl.BackColor = GUIStyles.primaryColor;
                transactionLbl.ForeColor = GUIStyles.whiteColor;
                reportLbl.BackColor = GUIStyles.primaryColor;
                reportLbl.ForeColor = GUIStyles.whiteColor;
                budgetLbl.BackColor = GUIStyles.primaryColor;
                budgetLbl.ForeColor = GUIStyles.whiteColor;
                convertLbl.BackColor = GUIStyles.primaryColor;
                convertLbl.ForeColor = GUIStyles.whiteColor;  
                back1.BackColor = GUIStyles.primaryColor;
                back2.BackColor = GUIStyles.primaryColor;
                back3.BackColor = GUIStyles.primaryColor;
                back4.BackColor = GUIStyles.primaryColor;

                GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
                ShowPieChart();
            }
        }

        private void OnGUIStyles_ColorChanged(bool e)
        {
            SetStyles();
        }

        public void SetStyles()
        {
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            back1.BackColor = GUIStyles.primaryColor;
            headingPanel.BackColor = GUIStyles.primaryColor;
            transactionLbl.ForeColor = GUIStyles.whiteColor;
            transactionLbl.BackColor = GUIStyles.primaryColor;
            cardPanel1.CardBorderColor = GUIStyles.primaryColor;
            transactionPage.BackColor = GUIStyles.backColor;
            panel1.BackColor = GUIStyles.backColor;
            pictureBox12.BackColor = GUIStyles.backColor;
            cardPanel1.CardBackColor = GUIStyles.backColor;
            cardPanel1.CardFlickerColor = GUIStyles.backColor;
            transactionDiagram.BackColor = GUIStyles.backColor;               

            back2.BackColor = GUIStyles.primaryColor;
            reportLbl.BackColor = GUIStyles.primaryColor;
            reportLbl.ForeColor = GUIStyles.whiteColor;
            reportPage.BackColor = GUIStyles.backColor;

            budgetLbl.BackColor = GUIStyles.primaryColor;
            budgetLbl.ForeColor = GUIStyles.whiteColor;
            back3.BackColor = GUIStyles.primaryColor;
            budgetPage.BackColor = GUIStyles.backColor;
            cardPanel2.CardBorderColor = GUIStyles.primaryColor;

            calculationsPage.BackColor = GUIStyles.backColor;
            back4.BackColor = GUIStyles.primaryColor;
            convertLbl.BackColor = GUIStyles.primaryColor;
            convertLbl.ForeColor = GUIStyles.whiteColor;

            light1.BackColor = GUIStyles.backColor;
            light2.BackColor = GUIStyles.backColor;
            light3.BackColor = GUIStyles.backColor;
            light4.BackColor = GUIStyles.backColor;
            dark1.BackColor = GUIStyles.backColor;
            dark2.BackColor = GUIStyles.backColor;
            dark3.BackColor = GUIStyles.backColor;
            dark4.BackColor = GUIStyles.backColor;

        }

        private void ShowPieChart()
        {
            pieChart2.InnerRadius = 30;
            SeriesCollection piechartData = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Rentals",
                    Values = new ChartValues<double> {60},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Gas bill",
                    Values = new ChartValues<double> {50},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Travel",
                    Values = new ChartValues<double> {77},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Food",
                    Values = new ChartValues<double> {55},
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "Fun Money",
                    Values = new ChartValues<double> {30},
                    DataLabels = true,
                },
            };

            piechartData.Add(
                new PieSeries
                {
                    Title = "EB Bill",
                    Values = new ChartValues<double> { 25 },
                    DataLabels = true,
                }
            );
            pieChart2.Series = piechartData;
            pieChart2.LegendLocation = LegendLocation.Right;
        }

        private void headingLbl_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = reportPage;
            dark2.BringToFront();
            dark1.SendToBack();
            dark3.SendToBack();
            dark4.SendToBack();
        }

        private void title_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = budgetPage;
            dark3.BringToFront();
            dark1.SendToBack();
            dark2.SendToBack();
            dark4.SendToBack();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = calculationsPage;
            dark4.BringToFront();
            dark1.SendToBack();
            dark2.SendToBack();
            dark3.SendToBack();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = transactionPage;
            dark1.BringToFront();
            dark2.SendToBack();
            dark3.SendToBack();
            dark4.SendToBack();
        }

        private void light1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = transactionPage;
            dark1.BringToFront();
            dark2.SendToBack();
            dark3.SendToBack();
            dark4.SendToBack();
        }

        private void light2_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = reportPage;
            dark2.BringToFront();
            dark1.SendToBack();
            dark3.SendToBack();
            dark4.SendToBack();
        }

        private void light3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = budgetPage;
            dark3.BringToFront();
            dark1.SendToBack();
            dark2.SendToBack();
            dark4.SendToBack();
        }

        private void light4_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = calculationsPage;
            dark4.BringToFront();
            dark1.SendToBack();
            dark2.SendToBack();
            dark3.SendToBack();
        }

        private void pictureBox12_MouseEnter(object sender, EventArgs e)
        {
            pictureBox12.Size = new Size(pictureBox12.Width + 5, pictureBox12.Height + 5);
        }

        private void pictureBox12_MouseLeave(object sender, EventArgs e)
        {
            pictureBox12.Size = new Size(pictureBox12.Width - 5, pictureBox12.Height - 5);
        }

        public event EventHandler walkthroughBackClick;

        private void back1_Click(object sender, EventArgs e)
        {
            walkthroughBackClick?.Invoke(this, EventArgs.Empty);
        }

        private void WalkThrough_Load(object sender, EventArgs e)
        {
            SetStyles();
        }
    }
}
