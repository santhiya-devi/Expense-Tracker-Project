namespace ExpenseTrackerGUI
{
    partial class HistoryBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistoryBox));
            this.pback = new System.Windows.Forms.Panel();
            this.pbottom = new System.Windows.Forms.Panel();
            this.backlb = new System.Windows.Forms.Label();
            this.pmid = new System.Windows.Forms.Panel();
            this.phead = new System.Windows.Forms.Panel();
            this.headlb = new System.Windows.Forms.Label();
            this.pimage = new System.Windows.Forms.Panel();
            this.incomepb = new System.Windows.Forms.PictureBox();
            this.expensepb = new System.Windows.Forms.PictureBox();
            this.transactiondata = new System.Windows.Forms.ListBox();
            this.pback.SuspendLayout();
            this.pbottom.SuspendLayout();
            this.phead.SuspendLayout();
            this.pimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.incomepb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.expensepb)).BeginInit();
            this.SuspendLayout();
            // 
            // pback
            // 
            this.pback.BackColor = System.Drawing.Color.Transparent;
            this.pback.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pback.Controls.Add(this.pbottom);
            this.pback.Controls.Add(this.pmid);
            this.pback.Controls.Add(this.phead);
            this.pback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pback.Location = new System.Drawing.Point(0, 0);
            this.pback.Name = "pback";
            this.pback.Size = new System.Drawing.Size(257, 220);
            this.pback.TabIndex = 22;
            // 
            // pbottom
            // 
            this.pbottom.BackColor = System.Drawing.Color.Transparent;
            this.pbottom.Controls.Add(this.transactiondata);
            this.pbottom.Controls.Add(this.backlb);
            this.pbottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbottom.Location = new System.Drawing.Point(0, 45);
            this.pbottom.Name = "pbottom";
            this.pbottom.Size = new System.Drawing.Size(257, 175);
            this.pbottom.TabIndex = 2;
            this.pbottom.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPaint);
            // 
            // backlb
            // 
            this.backlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backlb.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backlb.ForeColor = System.Drawing.Color.Black;
            this.backlb.Location = new System.Drawing.Point(0, 0);
            this.backlb.Name = "backlb";
            this.backlb.Size = new System.Drawing.Size(257, 175);
            this.backlb.TabIndex = 0;
            this.backlb.Text = "No Transactions";
            this.backlb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.backlb.MouseEnter += new System.EventHandler(this.OnHistoryBoxMouseEnter);
            this.backlb.MouseLeave += new System.EventHandler(this.OnHistoryBoxMouseLeave);
            // 
            // pmid
            // 
            this.pmid.BackColor = System.Drawing.Color.Transparent;
            this.pmid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pmid.Location = new System.Drawing.Point(0, 40);
            this.pmid.Name = "pmid";
            this.pmid.Size = new System.Drawing.Size(257, 5);
            this.pmid.TabIndex = 1;
            // 
            // phead
            // 
            this.phead.BackColor = System.Drawing.Color.Transparent;
            this.phead.Controls.Add(this.headlb);
            this.phead.Controls.Add(this.pimage);
            this.phead.Dock = System.Windows.Forms.DockStyle.Top;
            this.phead.Location = new System.Drawing.Point(0, 0);
            this.phead.Name = "phead";
            this.phead.Size = new System.Drawing.Size(257, 40);
            this.phead.TabIndex = 0;
            // 
            // headlb
            // 
            this.headlb.BackColor = System.Drawing.Color.Transparent;
            this.headlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headlb.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headlb.ForeColor = System.Drawing.Color.White;
            this.headlb.Location = new System.Drawing.Point(45, 0);
            this.headlb.Name = "headlb";
            this.headlb.Size = new System.Drawing.Size(212, 40);
            this.headlb.TabIndex = 3;
            this.headlb.Text = "Expense";
            this.headlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pimage
            // 
            this.pimage.Controls.Add(this.incomepb);
            this.pimage.Controls.Add(this.expensepb);
            this.pimage.Dock = System.Windows.Forms.DockStyle.Left;
            this.pimage.Location = new System.Drawing.Point(0, 0);
            this.pimage.Name = "pimage";
            this.pimage.Size = new System.Drawing.Size(45, 40);
            this.pimage.TabIndex = 2;
            // 
            // incomepb
            // 
            this.incomepb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("incomepb.BackgroundImage")));
            this.incomepb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.incomepb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.incomepb.Location = new System.Drawing.Point(0, 0);
            this.incomepb.Name = "incomepb";
            this.incomepb.Size = new System.Drawing.Size(45, 40);
            this.incomepb.TabIndex = 5;
            this.incomepb.TabStop = false;
            // 
            // expensepb
            // 
            this.expensepb.BackColor = System.Drawing.Color.Transparent;
            this.expensepb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("expensepb.BackgroundImage")));
            this.expensepb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.expensepb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.expensepb.Location = new System.Drawing.Point(0, 0);
            this.expensepb.Name = "expensepb";
            this.expensepb.Size = new System.Drawing.Size(45, 40);
            this.expensepb.TabIndex = 1;
            this.expensepb.TabStop = false;
            // 
            // transactiondata
            // 
            this.transactiondata.BackColor = System.Drawing.Color.White;
            this.transactiondata.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.transactiondata.Cursor = System.Windows.Forms.Cursors.Hand;
            this.transactiondata.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactiondata.ForeColor = System.Drawing.Color.Black;
            this.transactiondata.FormattingEnabled = true;
            this.transactiondata.ItemHeight = 22;
            this.transactiondata.Location = new System.Drawing.Point(28, 41);
            this.transactiondata.Name = "transactiondata";
            this.transactiondata.Size = new System.Drawing.Size(198, 110);
            this.transactiondata.TabIndex = 3;
            this.transactiondata.SelectedIndexChanged += new System.EventHandler(this.OntransactiondataSelectedIndexChanged);
            this.transactiondata.MouseEnter += new System.EventHandler(this.OnHistoryBoxMouseEnter);
            this.transactiondata.MouseLeave += new System.EventHandler(this.OnHistoryBoxMouseLeave);
            // 
            // HistoryBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.pback);
            this.MaximumSize = new System.Drawing.Size(257, 220);
            this.MinimumSize = new System.Drawing.Size(257, 220);
            this.Name = "HistoryBox";
            this.Size = new System.Drawing.Size(257, 220);
            this.Load += new System.EventHandler(this.OnHistoryDataLoad);
            this.pback.ResumeLayout(false);
            this.pbottom.ResumeLayout(false);
            this.phead.ResumeLayout(false);
            this.pimage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.incomepb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.expensepb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pback;
        private System.Windows.Forms.Panel pbottom;
        private System.Windows.Forms.Label backlb;
        private System.Windows.Forms.Panel pmid;
        private System.Windows.Forms.Panel phead;
        private System.Windows.Forms.Label headlb;
        private System.Windows.Forms.Panel pimage;
        private System.Windows.Forms.PictureBox incomepb;
        private System.Windows.Forms.PictureBox expensepb;
        private System.Windows.Forms.ListBox transactiondata;
    }
}
