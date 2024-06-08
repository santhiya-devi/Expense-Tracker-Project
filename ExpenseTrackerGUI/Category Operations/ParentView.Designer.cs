namespace ExpenseTrackerGUI
{
    partial class ParentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParentView));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.parentSearchBar = new ExpenseTrackerGUI.CategorySearchBar();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.pnlIncome = new System.Windows.Forms.Panel();
            this.pnlExpense = new System.Windows.Forms.Panel();
            this.tcParent = new System.Windows.Forms.TabControl();
            this.expenseTabPage = new System.Windows.Forms.TabPage();
            this.incomeTabPage = new System.Windows.Forms.TabPage();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.tcParent.SuspendLayout();
            this.expenseTabPage.SuspendLayout();
            this.incomeTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlTop.Controls.Add(this.parentSearchBar);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.pbBack);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(400, 45);
            this.pnlTop.TabIndex = 4;
            // 
            // parentSearchBar
            // 
            this.parentSearchBar.BackColor = System.Drawing.Color.Transparent;
            this.parentSearchBar.Dock = System.Windows.Forms.DockStyle.Right;
            this.parentSearchBar.Location = new System.Drawing.Point(355, 0);
            this.parentSearchBar.Name = "parentSearchBar";
            this.parentSearchBar.SearchBarShow = false;
            this.parentSearchBar.Size = new System.Drawing.Size(45, 45);
            this.parentSearchBar.TabIndex = 2;
            this.parentSearchBar.SearchBackClick += new System.EventHandler(this.OnSearchBackClicked);
            this.parentSearchBar.SearchBarClick += new System.EventHandler(this.OnSearchBarClicked);
            this.parentSearchBar.TextChange += new System.EventHandler<string>(this.OnSearchBarTextChanged);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(48, 14);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(155, 23);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Select Category";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Transparent;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(10, 12);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(28, 25);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 0;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.OnBackBtnClicked);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 45);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(10, 544);
            this.pnlLeft.TabIndex = 5;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(390, 45);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(10, 544);
            this.pnlRight.TabIndex = 6;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(10, 579);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(380, 10);
            this.pnlBottom.TabIndex = 7;
            // 
            // pnlIncome
            // 
            this.pnlIncome.AutoScroll = true;
            this.pnlIncome.BackColor = System.Drawing.Color.Transparent;
            this.pnlIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlIncome.Location = new System.Drawing.Point(3, 3);
            this.pnlIncome.Name = "pnlIncome";
            this.pnlIncome.Size = new System.Drawing.Size(366, 501);
            this.pnlIncome.TabIndex = 8;
            // 
            // pnlExpense
            // 
            this.pnlExpense.AutoScroll = true;
            this.pnlExpense.BackColor = System.Drawing.Color.Transparent;
            this.pnlExpense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExpense.Location = new System.Drawing.Point(3, 3);
            this.pnlExpense.Name = "pnlExpense";
            this.pnlExpense.Size = new System.Drawing.Size(366, 519);
            this.pnlExpense.TabIndex = 9;
            // 
            // tcParent
            // 
            this.tcParent.Controls.Add(this.expenseTabPage);
            this.tcParent.Controls.Add(this.incomeTabPage);
            this.tcParent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcParent.ItemSize = new System.Drawing.Size(0, 1);
            this.tcParent.Location = new System.Drawing.Point(10, 45);
            this.tcParent.Name = "tcParent";
            this.tcParent.SelectedIndex = 0;
            this.tcParent.Size = new System.Drawing.Size(380, 534);
            this.tcParent.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tcParent.TabIndex = 10;
            // 
            // expenseTabPage
            // 
            this.expenseTabPage.Controls.Add(this.pnlExpense);
            this.expenseTabPage.Location = new System.Drawing.Point(4, 5);
            this.expenseTabPage.Name = "expenseTabPage";
            this.expenseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.expenseTabPage.Size = new System.Drawing.Size(372, 525);
            this.expenseTabPage.TabIndex = 0;
            this.expenseTabPage.Text = "tabPage1";
            this.expenseTabPage.UseVisualStyleBackColor = true;
            // 
            // incomeTabPage
            // 
            this.incomeTabPage.Controls.Add(this.pnlIncome);
            this.incomeTabPage.Location = new System.Drawing.Point(4, 5);
            this.incomeTabPage.Name = "incomeTabPage";
            this.incomeTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.incomeTabPage.Size = new System.Drawing.Size(372, 507);
            this.incomeTabPage.TabIndex = 1;
            this.incomeTabPage.Text = "tabPage2";
            this.incomeTabPage.UseVisualStyleBackColor = true;
            // 
            // ParentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.tcParent);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlTop);
            this.Name = "ParentView";
            this.Size = new System.Drawing.Size(400, 589);
            this.VisibleChanged += new System.EventHandler(this.OnVisibilityChanged);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.tcParent.ResumeLayout(false);
            this.expenseTabPage.ResumeLayout(false);
            this.incomeTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbBack;
        public System.Windows.Forms.Panel pnlLeft;
        public System.Windows.Forms.Panel pnlRight;
        public System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.Panel pnlIncome;
        private System.Windows.Forms.Panel pnlExpense;
        private CategorySearchBar parentSearchBar;
        private System.Windows.Forms.TabControl tcParent;
        private System.Windows.Forms.TabPage expenseTabPage;
        private System.Windows.Forms.TabPage incomeTabPage;
    }
}
