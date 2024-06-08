﻿namespace ExpenseTrackerGUI
{
    partial class ModifyBudget
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyBudget));
            this.pback = new System.Windows.Forms.Panel();
            this.resultLbl = new System.Windows.Forms.Label();
            this.choiceComboBox = new System.Windows.Forms.ComboBox();
            this.choicelb = new System.Windows.Forms.Label();
            this.endDatePicker = new System.Windows.Forms.DateTimePicker();
            this.endDatelb = new System.Windows.Forms.Label();
            this.walletBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pborder = new System.Windows.Forms.Panel();
            this.warningPanel = new System.Windows.Forms.Panel();
            this.internalWarningPanel = new System.Windows.Forms.Panel();
            this.warningMessageLbl = new System.Windows.Forms.Label();
            this.cancelWarningBtn = new ExpenseTrackerGUI.CurveButtons();
            this.modifyExistingBtn = new ExpenseTrackerGUI.CurveButtons();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.padd = new System.Windows.Forms.Panel();
            this.walletlb = new System.Windows.Forms.Label();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.categorySelectBtn = new System.Windows.Forms.Button();
            this.modifyBtn = new System.Windows.Forms.Button();
            this.startDatePicker = new System.Windows.Forms.DateTimePicker();
            this.startDatelb = new System.Windows.Forms.Label();
            this.categorylb = new System.Windows.Forms.Label();
            this.amounttb = new System.Windows.Forms.TextBox();
            this.amountlb = new System.Windows.Forms.Label();
            this.paddtransaction = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pborder.SuspendLayout();
            this.warningPanel.SuspendLayout();
            this.internalWarningPanel.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.padd.SuspendLayout();
            this.paddtransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pback
            // 
            this.pback.BackColor = System.Drawing.Color.White;
            this.pback.Location = new System.Drawing.Point(235, 28);
            this.pback.Name = "pback";
            this.pback.Size = new System.Drawing.Size(694, 742);
            this.pback.TabIndex = 2;
            this.pback.Visible = false;
            // 
            // resultLbl
            // 
            this.resultLbl.AutoSize = true;
            this.resultLbl.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLbl.Location = new System.Drawing.Point(391, 468);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(0, 18);
            this.resultLbl.TabIndex = 40;
            // 
            // choiceComboBox
            // 
            this.choiceComboBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choiceComboBox.FormattingEnabled = true;
            this.choiceComboBox.ItemHeight = 18;
            this.choiceComboBox.Items.AddRange(new object[] {
            "ThisWeek",
            "ThisMonth",
            "ThisQuarter",
            "ThisYear",
            "Custom"});
            this.choiceComboBox.Location = new System.Drawing.Point(509, 210);
            this.choiceComboBox.Name = "choiceComboBox";
            this.choiceComboBox.Size = new System.Drawing.Size(235, 26);
            this.choiceComboBox.TabIndex = 39;
            this.choiceComboBox.SelectedIndexChanged += new System.EventHandler(this.OnChoiceComboBoxSelectedIndexChanged);
            // 
            // choicelb
            // 
            this.choicelb.AutoSize = true;
            this.choicelb.BackColor = System.Drawing.Color.Transparent;
            this.choicelb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choicelb.ForeColor = System.Drawing.Color.White;
            this.choicelb.Location = new System.Drawing.Point(129, 203);
            this.choicelb.Name = "choicelb";
            this.choicelb.Size = new System.Drawing.Size(100, 32);
            this.choicelb.TabIndex = 38;
            this.choicelb.Text = "Choice";
            this.choicelb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // endDatePicker
            // 
            this.endDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDatePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.endDatePicker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDatePicker.Location = new System.Drawing.Point(509, 387);
            this.endDatePicker.Name = "endDatePicker";
            this.endDatePicker.Size = new System.Drawing.Size(235, 26);
            this.endDatePicker.TabIndex = 37;
            // 
            // endDatelb
            // 
            this.endDatelb.AutoSize = true;
            this.endDatelb.BackColor = System.Drawing.Color.Transparent;
            this.endDatelb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDatelb.ForeColor = System.Drawing.Color.White;
            this.endDatelb.Location = new System.Drawing.Point(130, 382);
            this.endDatelb.Name = "endDatelb";
            this.endDatelb.Size = new System.Drawing.Size(129, 32);
            this.endDatelb.TabIndex = 36;
            this.endDatelb.Text = "End Date";
            this.endDatelb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // walletbt
            // 
            this.walletBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.walletBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.walletBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.walletBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletBtn.Location = new System.Drawing.Point(509, 266);
            this.walletBtn.Name = "walletbt";
            this.walletBtn.Size = new System.Drawing.Size(235, 29);
            this.walletBtn.TabIndex = 35;
            this.walletBtn.Text = "Select Wallet                      ➤";
            this.walletBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.walletBtn.UseVisualStyleBackColor = false;
            this.walletBtn.Click += new System.EventHandler(this.OnWalletBtClicked);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(56, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 42);
            this.label1.TabIndex = 5;
            this.label1.Text = "Modify Budget";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pborder
            // 
            this.pborder.BackColor = System.Drawing.Color.White;
            this.pborder.Controls.Add(this.warningPanel);
            this.pborder.Controls.Add(this.padd);
            this.pborder.Controls.Add(this.pback);
            this.pborder.Location = new System.Drawing.Point(12, 50);
            this.pborder.Name = "pborder";
            this.pborder.Size = new System.Drawing.Size(1273, 862);
            this.pborder.TabIndex = 3;
            // 
            // warningPanel
            // 
            this.warningPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.warningPanel.Controls.Add(this.internalWarningPanel);
            this.warningPanel.Controls.Add(this.pnlTop);
            this.warningPanel.Location = new System.Drawing.Point(19, 238);
            this.warningPanel.Name = "warningPanel";
            this.warningPanel.Size = new System.Drawing.Size(286, 225);
            this.warningPanel.TabIndex = 42;
            // 
            // internalWarningPanel
            // 
            this.internalWarningPanel.BackColor = System.Drawing.Color.White;
            this.internalWarningPanel.Controls.Add(this.warningMessageLbl);
            this.internalWarningPanel.Controls.Add(this.cancelWarningBtn);
            this.internalWarningPanel.Controls.Add(this.modifyExistingBtn);
            this.internalWarningPanel.Location = new System.Drawing.Point(7, 45);
            this.internalWarningPanel.Name = "internalWarningPanel";
            this.internalWarningPanel.Size = new System.Drawing.Size(268, 170);
            this.internalWarningPanel.TabIndex = 5;
            // 
            // warningMessageLbl
            // 
            this.warningMessageLbl.AutoSize = true;
            this.warningMessageLbl.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningMessageLbl.Location = new System.Drawing.Point(19, 20);
            this.warningMessageLbl.Name = "warningMessageLbl";
            this.warningMessageLbl.Size = new System.Drawing.Size(244, 44);
            this.warningMessageLbl.TabIndex = 2;
            this.warningMessageLbl.Text = "The Budget already exists , \r\nDo you want to override it?";
            // 
            // cancelWarningBtn
            // 
            this.cancelWarningBtn.Back = System.Drawing.Color.White;
            this.cancelWarningBtn.CurveSize = 30;
            this.cancelWarningBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelWarningBtn.ForeColor = System.Drawing.Color.White;
            this.cancelWarningBtn.Location = new System.Drawing.Point(27, 105);
            this.cancelWarningBtn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.cancelWarningBtn.Name = "cancelWarningBtn";
            this.cancelWarningBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.cancelWarningBtn.ReturnClicked = false;
            this.cancelWarningBtn.SecondColor = System.Drawing.Color.MediumSlateBlue;
            this.cancelWarningBtn.Select = false;
            this.cancelWarningBtn.Size = new System.Drawing.Size(82, 34);
            this.cancelWarningBtn.TabIndex = 1;
            this.cancelWarningBtn.Text = "CANCEL";
            this.cancelWarningBtn.UseVisualStyleBackColor = true;
            this.cancelWarningBtn.Click += new System.EventHandler(this.OnCancelWarningBtnClicked);
            // 
            // modifyExistingBtn
            // 
            this.modifyExistingBtn.Back = System.Drawing.Color.White;
            this.modifyExistingBtn.CurveSize = 30;
            this.modifyExistingBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyExistingBtn.ForeColor = System.Drawing.Color.White;
            this.modifyExistingBtn.Location = new System.Drawing.Point(157, 105);
            this.modifyExistingBtn.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.modifyExistingBtn.Name = "modifyExistingBtn";
            this.modifyExistingBtn.PrimaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.modifyExistingBtn.ReturnClicked = false;
            this.modifyExistingBtn.SecondColor = System.Drawing.Color.MediumSlateBlue;
            this.modifyExistingBtn.Select = false;
            this.modifyExistingBtn.Size = new System.Drawing.Size(86, 34);
            this.modifyExistingBtn.TabIndex = 0;
            this.modifyExistingBtn.Text = "MODIFY";
            this.modifyExistingBtn.UseVisualStyleBackColor = true;
            this.modifyExistingBtn.Click += new System.EventHandler(this.OnModifyExisitngBtnClicked);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlTop.Controls.Add(this.btnClose);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(284, 40);
            this.pnlTop.TabIndex = 4;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Location = new System.Drawing.Point(11, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "!";
            this.btnClose.UseVisualStyleBackColor = false;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(41, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(170, 23);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "Warning";
            // 
            // padd
            // 
            this.padd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.padd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.padd.Controls.Add(this.resultLbl);
            this.padd.Controls.Add(this.choiceComboBox);
            this.padd.Controls.Add(this.choicelb);
            this.padd.Controls.Add(this.endDatePicker);
            this.padd.Controls.Add(this.endDatelb);
            this.padd.Controls.Add(this.walletBtn);
            this.padd.Controls.Add(this.walletlb);
            this.padd.Controls.Add(this.deleteBtn);
            this.padd.Controls.Add(this.categorySelectBtn);
            this.padd.Controls.Add(this.modifyBtn);
            this.padd.Controls.Add(this.startDatePicker);
            this.padd.Controls.Add(this.startDatelb);
            this.padd.Controls.Add(this.categorylb);
            this.padd.Controls.Add(this.amounttb);
            this.padd.Controls.Add(this.amountlb);
            this.padd.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.padd.Location = new System.Drawing.Point(181, 99);
            this.padd.Name = "padd";
            this.padd.Size = new System.Drawing.Size(866, 625);
            this.padd.TabIndex = 1;
            this.padd.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaddPaint);
            // 
            // walletlb
            // 
            this.walletlb.AutoSize = true;
            this.walletlb.BackColor = System.Drawing.Color.Transparent;
            this.walletlb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletlb.ForeColor = System.Drawing.Color.White;
            this.walletlb.Location = new System.Drawing.Point(130, 266);
            this.walletlb.Name = "walletlb";
            this.walletlb.Size = new System.Drawing.Size(92, 32);
            this.walletlb.TabIndex = 34;
            this.walletlb.Text = "Wallet";
            this.walletlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // deletebtn
            // 
            this.deleteBtn.BackColor = System.Drawing.Color.White;
            this.deleteBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteBtn.ForeColor = System.Drawing.Color.MediumBlue;
            this.deleteBtn.Location = new System.Drawing.Point(305, 506);
            this.deleteBtn.Name = "deletebtn";
            this.deleteBtn.Size = new System.Drawing.Size(89, 36);
            this.deleteBtn.TabIndex = 32;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = false;
            this.deleteBtn.Click += new System.EventHandler(this.OnDeleteBtnClicked);
            // 
            // categoryselectbt
            // 
            this.categorySelectBtn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.categorySelectBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categorySelectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.categorySelectBtn.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorySelectBtn.Location = new System.Drawing.Point(509, 138);
            this.categorySelectBtn.Name = "categoryselectbt";
            this.categorySelectBtn.Size = new System.Drawing.Size(235, 29);
            this.categorySelectBtn.TabIndex = 31;
            this.categorySelectBtn.Text = "Select Category                ➤";
            this.categorySelectBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categorySelectBtn.UseVisualStyleBackColor = false;
            this.categorySelectBtn.Click += new System.EventHandler(this.OnCategorySelectLblClicked);
            // 
            // modifyBtn
            // 
            this.modifyBtn.BackColor = System.Drawing.Color.White;
            this.modifyBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.modifyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.modifyBtn.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modifyBtn.ForeColor = System.Drawing.Color.MediumBlue;
            this.modifyBtn.Location = new System.Drawing.Point(516, 506);
            this.modifyBtn.Name = "modifyBtn";
            this.modifyBtn.Size = new System.Drawing.Size(89, 36);
            this.modifyBtn.TabIndex = 25;
            this.modifyBtn.Text = "Modify";
            this.modifyBtn.UseVisualStyleBackColor = false;
            this.modifyBtn.Click += new System.EventHandler(this.OnModifyBtnClicked);
            // 
            // startDatePicker
            // 
            this.startDatePicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDatePicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.startDatePicker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDatePicker.Location = new System.Drawing.Point(509, 329);
            this.startDatePicker.Name = "startDatePicker";
            this.startDatePicker.Size = new System.Drawing.Size(235, 26);
            this.startDatePicker.TabIndex = 29;
            // 
            // startDatelb
            // 
            this.startDatelb.AutoSize = true;
            this.startDatelb.BackColor = System.Drawing.Color.Transparent;
            this.startDatelb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startDatelb.ForeColor = System.Drawing.Color.White;
            this.startDatelb.Location = new System.Drawing.Point(130, 324);
            this.startDatelb.Name = "startDatelb";
            this.startDatelb.Size = new System.Drawing.Size(139, 32);
            this.startDatelb.TabIndex = 27;
            this.startDatelb.Text = "Start Date";
            this.startDatelb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // categorylb
            // 
            this.categorylb.AutoSize = true;
            this.categorylb.BackColor = System.Drawing.Color.Transparent;
            this.categorylb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorylb.ForeColor = System.Drawing.Color.White;
            this.categorylb.Location = new System.Drawing.Point(130, 138);
            this.categorylb.Name = "categorylb";
            this.categorylb.Size = new System.Drawing.Size(126, 32);
            this.categorylb.TabIndex = 26;
            this.categorylb.Text = "Category";
            this.categorylb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // amounttb
            // 
            this.amounttb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amounttb.ForeColor = System.Drawing.Color.Black;
            this.amounttb.Location = new System.Drawing.Point(509, 68);
            this.amounttb.MaxLength = 8;
            this.amounttb.Multiline = true;
            this.amounttb.Name = "amounttb";
            this.amounttb.Size = new System.Drawing.Size(235, 26);
            this.amounttb.TabIndex = 24;
            this.amounttb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnAmounttbKeyPressed);
            // 
            // amountlb
            // 
            this.amountlb.AutoSize = true;
            this.amountlb.BackColor = System.Drawing.Color.Transparent;
            this.amountlb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountlb.ForeColor = System.Drawing.Color.White;
            this.amountlb.Location = new System.Drawing.Point(130, 68);
            this.amountlb.Name = "amountlb";
            this.amountlb.Size = new System.Drawing.Size(108, 32);
            this.amountlb.TabIndex = 23;
            this.amountlb.Text = "Amount";
            this.amountlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // paddtransaction
            // 
            this.paddtransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.paddtransaction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.paddtransaction.Controls.Add(this.closeBtn);
            this.paddtransaction.Controls.Add(this.label1);
            this.paddtransaction.Controls.Add(this.pictureBox1);
            this.paddtransaction.Controls.Add(this.pborder);
            this.paddtransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paddtransaction.Location = new System.Drawing.Point(0, 0);
            this.paddtransaction.Name = "paddtransaction";
            this.paddtransaction.Size = new System.Drawing.Size(1290, 924);
            this.paddtransaction.TabIndex = 12;
            // 
            // closeBtn
            // 
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.White;
            this.closeBtn.Location = new System.Drawing.Point(1238, 6);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(40, 38);
            this.closeBtn.TabIndex = 20;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = false;
            this.closeBtn.Click += new System.EventHandler(this.OnCloseBtnClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(7, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 39);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // ModifyBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.paddtransaction);
            this.Name = "ModifyBudget";
            this.Size = new System.Drawing.Size(1290, 924);
            this.Resize += new System.EventHandler(this.OnModifyBudgetResized);
            this.pborder.ResumeLayout(false);
            this.warningPanel.ResumeLayout(false);
            this.internalWarningPanel.ResumeLayout(false);
            this.internalWarningPanel.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.padd.ResumeLayout(false);
            this.padd.PerformLayout();
            this.paddtransaction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pback;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.ComboBox choiceComboBox;
        private System.Windows.Forms.Label choicelb;
        private System.Windows.Forms.DateTimePicker endDatePicker;
        private System.Windows.Forms.Label endDatelb;
        private System.Windows.Forms.Button walletBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pborder;
        private System.Windows.Forms.Panel padd;
        private System.Windows.Forms.Label walletlb;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.Button categorySelectBtn;
        private System.Windows.Forms.Button modifyBtn;
        private System.Windows.Forms.DateTimePicker startDatePicker;
        private System.Windows.Forms.Label startDatelb;
        private System.Windows.Forms.Label categorylb;
        private System.Windows.Forms.TextBox amounttb;
        private System.Windows.Forms.Label amountlb;
        private System.Windows.Forms.Panel paddtransaction;
        //private CategoryView categoryView;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Panel warningPanel;
        private System.Windows.Forms.Panel internalWarningPanel;
        private System.Windows.Forms.Label warningMessageLbl;
        private CurveButtons cancelWarningBtn;
        private CurveButtons modifyExistingBtn;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        //private ChangeWallet changeWallet;
    }
}
