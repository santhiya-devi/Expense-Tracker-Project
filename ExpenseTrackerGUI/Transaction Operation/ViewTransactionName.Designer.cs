﻿namespace ExpenseTrackerGUI
{
    partial class ViewTransactionName
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewTransactionName));
            this.pback = new System.Windows.Forms.Panel();
            this.amountlb = new System.Windows.Forms.Label();
            this.rupeelb = new System.Windows.Forms.Label();
            this.categorynamelb = new System.Windows.Forms.Label();
            this.imglb = new System.Windows.Forms.PictureBox();
            this.peditdelete = new System.Windows.Forms.Panel();
            this.Deletelb = new System.Windows.Forms.Label();
            this.deletebt = new System.Windows.Forms.Button();
            this.Editlb = new System.Windows.Forms.Label();
            this.editbt = new System.Windows.Forms.Button();
            this.pback.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imglb)).BeginInit();
            this.peditdelete.SuspendLayout();
            this.SuspendLayout();
            // 
            // pback
            // 
            this.pback.BackColor = System.Drawing.Color.Transparent;
            this.pback.Controls.Add(this.amountlb);
            this.pback.Controls.Add(this.rupeelb);
            this.pback.Controls.Add(this.categorynamelb);
            this.pback.Controls.Add(this.imglb);
            this.pback.Controls.Add(this.peditdelete);
            this.pback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pback.Location = new System.Drawing.Point(0, 0);
            this.pback.Name = "pback";
            this.pback.Size = new System.Drawing.Size(600, 25);
            this.pback.TabIndex = 2;
            this.pback.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.pback.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // amountlb
            // 
            this.amountlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.amountlb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountlb.Location = new System.Drawing.Point(292, 0);
            this.amountlb.Name = "amountlb";
            this.amountlb.Size = new System.Drawing.Size(159, 25);
            this.amountlb.TabIndex = 8;
            this.amountlb.Text = "1000";
            this.amountlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.amountlb.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.amountlb.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // rupeelb
            // 
            this.rupeelb.Dock = System.Windows.Forms.DockStyle.Left;
            this.rupeelb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rupeelb.Location = new System.Drawing.Point(272, 0);
            this.rupeelb.Name = "rupeelb";
            this.rupeelb.Size = new System.Drawing.Size(20, 25);
            this.rupeelb.TabIndex = 7;
            this.rupeelb.Text = "₹";
            this.rupeelb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rupeelb.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.rupeelb.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // categorynamelb
            // 
            this.categorynamelb.Dock = System.Windows.Forms.DockStyle.Left;
            this.categorynamelb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorynamelb.ForeColor = System.Drawing.Color.MidnightBlue;
            this.categorynamelb.Location = new System.Drawing.Point(36, 0);
            this.categorynamelb.Name = "categorynamelb";
            this.categorynamelb.Size = new System.Drawing.Size(236, 25);
            this.categorynamelb.TabIndex = 6;
            this.categorynamelb.Text = "Food";
            this.categorynamelb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categorynamelb.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.categorynamelb.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // imglb
            // 
            this.imglb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.imglb.Dock = System.Windows.Forms.DockStyle.Left;
            this.imglb.Location = new System.Drawing.Point(0, 0);
            this.imglb.Name = "imglb";
            this.imglb.Size = new System.Drawing.Size(36, 25);
            this.imglb.TabIndex = 5;
            this.imglb.TabStop = false;
            this.imglb.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.imglb.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // peditdelete
            // 
            this.peditdelete.Controls.Add(this.Deletelb);
            this.peditdelete.Controls.Add(this.deletebt);
            this.peditdelete.Controls.Add(this.Editlb);
            this.peditdelete.Controls.Add(this.editbt);
            this.peditdelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.peditdelete.Location = new System.Drawing.Point(451, 0);
            this.peditdelete.Name = "peditdelete";
            this.peditdelete.Size = new System.Drawing.Size(149, 25);
            this.peditdelete.TabIndex = 2;
            // 
            // Deletelb
            // 
            this.Deletelb.Dock = System.Windows.Forms.DockStyle.Left;
            this.Deletelb.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Deletelb.Location = new System.Drawing.Point(101, 0);
            this.Deletelb.Name = "Deletelb";
            this.Deletelb.Size = new System.Drawing.Size(49, 25);
            this.Deletelb.TabIndex = 6;
            this.Deletelb.Text = "Delete";
            this.Deletelb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Deletelb.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.Deletelb.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // deletebt
            // 
            this.deletebt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deletebt.BackgroundImage")));
            this.deletebt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.deletebt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deletebt.Dock = System.Windows.Forms.DockStyle.Left;
            this.deletebt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.deletebt.FlatAppearance.BorderSize = 0;
            this.deletebt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.deletebt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.deletebt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deletebt.Location = new System.Drawing.Point(75, 0);
            this.deletebt.Name = "deletebt";
            this.deletebt.Size = new System.Drawing.Size(26, 25);
            this.deletebt.TabIndex = 5;
            this.deletebt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.deletebt.UseVisualStyleBackColor = true;
            this.deletebt.Click += new System.EventHandler(this.OnDeleteBtClick);
            this.deletebt.MouseEnter += new System.EventHandler(this.OnDeleteBtMouseEnter);
            this.deletebt.MouseLeave += new System.EventHandler(this.OnDeleteBtMouseLeave);
            // 
            // Editlb
            // 
            this.Editlb.Dock = System.Windows.Forms.DockStyle.Left;
            this.Editlb.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Editlb.Location = new System.Drawing.Point(26, 0);
            this.Editlb.Name = "Editlb";
            this.Editlb.Size = new System.Drawing.Size(49, 25);
            this.Editlb.TabIndex = 4;
            this.Editlb.Text = "Edit";
            this.Editlb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Editlb.MouseEnter += new System.EventHandler(this.OnNameTransactionMouseEnter);
            this.Editlb.MouseLeave += new System.EventHandler(this.OnNameTransactionMouseLeave);
            // 
            // editbt
            // 
            this.editbt.BackColor = System.Drawing.Color.Transparent;
            this.editbt.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editbt.BackgroundImage")));
            this.editbt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.editbt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editbt.Dock = System.Windows.Forms.DockStyle.Left;
            this.editbt.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.editbt.FlatAppearance.BorderSize = 0;
            this.editbt.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.editbt.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.editbt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editbt.Location = new System.Drawing.Point(0, 0);
            this.editbt.Name = "editbt";
            this.editbt.Size = new System.Drawing.Size(26, 25);
            this.editbt.TabIndex = 3;
            this.editbt.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.editbt.UseVisualStyleBackColor = false;
            this.editbt.Click += new System.EventHandler(this.OnEditBtClick);
            this.editbt.MouseEnter += new System.EventHandler(this.OnEditBtMouseEnter);
            this.editbt.MouseLeave += new System.EventHandler(this.OnEditBtMouseLeave);
            // 
            // ViewTransactionName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pback);
            this.Name = "ViewTransactionName";
            this.Size = new System.Drawing.Size(600, 25);
            this.Load += new System.EventHandler(this.OnNameTransactionLoad);
            this.pback.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imglb)).EndInit();
            this.peditdelete.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pback;
        private System.Windows.Forms.Panel peditdelete;
        private System.Windows.Forms.Label Deletelb;
        private System.Windows.Forms.Button deletebt;
        private System.Windows.Forms.Label Editlb;
        private System.Windows.Forms.Button editbt;
        private System.Windows.Forms.Label categorynamelb;
        private System.Windows.Forms.PictureBox imglb;
        private System.Windows.Forms.Label amountlb;
        private System.Windows.Forms.Label rupeelb;
    }
}
