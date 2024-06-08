namespace ExpenseTrackerGUI
{
    partial class WalletCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WalletCard));
            this.pbWallet = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbGlobe = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbWallet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlobe)).BeginInit();
            this.SuspendLayout();
            // 
            // pbWallet
            // 
            this.pbWallet.Image = ((System.Drawing.Image)(resources.GetObject("pbWallet.Image")));
            this.pbWallet.Location = new System.Drawing.Point(14, 9);
            this.pbWallet.Name = "pbWallet";
            this.pbWallet.Size = new System.Drawing.Size(47, 45);
            this.pbWallet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbWallet.TabIndex = 0;
            this.pbWallet.TabStop = false;
            this.pbWallet.Click += new System.EventHandler(this.OnCardClicked);
            this.pbWallet.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.pbWallet.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(84, 8);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(220, 23);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Total";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblName.Click += new System.EventHandler(this.OnCardClicked);
            this.lblName.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.lblName.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.Transparent;
            this.lblAmount.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAmount.Location = new System.Drawing.Point(95, 31);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(166, 27);
            this.lblAmount.TabIndex = 1;
            this.lblAmount.Text = "10000";
            this.lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAmount.Click += new System.EventHandler(this.OnCardClicked);
            this.lblAmount.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.lblAmount.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "₹";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbGlobe
            // 
            this.pbGlobe.BackColor = System.Drawing.Color.Transparent;
            this.pbGlobe.Image = ((System.Drawing.Image)(resources.GetObject("pbGlobe.Image")));
            this.pbGlobe.Location = new System.Drawing.Point(14, 9);
            this.pbGlobe.Name = "pbGlobe";
            this.pbGlobe.Size = new System.Drawing.Size(47, 45);
            this.pbGlobe.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbGlobe.TabIndex = 3;
            this.pbGlobe.TabStop = false;
            this.pbGlobe.Visible = false;
            this.pbGlobe.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.pbGlobe.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            // 
            // WalletCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.pbGlobe);
            this.Controls.Add(this.pbWallet);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "WalletCard";
            this.Size = new System.Drawing.Size(320, 70);
            this.MouseEnter += new System.EventHandler(this.OnMouseEntered);
            this.MouseLeave += new System.EventHandler(this.OnMouseLeaved);
            ((System.ComponentModel.ISupportInitialize)(this.pbWallet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbGlobe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pbWallet;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbGlobe;
    }
}
