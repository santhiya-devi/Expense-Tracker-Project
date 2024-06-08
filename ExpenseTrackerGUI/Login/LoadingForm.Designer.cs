namespace ExpenseTrackerGUI
{
    partial class LoadingForm
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
            this.loginLoad1 = new ExpenseTrackerGUI.LoginLoad();
            this.SuspendLayout();
            // 
            // loginLoad1
            // 
            this.loginLoad1.BackColor = System.Drawing.Color.White;
            this.loginLoad1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginLoad1.LoadColor = System.Drawing.Color.RoyalBlue;
            this.loginLoad1.Location = new System.Drawing.Point(0, 0);
            this.loginLoad1.Name = "loginLoad1";
            this.loginLoad1.Size = new System.Drawing.Size(100, 100);
            this.loginLoad1.TabIndex = 0;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(100, 100);
            this.Controls.Add(this.loginLoad1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(100, 100);
            this.MinimumSize = new System.Drawing.Size(100, 100);
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoadingForm";
            this.ResumeLayout(false);

        }

        #endregion

        private LoginLoad loginLoad1;
    }
}