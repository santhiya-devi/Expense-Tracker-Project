using System;
using System.Drawing;
using System.Windows.Forms;
using ExpenseTracker;
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI
{
    public partial class AddBudget : UserControl
    {
        public AddBudget()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            choiceComboBox.SelectedIndex = 0;
            categoryview.CategorySelect += OnCategoryViewSelectClicked;
            categoryview.CategoryClose += OnCategoryClosedClicked;
            categoryview.ChangeCategoryShow = CategoryView.EditCategoryShow.Expense;
            walletView.WalletSelect += OnWalletSelectClicked;
            walletView.WalletClose += OnWalletCloseClicked;
            walletView.AddMode = false;
            walletView.EditMode = false;
            resultTimer.Interval = 800;
            resultTimer.Tick += OnResultTimerTicked;
            walletView.TotalShow = false;
            OnColorChanged(true);
            OnClearBtnClicked(new object(), EventArgs.Empty);
            GUIStyles.ColorChanged += OnColorChanged;
        }

        private Timer resultTimer = new Timer();

        private CategoryView categoryview = new CategoryView();

        private WalletView walletView = new WalletView();

        private ErrorProvider errorProvider;
        
        private int categoryid = 0, walletid = 1;

        private Budget.Choices choice = Budget.Choices.ThisWeek;

        private String categoryname = "";

        private float amount;

        private DateTime startDate , endDate ;

        private bool modifyExisting = false;

        private void AdjustSize()
        {
            paddtransaction.BackColor = GUIStyles.primaryColor;
            pback.Width = paddtransaction.Width * 60 / 100;
            pback.Height = paddtransaction.Height * 70 / 100;
            padd.Width = paddtransaction.Width * 70 / 100;
            padd.Height = paddtransaction.Height * 70 / 100;
            pback.Location = new Point(pborder.Width / 2 - pback.Width / 2, pborder.Height / 2 - pback.Height / 2);
            padd.Location = new Point(pborder.Width / 2 - padd.Width / 2, pborder.Height / 2 - padd.Height / 2);
            warningPanel.Location = new Point(Width/2 - (warningPanel.Width/2), Height /2 - (warningPanel.Height/2));
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

        private bool CheckWallet()
        {
            if (walletBtn.Text == "Select Wallet                      ➤")
            {
                errorProvider.SetError(walletBtn, "Choose Wallet");
                return false;
            }
            errorProvider.SetError(walletBtn, "");
            return true;
        }

        private bool CheckChoice()
        {
            if((choiceComboBox.SelectedIndex ==4 && startDatePicker.Value <= endDatePicker.Value && endDatePicker.Value >= DateTime.Now)|| (choiceComboBox.SelectedIndex <= 3))
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
            if (choiceComboBox.SelectedIndex == 0)
                choice = Budget.Choices.ThisWeek;
            if (choiceComboBox.SelectedIndex == 1)
                choice = Budget.Choices.ThisMonth;
            if (choiceComboBox.SelectedIndex == 2)
                choice = Budget.Choices.ThisQuarter;
            if (choiceComboBox.SelectedIndex == 3)
                choice = Budget.Choices.ThisYear;
            if (choiceComboBox.SelectedIndex == 4)
                choice = Budget.Choices.Custom;
        }
        
        private void OnColorChanged(bool e)
        {
            headingLbl.BackColor = GUIStyles.primaryColor;
            pictureBoxTop.BackColor = GUIStyles.primaryColor;
            paddtransaction.BackColor = GUIStyles.primaryColor;
            lblTitle.BackColor = GUIStyles.primaryColor;
            pnlTop.BackColor = GUIStyles.primaryColor;
            cancelWarningBtn.BackColor = GUIStyles.primaryColor;
            modifyExistingBtn.BackColor = GUIStyles.primaryColor;
            warningPanel.BackColor = GUIStyles.primaryColor;
            padd.BackColor = GUIStyles.primaryColor;
            clearBtn.ForeColor = saveBtn.ForeColor = GUIStyles.blackColor;
            clearBtn.FlatAppearance.MouseOverBackColor = saveBtn.FlatAppearance.MouseOverBackColor = GUIStyles.secondaryColor;
            amountlb.ForeColor = choicelb.ForeColor = categorylb.ForeColor = walletlb.ForeColor = startDatelb.ForeColor = endDatelb.ForeColor = GUIStyles.blackColor;
            cancelWarningBtn.PrimaryColor = modifyExistingBtn.PrimaryColor = GUIStyles.primaryColor;
            cancelWarningBtn.SecondColor = modifyExistingBtn.SecondColor = GUIStyles.secondaryColor;
        }
        
        private void OnAmounttbKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (!(e.KeyChar >= 48 && e.KeyChar <= 57) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void OnAddBudgetResized(object sender, EventArgs e)
        {
            pborder.Size = new Size(Width - 24, Height - 62);
        }

        private void OnCategoryClosedClicked(object sender, EventArgs e)
        {
            categoryview.Visible = false;
            padd.Visible = true;
        }

        private void OnCategorySelectLblClicked(object sender, EventArgs e)
        {
            if (walletBtn.Text == "Select Wallet                      ➤")
            {
                errorProvider.SetError(categorySelectBtn, "Choose Wallet");
            }
            else
            {
                errorProvider.SetError(categorySelectBtn, "");
                categoryview.BringToFront();
                walletView.SendToBack();
                categoryview.Visible = true;
                categoryview.WalletChange = new Wallet { WalletID = walletid };
                padd.Visible = false;

            }
        }

        private void OnCancelWarningBtnClicked(object sender, EventArgs e)
        {
            warningPanel.Visible = false;
            padd.Enabled = true;
        }

        private void OnCategoryViewSelectClicked(object sender, Category e)
        {
            Category c = new Category();
            c = e;
            categoryid = c.ID;
            categoryname = c.CategoryName;
            categoryview.Visible = false;
            padd.Visible = true;
            categorySelectBtn.Text = categoryname;
            categorySelectBtn.BackColor = Color.White;
        }

        private void OnChoiceComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            if(choiceComboBox.SelectedIndex != 4)
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

        private void OnClearBtnMouseLeave(object sender, EventArgs e)
        {
            clearBtn.BackColor = Color.White;
            clearBtn.ForeColor = Color.MediumBlue;
        }

        private void OnClearBtnMouseEnter(object sender, EventArgs e)
        {
            clearBtn.BackColor = GUIStyles.secondaryColor;
            clearBtn.ForeColor = Color.White;
        }

        private void OnClearBtnClicked(object sender, EventArgs e)
        {
            amounttb.Text = "";
            errorProvider.SetError(amounttb, "");
            categorySelectBtn.Text = "Select Category                ➤";
            walletBtn.Text = "Select Wallet                      ➤";
            choiceComboBox.SelectedIndex = 0;
            choice = Budget.Choices.ThisWeek;
            categorySelectBtn.BackColor = Color.WhiteSmoke;
            walletBtn.BackColor = Color.WhiteSmoke;
            startDatePicker.Value = DateTime.Now;
            endDatePicker.Value = DateTime.Now;
        }

        private void OnLoad(object sender, EventArgs e)
        {
            pback.Controls.Add(categoryview);
            categoryview.Dock = DockStyle.Fill;
            categoryview.Visible = false;
            categoryview.SendToBack();
            pback.Controls.Add(walletView);
            walletView.Dock = DockStyle.Fill;
            walletView.Visible = false;
            walletView.BringToFront();
            AdjustSize();
        }

        private void OnModifyExistingBtnClicked(object sender, EventArgs e)
        {
            modifyExisting = true;
            OnSaveBtnClicked(this, e);
            warningPanel.Visible = false;
            padd.Enabled = true;
        }

        private void OnPaddPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.backColor, padd.Width, padd.Height, 25, 50);
        }

        private void OnResultTimerTicked(object sender, EventArgs e)
        {
            resultLbl.Text = "";
            saveBtn.Enabled = true;
            clearBtn.Enabled = true;
            resultTimer.Stop();
        }

        private void OnSaveBtnMouseEnter(object sender, EventArgs e)
        {
            saveBtn.BackColor = GUIStyles.secondaryColor;
            saveBtn.ForeColor = Color.White;
        }

        private void OnSaveBtnMouseLeave(object sender, EventArgs e)
        {
            saveBtn.BackColor = Color.White;
            saveBtn.ForeColor = Color.MediumBlue;
        }

        private void OnSaveBtnClicked(object sender, EventArgs e)
        {
            if (choiceComboBox.SelectedIndex == 4 && endDatePicker.Value < DateTime.Now)
            {
                errorProvider.SetError(endDatePicker, "End date cannot be past");
                return;
            }
            else
            {
                errorProvider.SetError(endDatePicker, "");
            }
            if (CheckAmount() && CheckCategory() && CheckChoice() && CheckWallet())
            {
                amount = float.Parse(amounttb.Text);
                if(choiceComboBox.SelectedIndex ==  4)
                {
                    startDate = startDatePicker.Value;
                    endDate = endDatePicker.Value;
                }
                Budget budget = new Budget
                {
                    CategoryId = categoryid,
                    Amount = amount,
                    Choice = choice,
                    WalletId = walletid,
                    StartDate = startDate,
                    EndDate = endDate,
                };
                bool res = Communicator.Manager.AddData(budget , modifyExisting);

                if(res)
                {
                    resultLbl.Text = " Created Successfully ✔";
                    resultLbl.ForeColor = Color.Chartreuse;
                    saveBtn.Enabled = false;
                    clearBtn.Enabled = false;
                    resultTimer.Start();
                }
                else
                {
                    cancelWarningBtn.Select = false;
                    modifyExistingBtn.Select = false;
                    warningPanel.Visible = true;
                    padd.Enabled = false;
                }
                errorProvider.SetError(amounttb, "");
                modifyExisting = false;
            }
            
        }

        private void OnVisibilityChnaged(object sender, EventArgs e)
        {
            OnClearBtnClicked(sender, e);
            categoryview.Visible = false;
            walletView.Visible = false;
            padd.Visible = true;
        }

        private void OnWalletSelectClicked(object sender, Wallet e)
        {
            walletid = e.WalletID;
            walletBtn.Text = e.WalletName;
            walletView.Visible = false;
            padd.Visible = true;
            walletBtn.BackColor = Color.White;
        }
        
        private void OnWalletBtClicked(object sender, EventArgs e)
        {
            categoryview.SendToBack();
            walletView.BringToFront();
            walletView.Visible = true;
            walletView.ChangeWidth(pback.Width);
            padd.Visible = false;
        }
        
        private void OnWalletCloseClicked(object sender, EventArgs e)
        {
            walletView.Visible = false;
            padd.Visible = true;
        }
        
    }
}
