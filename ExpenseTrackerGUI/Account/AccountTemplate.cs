using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using ExpenseTrackerDS;
using ExpenseTracker;

namespace ExpenseTrackerGUI.Account
{
    public partial class AccountTemplate : UserControl
    {
        #region Constructors and Load events

        public AccountTemplate()
        {
            InitializeComponent();
            SetRoundPictureBox();
            ShowControls();
            settingsBtn.Click += settingsPicture_Click;
            toolsBtn.Click += toolsPicture_Click;
            aboutBtn.Click += aboutPicture_Click;
            showCsv.Hide();
            currencyConvertorPanel.Hide();
            interestRateCalculator.Hide();
            exportToCSV1.CloseBtnClick += OnExportToCSV1_CloseBtnClick;
            userNameLabel.Text = Communicator.Manager.username;
            mailLabel.Text = Communicator.Manager.mailId;
            signoutPanel.Hide();
            cardPanel1.Hide();
            UserNametextBox.Hide();
            themePanel.Hide();
            themePanel1.Hide();
        }

        private void AccountTemplate_Load(object sender, EventArgs e)
        {
            ShowControls();
            var res = Communicator.Manager.FetchImage();
            if (res != "")
            {
                Bitmap bitmap = new Bitmap(res);
                imagePictureBox.Image = null;
                imagePictureBox.BackgroundImage = null;
                imagePictureBox.Image = bitmap;
                imagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        #endregion

        #region Variable creation and Event creation

        static bool toolsCnt = true, settingsCnt = true, aboutCnt = true, themeCnt = true;

        public event EventHandler ImageChange;
        public event EventHandler walkthroughClick;
        public event EventHandler ChangeUserName;
        public event EventHandler Signout;

        #endregion

        #region User defined functions

        private void SetRoundPictureBox()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, imagePictureBox.Width, imagePictureBox.Height);
            imagePictureBox.Region = new Region(path);
            imagePictureBox.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ShowControls()
        {
            userNameLabel.Text = Communicator.Manager.username;
            mailLabel.Text = Communicator.Manager.mailId;
            this.BackColor = GUIStyles.backColor;
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;

            linePanel.Width = this.Width - 60;
            toolPanel.Height = 91;
            settingsPanel.Height = 91;
            aboutPanel.Height = 91;

            csvPicture.Hide();
            CSVBtn.Hide();
            interestRatePicture.Hide();
            interestRateBnt.Hide();
            theme.Hide();
            themePanel1.Hide();
            themePanel.Hide();
            themePicture.Hide();
            currency.Hide();
            currencyPicture.Hide();
            signoutPicture.Hide();
            signoutBtn.Hide();
            walkthroughPicture.Hide();
            walkthroughBtn.Hide();            
            showCsv.Hide();
            UserNametextBox.Hide();
            currencyConvertorPanel.Hide();
            interestRateCalculator.Hide();

            accountPanel.Show();
            space1.Show();
            toolPanel.Show();
            space2.Show();
            settingsPanel.Show();
            space3.Show();
            aboutPanel.Show();
            space4.Show();
        }

        private void ShowTools()
        {
            csvPicture.Show();
            CSVBtn.Show();
            interestRatePicture.Show();
            interestRateBnt.Show();
            currency.Show();
            currencyPicture.Show();

            theme.Hide();
            themePanel.Hide();
            themePanel1.Hide();
            themePicture.Hide();
            signoutPicture.Hide();
            signoutBtn.Hide();
            walkthroughPicture.Hide();
            walkthroughBtn.Hide();

            toolPanel.Height = 285;
            settingsPanel.Height = 91;
            aboutPanel.Height = 91;
        }

        public void ShowUsername()
        {
            userNameLabel.Text = Communicator.Manager.username;
            mailLabel.Text = Communicator.Manager.mailId;
            if (Communicator.Manager.image != "")
            {
                Bitmap bitmap = new Bitmap(Communicator.Manager.image);
                imagePictureBox.Image = null;
                imagePictureBox.BackgroundImage = null;
                imagePictureBox.Image = bitmap;
                imagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                imagePictureBox.Image = null;
                imagePictureBox.BackgroundImage = Image.FromFile(@".\Images\user1.png");
            }
        }

        public void SetStyles()
        {
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            userNameLabel.ForeColor = GUIStyles.blackColor;
            mailLabel.ForeColor = GUIStyles.blackColor;
            toolsBtn.ForeColor = GUIStyles.blackColor;
            CSVBtn.ForeColor = GUIStyles.blackColor;
            currency.ForeColor = GUIStyles.blackColor;
            interestRateBnt.ForeColor = GUIStyles.blackColor;
            settingsBtn.ForeColor = GUIStyles.blackColor;
            theme.ForeColor = GUIStyles.blackColor;
            signoutBtn.ForeColor = GUIStyles.blackColor;
            aboutBtn.ForeColor = GUIStyles.blackColor;
            walkthroughBtn.ForeColor = GUIStyles.blackColor;
            yesBtn.BackColor = GUIStyles.primaryColor;
            NoBtn.BackColor = GUIStyles.primaryColor;
            yesBtn.ForeColor = GUIStyles.whiteColor;
            NoBtn.ForeColor = GUIStyles.whiteColor;
            yesBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            NoBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            this.BackColor = GUIStyles.backColor;
            topPanel.BackColor = GUIStyles.primaryColor;
            bottomPanel.BackColor = GUIStyles.primaryColor;
            leftPanel.BackColor = GUIStyles.primaryColor;
            rightPanel.BackColor = GUIStyles.primaryColor;
            cardPanel1.CardBorderColor = GUIStyles.primaryColor;
            themePanel.CardBorderColor = GUIStyles.primaryColor;
            themePanel.CardBackColor = GUIStyles.whiteColor;
            themePanel1.BackColor = GUIStyles.whiteColor;

            if (GUIStyles.colorName == "black")
            {
                currencyPicture.Image = Image.FromFile(@".\Images\curr3.png");
                aboutPicture.Image = Image.FromFile(@".\Images\output4.png");
                themePicture.Image = Image.FromFile(@".\Images\theme3.png");
                toolsPicture.Image = Image.FromFile(@".\Images\tools2.png");
                settingsPicture.Image = Image.FromFile(@".\Images\set4.png");
                interestRatePicture.Image = Image.FromFile(@".\Images\per3.png");
                csvPicture.Image = Image.FromFile(@".\Images\e3.png");
                signoutPicture.Image = Image.FromFile(@".\Images\s5.png");
                walkthroughPicture.Image = Image.FromFile(@".\Images\w4.png");
            }
            else if (GUIStyles.colorName == "brown")
            {
                currencyPicture.Image = Image.FromFile(@".\Images\curr4.png");
                aboutPicture.Image = Image.FromFile(@".\Images\output5.png");
                themePicture.Image = Image.FromFile(@".\Images\theme2.png");
                toolsPicture.Image = Image.FromFile(@".\Images\tools3.png");
                settingsPicture.Image = Image.FromFile(@".\Images\set5.png");
                interestRatePicture.Image = Image.FromFile(@".\Images\per4.png");
                csvPicture.Image = Image.FromFile(@".\Images\e2.png");
                signoutPicture.Image = Image.FromFile(@".\Images\s3.png");
                walkthroughPicture.Image = Image.FromFile(@".\Images\w5.png");
            }
            else if (GUIStyles.colorName == "blue")
            {
                currencyPicture.Image = Image.FromFile(@".\Images\curr1.png");
                aboutPicture.Image = Image.FromFile(@".\Images\output1.png");
                themePicture.Image = Image.FromFile(@".\Images\theme5.png");
                toolsPicture.Image = Image.FromFile(@".\Images\tools5.png");
                settingsPicture.Image = Image.FromFile(@".\Images\set1.png");
                interestRatePicture.Image = Image.FromFile(@".\Images\per5.png");
                csvPicture.Image = Image.FromFile(@".\Images\e1.png");
                signoutPicture.Image = Image.FromFile(@".\Images\s1.png");
                walkthroughPicture.Image = Image.FromFile(@".\Images\w1.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                currencyPicture.Image = Image.FromFile(@".\Images\curr5.png");
                aboutPicture.Image = Image.FromFile(@".\Images\output2.png");
                themePicture.Image = Image.FromFile(@".\Images\theme1.png");
                toolsPicture.Image = Image.FromFile(@".\Images\tools1.png");
                settingsPicture.Image = Image.FromFile(@".\Images\set2.png");
                interestRatePicture.Image = Image.FromFile(@".\Images\per1.png");
                csvPicture.Image = Image.FromFile(@".\Images\e5.png");
                signoutPicture.Image = Image.FromFile(@".\Images\s2.png");
                walkthroughPicture.Image = Image.FromFile(@".\Images\w2.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                currencyPicture.Image = Image.FromFile(@".\Images\curr2.png");
                aboutPicture.Image = Image.FromFile(@".\Images\output3.png");
                themePicture.Image = Image.FromFile(@".\Images\theme4.png");
                toolsPicture.Image = Image.FromFile(@".\Images\tools4.png");
                settingsPicture.Image = Image.FromFile(@".\Images\set3.png");
                interestRatePicture.Image = Image.FromFile(@".\Images\per2.png");
                csvPicture.Image = Image.FromFile(@".\Images\e4.png");
                signoutPicture.Image = Image.FromFile(@".\Images\s4.png");
                walkthroughPicture.Image = Image.FromFile(@".\Images\w3.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                currencyPicture.Image = Image.FromFile(@".\Images\z13.png");
                aboutPicture.Image = Image.FromFile(@".\Images\z37.png");
                themePicture.Image = Image.FromFile(@".\Images\z29.png");
                toolsPicture.Image = Image.FromFile(@".\Images\z31.png");
                settingsPicture.Image = Image.FromFile(@".\Images\z28.png");
                interestRatePicture.Image = Image.FromFile(@".\Images\z25.png");
                csvPicture.Image = Image.FromFile(@".\Images\z15.png");
                signoutPicture.Image = Image.FromFile(@".\Images\z19.png");
                walkthroughPicture.Image = Image.FromFile(@".\Images\z4.png");
            }
        }

        private void ShowSettings()
        {
            csvPicture.Hide();
            CSVBtn.Hide();
            interestRatePicture.Hide();
            interestRateBnt.Hide();
            walkthroughPicture.Hide();
            walkthroughBtn.Hide();

            theme.Show();
            themePicture.Show();
            currency.Show();
            currencyPicture.Show();
            signoutPicture.Show();
            signoutBtn.Show();

            toolPanel.Height = 91;
            settingsPanel.Height = 215;
            aboutPanel.Height = 91;
        }

        private void ShowAbout()
        {
            csvPicture.Hide();
            CSVBtn.Hide();
            interestRatePicture.Hide();
            interestRateBnt.Hide();
            theme.Hide();
            themePanel1.Hide();
            themePanel1.Hide();
            themePicture.Hide();
            currency.Hide();
            currencyPicture.Hide();
            signoutPicture.Hide();
            signoutBtn.Hide();

            walkthroughPicture.Show();
            walkthroughBtn.Show();

            toolPanel.Height = 91;
            settingsPanel.Height = 91;
            aboutPanel.Height = 143;
        }

        public void Reload()
        {
            AccountTemplate_Load(this, EventArgs.Empty);
        }

        #endregion

        #region Subscribed events

        private void OnExportToCSV1_CloseBtnClick(object sender, EventArgs e)
        {
            showCsv.Hide();
            accountPanel.Show();
            space1.Show();
            toolPanel.Show();
            space2.Show();
            settingsPanel.Show();
            space3.Show();
            aboutPanel.Show();
            space4.Show();
        }      

        private void toolsPicture_Click(object sender, EventArgs e)
        {
            UserNametextBox.Hide();
            if (toolsCnt == true)
            {
                ShowTools();
                toolsCnt = false;
            }
            else
            {
                aboutCnt = true;
                settingsCnt = true;
                toolsCnt = true;
                ShowControls();
            }
        }        

        private void settingsPicture_Click(object sender, EventArgs e)
        {
            UserNametextBox.Hide();
            if (settingsCnt == true)
            {
                ShowSettings();
                settingsCnt = false;
            }
            else
            {
                themePanel.Hide();
                themePanel1.Hide();
                aboutCnt = true;
                settingsCnt = true;
                toolsCnt = true;
                ShowControls();
            }
        }

        private void aboutPicture_Click(object sender, EventArgs e)
        {
            UserNametextBox.Hide();
            themePanel.Hide();
            themePanel1.Hide();
            if (aboutCnt == true)
            {
                ShowAbout();
                aboutCnt = false;
            }
            else
            {                
                aboutCnt = true;
                settingsCnt = true;
                toolsCnt = true;
                ShowControls();
            }
        }        

        private void csvPicture_Click(object sender, EventArgs e)
        {
            accountPanel.Hide();
            space1.Hide();
            toolPanel.Hide();
            space2.Hide();
            settingsPanel.Hide();
            space3.Hide();
            aboutPanel.Hide();
            space4.Hide();
            showCsv.BringToFront();
            showCsv.Dock = DockStyle.Fill;
            showCsv.Show();
        }             

        private void imagePictureBox_Click(object sender, EventArgs e)
        {
            String file = "";
            openFileDialog1.ShowDialog();            
            openFileDialog1.Filter = "Image Files (*.png)|*.png";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                file = openFileDialog1.FileName;
            }
            string img = "";
            for(int i = 0; i < file.Length; i++)
            {
                if (file[i] == '\\')
                {
                    img += "\\\\";
                }
                img += file[i];
            }            

            if (file != "")
            {
                Communicator.Manager.image = file;
                Bitmap bitmap = new Bitmap(file);
                imagePictureBox.Image = null;
                imagePictureBox.BackgroundImage = null;
                imagePictureBox.Image = bitmap;
                imagePictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                var res = Communicator.Manager.EditData(img);
                ImageChange?.Invoke(this, EventArgs.Empty);
            }            
        }

        private void currency_Click(object sender, EventArgs e)
        {
            currencyConvertorPanel.Show();
            accountPanel.Enabled = false;
            toolPanel.Enabled = false;
            settingsPanel.Enabled = false;
            aboutPanel.Enabled = false;
            currencyConverter1.CurrencyConverterClosed += OnCurrencyConverter1_CurrencyConverterClosed;
        }

        private void OnCurrencyConverter1_CurrencyConverterClosed(object sender, EventArgs e)
        {
            currencyConvertorPanel.Hide();
            accountPanel.Enabled = true;
            toolPanel.Enabled = true;
            settingsPanel.Enabled = true;
            aboutPanel.Enabled = true;
        }

        private void interestRatePicture_Click(object sender, EventArgs e)
        {
            interestRateCalculator.Show();
            interestCalculator1.InterestCalculatorClosed += OnInterestCalculator1_InterestCalculatorClosed;
            accountPanel.Enabled = false;
            toolPanel.Enabled = false;
            settingsPanel.Enabled = false;
            aboutPanel.Enabled = false;
        }

        private void OnInterestCalculator1_InterestCalculatorClosed(object sender, EventArgs e)
        {
            interestRateCalculator.Hide();
            accountPanel.Enabled = true;
            toolPanel.Enabled = true;
            settingsPanel.Enabled = true;
            aboutPanel.Enabled = true;
        }        

        private void walkthroughPicture_Click(object sender, EventArgs e)
        {
            walkthroughClick?.Invoke(this, EventArgs.Empty);
        }
        
        private void signoutBtn_Click(object sender, EventArgs e)
        {
            signoutLabel.ForeColor = GUIStyles.primaryColor;
            yesBtn.BackColor = GUIStyles.primaryColor;
            NoBtn.BackColor = GUIStyles.primaryColor;
            yesBtn.ForeColor = GUIStyles.whiteColor;
            NoBtn.ForeColor = GUIStyles.whiteColor;
            yesBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            NoBtn.FlatAppearance.MouseOverBackColor = GUIStyles.terenaryColor;
            cardPanel1.Show();
            signoutPanel.Show();
            signoutPanel.BringToFront();
            toolPanel.Enabled = false;
            settingsPanel.Enabled = false;
            aboutPanel.Enabled = false;
        }        

        private void yesBtn_Click_1(object sender, EventArgs e)
        {
            toolPanel.Enabled = true;
            settingsPanel.Enabled = true;
            aboutPanel.Enabled = true;
            Signout?.Invoke(this, EventArgs.Empty);
            signoutPanel.Hide();
            cardPanel1.Hide();
        }

        private void NoBtn_Click_1(object sender, EventArgs e)
        {
            signoutPanel.Hide();
            cardPanel1.Hide();
            toolPanel.Enabled = true;
            settingsPanel.Enabled = true;
            aboutPanel.Enabled = true;
        }

        private void themePicture_Click(object sender, EventArgs e)
        {
            if (themeCnt == true)
            {
                themePanel.Show();
                themePanel1.Show();
                themePanel.BringToFront();
                themePanel1.BringToFront();
                themeCnt = false;
            }
            else
            {
                themePanel.Hide();
                themePanel1.Hide();
                themeCnt = true;
            }            
        }

        private void OnGUIStyles_ColorChanged(bool e)
        {
            SetStyles();
        }        

        private void systemStyles_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = GUIStyles.primaryColor;
            btn.ForeColor = GUIStyles.whiteColor;
        }

        private void editPictureBox_Click(object sender, EventArgs e)
        {
            UserNametextBox.Show();
            UserNametextBox.Text = userNameLabel.Text;
        }

        private void UserNametextBox_TextChanged(object sender, EventArgs e)
        {
            userNameLabel.Text = UserNametextBox.Text;
        }
        
        private void UserNametextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                userNameLabel.Text = UserNametextBox.Text;
                Communicator.Manager.EditData(UserNametextBox.Text, Communicator.Manager.mailId);
                ChangeUserName?.Invoke(this, EventArgs.Empty);
                UserNametextBox.Hide();
            }
        }

        private void black_Click(object sender, EventArgs e)
        {
            GUIStyles.ChangeColor("black");
            SetStyles();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            themePanel.Hide();
            themePanel1.Hide();
            exportToCSV1.SetStyles();
        }

        private void brown_Click(object sender, EventArgs e)
        {
            GUIStyles.ChangeColor("brown");
            SetStyles();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            themePanel.Hide();
            themePanel1.Hide();
            exportToCSV1.SetStyles();
        }

        private void blue_Click(object sender, EventArgs e)
        {
            GUIStyles.ChangeColor("blue");
            SetStyles();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            themePanel.Hide();
            themePanel1.Hide();
            exportToCSV1.SetStyles();
        }

        private void red_Click(object sender, EventArgs e)
        {
            GUIStyles.ChangeColor("red");
            SetStyles();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            themePanel.Hide();
            themePanel1.Hide();
            exportToCSV1.SetStyles();
        }

        private void orange_Click(object sender, EventArgs e)
        {
            GUIStyles.ChangeColor("orange");
            SetStyles();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            themePanel.Hide();
            themePanel1.Hide();
            exportToCSV1.SetStyles();
        }

        private void black_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            MouseEnterEvent(pictureBox);
        }

        private void black_MouseLeave(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            MouseLeaveEvent(pictureBox);
        }

        private void pink_Click(object sender, EventArgs e)
        {
            GUIStyles.ChangeColor("pink");
            SetStyles();
            GUIStyles.ColorChanged += OnGUIStyles_ColorChanged;
            themePanel.Hide();
            themePanel1.Hide();
            exportToCSV1.SetStyles();
        }

        private void MouseEnterEvent(PictureBox pictureBox)
        {
            pictureBox.Size = new Size(pictureBox.Width + 5, pictureBox.Height + 5);
            pictureBox.Location = new Point(pictureBox.Location.X - 5, pictureBox.Location.Y - 5);
        }

        private void MouseLeaveEvent(PictureBox pictureBox)
        {
            pictureBox.Size = new Size(pictureBox.Width - 5, pictureBox.Height - 5);
            pictureBox.Location = new Point(pictureBox.Location.X + 5, pictureBox.Location.Y + 5);
        }

        private void systemStyles_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = GUIStyles.whiteColor;
            btn.ForeColor = GUIStyles.primaryColor;
        }

        #endregion
    }
}