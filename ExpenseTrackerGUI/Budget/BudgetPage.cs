using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseTracker;
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI
{
    public partial class BudgetPage : UserControl
    {
        public BudgetPage()
        {
            InitializeComponent();
            BackColor = GUIStyles.backColor;
            paginationControl.Location = new Point(((Width / 2) - (paginationControl.Width) / 2) - 5, paginationControl.Location.Y);
            paginationControl.ValueChanged += OnPaginationValueChanged;
            curveBtn1.Select = !curveBtn1.Select;
            Controls.Add(modifyBudget);
            modifyBudget.ModifiedOrDeleted += OnBudgetModifiedOrDeleted;
            modifyBudget.SendToBack();
            modifyBudget.Dock = DockStyle.Fill;
            InitializeCollection();
            choiceId = 1;
            noDataPanel.Hide();
            pastChoicePanel.Hide();
            InitializeWallets();
            OnColorChanged(true);
            GUIStyles.ColorChanged += OnColorChanged;
        }

        private Budget.Choices choice = Budget.Choices.ThisWeek;

        private List<Budget> budgets = new List<Budget>();
        
        private List<BudgetSquare> budgetSquares = new List<BudgetSquare>();

        private List<CurveButtons> currentChoices = new List<CurveButtons>();

        private List<CurveButtons>  pastChoices= new List<CurveButtons>();

        private List<Tuple<string, string>> customeDates = new List<Tuple<string, string>>();

        private ModifyBudget modifyBudget = new ModifyBudget();

        private List<Budget> pastBudgets = new List<Budget>();

        private bool flag = false;

        private int choiceIndex = 0, pageNo = 1 , walletId = 1 , choiceId = 1;

        public void InitializeBudgetPage()
        {
            List<CurveButtons> disposeList = new List<CurveButtons>();
            if (choiceId == 1)
            {
                customeDates = Communicator.Manager.FetchCustomDates(walletId);
                while (currentChoices.Count >= 5)
                {
                    disposeList.Add(currentChoices[4]);
                    currentChoices[4].SelectedValueChange -= OnSelectedValuesChanged;
                    currentChoicePanel.Controls.Remove(currentChoices[4]);
                    currentChoices.Remove(currentChoices[4]);
                }
                foreach (CurveButtons button in disposeList.ToArray())
                {
                    button.Dispose();
                }
                disposeList.Clear();
                CreateChoiceButtons();
                if (currentChoices.Count > 5)
                {
                    currentChoicePanel.AutoScroll = true;
                    currentChoicePanel.Height = 58;
                }
                else
                {
                    currentChoicePanel.AutoScroll = false;
                    currentChoicePanel.Height = 40;
                }
                OnSelectedValuesChanged(new object(), EventArgs.Empty.ToString());
            }
            else
            {
                customeDates = Communicator.Manager.FetchDistinctDates(walletId, out pastBudgets);
                if(customeDates.Count == 0)
                {
                    noDataPanel.Show();
                }
                else
                {
                    noDataPanel.Hide();
                }
                while(pastChoicePanel.Controls.Count>=1)
                {
                    disposeList.Add(pastChoices[pastChoicePanel.Controls.Count - 1]);
                    pastChoices[pastChoicePanel.Controls.Count - 1].SelectedValueChange -= OnSelectedValuesChanged;
                    pastChoices.RemoveAt(pastChoicePanel.Controls.Count - 1);
                    pastChoicePanel.Controls.RemoveAt(pastChoicePanel.Controls.Count - 1);
                }
                foreach (CurveButtons button in disposeList.ToArray())
                {
                    button.Dispose();
                }
                disposeList.Clear();
                CreateChoiceButtons();
                if(pastChoices.Count > 5)
                {
                    pastChoicePanel.AutoScroll = true;
                    pastChoicePanel.Height = 58;
                }
                else
                {
                    pastChoicePanel.AutoScroll = false;
                    pastChoicePanel.Height = 40;
                }
                OnSelectedValuesChanged(new object(), EventArgs.Empty.ToString());
            }
        }
        
        public void InitializeWallets()
        {
            walletsPanel.Visible = false;
            periodPanel.Visible = false;
            while (walletsPanel.Controls.Count > 0)
            {
                if (walletsPanel.Controls[0] is SingleWallet s)
                {
                    s.Selected -= OnSingleWalletSelected;
                }
                walletsPanel.Controls.RemoveAt(0);
            }
            walletsPanel.Height = 0;
            List<Wallet> wallets = Communicator.Manager.FetchWallet();
            walletId = 0;
            walletNameLbl.Text = "Total";
            SingleWallet wallet = new SingleWallet() { Id = 0, LabelText = "Total" , ViewImage = Image.FromFile(@".\Images\BlueWallet.PNG") };
            wallet.Selected += OnSingleWalletSelected;
            wallet.Dock = DockStyle.Top;
            walletsPanel.Controls.Add(wallet);
            walletsPanel.Height += 26;
            wallet.BringToFront();
            foreach (Wallet w in wallets)
            {
                wallet = new SingleWallet() { Id = w.WalletID, LabelText = w.WalletName };
                wallet.Selected += OnSingleWalletSelected;
                wallet.Dock = DockStyle.Top;
                walletsPanel.Controls.Add(wallet);
                walletsPanel.Height += 26;
                wallet.BringToFront();
                wallet.ViewImage = Image.FromFile(@".\Images\BlueWallet.PNG");
            }
            SetSingleWalletsImage();
        }
        
        private void CheckChoice()
        {
            if(choiceIndex == 0)
                choice = ExpenseTrackerDS.Budget.Choices.ThisWeek;
            if(choiceIndex == 1)
                choice = ExpenseTrackerDS.Budget.Choices.ThisMonth;
            if(choiceIndex == 2)
                choice = ExpenseTrackerDS.Budget.Choices.ThisQuarter;
            if(choiceIndex == 3)
                choice = ExpenseTrackerDS.Budget.Choices.ThisYear;
            if(choiceIndex >=4)
                choice = ExpenseTrackerDS.Budget.Choices.Custom;
        }

        private void EnableOrDisableControls(bool value)
        {
            pastChoicePanel.Enabled = value;
            currentChoicePanel.Enabled = value;
            paginationControl.Enabled = value;
            mainPanel.Enabled = value;
        }

        private void ShowBudgets()
        {
            int count = pageNo * 12;
            int remaining = 0;
            for(int i= ((pageNo-1)*12), j = 0;i< budgets.Count && i<count;i++,j++)
            {
                budgetSquares[j].Show();
                budgetSquares[j].InitializeValues( budgets[i].BudgetId ,Convert.ToInt32(budgets[i].Amount), Convert.ToInt32(Communicator.Manager.FetchAmount(budgets[i])), Communicator.Manager.FetchCategoryName(budgets[i].CategoryId).CategoryName, Communicator.Manager.FetchCategoryName(budgets[i].CategoryId).ImagePath);
                remaining = j;
            }
            if (budgets.Count == 0) remaining--;
            for(int i = remaining+1;i<12;i++)
            {
                budgetSquares[i].Hide();
            }
            if(budgets.Count == 0)
            {
                noDataPanel.Show();
            }
            else
            {
                noDataPanel.Hide();
            }
        }

        private void CreateChoiceButtons()
        {
            int i = 0;
            foreach (Tuple<string, string> dates in customeDates)
            {
                CurveButtons btn = new CurveButtons()
                {
                    Text = $" { Convert.ToDateTime(dates.Item1).ToShortDateString() }  -  { Convert.ToDateTime(dates.Item2).ToShortDateString() }",
                };
                btn.SelectedValueChange += OnSelectedValuesChanged;
                if (choiceId == 1)
                {
                    currentChoices.Add(btn);
                    currentChoicePanel.Controls.Add(btn);
                }
                else
                {
                    pastChoices.Add(btn);
                    pastChoicePanel.Controls.Add(btn);
                    if (pastBudgets[i].Choice != Budget.Choices.ThisWeek && pastBudgets[i].Choice != Budget.Choices.Custom)
                    {
                        btn.Text = GetButtonText(pastBudgets[i]);
                    }
                    i++;
                }
                btn.Back = GUIStyles.backColor;
                btn.PrimaryColor = GUIStyles.primaryColor;
                btn.SecondColor = GUIStyles.secondaryColor;
                btn.Dock = DockStyle.Left;
                btn.Size = new Size(190, 40);
                btn.Font = new Font("Arial", 9);
                btn.BringToFront();
            }
        }

        private void InitializePaginationButtons()
        {
            pageNo = 1;
            paginationControl.ButtonCount = budgets.Count / 12;
            if (budgets.Count % 12 != 0 || paginationControl.ButtonCount == 0)
                paginationControl.ButtonCount++;

            if (paginationControl.ButtonCount == 1)
            {
                paginationControl.Visible = false;
            }
            else
            {
                paginationControl.Visible = true;
            }
        }
        
        private void InitializeCollection()
        {
            budgetSquares.Add(budgetSquare1);
            budgetSquare1.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare2);
            budgetSquare2.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare3);
            budgetSquare3.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare4);
            budgetSquare4.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare5);
            budgetSquare5.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare6);
            budgetSquare6.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare7);
            budgetSquare7.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare8);
            budgetSquare8.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare9);
            budgetSquare9.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare10);
            budgetSquare10.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare11);
            budgetSquare11.BudgetSquareClicked += OnBudgetSquareClicked;
            budgetSquares.Add(budgetSquare12);
            budgetSquare12.BudgetSquareClicked += OnBudgetSquareClicked;

            currentChoices.Add(curveBtn1);
            currentChoices.Add(curveBtn2);
            currentChoices.Add(curveBtn3);
            currentChoices.Add(curveBtn4);
            curveBtn1.SelectedValueChange += OnSelectedValuesChanged;
            curveBtn2.SelectedValueChange += OnSelectedValuesChanged;
            curveBtn3.SelectedValueChange += OnSelectedValuesChanged;
            curveBtn4.SelectedValueChange += OnSelectedValuesChanged;

        }

        private void SetSingleWalletsImage()
        {
            foreach (SingleWallet s in walletsPanel.Controls)
            {
                if (GUIStyles.colorName == "black")
                {
                    s.ViewImage = Image.FromFile(@".\Images\BlackWallet.PNG");
                }
                if (GUIStyles.colorName == "brown")
                {
                    s.ViewImage = Image.FromFile(@".\Images\BrownWallet.PNG");
                }
                if (GUIStyles.colorName == "blue")
                {
                    s.ViewImage = Image.FromFile(@".\Images\BlueWallet.PNG");
                }
                if (GUIStyles.colorName == "red")
                {
                    s.ViewImage = Image.FromFile(@".\Images\RedWallet.PNG");
                }
                if (GUIStyles.colorName == "orange")
                {
                    s.ViewImage = Image.FromFile(@".\Images\Orangewallet.PNG");
                }
                if(GUIStyles.colorName == "pink")
                {
                    s.ViewImage = Image.FromFile(@".\Images\PinkWallet.PNG");
                }
            }
        }

        private string GetButtonText(Budget b)
        {
            if (b.Choice == Budget.Choices.ThisYear)
                return b.StartDate.Year.ToString();
            if (b.Choice == Budget.Choices.ThisMonth)
                return $"{b.StartDate.ToString("MMMM")} {b.StartDate.Year}";
            if(b.Choice == Budget.Choices.ThisQuarter)
            {
                if (b.StartDate.Month == 1)
                    return $"Q-I({b.StartDate.Year})";
                if (b.StartDate.Month == 4)
                    return $"Q-II({b.StartDate.Year})";
                if (b.StartDate.Month == 7)
                    return $"Q-III({b.StartDate.Year})";
                if (b.StartDate.Month == 10)
                    return $"Q-IV({b.StartDate.Year})";
            }
            return "";
        }

        private void OnColorChanged(bool e)
        {
            walletsPanel.BackColor = GUIStyles.whiteColor;
            periodPanel.BackColor = GUIStyles.whiteColor;
            ControlsPanel.BackColor = pastChoicePanel.BackColor = currentChoicePanel.BackColor = GUIStyles.backColor;
            paginationControl.BackColor = GUIStyles.backColor;
            selectChoicePanel.BackColor = mainPanel.BackColor = selectWalletPanel.BackColor = GUIStyles.terenaryColor;
            backPanel.BackColor = GUIStyles.primaryColor;
            currentChoice.BackColor = pastChoice.BackColor = GUIStyles.whiteColor;
            curveBtn1.PrimaryColor = curveBtn2.PrimaryColor = curveBtn3.PrimaryColor = curveBtn4.PrimaryColor = GUIStyles.primaryColor;
            curveBtn1.SecondColor = curveBtn2.SecondColor = curveBtn3.SecondColor = curveBtn4.SecondColor = GUIStyles.secondaryColor;
            curveBtn1.Back = curveBtn2.Back = curveBtn3.Back = curveBtn4.Back = GUIStyles.backColor;
            selectChoiceBtn.FlatAppearance.MouseOverBackColor = selectwalletbtn.FlatAppearance.MouseOverBackColor = GUIStyles.secondaryColor;

            if (GUIStyles.colorName == "black")
            {
                choicePb.BackgroundImage = currentChoice.ViewImage = pastChoice.ViewImage = Image.FromFile(@".\Images\BlackClock.PNG");
                walletpb.BackgroundImage = Image.FromFile(@".\Images\BlackWallet.PNG");
            }
            if (GUIStyles.colorName == "brown")
            {
                choicePb.BackgroundImage = currentChoice.ViewImage = pastChoice.ViewImage = Image.FromFile(@".\Images\BrownClock.PNG");
                walletpb.BackgroundImage = Image.FromFile(@".\Images\BrownWallet.PNG");
            }
            if (GUIStyles.colorName == "blue")
            {
                choicePb.BackgroundImage = currentChoice.ViewImage = pastChoice.ViewImage = Image.FromFile(@".\Images\BlueClock.PNG");
                walletpb.BackgroundImage = Image.FromFile(@".\Images\BlueWallet.PNG");
            }
            if (GUIStyles.colorName == "red")
            {
                choicePb.BackgroundImage = currentChoice.ViewImage = pastChoice.ViewImage = Image.FromFile(@".\Images\RedClock.PNG");
                walletpb.BackgroundImage = Image.FromFile(@".\Images\RedWallet.PNG");
            }
            if (GUIStyles.colorName == "orange")
            {
                choicePb.BackgroundImage = currentChoice.ViewImage = pastChoice.ViewImage = Image.FromFile(@".\Images\OrangeClock.PNG");
                walletpb.BackgroundImage = Image.FromFile(@".\Images\OrangeWallet.PNG");
            }
            if(GUIStyles.colorName == "pink")
            {
                choicePb.BackgroundImage = currentChoice.ViewImage = pastChoice.ViewImage = Image.FromFile(@".\Images\PinkClock.PNG");
                walletpb.BackgroundImage = Image.FromFile(@".\Images\PinkWallet.PNG");
            }

            SetSingleWalletsImage();

        }
        
        private void OnBudgetModifiedOrDeleted(object sender, bool e)
        {
            InitializeBudgetPage();
            modifyBudget.SendToBack();
            pageNo = 1;
            paginationControl.SelectStarting();
        }

        private void OnBudgetSquareClicked(object sender, int e)
        {
            modifyBudget.Initialize(Communicator.Manager.FetchBudgets(e));
            modifyBudget.BringToFront();
        }

        private void OnBudgetPageVisibilityChanged(object sender, EventArgs e)
        {
            modifyBudget.SendToBack();
            InitializeWallets();
            InitializeBudgetPage();
            walletsPanel.Visible = false;
            periodPanel.Visible = false;
            EnableOrDisableControls(true);
            selectWalletPanel.Enabled = true;
            selectChoicePanel.Enabled = true;
        }
        
        private void OnBudgetPageResized(object sender, EventArgs e)
        {
            ControlsPanel.Size = new Size(Width - 24, Height - 62);
        }

        private void OnChoiceSelected(object sender, string name, int id)
        {
            pastChoicePanel.Enabled = true;
            currentChoicePanel.Enabled = true;
            paginationControl.Enabled = true;
            mainPanel.Enabled = true;
            selectWalletPanel.Enabled = true;
            periodPanel.Visible = false;
            if (id == 1)
            {
                choiceId = 1;
                choiceLbl.Text = "Current";
                currentChoicePanel.Show();
                pastChoicePanel.Hide();
                InitializeBudgetPage();
                modifyBudget.IsEditable = true;
            }
            else
            {
                choiceId = 2;
                choiceLbl.Text = "Past";
                pastChoicePanel.Show();
                currentChoicePanel.Hide();
                pastBudgets.Clear();
                InitializeBudgetPage();
                modifyBudget.IsEditable = false;
            }
        }

        private void OnPaginationValueChanged(object sender, int e)
        {
            pageNo = e;
            ShowBudgets();
        }

        private void OnPaginationSizeChanged(object sender, EventArgs e)
        {
            paginationControl.Location = new Point(((Width /2)-(paginationControl.Width)/2) , paginationControl.Location.Y);
        }
        
        private void OnSelectedValuesChanged(object sender, string e)
        {
            budgets.Clear();
            if (choiceId == 1)
            {
                if ((sender is CurveButtons btn) && !flag)
                {
                    flag = true;
                    if (!(btn.Text == currentChoices[choiceIndex].Text))
                        currentChoices[choiceIndex].Select = false;
                    else
                        currentChoices[choiceIndex].Select = true;
                }
                else if (!flag)
                {
                    flag = true;
                    if (pastChoices.Count > choiceIndex)
                    {
                        pastChoices[choiceIndex].Select = false;
                    }
                    if (currentChoices.Count > choiceIndex)
                    {
                        currentChoices[choiceIndex].Select = false;
                    }
                    currentChoices[0].Select = true;
                }
                flag = false;
                choiceIndex = 0;
                foreach (CurveButtons btns in currentChoices)
                {
                    if (btns.Select == true)
                    {
                        break;
                    }
                    choiceIndex++;
                }
                CheckChoice();
                if (choice == ExpenseTrackerDS.Budget.Choices.Custom && customeDates.Count > 0)
                    budgets = Communicator.Manager.FetchRecords(ExpenseTrackerDS.Budget.Choices.Custom, Convert.ToDateTime(customeDates[choiceIndex - 4].Item1), Convert.ToDateTime(customeDates[choiceIndex - 4].Item2) , walletId , true);
                else
                    budgets = Communicator.Manager.FetchRecords(choice, DateTime.Now, DateTime.Now ,walletId , true);
                InitializePaginationButtons();
            }
            else
            {
                if ((sender is CurveButtons btn) && !flag)
                {
                    flag = true;
                    if (choiceIndex < pastChoices.Count)
                    {   
                        if (pastChoices[choiceIndex].Select == true)
                        {
                            pastChoices[choiceIndex].Select = false;
                        }
                        else
                        {
                            pastChoices[choiceIndex].Select = true;
                        }
                    }
                }
                else if (!flag)
                {
                    flag = true;
                    if (currentChoices.Count > choiceIndex)
                    {
                        currentChoices[choiceIndex].Select = false;
                    }
                    if (pastChoices.Count > choiceIndex)
                    {
                        pastChoices[choiceIndex].Select = false;
                    }
                    if (pastChoices.Count != 0)
                    {
                        pastChoices[0].Select = true;
                    }
                }
                flag = false;
                choiceIndex = 0;
                foreach(CurveButtons btns in pastChoices)
                {
                    if (btns.Select == true)
                    {
                        break;
                    }
                    choiceIndex++;
                }
                if (customeDates.Count > choiceIndex)
                {
                    budgets = Communicator.Manager.FetchRecords(pastBudgets[choiceIndex].Choice , Convert.ToDateTime(customeDates[choiceIndex].Item1), Convert.ToDateTime(customeDates[choiceIndex].Item2), walletId , false);//add wallet id
                }
                InitializePaginationButtons();
            }
            paginationControl.SelectStarting();
            ShowBudgets();
        }

        private void OnSelectChoiceBtnClicked(object sender, EventArgs e)
        {
            if(periodPanel.Visible == true)
            {
                EnableOrDisableControls(true);
                selectWalletPanel.Enabled = true;
                periodPanel.Visible = false;
            }
            else
            {
                EnableOrDisableControls(false);
                selectWalletPanel.Enabled = false;
                periodPanel.Visible = true;
            }
        }
        
        private void OnSelectWalletBtnClicked(object sender, EventArgs e)
        {
            if(walletsPanel.Visible == true)
            {
                EnableOrDisableControls(true);
                selectChoicePanel.Enabled = true;
                walletsPanel.Visible = false;
            }
            else
            {
                EnableOrDisableControls(false);
                selectChoicePanel.Enabled = false;
                walletsPanel.Visible = true;
            }
        }
        
        private void OnSingleWalletSelected(object sender, string name, int id)
        {
            walletId = id;
            walletNameLbl.Text = name;
            InitializeBudgetPage();
            walletsPanel.Visible = false;
            pastChoicePanel.Enabled = true;
            currentChoicePanel.Enabled = true;
            paginationControl.Enabled = true;
            mainPanel.Enabled = true;
            walletsPanel.Visible = false;
            selectChoicePanel.Enabled = true;
        }
    }
}
