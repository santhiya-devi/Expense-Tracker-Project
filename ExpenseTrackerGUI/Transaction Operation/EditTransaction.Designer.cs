﻿namespace ExpenseTrackerGUI
{
    partial class EditTransaction
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTransaction));
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ptop = new System.Windows.Forms.Panel();
            this.headlb = new System.Windows.Forms.Label();
            this.imagepb = new System.Windows.Forms.PictureBox();
            this.pbackground = new System.Windows.Forms.Panel();
            this.pbottom = new System.Windows.Forms.Panel();
            this.pcalculator = new System.Windows.Forms.Panel();
            this.pdesign = new System.Windows.Forms.Panel();
            this.pback = new System.Windows.Forms.Panel();
            this.descriptiontb = new System.Windows.Forms.RichTextBox();
            this.pdate = new System.Windows.Forms.Panel();
            this.pwallet = new System.Windows.Forms.Panel();
            this.walletbt = new System.Windows.Forms.Button();
            this.walletimg = new System.Windows.Forms.PictureBox();
            this.datepicker = new System.Windows.Forms.DateTimePicker();
            this.pcategoryamt = new System.Windows.Forms.Panel();
            this.pamount = new System.Windows.Forms.Panel();
            this.amountbt = new System.Windows.Forms.Button();
            this.rupeelb = new System.Windows.Forms.Label();
            this.pcategory = new System.Windows.Forms.Panel();
            this.categorybt = new System.Windows.Forms.Button();
            this.categoryimg = new System.Windows.Forms.PictureBox();
            this.pdown = new System.Windows.Forms.Panel();
            this.pbutton = new System.Windows.Forms.Panel();
            this.pcancel = new System.Windows.Forms.Panel();
            this.cancelbt = new System.Windows.Forms.Button();
            this.psave = new System.Windows.Forms.Panel();
            this.donebt = new System.Windows.Forms.Button();
            this.pmid = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.ptop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagepb)).BeginInit();
            this.pbackground.SuspendLayout();
            this.pbottom.SuspendLayout();
            this.pdesign.SuspendLayout();
            this.pback.SuspendLayout();
            this.pdate.SuspendLayout();
            this.pwallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.walletimg)).BeginInit();
            this.pcategoryamt.SuspendLayout();
            this.pamount.SuspendLayout();
            this.pcategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categoryimg)).BeginInit();
            this.pdown.SuspendLayout();
            this.pbutton.SuspendLayout();
            this.pcancel.SuspendLayout();
            this.psave.SuspendLayout();
            this.SuspendLayout();
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.ContainerControl = this;
            // 
            // ptop
            // 
            this.ptop.BackColor = System.Drawing.Color.Transparent;
            this.ptop.Controls.Add(this.headlb);
            this.ptop.Controls.Add(this.imagepb);
            this.ptop.Dock = System.Windows.Forms.DockStyle.Top;
            this.ptop.Location = new System.Drawing.Point(0, 0);
            this.ptop.Name = "ptop";
            this.ptop.Size = new System.Drawing.Size(600, 47);
            this.ptop.TabIndex = 7;
            // 
            // headlb
            // 
            this.headlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headlb.Font = new System.Drawing.Font("Arial", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headlb.ForeColor = System.Drawing.Color.White;
            this.headlb.Location = new System.Drawing.Point(61, 0);
            this.headlb.Name = "headlb";
            this.headlb.Size = new System.Drawing.Size(539, 47);
            this.headlb.TabIndex = 7;
            this.headlb.Text = "Edit Transaction";
            this.headlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imagepb
            // 
            this.imagepb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imagepb.BackgroundImage")));
            this.imagepb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imagepb.Dock = System.Windows.Forms.DockStyle.Left;
            this.imagepb.Location = new System.Drawing.Point(0, 0);
            this.imagepb.Name = "imagepb";
            this.imagepb.Size = new System.Drawing.Size(61, 47);
            this.imagepb.TabIndex = 0;
            this.imagepb.TabStop = false;
            // 
            // pbackground
            // 
            this.pbackground.BackColor = System.Drawing.Color.Transparent;
            this.pbackground.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbackground.Controls.Add(this.pbottom);
            this.pbackground.Controls.Add(this.pmid);
            this.pbackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbackground.Location = new System.Drawing.Point(0, 47);
            this.pbackground.Name = "pbackground";
            this.pbackground.Size = new System.Drawing.Size(600, 413);
            this.pbackground.TabIndex = 8;
            // 
            // pbottom
            // 
            this.pbottom.BackColor = System.Drawing.Color.Transparent;
            this.pbottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbottom.Controls.Add(this.pcalculator);
            this.pbottom.Controls.Add(this.pdesign);
            this.pbottom.Controls.Add(this.pdown);
            this.pbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbottom.Location = new System.Drawing.Point(0, 6);
            this.pbottom.Name = "pbottom";
            this.pbottom.Size = new System.Drawing.Size(600, 407);
            this.pbottom.TabIndex = 6;
            this.pbottom.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPbottomPaint);
            // 
            // pcalculator
            // 
            this.pcalculator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.pcalculator.Location = new System.Drawing.Point(27, 50);
            this.pcalculator.Name = "pcalculator";
            this.pcalculator.Size = new System.Drawing.Size(34, 37);
            this.pcalculator.TabIndex = 17;
            this.pcalculator.Visible = false;
            // 
            // pdesign
            // 
            this.pdesign.Controls.Add(this.pback);
            this.pdesign.Location = new System.Drawing.Point(67, 33);
            this.pdesign.Name = "pdesign";
            this.pdesign.Size = new System.Drawing.Size(497, 210);
            this.pdesign.TabIndex = 22;
            this.pdesign.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPdesignPaint);
            // 
            // pback
            // 
            this.pback.AutoScroll = true;
            this.pback.BackColor = System.Drawing.Color.White;
            this.pback.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pback.Controls.Add(this.descriptiontb);
            this.pback.Controls.Add(this.pdate);
            this.pback.Controls.Add(this.pcategoryamt);
            this.pback.Location = new System.Drawing.Point(24, 36);
            this.pback.Name = "pback";
            this.pback.Size = new System.Drawing.Size(429, 130);
            this.pback.TabIndex = 16;
            // 
            // descriptiontb
            // 
            this.descriptiontb.BackColor = System.Drawing.Color.White;
            this.descriptiontb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descriptiontb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.descriptiontb.Location = new System.Drawing.Point(0, 69);
            this.descriptiontb.Name = "descriptiontb";
            this.descriptiontb.Size = new System.Drawing.Size(427, 59);
            this.descriptiontb.TabIndex = 5;
            this.descriptiontb.Text = "";
            // 
            // pdate
            // 
            this.pdate.Controls.Add(this.pwallet);
            this.pdate.Controls.Add(this.datepicker);
            this.pdate.Dock = System.Windows.Forms.DockStyle.Top;
            this.pdate.Location = new System.Drawing.Point(0, 43);
            this.pdate.Name = "pdate";
            this.pdate.Size = new System.Drawing.Size(427, 26);
            this.pdate.TabIndex = 4;
            // 
            // pwallet
            // 
            this.pwallet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pwallet.Controls.Add(this.walletbt);
            this.pwallet.Controls.Add(this.walletimg);
            this.pwallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pwallet.Location = new System.Drawing.Point(260, 0);
            this.pwallet.Name = "pwallet";
            this.pwallet.Size = new System.Drawing.Size(167, 26);
            this.pwallet.TabIndex = 3;
            // 
            // walletbt
            // 
            this.walletbt.BackColor = System.Drawing.Color.White;
            this.walletbt.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.walletbt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.walletbt.FlatAppearance.BorderSize = 0;
            this.walletbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.walletbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.walletbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.walletbt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.walletbt.Location = new System.Drawing.Point(30, 0);
            this.walletbt.Name = "walletbt";
            this.walletbt.Size = new System.Drawing.Size(135, 24);
            this.walletbt.TabIndex = 9;
            this.walletbt.Text = "Wallet";
            this.walletbt.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.walletbt.UseVisualStyleBackColor = false;
            // 
            // walletimg
            // 
            this.walletimg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("walletimg.BackgroundImage")));
            this.walletimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.walletimg.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.walletimg.Dock = System.Windows.Forms.DockStyle.Left;
            this.walletimg.Location = new System.Drawing.Point(0, 0);
            this.walletimg.Name = "walletimg";
            this.walletimg.Size = new System.Drawing.Size(30, 24);
            this.walletimg.TabIndex = 8;
            this.walletimg.TabStop = false;
            // 
            // datepicker
            // 
            this.datepicker.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepicker.CalendarMonthBackground = System.Drawing.Color.White;
            this.datepicker.Cursor = System.Windows.Forms.Cursors.Hand;
            this.datepicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.datepicker.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datepicker.Location = new System.Drawing.Point(0, 0);
            this.datepicker.Name = "datepicker";
            this.datepicker.Size = new System.Drawing.Size(260, 26);
            this.datepicker.TabIndex = 2;
            // 
            // pcategoryamt
            // 
            this.pcategoryamt.Controls.Add(this.pamount);
            this.pcategoryamt.Controls.Add(this.pcategory);
            this.pcategoryamt.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcategoryamt.Location = new System.Drawing.Point(0, 0);
            this.pcategoryamt.Name = "pcategoryamt";
            this.pcategoryamt.Size = new System.Drawing.Size(427, 43);
            this.pcategoryamt.TabIndex = 3;
            // 
            // pamount
            // 
            this.pamount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pamount.Controls.Add(this.amountbt);
            this.pamount.Controls.Add(this.rupeelb);
            this.pamount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pamount.Location = new System.Drawing.Point(260, 0);
            this.pamount.Name = "pamount";
            this.pamount.Size = new System.Drawing.Size(167, 43);
            this.pamount.TabIndex = 13;
            // 
            // amountbt
            // 
            this.amountbt.BackColor = System.Drawing.Color.White;
            this.amountbt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.amountbt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amountbt.FlatAppearance.BorderSize = 0;
            this.amountbt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.amountbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.amountbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.amountbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.amountbt.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountbt.Location = new System.Drawing.Point(29, 0);
            this.amountbt.Name = "amountbt";
            this.amountbt.Size = new System.Drawing.Size(136, 41);
            this.amountbt.TabIndex = 11;
            this.amountbt.Text = "500";
            this.amountbt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.amountbt.UseVisualStyleBackColor = false;
            this.amountbt.Click += new System.EventHandler(this.OnAmountBtClick);
            this.amountbt.MouseEnter += new System.EventHandler(this.OnAmountMouseEnter);
            this.amountbt.MouseLeave += new System.EventHandler(this.OnAmountMouseLeave);
            // 
            // rupeelb
            // 
            this.rupeelb.BackColor = System.Drawing.Color.White;
            this.rupeelb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rupeelb.Dock = System.Windows.Forms.DockStyle.Left;
            this.rupeelb.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rupeelb.Location = new System.Drawing.Point(0, 0);
            this.rupeelb.Name = "rupeelb";
            this.rupeelb.Size = new System.Drawing.Size(29, 41);
            this.rupeelb.TabIndex = 10;
            this.rupeelb.Text = "₹";
            this.rupeelb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rupeelb.Click += new System.EventHandler(this.OnAmountBtClick);
            this.rupeelb.MouseEnter += new System.EventHandler(this.OnAmountMouseEnter);
            this.rupeelb.MouseLeave += new System.EventHandler(this.OnAmountMouseLeave);
            // 
            // pcategory
            // 
            this.pcategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pcategory.Controls.Add(this.categorybt);
            this.pcategory.Controls.Add(this.categoryimg);
            this.pcategory.Dock = System.Windows.Forms.DockStyle.Left;
            this.pcategory.Location = new System.Drawing.Point(0, 0);
            this.pcategory.Name = "pcategory";
            this.pcategory.Size = new System.Drawing.Size(260, 43);
            this.pcategory.TabIndex = 12;
            // 
            // categorybt
            // 
            this.categorybt.BackColor = System.Drawing.Color.White;
            this.categorybt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categorybt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categorybt.FlatAppearance.BorderSize = 0;
            this.categorybt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.categorybt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.categorybt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.categorybt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.categorybt.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorybt.Location = new System.Drawing.Point(44, 0);
            this.categorybt.Name = "categorybt";
            this.categorybt.Size = new System.Drawing.Size(214, 41);
            this.categorybt.TabIndex = 9;
            this.categorybt.Text = "Food";
            this.categorybt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categorybt.UseVisualStyleBackColor = false;
            this.categorybt.Click += new System.EventHandler(this.OnCategoryBtClick);
            this.categorybt.MouseEnter += new System.EventHandler(this.OnCategoryMouseEnter);
            this.categorybt.MouseLeave += new System.EventHandler(this.OnCategoryMouseLeave);
            // 
            // categoryimg
            // 
            this.categoryimg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.categoryimg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.categoryimg.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoryimg.Location = new System.Drawing.Point(0, 0);
            this.categoryimg.Name = "categoryimg";
            this.categoryimg.Size = new System.Drawing.Size(44, 41);
            this.categoryimg.TabIndex = 0;
            this.categoryimg.TabStop = false;
            this.categoryimg.Click += new System.EventHandler(this.OnCategoryBtClick);
            this.categoryimg.MouseEnter += new System.EventHandler(this.OnCategoryMouseEnter);
            this.categoryimg.MouseLeave += new System.EventHandler(this.OnCategoryMouseLeave);
            // 
            // pdown
            // 
            this.pdown.Controls.Add(this.pbutton);
            this.pdown.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pdown.Location = new System.Drawing.Point(0, 308);
            this.pdown.Name = "pdown";
            this.pdown.Size = new System.Drawing.Size(600, 99);
            this.pdown.TabIndex = 21;
            // 
            // pbutton
            // 
            this.pbutton.Controls.Add(this.pcancel);
            this.pbutton.Controls.Add(this.psave);
            this.pbutton.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbutton.Location = new System.Drawing.Point(0, 0);
            this.pbutton.Name = "pbutton";
            this.pbutton.Size = new System.Drawing.Size(600, 41);
            this.pbutton.TabIndex = 23;
            // 
            // pcancel
            // 
            this.pcancel.Controls.Add(this.cancelbt);
            this.pcancel.Dock = System.Windows.Forms.DockStyle.Right;
            this.pcancel.Location = new System.Drawing.Point(305, 0);
            this.pcancel.Name = "pcancel";
            this.pcancel.Size = new System.Drawing.Size(133, 41);
            this.pcancel.TabIndex = 1;
            // 
            // cancelbt
            // 
            this.cancelbt.BackColor = System.Drawing.Color.GhostWhite;
            this.cancelbt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancelbt.Dock = System.Windows.Forms.DockStyle.Left;
            this.cancelbt.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.cancelbt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lavender;
            this.cancelbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.cancelbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.cancelbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelbt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancelbt.ForeColor = System.Drawing.Color.Black;
            this.cancelbt.Location = new System.Drawing.Point(0, 0);
            this.cancelbt.Name = "cancelbt";
            this.cancelbt.Size = new System.Drawing.Size(82, 41);
            this.cancelbt.TabIndex = 21;
            this.cancelbt.Text = "Cancel";
            this.cancelbt.UseVisualStyleBackColor = false;
            this.cancelbt.Click += new System.EventHandler(this.OnCancelBtClick);
            // 
            // psave
            // 
            this.psave.Controls.Add(this.donebt);
            this.psave.Dock = System.Windows.Forms.DockStyle.Right;
            this.psave.Location = new System.Drawing.Point(438, 0);
            this.psave.Name = "psave";
            this.psave.Size = new System.Drawing.Size(162, 41);
            this.psave.TabIndex = 0;
            // 
            // donebt
            // 
            this.donebt.BackColor = System.Drawing.Color.GhostWhite;
            this.donebt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.donebt.Dock = System.Windows.Forms.DockStyle.Left;
            this.donebt.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.donebt.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lavender;
            this.donebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lavender;
            this.donebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.donebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.donebt.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.donebt.ForeColor = System.Drawing.Color.Black;
            this.donebt.Location = new System.Drawing.Point(0, 0);
            this.donebt.Name = "donebt";
            this.donebt.Size = new System.Drawing.Size(82, 41);
            this.donebt.TabIndex = 22;
            this.donebt.Text = "Save";
            this.donebt.UseVisualStyleBackColor = false;
            this.donebt.Click += new System.EventHandler(this.OnDoneBtClick);
            // 
            // pmid
            // 
            this.pmid.BackColor = System.Drawing.Color.White;
            this.pmid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pmid.Location = new System.Drawing.Point(0, 0);
            this.pmid.Name = "pmid";
            this.pmid.Size = new System.Drawing.Size(600, 6);
            this.pmid.TabIndex = 5;
            // 
            // EditTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(600, 460);
            this.Controls.Add(this.pbackground);
            this.Controls.Add(this.ptop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EditTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditView";
            this.Load += new System.EventHandler(this.OnEditTransactionLoad);
            this.Resize += new System.EventHandler(this.OnEditTransactionResize);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ptop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imagepb)).EndInit();
            this.pbackground.ResumeLayout(false);
            this.pbottom.ResumeLayout(false);
            this.pdesign.ResumeLayout(false);
            this.pback.ResumeLayout(false);
            this.pdate.ResumeLayout(false);
            this.pwallet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.walletimg)).EndInit();
            this.pcategoryamt.ResumeLayout(false);
            this.pamount.ResumeLayout(false);
            this.pcategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categoryimg)).EndInit();
            this.pdown.ResumeLayout(false);
            this.pbutton.ResumeLayout(false);
            this.pcancel.ResumeLayout(false);
            this.psave.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider ErrorProvider;
        private System.Windows.Forms.Panel ptop;
        private System.Windows.Forms.Label headlb;
        private System.Windows.Forms.PictureBox imagepb;
        private System.Windows.Forms.Panel pbackground;
        private System.Windows.Forms.Panel pmid;
        private System.Windows.Forms.Panel pbottom;
        private System.Windows.Forms.Panel pdown;
        private System.Windows.Forms.Button donebt;
        private System.Windows.Forms.Button cancelbt;
        private System.Windows.Forms.Panel pback;
        private System.Windows.Forms.RichTextBox descriptiontb;
        private System.Windows.Forms.Panel pdate;
        private System.Windows.Forms.DateTimePicker datepicker;
        private System.Windows.Forms.Panel pcategoryamt;
        private System.Windows.Forms.Panel pbutton;
        private System.Windows.Forms.Panel pcancel;
        private System.Windows.Forms.Panel psave;
        private System.Windows.Forms.Button amountbt;
        private System.Windows.Forms.Label rupeelb;
        private System.Windows.Forms.Button categorybt;
        private System.Windows.Forms.PictureBox categoryimg;
        private System.Windows.Forms.Panel pamount;
        private System.Windows.Forms.Panel pcategory;
        private System.Windows.Forms.Panel pwallet;
        private System.Windows.Forms.Button walletbt;
        private System.Windows.Forms.PictureBox walletimg;
        private System.Windows.Forms.Panel pdesign;
        private System.Windows.Forms.Panel pcalculator;
    }
}