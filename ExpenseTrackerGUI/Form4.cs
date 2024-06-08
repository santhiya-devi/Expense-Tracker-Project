using ExpenseTracker;
using ExpenseTrackerDS;
using ExpenseTrackerGUI.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            this.BackColor = GUIStyles.primaryColor;
            space1.BackColor = Color.White;
            space2.BackColor = Color.White;
            space3.BackColor = Color.White;
            space4.BackColor = Color.White;
            logo1.TimerStop += OnLogo1_TimerStop;
        }

        private void OnLogo1_TimerStop(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.Show();
            this.Hide();            
            mainForm.Timerstop += OnMainForm_Timerstop;
        }

        private void OnMainForm_Timerstop(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
