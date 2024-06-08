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
using System.IO;

namespace ExpenseTrackerGUI.Account
{
    public partial class ExportToCSV : UserControl
    {
        #region Constructor

        public ExportToCSV()
        {
            InitializeComponent();
            
            space2.Size = new Size(726, 10);
            timePanel.Height = 79;
            startDateSelect.Location = border2.Location;
            endDateSelect.Location = border3.Location;

            timeSelectPanel.Hide();
            startDateSelect.Hide();
            endDateSelect.Hide();
            panel2.Hide();
            delimiters.Hide();
            showCategory.Hide();
            border1.Hide();
            border2.Hide();
            border3.Hide();
            changeWallet1.Hide();

            titleLbl.ForeColor = GUIStyles.primaryColor;
            exportBtn.BackColor = GUIStyles.primaryColor;
            exportBtn.ForeColor = GUIStyles.whiteColor;
            exportBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            allCategoryLbl.ForeColor = GUIStyles.primaryColor;
            allIncomeLbl.ForeColor = GUIStyles.primaryColor;
            allExpenseLbl.ForeColor = GUIStyles.primaryColor;
            border1.BackColor = GUIStyles.primaryColor;
            showCategory.BackColor = GUIStyles.backColor;
            startDateSelect.BackColor = GUIStyles.primaryColor;
            endDateSelect.BackColor = GUIStyles.primaryColor;
            border2.BackColor = GUIStyles.primaryColor;
            timeSelectPanel.BackColor = GUIStyles.backColor;
            border3.BackColor = GUIStyles.primaryColor;
            delimiters.BackColor = GUIStyles.backColor;
            cancelBtn.BackColor = GUIStyles.primaryColor;
            cancelBtn.ForeColor = GUIStyles.whiteColor;
            cancelBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            selectBtn.BackColor = GUIStyles.primaryColor;
            selectBtn.ForeColor = GUIStyles.whiteColor;
            selectBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
        }

        #endregion

        #region User defined functions

        public void SetStyles()
        {
            exportBtn.BackColor = GUIStyles.primaryColor;
            exportBtn.ForeColor = GUIStyles.whiteColor;
            border3.BackColor = GUIStyles.primaryColor;
            border2.BackColor = GUIStyles.primaryColor;
            border1.BackColor = GUIStyles.primaryColor;
            delimiterPanel.BackColor = GUIStyles.backColor;
            showCategory.BackColor = GUIStyles.backColor;
            timeSelectPanel.BackColor = GUIStyles.backColor;
            panel2.BackColor = GUIStyles.primaryColor;
            betweenPanel.BackColor = GUIStyles.backColor;
            delimiters.BackColor = GUIStyles.backColor;
            semicolonLbl.ForeColor = GUIStyles.primaryColor;
            commaLbl.ForeColor = GUIStyles.primaryColor;
            tabLbl.ForeColor = GUIStyles.primaryColor;
            allCategoryLbl.ForeColor = GUIStyles.primaryColor;
            allExpenseLbl.ForeColor = GUIStyles.primaryColor;
            allIncomeLbl.ForeColor = GUIStyles.primaryColor;
            afterLbl.ForeColor = GUIStyles.primaryColor;
            betweenLbl.ForeColor = GUIStyles.primaryColor;
            beforeLbl.ForeColor = GUIStyles.primaryColor;
            exactLbl.ForeColor = GUIStyles.primaryColor;
            allLbl.ForeColor = GUIStyles.primaryColor;
            selectBtn.BackColor = GUIStyles.primaryColor;
            cancelBtn.BackColor = GUIStyles.primaryColor;
            selectBtn.ForeColor = GUIStyles.whiteColor;
            cancelBtn.ForeColor = GUIStyles.whiteColor;
            selectBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            cancelBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;

            titleLbl.ForeColor = GUIStyles.primaryColor;
            exportBtn.BackColor = GUIStyles.primaryColor;
            exportBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;

            if (GUIStyles.colorName == "black")
            {
                walletPicture.Image = Image.FromFile(@".\Images\globe3.png");
                categoryPicture.Image = Image.FromFile(@".\Images\globe3.png");
                closeBtn.Image = Image.FromFile(@".\Images\cross2.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                walletPicture.Image = Image.FromFile(@".\Images\globe4.png");
                categoryPicture.Image = Image.FromFile(@".\Images\globe4.png");
                closeBtn.Image = Image.FromFile(@".\Images\cross3.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                walletPicture.Image = Image.FromFile(@".\Images\globe.png");
                categoryPicture.Image = Image.FromFile(@".\Images\globe.png");
                closeBtn.Image = Image.FromFile(@".\Images\cross1.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                walletPicture.Image = Image.FromFile(@".\Images\globe1.png");
                categoryPicture.Image = Image.FromFile(@".\Images\globe1.png");
                closeBtn.Image = Image.FromFile(@".\Images\cross4.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                walletPicture.Image = Image.FromFile(@".\Images\globe2.png");
                categoryPicture.Image = Image.FromFile(@".\Images\globe2.png");
                closeBtn.Image = Image.FromFile(@".\Images\cross5.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                walletPicture.Image = Image.FromFile(@".\Images\z16.png");
                categoryPicture.Image = Image.FromFile(@".\Images\z16.png");
                closeBtn.Image = Image.FromFile(@".\Images\z12.png");
            }
        }

        private void ToCSV(List<Transaction> result1)
        {
            StringBuilder output = new StringBuilder();
            String[] headings = { "Transaction Id", "Category Name", "Amount", "Date", "Description" };
            output.AppendLine(string.Join(separator, headings));

            foreach (Transaction t in result1)
            {
                String[] newLine = { t.TransactionId.ToString(), t.CategoryName, t.Amount.ToString(), t.Date.ToString(), t.Description };
                output.AppendLine(string.Join(separator, newLine));
            }

            try
            {
                String file = "";
                saveFileDialog1.ShowDialog();
                saveFileDialog1.InitialDirectory = @"C:\";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    file = saveFileDialog1.FileName;
                }
                File.AppendAllText(file, output.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Data could not be written to the CSV file.");
                return;
            }
        }

        private void MouseEnterEvent(Panel panel, Label label)
        {
            panel.BackColor = GUIStyles.primaryColor;
            label.BackColor = GUIStyles.primaryColor;
            label.ForeColor = GUIStyles.whiteColor;
        }

        private void MouseLeaveEvent(Panel panel, Label label)
        {
            panel.BackColor = GUIStyles.backColor;
            label.BackColor = GUIStyles.backColor;
            label.ForeColor = GUIStyles.primaryColor;
        }

        #endregion

        #region Variable and Event creation

        static int categoryCnt = 0, timeCnt = 0, delimiterCnt = 0;
        int walletId = 0;
        string startDate = "", endDate = "";
        bool startFlag = false, endFlag = false;
        String separator = ",";

        public event EventHandler CloseBtnClick;

        #endregion

        #region Click events

        private void walletSelectPanel_Click(object sender, EventArgs e)
        {
            changeWallet1.Show();
            changeWallet1.WalletSelect += OnChangeWallet1_WalletClick;
            changeWallet1.WalletClose += OnChangeWallet1_WalletClose;
            border1.Hide();
            border2.Hide();
            border3.Hide();
        }

        private void categoryPicture_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            border2.Hide();
            border3.Hide();
            timeSelectPanel.Hide();
            delimiters.Hide();

            space2.Size = new Size(726, 10);
            timePanel.Height = 79;
            timeCnt = 0;
            categoryCnt++;
            if (categoryCnt % 2 != 0)
            {
                space2.Size = new Size(726, 126);
                border1.Show();
                border1.BringToFront();
                showCategory.Show();
                showCategory.BringToFront();
            }
            else
            {
                border1.Hide();
                showCategory.Hide();
                space2.Size = new Size(726, 10);
            }
        }

        private void timePanel_Click(object sender, EventArgs e)
        {
            border1.Hide();
            border3.Hide();
            startDateSelect.Hide();
            endDateSelect.Hide();
            delimiters.Hide();
            panel2.Hide();
            showCategory.Hide();
            space2.Size = new Size(726, 10);
            categoryCnt = 0;
            timeCnt++;
            if (timeCnt % 2 != 0)
            {
                timePanel.Height = 280;
                border2.Show();
                timeSelectPanel.Show();
            }
            else
            {
                timeSelectPanel.Hide();
                border2.Hide();
                timePanel.Height = 79;
            }
        }

        private void delimiterPanel_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            startDateSelect.Hide();
            border1.Hide();
            border2.Hide();
            timeSelectPanel.Hide();
            showCategory.Hide();
            space2.Size = new Size(726, 10);
            timePanel.Height = 79;
            timeCnt = 0;
            categoryCnt = 0;
            delimiterCnt++;
            if (delimiterCnt % 2 != 0)
            {
                delimiters.Show();
                border3.Show();
            }
            else
            {
                border3.Hide();
                delimiters.Hide();
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            border1.Hide();
            border2.Hide();
            CloseBtnClick?.Invoke(this, EventArgs.Empty);
        }

        private void allCategoryLbl_Click(object sender, EventArgs e)
        {
            selectCategoryLbl.Text = allCategoryLbl.Text;
            space2.Size = new Size(726, 10);
            categoryCnt = 0;
            border1.Hide();
        }

        private void allIncomeLbl_Click(object sender, EventArgs e)
        {
            selectCategoryLbl.Text = allIncomeLbl.Text;
            space2.Size = new Size(726, 10);
            categoryCnt = 0;
            border1.Hide();
        }

        private void allExpenseLbl_Click(object sender, EventArgs e)
        {
            selectCategoryLbl.Text = allExpenseLbl.Text;
            space2.Size = new Size(726, 10);
            categoryCnt = 0;
            border1.Hide();
        }

        private void allPanel_Click(object sender, EventArgs e)
        {
            endFlag = false;
            startFlag = false;
            label2.Hide();
            selectedTime.Text = allLbl.Text;
            timeSelectPanel.Hide();
            timePanel.Height = 79;
            timeCnt = 0;
            border2.Hide();
        }

        private void afterLbl_Click(object sender, EventArgs e)
        {
            endFlag = false;
            startFlag = false;
            selectedTime.Text = afterLbl.Text;
            timeSelectPanel.Hide();
            panel2.Hide();
            endDateSelect.Hide();
            timeCnt = 0;
            startDateSelect.Show();
            startDateSelect.Location = new Point(261, 60);
            label2.Text = startDate;
            border2.Hide();
        }

        private void beforeLbl_Click(object sender, EventArgs e)
        {
            endFlag = false;
            startFlag = false;
            selectedTime.Text = beforeLbl.Text;
            timeSelectPanel.Hide();
            panel2.Hide();
            startDateSelect.Hide();
            timeCnt = 0;
            endDateSelect.Show();
            endDateSelect.Location = new Point(261, 60);
            label2.Text = endDate;
            border2.Hide();
        }

        private void betweenLbl_Click(object sender, EventArgs e)
        {
            panel2.BackColor = GUIStyles.primaryColor;
            betweenTime.BackColor = GUIStyles.backColor;
            betweenTime.BringToFront();
            endDateSelect.Hide();
            startDateSelect.Hide();
            selectedTime.Text = betweenLbl.Text;
            timeSelectPanel.Hide();
            panel2.Location = new Point(350, 40);
            panel2.Show();
            timeCnt = 0;
            border2.Hide();
        }

        private void date2_Click(object sender, EventArgs e)
        {
            endDateSelect.Location = panel2.Location;
            panel2.Hide();
            endDateSelect.Show();
            endFlag = true;
        }

        private void selectBtn_Click(object sender, EventArgs e)
        {
            startDate = date1Lbl.Text;
            endDate = date2.Text;

            if (startDate == "Yesterday")
            {
                startDate = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            if (endDate == "Today")
            {
                endDate = DateTime.Now.ToString("yyyy-MM-dd");
            }

            label2.Text = startDate + " - " + endDate;
            timePanel.Height = 79;
            panel2.Hide();

        }

        private void exportBtn_Click_1(object sender, EventArgs e)
        {
            List<Transaction> result = new List<Transaction>();

            if (selectCategoryLbl.Text == allCategoryLbl.Text)
            {
                if (selectedTime.Text == allLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "All", "All", walletId);
                }
                else if (selectedTime.Text == afterLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, startDate, "After", "All", walletId);
                }
                else if (selectedTime.Text == beforeLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(endDate, endDate, "Before", "All", walletId);
                }
                else if (selectedTime.Text == betweenLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "Between", "All", walletId);
                }
                else if (selectedTime.Text == beforeLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "Exact", "All", walletId);
                }
            }
            else if (selectCategoryLbl.Text == allIncomeLbl.Text)
            {
                if (selectedTime.Text == allLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "All", "Income", walletId);
                }
                else if (selectedTime.Text == afterLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, startDate, "After", "Income", walletId);
                }
                else if (selectedTime.Text == beforeLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(endDate, endDate, "Before", "Income", walletId);
                }
                else if (selectedTime.Text == betweenLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "Between", "Income", walletId);
                }
                else if (selectedTime.Text == beforeLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "Exact", "Income", walletId);
                }
            }
            else if (selectCategoryLbl.Text == allExpenseLbl.Text)
            {
                if (selectedTime.Text == allLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "All", "Expense", walletId);
                }
                else if (selectedTime.Text == afterLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, startDate, "After", "Expense", walletId);
                }
                else if (selectedTime.Text == beforeLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(endDate, endDate, "Before", "Expense", walletId);
                }
                else if (selectedTime.Text == betweenLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "Between", "Expense", walletId);
                }
                else if (selectedTime.Text == beforeLbl.Text)
                {
                    result = Communicator.Manager.FetchTransactionToExport(startDate, endDate, "Exact", "Expense", walletId);
                }
            }
            ToCSV(result);
        }

        private void semicolonLbl_Click(object sender, EventArgs e)
        {
            separator = ";";
            delimiters.Hide();
            border3.Hide();
            selectedDelimiiter.Text = semicolonLbl.Text;
        }

        private void commaLbl_Click(object sender, EventArgs e)
        {
            separator = ",";
            delimiters.Hide();
            border3.Hide();
            selectedDelimiiter.Text = commaLbl.Text;
        }

        private void tabLbl_Click(object sender, EventArgs e)
        {
            separator = "\t";
            delimiters.Hide();
            border3.Hide();
            selectedDelimiiter.Text = tabLbl.Text;
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            border2.Show();
            timeSelectPanel.Show();
        }

        private void date1Lbl_Click(object sender, EventArgs e)
        {
            startDateSelect.Location = panel2.Location;
            panel2.Hide();
            startDateSelect.Show();
            startFlag = true;
        }

        private void exactLbl_Click(object sender, EventArgs e)
        {
            endFlag = false;
            startFlag = false;
            selectedTime.Text = exactLbl.Text;
            startDateSelect.Show();
            startDateSelect.Location = new Point(261, 60);
            timeSelectPanel.Hide();

            timeCnt = 0;
            label2.Text = startDate;
            border2.Hide();
        }

        #endregion

        #region MouseEnter events

        private void allLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(allPanel, allLbl);
        }

        private void afterLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(afterPanel, afterLbl);
        }

        private void beforeLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(beforePanel, beforeLbl);
        }

        private void betweenLbl_Enter(object sender, EventArgs e)
        {
            MouseEnterEvent(betweenPanel, betweenLbl);
        }

        private void exactLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(exactPanel, exactLbl);
        }

        private void allCategoryLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(allCategoryPanel, allCategoryLbl);
        }

        private void allIncomeLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(allIncomePanel, allIncomeLbl);
        }

        private void allExpenseLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(allExpensePanel, allExpenseLbl);
        }

        private void betweenLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(betweenPanel, betweenLbl);
        }

        private void semicolonLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(semicolonPanel, semicolonLbl);
        }

        private void commaLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(commaPanel, commaLbl);
        }

        private void tabLbl_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEvent(tabPanel, tabLbl);
        }

        #endregion

        #region MouseLeave events

        private void border1_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(allExpensePanel, allExpenseLbl);
            MouseLeaveEvent(allIncomePanel, allIncomeLbl);
            MouseLeaveEvent(allCategoryPanel, allCategoryLbl);
        }

        private void allLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(allPanel, allLbl);
        }

        private void afterLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(afterPanel, afterLbl);
        }

        private void beforeLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(beforePanel, beforeLbl);
        }

        private void betweenLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(betweenPanel, betweenLbl);
        }

        private void exactLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(exactPanel, exactLbl);
        }

        private void border2_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(allPanel, allLbl);
            MouseLeaveEvent(afterPanel, afterLbl);
            MouseLeaveEvent(beforePanel, beforeLbl);
            MouseLeaveEvent(betweenPanel, betweenLbl);
            MouseLeaveEvent(exactPanel, exactLbl);
        }

        private void allCategoryLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(allCategoryPanel, allCategoryLbl);
        }

        private void allIncomeLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(allIncomePanel, allIncomeLbl);
        }

        private void allExpenseLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(allExpensePanel, allExpenseLbl);
        }
               
        private void semicolonLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(semicolonPanel, semicolonLbl);
        }

        private void commaLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(commaPanel, commaLbl);
        }

        private void tabLbl_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEvent(tabPanel, tabLbl);
        }

        #endregion

        #region Subscribed user defined-events

        private void OnChangeWallet1_WalletClose(object sender, EventArgs e)
        {
            changeWallet1.Hide();
        }               

        private void OnChangeWallet1_WalletClick(object sender, Wallet e)
        {
            selectWallet.Text = e.WalletName;
            walletId = e.WalletID;            
            changeWallet1.Hide();
        }

        #endregion

        #region Other events

        private void ExportToCSV_Resize(object sender, EventArgs e)
        {
            exportBtn.Location = new Point(Width - exportBtn.Width - 50, exportBtn.Location.Y);
        }

        private void ExportToCSV_Load(object sender, EventArgs e)
        {
            titleLbl.ForeColor = GUIStyles.primaryColor;
            showCategory.Hide();
            selectCategoryLbl.Text = allCategoryLbl.Text;
            space2.Size = new Size(726, 10);
            categoryCnt = 0;
        }        

        private void startDateSelect_DateSelected(object sender, DateRangeEventArgs e)
        {
            startDate = startDateSelect.SelectionRange.Start.ToString("yyyy-MM-dd");
            startDateSelect.Hide();

            if (startFlag)
            {
                date1Lbl.Text = startDate;
                panel2.Show();
                startFlag = false;
            }
            else
            {
                timePanel.Height = 79;
                label2.Text =  Convert.ToDateTime(startDate).ToString("dd/MM/yyyy");
            }
        }        

        private void endDateSelect_DateSelected(object sender, DateRangeEventArgs e)
        {
            endDate = endDateSelect.SelectionRange.Start.ToString("yyyy-MM-dd");
            endDateSelect.Hide();
            if (endFlag)
            {
                date2.Text = endDate;
                panel2.Show();
                
                endFlag = false;
            }
            else
            {
                timePanel.Height = 79;
                label2.Text = Convert.ToDateTime(endDate).ToString("dd/MM/yyyy");
            }
        }

        #endregion
    }
}