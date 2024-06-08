namespace ExpenseTrackerGUI
{
    partial class Form3
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
            this.expenseTrackerLogo1 = new ExpenseTrackerGUI.ExpenseTrackerLogo();
            this.SuspendLayout();
            // 
            // expenseTrackerLogo1
            // 
            this.expenseTrackerLogo1.BackColor = System.Drawing.Color.White;
            this.expenseTrackerLogo1.Location = new System.Drawing.Point(124, 142);
            this.expenseTrackerLogo1.MaximumSize = new System.Drawing.Size(272, 122);
            this.expenseTrackerLogo1.MinimumSize = new System.Drawing.Size(272, 122);
            this.expenseTrackerLogo1.Name = "expenseTrackerLogo1";
            this.expenseTrackerLogo1.Size = new System.Drawing.Size(272, 122);
            this.expenseTrackerLogo1.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 421);
            this.Controls.Add(this.expenseTrackerLogo1);
            this.Name = "Form3";
            this.Text = "Form3";
            this.ResumeLayout(false);

        }

        #endregion

        private ExpenseTrackerLogo expenseTrackerLogo1;
    }
}