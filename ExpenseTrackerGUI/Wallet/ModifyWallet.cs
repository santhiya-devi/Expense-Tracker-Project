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

namespace ExpenseTrackerGUI
{
    public partial class ModifyWallet : UserControl
    {
        public ModifyWallet()
        {
            InitializeComponent();

            wallet = new Wallet();
            temp = new Wallet();

            GUIStyles.ColorChanged += OnColorChanged;
        }

        public delegate void WalletChangeHander(WalletMode mode, Wallet e);

        public event EventHandler WalletClose;
        public event WalletChangeHander WalletChange;

        private Wallet wallet, temp;
        private WalletMode walletMode = WalletMode.AddMode;
        private bool nameCheck = false, balanceCheck = false;

        #region Properties

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public enum WalletMode
        {
            AddMode,
            EditMode,
            DeleteMode
        };

        #endregion

        #region GetData

        public void GetData(Wallet e, WalletMode mode)
        {
            if (e == null) return;
            
            temp = wallet = e;
            walletMode = mode;

            ChangeDeleteUI();
            Rebuild();

            if (mode == WalletMode.AddMode)
            {
                Title = "Add Wallet";
                this.Size = new Size(400, 340);

                tbWalletName.Text = "Wallet Name";
                tbBalance.Text = "Enter your current balance";
                tbWalletName.ForeColor = tbBalance.ForeColor = Color.Gray;

                btnSave.Enabled = false;
                btnSave.ButtonColor = Color.WhiteSmoke;
                btnSave.Show();

                nameCheck = balanceCheck = false;
            }
            else if (mode == WalletMode.EditMode)
            {
                Title = "Edit Wallet";
                this.Size = new Size(400, 400);

                tbWalletName.Text = e.WalletName;
                tbBalance.Text = e.Amount.ToString();
                tbWalletName.ForeColor = tbBalance.ForeColor = Color.Gray;

                nameCheck = balanceCheck = true;

                btnSave.Enabled = true;
                btnSave.ButtonColor = GUIStyles.primaryColor;
                btnSave.ButtonForeColor = GUIStyles.whiteColor;
            }
            tcWallet.SelectedTab = tabPage1;
            lblExist.Hide();

        }

        #endregion

        #region KeyPress

        bool WalletNameCheck = false, balanceNameCheck=false;

        private void OnTextBoxKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) WalletNameCheck = true;
            else WalletNameCheck = false;

            if((tbWalletName.Text=="" || tbWalletName.Text== "Wallet Name") && e.KeyChar==(char)Keys.Space)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || e.KeyChar == '\b' || e.KeyChar == ' ')
            {
                if ((tbWalletName.Text == "" || (tbWalletName.Text.Length == 1 && e.KeyChar == 8))&&e.KeyChar==(char)Keys.Back)
                {
                    tbWalletName.Text = "Wallet Name";
                    tbWalletName.ForeColor = Color.Gray;
                    nameCheck = false;
                }
                else if (tbWalletName.Text == "Wallet Name" && e.KeyChar != 8)
                {
                    tbWalletName.Text = "";
                    tbWalletName.ForeColor = GUIStyles.blackColor;
                    nameCheck = true;
                }
                else if (tbWalletName.Text == "Wallet Name" && e.KeyChar == 8)
                {
                    e.Handled = true;
                }
                else tbWalletName.ForeColor = GUIStyles.blackColor;
            }
            else e.Handled = true;
            CheckTextBox();
        }

        private void OnBalanceKeyPressed(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Back) balanceNameCheck = true;
            else balanceNameCheck = false;

            if ((tbBalance.Text == "" || tbBalance.Text== "Enter your current balance") && e.KeyChar == (char)Keys.Space)
            {
                e.Handled = true;
                return;
            }

            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '\b')
            {
                if ((tbBalance.Text == "" || (tbBalance.Text.Length == 1 && e.KeyChar == 8)) && e.KeyChar == (char)Keys.Back)
                {
                    tbBalance.Text = "Enter your current balance";
                    tbBalance.ForeColor = Color.Gray;
                    balanceCheck = false;
                }
                else if (tbBalance.Text == "Enter your current balance" && e.KeyChar != 8)
                {
                    tbBalance.Text = "";
                    tbBalance.ForeColor = GUIStyles.blackColor;
                    balanceCheck = true;
                }
                else if (tbBalance.Text == "Enter your current balance" && e.KeyChar == 8)
                {
                    e.Handled = true;
                }
                else tbBalance.ForeColor = GUIStyles.blackColor;
            }
            else e.Handled = true;
            CheckTextBox();
        }

        private void OnTextChanged(object sender, EventArgs e)
        {
            if (walletMode == WalletMode.AddMode)
            {
                if (Communicator.Manager.IsWalletExists(tbWalletName.Text))
                {
                    lblExist.Text = "This wallet already exists";
                    lblExist.Show();
                    nameCheck = false;
                }
                else if ((tbWalletName.Text == "" || string.IsNullOrEmpty(tbWalletName.Text.Trim())) && WalletNameCheck == true)
                {
                    tbWalletName.Text = "Wallet Name";
                    tbWalletName.ForeColor = Color.Gray;
                    nameCheck = false;
                }
                else
                {
                    lblExist.Hide();
                    nameCheck = true;
                }
            }
            else
            {
                if (temp.WalletName != tbWalletName.Text && Communicator.Manager.IsWalletExists(tbWalletName.Text))
                {
                    lblExist.Text = "This wallet already exists";
                    lblExist.Show();
                    nameCheck = false;
                }
                else if ((tbWalletName.Text == "" || string.IsNullOrEmpty(tbWalletName.Text.Trim())) && WalletNameCheck == true)
                {
                    tbWalletName.Text = "Wallet Name";
                    tbWalletName.ForeColor = Color.Gray;
                    nameCheck = false;
                }
                else
                {
                    lblExist.Hide();
                    nameCheck = true;
                }
            }
            CheckTextBox();
        }

        private void CheckTextBox()
        {
            if (nameCheck == true && balanceCheck == true)
            {
                btnSave.Enabled = true;
                btnSave.ButtonColor = GUIStyles.primaryColor;
                btnSave.ButtonForeColor = GUIStyles.whiteColor;
            }
            else
            {
                btnSave.Enabled = false;
                btnSave.ButtonColor = Color.WhiteSmoke;
                btnSave.ButtonForeColor = GUIStyles.blackColor;
            }
        }

        #endregion

        #region Cancel Click

        private void OnCancelClickTriggered(object sender, EventArgs e)
        {
            WalletClose?.Invoke(this, EventArgs.Empty);
            Rebuild();
        }

        #endregion

        #region Delete Wallet

        private void OnDeleteClickTriggered(object sender, EventArgs e)
        {
            pnlTop.Height = pnlBottom.Height = pnlLeft.Width = pnlRight.Width = 10;
            this.Size = new Size(400, 280);
            
            lblDeleteTitle.Text = $"Do you want to delete {wallet.WalletName} wallet?";
            lblMsg.Text = "You will also delete all of its transaction, budgets, events, bills and this action cannot be undone.";

            btnCancel.ButtonText = "Cancel";
            btnCancel.Show();
            btnDelete.Show();

            tcWallet.SelectedTab = tabPage2;
        }

        private void OnCancelBtnClicked(object sender, EventArgs e)
        {
            ChangeDeleteUI();
        }

        private void OnDeleteBtnClicked(object sender, EventArgs e)
        {
            Communicator.Manager.RemoveData(wallet);
            WalletChange?.Invoke(WalletMode.DeleteMode, wallet);
            ChangeDeleteUI();
            Rebuild();
        }

        #endregion

        #region Save Click

        private void OnSaveBtnClickTriggered(object sender, EventArgs e)
        {
            wallet.WalletName = tbWalletName.Text;
            wallet.Amount = float.Parse(tbBalance.Text);
            
            if(walletMode== WalletMode.AddMode)
            {
                Communicator.Manager.AddData(wallet);
                WalletChange?.Invoke(WalletMode.AddMode, wallet);
            }
            else if(walletMode== WalletMode.EditMode)
            {
                Communicator.Manager.EditData(wallet);
                WalletChange?.Invoke(WalletMode.EditMode, wallet);
            }
            
            Rebuild();
        }
        
        #endregion

        #region UI Rebuid

        private void Rebuild()
        {
            tbWalletName.Text = "Wallet Name";
            tbBalance.Text = "Enter your current balance";

            tbWalletName.ForeColor = tbBalance.ForeColor = Color.Gray;

            tcWallet.SelectedTab = tabPage1;
        }

        private void OnBalanceTextChanged(object sender, EventArgs e)
        {
            if ((tbBalance.Text == "" || string.IsNullOrEmpty(tbWalletName.Text.Trim())) && balanceNameCheck == true)
            {
                tbBalance.Text = "Enter your current balance";
                tbBalance.ForeColor = Color.Gray;
                balanceCheck = false;
            }
            CheckTextBox();
        }

        private void ChangeDeleteUI()
        {
            pnlTop.Height = 40;
            this.Size = new Size(400, 400);
            tcWallet.SelectedTab = tabPage1;
        }
        
        private void OnColorChanged(bool e)
        {
            lblTitle.ForeColor = GUIStyles.whiteColor;
            tabPage1.BackColor = tabPage2.BackColor = GUIStyles.backColor;
            tbWalletName.BackColor = tbBalance.BackColor = GUIStyles.backColor;

            pnlTop.BackColor = pnlRight.BackColor = pnlLeft.BackColor = pnlBottom.BackColor = GUIStyles.primaryColor;

            btnSave.ButtonColor = btnDelete.ButtonColor = btnCancel.ButtonColor = GUIStyles.primaryColor;
            btnSave.BorderColor = btnDelete.BorderColor = btnCancel.BorderColor = GUIStyles.backColor;
            btnSave.ForeColor = btnDelete.ForeColor = btnCancel.ForeColor = GUIStyles.whiteColor;

            //ImageChange
            if (GUIStyles.colorName == "black")
            {
                pbWallet.Image = Image.FromFile(".\\WalletImages\\BlackWallet.png");
                pbBalance.Image= Image.FromFile(".\\WalletImages\\BlackBalance.png");
                pbDelete.Image= Image.FromFile(".\\WalletImages\\BlackBin.png");
            }
            else if(GUIStyles.colorName == "brown")
            {
                pbWallet.Image = Image.FromFile(".\\WalletImages\\DarkWallet.png");
                pbBalance.Image = Image.FromFile(".\\WalletImages\\DarkBalance.png");
                pbDelete.Image = Image.FromFile(".\\WalletImages\\DarkBin.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                pbWallet.Image = Image.FromFile(".\\WalletImages\\RedWallet.png");
                pbBalance.Image = Image.FromFile(".\\WalletImages\\RedBalance.png");
                pbDelete.Image = Image.FromFile(".\\WalletImages\\RedBin.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                pbWallet.Image = Image.FromFile(".\\WalletImages\\OrangeWallet.png");
                pbBalance.Image = Image.FromFile(".\\WalletImages\\OrangeBalance.png");
                pbDelete.Image = Image.FromFile(".\\WalletImages\\OrangeBin.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                pbWallet.Image = Image.FromFile(".\\WalletImages\\PinkWallet.png");
                pbBalance.Image = Image.FromFile(".\\WalletImages\\PinkBalance.png");
                pbDelete.Image = Image.FromFile(".\\WalletImages\\PinkBin.png");
            }
            else
            {
                pbWallet.Image = Image.FromFile(".\\WalletImages\\BlueWallet.png");
                pbBalance.Image = Image.FromFile(".\\WalletImages\\BlueBalance.png");
                pbDelete.Image = Image.FromFile(".\\WalletImages\\BlueBin.png");
            }

            this.BackColor = GUIStyles.backColor;
        }
        
        #endregion

    }
}
