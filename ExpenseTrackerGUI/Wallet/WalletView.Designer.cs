namespace ExpenseTrackerGUI
{
    partial class WalletView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletView));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pbBack = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.tpnlTotal = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlAddWallet = new System.Windows.Forms.Panel();
            this.lblAddWallet = new System.Windows.Forms.Label();
            this.pbAdd = new System.Windows.Forms.PictureBox();
            this.pnlShow = new System.Windows.Forms.Panel();
            this.totalWallet = new ExpenseTrackerGUI.WalletCard();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).BeginInit();
            this.tpnlTotal.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.pnlAddWallet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlTop.Controls.Add(this.pbBack);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(530, 50);
            this.pnlTop.TabIndex = 3;
            // 
            // pbBack
            // 
            this.pbBack.BackColor = System.Drawing.Color.Transparent;
            this.pbBack.Image = ((System.Drawing.Image)(resources.GetObject("pbBack.Image")));
            this.pbBack.Location = new System.Drawing.Point(11, 13);
            this.pbBack.Name = "pbBack";
            this.pbBack.Size = new System.Drawing.Size(28, 25);
            this.pbBack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbBack.TabIndex = 5;
            this.pbBack.TabStop = false;
            this.pbBack.Click += new System.EventHandler(this.OnBackBtnClicked);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(49, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(186, 40);
            this.lblTitle.TabIndex = 4;
            this.lblTitle.Text = "Select Wallet";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlRight
            // 
            this.pnlRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(518, 50);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(12, 585);
            this.pnlRight.TabIndex = 5;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 50);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(12, 585);
            this.pnlLeft.TabIndex = 6;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(12, 623);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(506, 12);
            this.pnlBottom.TabIndex = 7;
            // 
            // tpnlTotal
            // 
            this.tpnlTotal.BackColor = System.Drawing.Color.Transparent;
            this.tpnlTotal.ColumnCount = 3;
            this.tpnlTotal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlTotal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tpnlTotal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tpnlTotal.Controls.Add(this.totalWallet, 1, 1);
            this.tpnlTotal.Dock = System.Windows.Forms.DockStyle.Top;
            this.tpnlTotal.Location = new System.Drawing.Point(12, 50);
            this.tpnlTotal.Name = "tpnlTotal";
            this.tpnlTotal.RowCount = 3;
            this.tpnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tpnlTotal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tpnlTotal.Size = new System.Drawing.Size(506, 100);
            this.tpnlTotal.TabIndex = 9;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pnlAddWallet, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.pnlShow, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 150);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(506, 473);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // pnlAddWallet
            // 
            this.pnlAddWallet.BackColor = System.Drawing.Color.White;
            this.pnlAddWallet.Controls.Add(this.lblAddWallet);
            this.pnlAddWallet.Controls.Add(this.pbAdd);
            this.pnlAddWallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddWallet.Location = new System.Drawing.Point(23, 23);
            this.pnlAddWallet.Name = "pnlAddWallet";
            this.pnlAddWallet.Size = new System.Drawing.Size(460, 44);
            this.pnlAddWallet.TabIndex = 8;
            // 
            // lblAddWallet
            // 
            this.lblAddWallet.BackColor = System.Drawing.Color.Transparent;
            this.lblAddWallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAddWallet.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddWallet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.lblAddWallet.Location = new System.Drawing.Point(49, 0);
            this.lblAddWallet.Name = "lblAddWallet";
            this.lblAddWallet.Size = new System.Drawing.Size(411, 44);
            this.lblAddWallet.TabIndex = 11;
            this.lblAddWallet.Text = "  Add Wallet";
            this.lblAddWallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAddWallet.Click += new System.EventHandler(this.OnAddWalletClickTriggered);
            this.lblAddWallet.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.lblAddWallet.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            // 
            // pbAdd
            // 
            this.pbAdd.BackColor = System.Drawing.Color.Transparent;
            this.pbAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbAdd.Image = ((System.Drawing.Image)(resources.GetObject("pbAdd.Image")));
            this.pbAdd.Location = new System.Drawing.Point(0, 0);
            this.pbAdd.Name = "pbAdd";
            this.pbAdd.Size = new System.Drawing.Size(49, 44);
            this.pbAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbAdd.TabIndex = 10;
            this.pbAdd.TabStop = false;
            this.pbAdd.Click += new System.EventHandler(this.OnAddWalletClickTriggered);
            this.pbAdd.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.pbAdd.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            // 
            // pnlShow
            // 
            this.pnlShow.AutoScroll = true;
            this.pnlShow.BackColor = System.Drawing.Color.Transparent;
            this.pnlShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlShow.Location = new System.Drawing.Point(23, 93);
            this.pnlShow.Name = "pnlShow";
            this.pnlShow.Size = new System.Drawing.Size(460, 357);
            this.pnlShow.TabIndex = 9;
            // 
            // totalWallet
            // 
            this.totalWallet.BackColor = System.Drawing.Color.White;
            this.totalWallet.CardBackColor = System.Drawing.Color.White;
            this.totalWallet.CardBalance = "0";
            this.totalWallet.CardName = "Total";
            this.totalWallet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalWallet.ForeColor = System.Drawing.Color.Black;
            this.totalWallet.IsWallet = false;
            this.totalWallet.Location = new System.Drawing.Point(23, 33);
            this.totalWallet.Name = "totalWallet";
            this.totalWallet.OutLineColor = System.Drawing.Color.GhostWhite;
            this.totalWallet.Radius = 20;
            this.totalWallet.Size = new System.Drawing.Size(460, 64);
            this.totalWallet.TabIndex = 0;
            this.totalWallet.Click += new System.EventHandler(this.OnTotalClicked);
            // 
            // WalletView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tpnlTotal);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlTop);
            this.Name = "WalletView";
            this.Size = new System.Drawing.Size(530, 635);
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBack)).EndInit();
            this.tpnlTotal.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.pnlAddWallet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbAdd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.PictureBox pbBack;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.TableLayoutPanel tpnlTotal;
        private WalletCard totalWallet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlAddWallet;
        private System.Windows.Forms.Label lblAddWallet;
        private System.Windows.Forms.PictureBox pbAdd;
        private System.Windows.Forms.Panel pnlShow;
    }
}
