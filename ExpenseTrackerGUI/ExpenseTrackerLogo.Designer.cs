namespace ExpenseTrackerGUI
{
    partial class ExpenseTrackerLogo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExpenseTrackerLogo));
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.logopb = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.logopb)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer
            // 
            this.Timer.Enabled = true;
            this.Timer.Tick += new System.EventHandler(this.OnExpenseTrackerTimer);
            // 
            // logopb
            // 
            this.logopb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("logopb.BackgroundImage")));
            this.logopb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.logopb.Location = new System.Drawing.Point(13, 69);
            this.logopb.Name = "logopb";
            this.logopb.Size = new System.Drawing.Size(49, 39);
            this.logopb.TabIndex = 0;
            this.logopb.TabStop = false;
            this.logopb.Visible = false;
            // 
            // ExpenseTrackerLogo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.logopb);
            this.MaximumSize = new System.Drawing.Size(272, 122);
            this.MinimumSize = new System.Drawing.Size(272, 122);
            this.Name = "ExpenseTrackerLogo";
            this.Size = new System.Drawing.Size(272, 122);
            this.Load += new System.EventHandler(this.OnExpenseTrackerLoad);
            ((System.ComponentModel.ISupportInitialize)(this.logopb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.PictureBox logopb;
    }
}
