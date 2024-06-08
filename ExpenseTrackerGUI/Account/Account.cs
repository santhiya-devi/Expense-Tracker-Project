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

namespace ExpenseTrackerGUI.Account
{
    public partial class Account : UserControl
    {
        #region Constructor & Load event

        public Account()
        {
            InitializeComponent();            
        }

        private void accountDetailsPanel_Load(object sender, EventArgs e)
        {
            changeBtn.ForeColor = GUIStyles.primaryColor;
            deleteBtn.ForeColor = GUIStyles.primaryColor;
            signOutBtn.ForeColor = GUIStyles.primaryColor;
            changePassword.ForeColor = GUIStyles.primaryColor;
            deleteAccount.ForeColor = GUIStyles.primaryColor;

            GUIStyles.ColorChanged += ONGUIStyles_ColorChanged;

            HideFunction();
            resultShowPanel.Hide();
        }

        #endregion

        #region Variable creation

        bool cnt1 = true, cnt2 = true;
        int cnt = 0, count = 0;

        #endregion

        #region Events

        public event EventHandler OnNextPictureClick;
        public event EventHandler DeleteAccount;
        public event EventHandler AccountClick;

        private void ONGUIStyles_ColorChanged(bool e)
        {
            SetStyles();
        }
        #endregion

        #region User defined function

        public void ChangeImage()
        {
            userNameLabel.Text = Communicator.Manager.username;
            emailLabel.Text = Communicator.Manager.mailId;
            Communicator.Manager.FetchUserImage();
            if (Communicator.Manager.image != "")
            {
                Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                pictureBox1.Image = null;
                pictureBox1.BackgroundImage = null;
                pictureBox1.Image = bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                SetStyles();
            }
        }

        public void ShowUsername()
        {
            userNameLabel.Text = Communicator.Manager.username;
            emailLabel.Text = Communicator.Manager.mailId;
        }

        private void ShowFunction()
        {
            deletePanel.Location = new Point(3, 410);
            changePicture.Show();
            changeLabel.Show();
            oldLbl.Show();
            newLbl.Show();
            oldTextBox.Show();
            newTextbox.Show();
            oldEyeShow.Show();
            OldEyeClose.Show();
            newEyeHide.Show();
            newEyeShow.Show();
            changePassword.Show();
            passwordPanel.Show();
            panel1.BringToFront();
            panel2.BringToFront();
            panel1.Show();
            panel2.Show();

            infoPanel.Hide();
            infoLabel.Hide();
            info1.Hide();
            info2.Hide();
            info3.Hide();
            picture1.Hide();
            picture2.Hide();
            picture3.Hide();
            deleteAccount.Hide();
        }

        public void HideFunction()
        {
            changePicture.Hide();
            changeLabel.Hide();
            oldLbl.Hide();
            newLbl.Hide();
            oldTextBox.Hide();
            newTextbox.Hide();
            oldEyeShow.Hide();
            OldEyeClose.Hide();
            newEyeHide.Hide();
            newEyeShow.Hide();
            changePassword.Hide();
            passwordPanel.Hide();
            panel1.Hide();
            panel2.Hide();
            infoPanel.Hide();
            infoLabel.Hide();
            info1.Hide();
            info2.Hide();
            info3.Hide();
            picture1.Hide();
            picture2.Hide();
            picture3.Hide();
            deleteAccount.Hide();
        }

        public void SetStyles()
        {
            accountDetailsPanel.CardBorderColor = GUIStyles.primaryColor;
            changeBtn.ForeColor = GUIStyles.primaryColor;
            deleteBtn.ForeColor = GUIStyles.primaryColor;
            signOutBtn.ForeColor = GUIStyles.primaryColor;
            deleteAccount.ForeColor = GUIStyles.primaryColor;
            changePassword.ForeColor = GUIStyles.primaryColor;
            passwordPanel.CardBorderColor = GUIStyles.primaryColor;
            infoPanel.CardBorderColor = GUIStyles.primaryColor;

            if (GUIStyles.colorName == "black")
            {
                pictureBox1.Image = Image.FromFile(@".\Images\account2.png");
                nextPicture.Image = Image.FromFile(@".\Images\n4.png");
                changePicture.Image = Image.FromFile(@".\Images\r3.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                pictureBox1.Image = Image.FromFile(@".\Images\account3.png");
                nextPicture.Image = Image.FromFile(@".\Images\n4.png");
                changePicture.Image = Image.FromFile(@".\Images\r4.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                pictureBox1.Image = Image.FromFile(@".\Images\account.png");
                nextPicture.Image = Image.FromFile(@".\Images\n1.png");
                changePicture.Image = Image.FromFile(@".\Images\r5.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                pictureBox1.Image = Image.FromFile(@".\Images\account4.png");
                nextPicture.Image = Image.FromFile(@".\Images\n2.png");
                changePicture.Image = Image.FromFile(@".\Images\r1.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                pictureBox1.Image = Image.FromFile(@".\Images\account5.png");
                nextPicture.Image = Image.FromFile(@".\Images\n3.png");
                changePicture.Image = Image.FromFile(@".\Images\r2.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                pictureBox1.Image = Image.FromFile(@".\Images\z23.png");
                nextPicture.Image = Image.FromFile(@".\Images\z36.png");
                changePicture.Image = Image.FromFile(@".\Images\z27.png");
            }

            if (Communicator.Manager.image != "")
            {
                Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                pictureBox1.Image = null;
                pictureBox1.BackgroundImage = null;
                pictureBox1.Image = bitmap;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public void Reload()
        {
            accountDetailsPanel_Load(this, EventArgs.Empty);
        }

        #endregion

        #region Click events

        private void oldLbl_Click(object sender, EventArgs e)
        {
            oldLbl.Hide();
            oldTextBox.Cursor = Cursors.IBeam;
        }

        private void newLbl_Click(object sender, EventArgs e)
        {
            newLbl.Hide();
        }

        private void OldEyeClose_Click(object sender, EventArgs e)
        {
            if (oldTextBox.PasswordChar == '\0')
            {
                OldEyeClose.Hide();
                oldEyeShow.Show();
                oldTextBox.PasswordChar = '*';
                oldTextBox.Font = new Font("Arial", 18, FontStyle.Bold);
            }            
        }

        private void newEyeHide_Click(object sender, EventArgs e)
        {
            if (newTextbox.PasswordChar == '\0')
            {
                newEyeHide.Hide();
                newEyeShow.Show();
                newTextbox.PasswordChar = '*';
                newTextbox.Font = new Font("Arial", 18, FontStyle.Bold);
            }
        }

        private void oldEyeShow_Click(object sender, EventArgs e)
        {
            if (oldTextBox.PasswordChar == '*')
            {
                oldEyeShow.Hide();
                OldEyeClose.Show();
                oldTextBox.PasswordChar = '\0';
                oldTextBox.Font = new Font("Arial", 10, FontStyle.Bold);
            }
        }

        private void newEyeShow_Click(object sender, EventArgs e)
        {
            if (newTextbox.PasswordChar == '*')
            {
                newEyeShow.Hide();
                newEyeHide.Show();
                newTextbox.PasswordChar = '\0';
                newTextbox.Font = new Font("Arial", 10, FontStyle.Bold);
            }            
        }        

        private void changeBtn_Click(object sender, EventArgs e)
        {
            cnt2 = true;
            if (cnt1 == true)
            {
                HideFunction();
                cnt1 = false;
                cnt2 = true;
            }
            else
            {
                ShowFunction();
                cnt1 = true;
                cnt2 = true;
            }
        }                

        private void nextPicture_Click(object sender, EventArgs e)
        {
            OnNextPictureClick?.Invoke(this, EventArgs.Empty);
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            string result = "";
            if (Communicator.Manager.IsPasswordEqual(oldTextBox.Text))
            {
                Communicator.Manager.SwitchDatabase("expense_tracker_application");
                var res = Communicator.Manager.ResetPassword(Communicator.Manager.mailId, newTextbox.Text);
                Communicator.Manager.SwitchDatabase("expensetracker");
                result = "Changed successfully";
                timer2.Start();
            }
            else
            {
                result = "Password incorrect.";
            }
            timer1.Start();
            resultShowLbl.Text = result;
        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            Communicator.Manager.RemoveData();
            DeleteAccount?.Invoke(this, EventArgs.Empty);
        }

        private void signOutBtn_Click(object sender, EventArgs e)
        {
            DeleteAccount?.Invoke(this, EventArgs.Empty);
        }

        private void accountDetailsPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountClick?.Invoke(this, EventArgs.Empty);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            cnt1 = true;
            if (cnt2 == true)
            {
                HideFunction();
                cnt2 = false;
                cnt1 = true;
            }
            else
            {
                changePicture.Hide();
                changeLabel.Hide();
                oldLbl.Hide();
                newLbl.Hide();
                oldTextBox.Hide();
                newTextbox.Hide();
                oldEyeShow.Hide();
                OldEyeClose.Hide();
                newEyeHide.Hide();
                newEyeShow.Hide();
                changePassword.Hide();
                passwordPanel.Hide();
                panel1.Hide();
                panel2.Hide();

                infoPanel.Show();
                infoLabel.Show();
                info1.Show();
                info2.Show();
                info3.Show();
                picture1.Show();
                picture2.Show();
                picture3.Show();
                deleteAccount.Show();

                deletePanel.Location = new Point(0, 179);
                cnt2 = true;
                cnt1 = true;
            }
        }

        private void cross1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AccountClick?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Timer tick events

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            if (cnt == 10)
            {
                timer1.Stop();
                resultShowPanel.Hide();
                cnt = 0;
            }
            else
            {
                resultShowPanel.Show();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            count++;
            if (count == 5)
            {
                timer2.Stop();
                this.Hide();
                AccountClick?.Invoke(this, EventArgs.Empty);
                count = 0;
            }
        }

        #endregion

        #region MouseEnter and MouseLeave events

        private void cross1_MouseEnter(object sender, EventArgs e)
        {
            cross1.Hide();
            cross2.Show();
        }

        private void cross1_MouseLeave(object sender, EventArgs e)
        {
            cross2.Hide();
            cross1.Show();
        }

        #endregion
    }
}