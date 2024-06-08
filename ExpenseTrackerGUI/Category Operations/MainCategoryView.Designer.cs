namespace ExpenseTrackerGUI
{
    partial class MainCategoryView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCategoryView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblWalletName = new System.Windows.Forms.Label();
            this.pbWalletIamge = new System.Windows.Forms.PictureBox();
            this.mainCategoryViewSearch = new ExpenseTrackerGUI.CategorySearchBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tcCategory = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.load1 = new ExpenseTrackerGUI.Load();
            this.treeControl4 = new ExpenseTrackerGUI.TreeControl();
            this.treeControl3 = new ExpenseTrackerGUI.TreeControl();
            this.treeControl2 = new ExpenseTrackerGUI.TreeControl();
            this.treeControl1 = new ExpenseTrackerGUI.TreeControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.categoryTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWalletIamge)).BeginInit();
            this.tcCategory.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.pnlLoad.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.mainCategoryViewSearch);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 50);
            this.panel1.TabIndex = 0;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lblWalletName);
            this.panel5.Controls.Add(this.pbWalletIamge);
            this.panel5.Location = new System.Drawing.Point(1129, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(120, 38);
            this.panel5.TabIndex = 6;
            // 
            // lblWalletName
            // 
            this.lblWalletName.BackColor = System.Drawing.Color.Transparent;
            this.lblWalletName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblWalletName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWalletName.ForeColor = System.Drawing.Color.White;
            this.lblWalletName.Location = new System.Drawing.Point(36, 0);
            this.lblWalletName.Name = "lblWalletName";
            this.lblWalletName.Size = new System.Drawing.Size(84, 38);
            this.lblWalletName.TabIndex = 1;
            this.lblWalletName.Text = "  Total";
            this.lblWalletName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWalletName.Click += new System.EventHandler(this.OnWalletChangeClicked);
            // 
            // pbWalletIamge
            // 
            this.pbWalletIamge.BackColor = System.Drawing.Color.Transparent;
            this.pbWalletIamge.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbWalletIamge.Image = ((System.Drawing.Image)(resources.GetObject("pbWalletIamge.Image")));
            this.pbWalletIamge.Location = new System.Drawing.Point(0, 0);
            this.pbWalletIamge.Name = "pbWalletIamge";
            this.pbWalletIamge.Size = new System.Drawing.Size(36, 38);
            this.pbWalletIamge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWalletIamge.TabIndex = 0;
            this.pbWalletIamge.TabStop = false;
            this.pbWalletIamge.Click += new System.EventHandler(this.OnWalletChangeClicked);
            // 
            // mainCategoryViewSearch
            // 
            this.mainCategoryViewSearch.BackColor = System.Drawing.Color.Transparent;
            this.mainCategoryViewSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.mainCategoryViewSearch.Location = new System.Drawing.Point(1237, 0);
            this.mainCategoryViewSearch.Name = "mainCategoryViewSearch";
            this.mainCategoryViewSearch.SearchBarShow = false;
            this.mainCategoryViewSearch.Size = new System.Drawing.Size(63, 50);
            this.mainCategoryViewSearch.TabIndex = 5;
            this.mainCategoryViewSearch.SearchBackClick += new System.EventHandler(this.OnSearchBackClicked);
            this.mainCategoryViewSearch.SearchBarClick += new System.EventHandler(this.OnSearchBarClicked);
            this.mainCategoryViewSearch.TextChange += new System.EventHandler<string>(this.OnSearchBarTextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(13, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(173, 40);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "My Categories";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 50);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(12, 850);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1288, 50);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(12, 850);
            this.panel3.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(12, 888);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1276, 12);
            this.panel4.TabIndex = 3;
            // 
            // tcCategory
            // 
            this.tcCategory.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tcCategory.Controls.Add(this.tabPage1);
            this.tcCategory.Controls.Add(this.tabPage2);
            this.tcCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcCategory.ItemSize = new System.Drawing.Size(0, 1);
            this.tcCategory.Location = new System.Drawing.Point(12, 50);
            this.tcCategory.Name = "tcCategory";
            this.tcCategory.SelectedIndex = 0;
            this.tcCategory.Size = new System.Drawing.Size(1276, 838);
            this.tcCategory.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcCategory.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage1.Controls.Add(this.pnlLoad);
            this.tabPage1.Location = new System.Drawing.Point(4, 5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1268, 829);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // pnlLoad
            // 
            this.pnlLoad.BackColor = System.Drawing.Color.Silver;
            this.pnlLoad.Controls.Add(this.tabControl1);
            this.pnlLoad.Location = new System.Drawing.Point(58, 6);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(606, 789);
            this.pnlLoad.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(0, 1);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(606, 789);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.load1);
            this.tabPage4.Controls.Add(this.treeControl4);
            this.tabPage4.Controls.Add(this.treeControl3);
            this.tabPage4.Controls.Add(this.treeControl2);
            this.tabPage4.Controls.Add(this.treeControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 5);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(598, 780);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "tabPage2";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // load1
            // 
            this.load1.BackColor = System.Drawing.Color.Transparent;
            this.load1.LoadColor = System.Drawing.Color.Silver;
            this.load1.Location = new System.Drawing.Point(197, 303);
            this.load1.MaximumSize = new System.Drawing.Size(200, 200);
            this.load1.MinimumSize = new System.Drawing.Size(200, 200);
            this.load1.Name = "load1";
            this.load1.RotateDirection = ExpenseTrackerGUI.Load.Direction.ClockWise;
            this.load1.Size = new System.Drawing.Size(200, 200);
            this.load1.TabIndex = 4;
            this.load1.Timerload = false;
            // 
            // treeControl4
            // 
            this.treeControl4.AutoScroll = true;
            this.treeControl4.BackColor = System.Drawing.Color.White;
            this.treeControl4.Location = new System.Drawing.Point(25, 527);
            this.treeControl4.Name = "treeControl4";
            this.treeControl4.OutLineColor = System.Drawing.Color.GhostWhite;
            this.treeControl4.Radius = 20;
            this.treeControl4.Size = new System.Drawing.Size(524, 236);
            this.treeControl4.TabIndex = 3;
            this.treeControl4.TreeBackColor = System.Drawing.Color.White;
            // 
            // treeControl3
            // 
            this.treeControl3.AutoScroll = true;
            this.treeControl3.BackColor = System.Drawing.Color.White;
            this.treeControl3.Location = new System.Drawing.Point(25, 441);
            this.treeControl3.Name = "treeControl3";
            this.treeControl3.OutLineColor = System.Drawing.Color.GhostWhite;
            this.treeControl3.Radius = 20;
            this.treeControl3.Size = new System.Drawing.Size(524, 63);
            this.treeControl3.TabIndex = 2;
            this.treeControl3.TreeBackColor = System.Drawing.Color.White;
            // 
            // treeControl2
            // 
            this.treeControl2.AutoScroll = true;
            this.treeControl2.BackColor = System.Drawing.Color.White;
            this.treeControl2.Location = new System.Drawing.Point(25, 329);
            this.treeControl2.Name = "treeControl2";
            this.treeControl2.OutLineColor = System.Drawing.Color.GhostWhite;
            this.treeControl2.Radius = 20;
            this.treeControl2.Size = new System.Drawing.Size(524, 88);
            this.treeControl2.TabIndex = 1;
            this.treeControl2.TreeBackColor = System.Drawing.Color.White;
            // 
            // treeControl1
            // 
            this.treeControl1.AutoScroll = true;
            this.treeControl1.BackColor = System.Drawing.Color.White;
            this.treeControl1.Location = new System.Drawing.Point(25, 63);
            this.treeControl1.Name = "treeControl1";
            this.treeControl1.OutLineColor = System.Drawing.Color.GhostWhite;
            this.treeControl1.Radius = 20;
            this.treeControl1.Size = new System.Drawing.Size(524, 240);
            this.treeControl1.TabIndex = 0;
            this.treeControl1.TreeBackColor = System.Drawing.Color.White;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1268, 829);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // categoryTimer
            // 
            this.categoryTimer.Interval = 1000;
            this.categoryTimer.Tick += new System.EventHandler(this.OnTimerTicked);
            // 
            // MainCategoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.tcCategory);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainCategoryView";
            this.Size = new System.Drawing.Size(1300, 900);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbWalletIamge)).EndInit();
            this.tcCategory.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.pnlLoad.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblTitle;
        private CategorySearchBar mainCategoryViewSearch;
        private System.Windows.Forms.TabControl tcCategory;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblWalletName;
        private System.Windows.Forms.PictureBox pbWalletIamge;
        private System.Windows.Forms.Panel pnlLoad;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private Load load1;
        private TreeControl treeControl4;
        private TreeControl treeControl3;
        private TreeControl treeControl2;
        private TreeControl treeControl1;
        private System.Windows.Forms.Timer categoryTimer;
        //private CategoryView categoryView1;
    }
}
