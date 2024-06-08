namespace ExpenseTrackerGUI
{
    partial class Form4
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.space1 = new System.Windows.Forms.Panel();
            this.space4 = new System.Windows.Forms.Panel();
            this.space2 = new System.Windows.Forms.Panel();
            this.space3 = new System.Windows.Forms.Panel();
            this.logo1 = new ExpenseTrackerGUI.Home.Logo();
            this.SuspendLayout();
            // 
            // space1
            // 
            this.space1.Dock = System.Windows.Forms.DockStyle.Left;
            this.space1.Location = new System.Drawing.Point(0, 0);
            this.space1.Name = "space1";
            this.space1.Size = new System.Drawing.Size(8, 313);
            this.space1.TabIndex = 1;
            // 
            // space4
            // 
            this.space4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.space4.Location = new System.Drawing.Point(8, 305);
            this.space4.Name = "space4";
            this.space4.Size = new System.Drawing.Size(672, 8);
            this.space4.TabIndex = 2;
            // 
            // space2
            // 
            this.space2.Dock = System.Windows.Forms.DockStyle.Top;
            this.space2.Location = new System.Drawing.Point(8, 0);
            this.space2.Name = "space2";
            this.space2.Size = new System.Drawing.Size(664, 8);
            this.space2.TabIndex = 3;
            // 
            // space3
            // 
            this.space3.Dock = System.Windows.Forms.DockStyle.Right;
            this.space3.Location = new System.Drawing.Point(672, 0);
            this.space3.Name = "space3";
            this.space3.Size = new System.Drawing.Size(8, 305);
            this.space3.TabIndex = 4;
            // 
            // logo1
            // 
            this.logo1.BackColor = System.Drawing.Color.Transparent;
            this.logo1.Location = new System.Drawing.Point(1, -12);
            this.logo1.Name = "logo1";
            this.logo1.Size = new System.Drawing.Size(650, 289);
            this.logo1.TabIndex = 0;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(680, 313);
            this.Controls.Add(this.space2);
            this.Controls.Add(this.space3);
            this.Controls.Add(this.space4);
            this.Controls.Add(this.space1);
            this.Controls.Add(this.logo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form4";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private CreateTransaction createTransaction1;
        private Home.Logo logo1;
        private System.Windows.Forms.Panel space1;
        private System.Windows.Forms.Panel space4;
        private System.Windows.Forms.Panel space2;
        private System.Windows.Forms.Panel space3;
    }
}