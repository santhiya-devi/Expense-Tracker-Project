using System;
using System.Drawing;
using System.Windows.Forms;
using ExpenseTracker;
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI
{
    public partial class ModifyBudget : UserControl
    {
        public ModifyBudget()
        {
            InitializeComponent();
            choiceComboBox.SelectedIndex = 0;
            resultTimer.Interval = 800;
            resultTimer.Tick += OnResultTimerTicked;
            walletView.TotalShow = false;
            GUIStyles.ColorChanged += OnColorChanged;
            OnColorChanged(true);
        }
        
        public event EventHandler<bool> ModifiedOrDeleted;
        
        private CategoryView categoryView = new CategoryView();

        private WalletView walletView = new WalletView();

        private Budget budget , tempBudget;

        private Budget budget2 = new Budget();

        private Timer resultTimer = new Timer();

        private ErrorProvider errorProvider = new ErrorProvider();
        
        private Budget.Choices choice = Budget.Choices.ThisWeek;

        private int categoryid = 0, walletid = 1;
        
        private String categoryname = "";

        private float amount;

        private DateTime startDate, endDate;
        
        private bool modifyExisting = false , isEditable = true;

        public bool IsEditable
        {
            get => isEditable;
            set
            {
                isEditable = value;
                ChangeState();
            }
        }

        public void Initialize(Budget budget)
        {
            this.budget = budget;
            this.budget.BudgetId = budget.BudgetId;//////
            amounttb.Text = budget.Amount.ToString();
            choiceComboBox.Text = budget.Choice.ToString();
            if (budget.Choice.ToString() == "Custom")
            {
                choiceComboBox.SelectedIndex = 4;
                startDatelb.Show();
                endDatelb.Show();
                startDatePicker.Show();
                endDatePicker.Show();
            }
            else
            {
                startDatelb.Hide();
                endDatelb.Hide();
                startDatePicker.Hide();
                endDatePicker.Hide();
            }
            ChangeChoice();
            categorySelectBtn.Text = $"{Communicator.Manager.FetchCategoryName(budget.CategoryId).CategoryName}";
            walletid = budget.WalletId;
            walletBtn.Text = Communicator.Manager.FetchWallet(walletid).WalletName;
            categoryid = budget.CategoryId;
            categoryname = categorySelectBtn.Text;
            startDatePicker.Value = budget.StartDate;
            endDatePicker.Value = budget.EndDate;
            categorySelectBtn.BackColor = Color.White;
            walletBtn.BackColor = Color.White;
            errorProvider.SetError(endDatePicker, "");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            pback.Controls.Add(categoryView);
            categoryView.Dock = DockStyle.Fill;
            categoryView.Visible = false;
            categoryView.SendToBack();
            pback.Controls.Add(walletView);
            walletView.Dock = DockStyle.Fill;
            walletView.Visible = false;
            walletView.BringToFront();
            AdjustSize();
            categoryView.ChangeCategoryShow = CategoryView.EditCategoryShow.Expense;
            categoryView.CategorySelect += OnCategoryViewSelectClicked;
            categoryView.CategoryClose += OnCategoryClosedClicked;
            walletView.WalletSelect += OnWalletSelectClicked;
            walletView.WalletClose += OnWalletCloseClicked;
        }

        private void AdjustSize()
        {
            pback.Width = paddtransaction.Width * 60 / 100;
            pback.Height = paddtransaction.Height * 70 / 100;
            padd.Width = paddtransaction.Width * 70 / 100;
            padd.Height = paddtransaction.Height * 70 / 100;
            pback.Location = new Point(pborder.Width / 2 - pback.Width / 2, pborder.Height / 2 - pback.Height / 2);
            padd.Location = new Point(pborder.Width / 2 - padd.Width / 2, pborder.Height / 2 - padd.Height / 2);
            warningPanel.Location = new Point(Width / 2 - (warningPanel.Width / 2), Height / 2 - (warningPanel.Height / 2));
            warningPanel.Visible = false;
        }

        private bool CheckAmount()
        {
            if (amounttb.TextLength > 0)
            {
                errorProvider.SetError(amounttb, "");
                return true;
            }
            errorProvider.SetError(amounttb, "Amount is required");
            return false;
        }

        private bool CheckCategory()
        {
            if (categorySelectBtn.Text == "Select Category                ➤")
            {
                errorProvider.SetError(categorySelectBtn, "Choose Category");
                return false;
            }
            errorProvider.SetError(categorySelectBtn, "");
            return true;
        }

        private bool CheckChoice()
        {
            if ((choiceComboBox.SelectedIndex == 4 && startDatePicker.Value <= endDatePicker.Value && endDatePicker.Value >= DateTime.Now) || (choiceComboBox.SelectedIndex <= 3))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void ChangeChoice()
        {
            if (choiceComboBox.SelectedIndex == 0 || choiceComboBox.Text == "This Week")
                choice = ExpenseTrackerDS.Budget.Choices.ThisWeek;
            if (choiceComboBox.SelectedIndex == 1 || choiceComboBox.Text == "This Month")
                choice = ExpenseTrackerDS.Budget.Choices.ThisMonth;
            if (choiceComboBox.SelectedIndex == 2 || choiceComboBox.Text == "This Quarter")
                choice = ExpenseTrackerDS.Budget.Choices.ThisQuarter;
            if (choiceComboBox.SelectedIndex == 3 || choiceComboBox.Text == "This Year")
                choice = ExpenseTrackerDS.Budget.Choices.ThisYear;
            if (choiceComboBox.SelectedIndex == 4 || choiceComboBox.Text == "Custom")
                choice = ExpenseTrackerDS.Budget.Choices.Custom;
        }

        private void ChangeState()
        {
            if(!isEditable)
            {
                amounttb.Enabled = false;
                categorySelectBtn.Enabled = false;
                choiceComboBox.Enabled = false;
                walletBtn.Enabled = false;
                startDatePicker.Enabled = false;
                endDatePicker.Enabled = false;
                modifyBtn.Visible = false;
                deleteBtn.Visible = false;
            }
            else
            {
                amounttb.Enabled = true;
                categorySelectBtn.Enabled = true;
                choiceComboBox.Enabled = true;
                walletBtn.Enabled = true;
                startDatePicker.Enabled = true;
                endDatePicker.Enabled = true;
                modifyBtn.Visible = true;
                deleteBtn.Visible = true;
            }
        }
        
        private void OnColorChanged(bool e)
        {
            closeBtn.BackColor = GUIStyles.primaryColor;
            paddtransaction.BackColor = GUIStyles.primaryColor;
            pnlTop.BackColor = GUIStyles.primaryColor;
            cancelWarningBtn.BackColor = GUIStyles.primaryColor;
            modifyExistingBtn.BackColor = GUIStyles.primaryColor;
            warningPanel.BackColor = GUIStyles.primaryColor;
            padd.BackColor = GUIStyles.primaryColor;
            deleteBtn.ForeColor = modifyBtn.ForeColor = GUIStyles.blackColor;
            deleteBtn.FlatAppearance.MouseOverBackColor = modifyBtn.FlatAppearance.MouseOverBackColor = GUIStyles.secondaryColor;
            amountlb.ForeColor = choicelb.ForeColor = categorylb.ForeColor = walletlb.ForeColor = startDatelb.ForeColor = endDatelb.ForeColor = GUIStyles.blackColor;
            cancelWarningBtn.PrimaryColor = modifyExistingBtn.PrimaryColor = GUIStyles.primaryColor;
            cancelWarningBtn.SecondColor = modifyExistingBtn.SecondColor = GUIStyles.secondaryColor;
        }

        private void Result(bool res , bool modify)
        {
            if (res)
            {
                if (modify)
                    resultLbl.Text = "Modified ✔";
                else
                    resultLbl.Text = "Deleted ✔";
                resultLbl.ForeColor = Color.Chartreuse;
                modifyBtn.Enabled = false;
                deleteBtn.Enabled = false;
                resultTimer.Start();
            }
            else
            {
                //resultLbl.Text = " Failed ✘";
                //resultLbl.ForeColor = Color.Red;
                cancelWarningBtn.Select = false;
                modifyExistingBtn.Select = false;
                warningPanel.Visible = true;
                padd.Enabled = false;
            }
        }
        
        private void OnAmounttbKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void OnCancelWarningBtnClicked(object sender, EventArgs e)
        {
            warningPanel.Visible = false;
            padd.Enabled = true;
            cancelWarningBtn.Select = false;
            if(tempBudget!= null)
            {
                bool res = Communicator.Manager.AddData(tempBudget, false);
                errorProvider.SetError(amounttb, "");
                modifyExisting = false;
                tempBudget = null;
            }
        }

        private void OnCategorySelectLblClicked(object sender, EventArgs e)
        {
            categoryView.WalletChange = new Wallet { WalletID = walletid };
            pback.Visible = true;
            walletView.SendToBack();
            categoryView.BringToFront();
            categoryView.Visible = true;
            padd.Visible = false;
        }

        private void OnCategoryViewSelectClicked(object sender, Category e)
        {
            Category c = new Category();
            c = e;
            categoryid = c.ID;
            categoryname = c.CategoryName;
            pback.Visible = false;
            categoryView.Visible = false;
            padd.Visible = true;
            categorySelectBtn.Text = categoryname;
            categorySelectBtn.BackColor = Color.White;
        }

        private void OnCategoryClosedClicked(object sender, EventArgs e)
        {
            pback.Visible = false;
            categoryView.Visible = false;
            padd.Visible = true;
        }

        private void OnCloseBtnClicked(object sender, EventArgs e)
        {
            SendToBack();
        }

        private void OnChoiceComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if (choiceComboBox.SelectedIndex != 4)
            {
                startDatelb.Hide();
                endDatelb.Hide();
                startDatePicker.Hide();
                endDatePicker.Hide();
            }
            else
            {
                startDatelb.Show();
                endDatelb.Show();
                startDatePicker.Show();
                endDatePicker.Show();
            }
            ChangeChoice();
        }

        private void OnDeleteBtnClicked(object sender, EventArgs e)
        {
            bool res = Communicator.Manager.RemoveData(budget);
            Result(res , false);
        }

        private void OnDeleteBtnMouseLeaved(object sender, EventArgs e)
        {
            deleteBtn.BackColor = Color.White;
            deleteBtn.ForeColor = Color.MediumBlue;
        }

        private void OnDeleteBtnMouseEntered(object sender, EventArgs e)
        {
            deleteBtn.BackColor = GUIStyles.secondaryColor;
            deleteBtn.ForeColor = Color.White;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            categoryView.Visible = false;
            pback.Visible = false;
            AdjustSize();
        }

        private void OnModifyExisitngBtnClicked(object sender, EventArgs e)
        {
            modifyExisting = true;
            padd.Enabled = true;
            OnModifyBtnClicked(this, e);
            warningPanel.Visible = false;
            modifyExistingBtn.Select = false;
            tempBudget = null;
        }

        private void OnModifyBtnClicked(object sender, EventArgs e)
        {
            if(choiceComboBox.SelectedIndex==4 && endDatePicker.Value < DateTime.Now)
            {
                errorProvider.SetError(endDatePicker, "End date cannot be past");
                return;
            }
            else
            {
                errorProvider.SetError(endDatePicker, "");
            }

            if (CheckAmount() && CheckCategory() && CheckChoice())
            {
                amount = float.Parse(amounttb.Text);
                if (choiceComboBox.SelectedIndex == 4)
                {
                    startDate = startDatePicker.Value;
                    endDate = endDatePicker.Value;
                }

                budget2.CategoryId = categoryid;
                budget2.Amount = amount;
                budget2.Choice = choice;
                budget2.WalletId = walletid;
                budget2.StartDate = startDate;
                budget2.EndDate = endDate;

                if(budget!=null && (budget.CategoryId == budget2.CategoryId && budget.Amount == budget2.Amount && budget.WalletId == budget2.WalletId && budget.Choice == budget2.Choice))
                {
                    modifyBtn.Enabled = false;
                    deleteBtn.Enabled = false;
                    resultTimer.Start();
                    return;
                }
                else
                {
                    if (budget != null)
                    {
                        Communicator.Manager.RemoveData(budget);
                        tempBudget = new Budget() { BudgetId = budget.BudgetId , Amount = budget.Amount , CategoryId = budget.CategoryId , Choice = budget.Choice , EndDate = budget.EndDate , StartDate = budget.StartDate , WalletId = budget.WalletId};
                        budget = null;
                    }
                }

                bool res = Communicator.Manager.AddData(budget2, modifyExisting);
                Result(res, true);
                errorProvider.SetError(amounttb, "");
                modifyExisting = false;
            }
        }

        private void OnModifyBudgetResized(object sender, EventArgs e)
        {
            pborder.Size = new Size(Width - 24, Height - 62);
        }

        private void OnModifyBtnMouseEntered(object sender, EventArgs e)
        {
            modifyBtn.BackColor = GUIStyles.secondaryColor;
            modifyBtn.ForeColor = Color.White;
        }

        private void OnModifyBtnMouseLeaved(object sender, EventArgs e)
        {
            modifyBtn.BackColor = Color.White;
            modifyBtn.ForeColor = Color.MediumBlue;
        }

        private void OnPaddPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.backColor, padd.Width, padd.Height, 25, 50);
        }

        private void OnResultTimerTicked(object sender, EventArgs e)
        {
            resultLbl.Text = "";
            modifyBtn.Enabled = true;
            deleteBtn.Enabled = true;
            resultTimer.Stop();
            ModifiedOrDeleted?.Invoke(this, true);
        }

        private void OnWalletBtClicked(object sender, EventArgs e)
        {
            pback.Visible = true;
            categoryView.SendToBack();
            walletView.BringToFront();
            walletView.Visible = true;
            walletView.ChangeWidth(pback.Width);
            padd.Visible = false;
        }

        private void OnWalletSelectClicked(object sender, Wallet e)
        {
            walletView.Visible = false;
            pback.Visible = false;
            padd.Visible = true;
            walletBtn.Text = e.WalletName;
            walletid = e.WalletID;
            categorySelectBtn.Text = "Select Category                ➤";
            categorySelectBtn.BackColor = Color.WhiteSmoke;
        }

        private void OnWalletCloseClicked(object sender, EventArgs e)
        {
            walletView.Visible = false;
            pback.Visible = false;
            padd.Visible = true;
        }
        
    }
}
