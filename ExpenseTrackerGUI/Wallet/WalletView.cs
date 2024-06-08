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
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI
{
    public partial class WalletView : UserControl
    {
        public WalletView()
        {
            InitializeComponent();

            modifyWallet = new ModifyWallet();
            modifyWallet.WalletChange += OnWalletChanged;
            modifyWallet.WalletClose += OnWalletClosed;
            modifyWallet.Hide();
            this.Controls.Add(modifyWallet);

            GUIStyles.ColorChanged += OnColorChanged;
        }

        public delegate void WalletEventHandler(Image image, Wallet e);
        public event WalletEventHandler WalletSelect;
        public event EventHandler WalletClose;

        private ModifyWallet modifyWallet;
        private List<WalletCard> walletCards = new List<WalletCard>();
        private bool totalShow = true, showBorder = true, editMode=false, addMode;

        #region Properties 

        public string Title
        {
            get => lblTitle.Text;
            set
            {
                if (value == null || value == "") return;
                lblTitle.Text = value;
            }
        }

        public bool EditMode
        {
            get => editMode;
            set
            {
                editMode = value;
                if (value)
                {
                    Title = "My Wallets";
                    pbBack.Hide();
                    lblTitle.Location = new Point(11, 6);
                }
                else
                {
                    Title = "Select Wallet";
                    pbBack.Show();
                    lblTitle.Location = new Point(50, 6);
                }
            }
        }

        public bool AddMode
        {
            get => addMode;
            set
            {
                addMode = value;
                if (addMode)
                {
                    pnlAddWallet.Show();
                    tableLayoutPanel1.RowStyles[1] = new RowStyle(SizeType.Absolute, 50);
                    tableLayoutPanel1.RowStyles[2] = new RowStyle(SizeType.Absolute, 20);
                }
                else
                {
                    pnlAddWallet.Hide();
                    tableLayoutPanel1.RowStyles[1] = new RowStyle(SizeType.Absolute, 0);
                    tableLayoutPanel1.RowStyles[2] = new RowStyle(SizeType.Absolute, 0);
                }
            }
        }

        public bool ShowBorder
        {
            get => showBorder;
            set
            {
                showBorder = value;
                if (value)
                {
                    pnlTop.Height = 50;
                    pnlLeft.Width = pnlRight.Width = pnlBottom.Height = 12;
                }
                else
                {
                    pnlTop.Height = pnlLeft.Width = pnlRight.Width = pnlBottom.Height = 0;
                }
            }
        }

        public bool TotalShow
        {
            get => totalShow;
            set
            {
                totalShow = value;
                if (value)
                {
                    tpnlTotal.Show();
                    tpnlTotal.Height = 100;
                }
                else
                {
                    tpnlTotal.Hide();
                    tpnlTotal.Height = 0;
                }
            }
        }

        public void ChangeWidth(int W)
        {
            int width = W - 70;
            if (pnlShow.VerticalScroll.Visible) width -= 30;
            foreach (Control c in pnlShow.Controls) c.Width = width;
        }

        #endregion

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.DesignMode)
            {
                GetWallets();
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (!this.DesignMode)
            {
                if (this.Visible)
                {
                    this.SuspendLayout();
                    modifyWallet.Hide();
                    GetWallets();
                    ChangeTotalWallet();
                    this.ResumeLayout();
                }
            }
        }
        
        #endregion

        #region Total Wallet 

        private void OnTotalClicked(object sender, EventArgs e)
        {
            WalletSelect?.Invoke(Image.FromFile(".\\ResourceImages\\globe.png"), new Wallet() { WalletID = 0, WalletName = "Total", Amount = ChangeTotalWallet() });
        }

        private int ChangeTotalWallet()
        {
            if (!this.DesignMode)
            {
                int amount = 0;
                foreach (int num in Communicator.Manager.FetchWallet().Select(i => i.Amount)) amount += num;
                totalWallet.CardBalance = amount.ToString();
                return amount;
            }
            return 0;
        }

        #endregion

        #region Wallet Change

        private void GetWallets()
        {
            if (!this.DesignMode)
            {
                foreach (var v in walletCards)
                {
                    v.Dispose();
                    v.Click -= OnCardClicked;
                }
                walletCards.Clear();
                pnlShow.Controls.Clear();

                List<Wallet> list = Communicator.Manager.FetchWallet();
                if (list == null || list.Count == 0) return;
                foreach (Wallet wallet in list)
                {
                    WalletCard card = new WalletCard();
                    walletCards.Add(card);
                    pnlShow.Controls.Add(card);
                    card.IsWallet = true;
                    card.Name = wallet.WalletID.ToString();
                    card.CardName = wallet.WalletName;
                    card.CardBalance = wallet.Amount.ToString();

                    card.CardBackColor = GUIStyles.whiteColor;
                    card.ForeColor = GUIStyles.blackColor;
                    card.OutLineColor = GUIStyles.backColor;

                    card.Click += OnCardClicked;
                }
                ArrangeCards();
            }
        }

        private void ArrangeCards()
        {
            int xPos = 0, yPos = 0, walletSpace = 10;
            pnlShow.VerticalScroll.Value = 0;
            if (walletCards == null || walletCards.Count == 0) return;
            foreach (WalletCard card in walletCards)
            {
                card.Location = new Point(xPos, yPos);
                yPos += (card.Height + walletSpace);
                card.Width = pnlShow.Width;
            }

            if (pnlShow.VerticalScroll.Visible)
            {
                foreach (WalletCard card in walletCards)
                {
                    card.Width = pnlShow.Width - 20;
                }
            }
        }
        
        private void OnBackBtnClicked(object sender, EventArgs e)
        {
            modifyWallet.Hide();
            WalletClose?.Invoke(this, EventArgs.Empty);
        }
        
        private void OnWalletClosed(object sender, EventArgs e)
        {
            modifyWallet.Hide();
        }

        private void OnWalletChanged(ModifyWallet.WalletMode mode, Wallet e)
        {
            if (mode == ModifyWallet.WalletMode.AddMode)
            {
                GetWallets();
            }
            else if (mode == ModifyWallet.WalletMode.EditMode)
            {
                WalletCard card = walletCards.Find(i => int.Parse(i.Name) == e.WalletID);
                card.CardName = e.WalletName;
                card.CardBalance = e.Amount.ToString();
            }
            else if (mode == ModifyWallet.WalletMode.DeleteMode)
            {
                WalletCard card = walletCards.Find(i => int.Parse(i.Name) == e.WalletID);
                card.Click -= OnCardClicked;
                walletCards.Remove(card);
                pnlShow.Controls.Remove(card);

                card.Dispose();

                ArrangeCards();
            }
            ChangeTotalWallet();
            modifyWallet.Hide();
        }

        private void OnMouseEntered(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void OnMouseLeaved(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

        private void OnCardClicked(object sender, EventArgs e)
        {
            if (sender is WalletCard card)
            {
                Wallet wallet = Communicator.Manager.FetchWallet(int.Parse(card.Name));
                if (EditMode)
                {
                    modifyWallet.GetData(wallet, ModifyWallet.WalletMode.EditMode);
                    modifyWallet.Location = new Point(((Width / 2) - (modifyWallet.Width / 2)), ((Height / 2) - (modifyWallet.Height / 2)));
                    modifyWallet.Show();
                    modifyWallet.BringToFront();
                }
                else
                {
                    WalletSelect?.Invoke(Image.FromFile(".\\ResourceImages\\Wallets.png"), wallet);
                }
            }
        }

        private void OnAddWalletClickTriggered(object sender, EventArgs e)
        {
            if (!modifyWallet.Visible)
            {
                modifyWallet.GetData(new Wallet(), ModifyWallet.WalletMode.AddMode);
                modifyWallet.Location = new Point(((Width / 2) - (modifyWallet.Width / 2)), ((Height / 2) - (modifyWallet.Height / 2)));
                modifyWallet.Show();
                modifyWallet.BringToFront();
            }
        }
        
        private void OnColorChanged(bool e)
        {
            pnlTop.BackColor = pnlRight.BackColor = pnlLeft.BackColor = pnlBottom.BackColor = GUIStyles.primaryColor;
            lblTitle.ForeColor = GUIStyles.whiteColor;

            totalWallet.CardBackColor = GUIStyles.whiteColor;
            totalWallet.ForeColor = GUIStyles.blackColor;
            totalWallet.OutLineColor = GUIStyles.backColor;

            lblAddWallet.ForeColor = GUIStyles.primaryColor;
            pnlAddWallet.BackColor = GUIStyles.whiteColor;

            if (GUIStyles.colorName == "black")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\BlackPlus.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\DarkPlus.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\RedPlus.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\OrangePlus.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\PinkPlus.png");
            }
            else
            {
                pbAdd.Image = Image.FromFile(".\\CategoryImages\\BluePlus.png");
            }

            this.BackColor = GUIStyles.backColor;
        }
        
        #endregion
    }
}
