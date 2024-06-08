using ExpenseTracker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1174, 775);
            this.Location = new Point(390, 160);
            loginPage1.Show();
            loginPage1.LoginSuccessful += OnLoginPage1_LoginSuccessful;
            MemoryAllocation();
            this.Controls.Add(homeDashboard1);
            ratingPanel.BackColor = GUIStyles.primaryColor;
            ratingPanel.Hide();
            ratingLbl.Hide();
            rating1.Hide();
            mayBeLaterBtn.Hide();
            submitBtn.Hide();
            close.Hide();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
        }

        private HomeDashboard homeDashboard1;

        #region user-defined functions

        private void SetStyles()
        {
            ratingLbl.ForeColor = GUIStyles.primaryColor;
            ratingPanel.CardBorderColor = GUIStyles.primaryColor;
            mayBeLaterBtn.BackColor = GUIStyles.primaryColor;
            submitBtn.BackColor = GUIStyles.primaryColor;
            close.BackColor = GUIStyles.primaryColor;
            rating1.BorderColor = GUIStyles.primaryColor;
            ratingPanel.BackColor = GUIStyles.primaryColor;
        }

        private void MemoryAllocation()
        {
            homeDashboard1 = new HomeDashboard()
            {
                Dock = DockStyle.Fill,
                Visible = false
            };
            homeDashboard1.OnExitClick += OnHomeDashboard1_OnExitClick;
            homeDashboard1.HideHomeDashboard += OnHomeDashboard1_HideHomeDashboard;
        }

        #endregion

        #region subscribed  user defined-events

        private void OnLoginPage1_LoginSuccessful(object sender, EventArgs e)
        {
            loginPage1.Hide();
            this.WindowState = FormWindowState.Maximized;
            homeDashboard1.Show();
            homeDashboard1.HomeDashboard_Load(this, EventArgs.Empty);
            homeDashboard1.UpdateFunctions();
        }

        private void OnHomeDashboard1_HideHomeDashboard(object sender, EventArgs e)
        {
            homeDashboard1.Hide();
            this.WindowState = FormWindowState.Normal;
            this.Size = new Size(1174, 775);
            this.Location = new Point(390, 160);
            loginPage1.Show();
        }

        private void OnHomeDashboard1_OnExitClick(object sender, EventArgs e)
        {
            homeDashboard1.Enabled = false;
            if (!Communicator.Manager.IsRated())
            {
                ratingTimer.Stop();
                ratingPanel.Show();
                ratingLbl.Show();
                rating1.Show();
                mayBeLaterBtn.Show();
                submitBtn.Show();
                close.Show();
                ratingLbl.BringToFront();
                mayBeLaterBtn.BringToFront();
                close.BringToFront();
                rating1.BringToFront();
                submitBtn.BringToFront();
            } 
            else
            {
                this.Close();
            }            
        }

        private void OnGUIStyles_ColorChanged(bool e)
        {
            SetStyles();
        }

        public event EventHandler Timerstop;
        #endregion

        #region Click events

        private void mayBeLaterBtn_Click(object sender, EventArgs e)
        {
            this.Timerstop?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            Communicator.Manager.EditData(rating1.finalAns);
            this.Timerstop?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void close_Click_1(object sender, EventArgs e)
        {
            rating1.Hide();
            ratingPanel.Hide();
            submitBtn.Hide();
            mayBeLaterBtn.Hide();
            ratingLbl.Hide();
            close.Hide();
            homeDashboard1.Enabled = true;
        }
        #endregion
    }
}