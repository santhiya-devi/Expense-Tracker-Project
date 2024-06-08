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

namespace ExpenseTrackerGUI
{
    public partial class MainCategoryView : UserControl
    {
        public MainCategoryView()
        {
            InitializeComponent();

            categoryView = new CategoryView();
            this.tabPage1.Controls.Add(categoryView);
            categoryView.Dock = DockStyle.Fill;
            categoryView.EditMode = true;
            categoryView.BorderWidth = 0;
            categoryView.SearchBar += OnSearchBarChanged;
            
            walletView = new WalletView();
            this.tabPage2.Controls.Add(walletView);
            walletView.Dock = DockStyle.Fill;

            walletView.AddMode = true;
            walletView.EditMode = false;
            walletView.TotalShow = true;
            walletView.ShowBorder = false;

            walletView.WalletSelect += OnWalletSelected;
            walletView.WalletClose += OnWalletClosed;

            tcCategory.SelectedTab = tabPage1;

            GUIStyles.ColorChanged += OnColorChanged;
        }

        private CategoryView categoryView;
        private WalletView walletView;

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (!this.DesignMode)
            {
                this.SuspendLayout();

                categoryView.Visible = false;

                LoadShow();

                categoryView.WalletChange = new Wallet() { WalletID = 0, WalletName = "Total" };

                lblTitle.Text = "My Categories";
                mainCategoryViewSearch.Show();

                lblWalletName.Text = "Total";
                tcCategory.SelectedTab = tabPage1;

                pbWalletIamge.Image = Image.FromFile(".\\ResourceImages\\globe.png");

                categoryView.Visible = true;
                this.ResumeLayout();
            }
        }

        private void OnWalletClosed(object sender, EventArgs e)
        {
            lblTitle.Text = "My Categories";
            mainCategoryViewSearch.Show();

            tcCategory.SelectedTab = tabPage1;
        }

        private void OnWalletSelected(Image image, Wallet e)
        {
            LoadShow();

            lblTitle.Text = "My Categories";
            mainCategoryViewSearch.Show();

            lblWalletName.Text = e.WalletName;
            categoryView.WalletChange = e;
            tcCategory.SelectedTab = tabPage1;

            pbWalletIamge.Image = image;
        }
        
        private void OnSearchBackClicked(object sender, EventArgs e)
        {
            categoryView.SearchText = "";
            mainCategoryViewSearch.SendToBack();
            mainCategoryViewSearch.Width = 90;
        }

        private void OnSearchBarClicked(object sender, EventArgs e)
        {
            if (!categoryView.ModifyCategoryVisibility)
            {
                mainCategoryViewSearch.BringToFront();
                mainCategoryViewSearch.Width = this.Width;
            }
        }

        private void OnSearchBarTextChanged(object sender, string e)
        {
            categoryView.SearchText = e;
        }

        private void OnSearchBarChanged(object sender, EventArgs e)
        {
            mainCategoryViewSearch.SearchBarShow = false;
            categoryView.SearchText = "";
        }

        private void OnWalletChangeClicked(object sender, EventArgs e)
        {
            if (!categoryView.ModifyCategoryVisibility)
            {
                lblTitle.Text = "Select Wallet";
                mainCategoryViewSearch.Hide();
                tcCategory.SelectedTab = tabPage2;
            }
        }
        
        private void OnColorChanged(bool e)
        {
            lblTitle.ForeColor = lblWalletName.ForeColor = GUIStyles.whiteColor;
            panel1.BackColor = panel2.BackColor = panel3.BackColor = panel4.BackColor = GUIStyles.primaryColor;
            tabPage1.BackColor = tabPage2.BackColor = GUIStyles.backColor;
            mainCategoryViewSearch.ColorChange();
        }

        private void OnTimerTicked(object sender, EventArgs e)
        {
            pnlLoad.Visible = false;
            pnlLoad.SendToBack();
            categoryTimer.Stop();
            load1.Timerload = false;
        }

        private void LoadShow()
        {
            pnlLoad.Dock = DockStyle.Fill;
            pnlLoad.BringToFront();
            treeControl1.Width = treeControl2.Width = treeControl3.Width = treeControl4.Width = this.Width - 60;
            load1.Location = new Point(((this.Width / 2) - (load1.Width / 2)), ((this.Height / 2) - (load1.Height / 2)));
            pnlLoad.Visible = true;
            load1.Timerload = true;
            categoryTimer.Start();
        }
    }
}
