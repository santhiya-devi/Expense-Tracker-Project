namespace ExpenseTrackerGUI
{
    partial class SelectCategory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectCategory));
            this.pselectcategorytransaction = new System.Windows.Forms.Panel();
            this.ptransaction = new System.Windows.Forms.Panel();
            this.transactionlb = new System.Windows.Forms.Label();
            this.transactonmid = new System.Windows.Forms.Panel();
            this.transactionpb = new System.Windows.Forms.PictureBox();
            this.pcategory = new System.Windows.Forms.Panel();
            this.categorylb = new System.Windows.Forms.Label();
            this.categorymid = new System.Windows.Forms.Panel();
            this.categorypb = new System.Windows.Forms.PictureBox();
            this.pindividual = new System.Windows.Forms.Panel();
            this.individuallb = new System.Windows.Forms.Label();
            this.individualmid = new System.Windows.Forms.Panel();
            this.individualpb = new System.Windows.Forms.PictureBox();
            this.pselectcategorytransaction.SuspendLayout();
            this.ptransaction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.transactionpb)).BeginInit();
            this.pcategory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.categorypb)).BeginInit();
            this.pindividual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.individualpb)).BeginInit();
            this.SuspendLayout();
            // 
            // pselectcategorytransaction
            // 
            this.pselectcategorytransaction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pselectcategorytransaction.Controls.Add(this.ptransaction);
            this.pselectcategorytransaction.Controls.Add(this.pcategory);
            this.pselectcategorytransaction.Controls.Add(this.pindividual);
            this.pselectcategorytransaction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pselectcategorytransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pselectcategorytransaction.Location = new System.Drawing.Point(0, 0);
            this.pselectcategorytransaction.Name = "pselectcategorytransaction";
            this.pselectcategorytransaction.Size = new System.Drawing.Size(271, 107);
            this.pselectcategorytransaction.TabIndex = 29;
            // 
            // ptransaction
            // 
            this.ptransaction.Controls.Add(this.transactionlb);
            this.ptransaction.Controls.Add(this.transactonmid);
            this.ptransaction.Controls.Add(this.transactionpb);
            this.ptransaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ptransaction.Location = new System.Drawing.Point(0, 70);
            this.ptransaction.Name = "ptransaction";
            this.ptransaction.Size = new System.Drawing.Size(269, 35);
            this.ptransaction.TabIndex = 2;
            // 
            // transactionlb
            // 
            this.transactionlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transactionlb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionlb.Location = new System.Drawing.Point(53, 0);
            this.transactionlb.Name = "transactionlb";
            this.transactionlb.Size = new System.Drawing.Size(216, 35);
            this.transactionlb.TabIndex = 4;
            this.transactionlb.Text = "View by Transaction";
            this.transactionlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.transactionlb.Click += new System.EventHandler(this.OnTransactionClick);
            this.transactionlb.MouseEnter += new System.EventHandler(this.OnTransactionMouseEnter);
            this.transactionlb.MouseLeave += new System.EventHandler(this.OnTransactionMouseLeave);
            // 
            // transactonmid
            // 
            this.transactonmid.Dock = System.Windows.Forms.DockStyle.Left;
            this.transactonmid.Location = new System.Drawing.Point(37, 0);
            this.transactonmid.Name = "transactonmid";
            this.transactonmid.Size = new System.Drawing.Size(16, 35);
            this.transactonmid.TabIndex = 2;
            this.transactonmid.Click += new System.EventHandler(this.OnTransactionClick);
            this.transactonmid.MouseEnter += new System.EventHandler(this.OnTransactionMouseEnter);
            this.transactonmid.MouseLeave += new System.EventHandler(this.OnTransactionMouseLeave);
            // 
            // transactionpb
            // 
            this.transactionpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("transactionpb.BackgroundImage")));
            this.transactionpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.transactionpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.transactionpb.Location = new System.Drawing.Point(0, 0);
            this.transactionpb.Name = "transactionpb";
            this.transactionpb.Size = new System.Drawing.Size(37, 35);
            this.transactionpb.TabIndex = 1;
            this.transactionpb.TabStop = false;
            this.transactionpb.Click += new System.EventHandler(this.OnTransactionClick);
            this.transactionpb.MouseEnter += new System.EventHandler(this.OnTransactionMouseEnter);
            this.transactionpb.MouseLeave += new System.EventHandler(this.OnTransactionMouseLeave);
            // 
            // pcategory
            // 
            this.pcategory.Controls.Add(this.categorylb);
            this.pcategory.Controls.Add(this.categorymid);
            this.pcategory.Controls.Add(this.categorypb);
            this.pcategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.pcategory.Location = new System.Drawing.Point(0, 35);
            this.pcategory.Name = "pcategory";
            this.pcategory.Size = new System.Drawing.Size(269, 35);
            this.pcategory.TabIndex = 1;
            // 
            // categorylb
            // 
            this.categorylb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categorylb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categorylb.Location = new System.Drawing.Point(53, 0);
            this.categorylb.Name = "categorylb";
            this.categorylb.Size = new System.Drawing.Size(216, 35);
            this.categorylb.TabIndex = 4;
            this.categorylb.Text = "View by Category";
            this.categorylb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.categorylb.Click += new System.EventHandler(this.OnCategoryClick);
            this.categorylb.MouseEnter += new System.EventHandler(this.OnCategoryMouseEnter);
            this.categorylb.MouseLeave += new System.EventHandler(this.OnCategoryMouseLeave);
            // 
            // categorymid
            // 
            this.categorymid.Dock = System.Windows.Forms.DockStyle.Left;
            this.categorymid.Location = new System.Drawing.Point(37, 0);
            this.categorymid.Name = "categorymid";
            this.categorymid.Size = new System.Drawing.Size(16, 35);
            this.categorymid.TabIndex = 2;
            this.categorymid.Click += new System.EventHandler(this.OnCategoryClick);
            this.categorymid.MouseEnter += new System.EventHandler(this.OnCategoryMouseEnter);
            this.categorymid.MouseLeave += new System.EventHandler(this.OnCategoryMouseLeave);
            // 
            // categorypb
            // 
            this.categorypb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("categorypb.BackgroundImage")));
            this.categorypb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.categorypb.Dock = System.Windows.Forms.DockStyle.Left;
            this.categorypb.Location = new System.Drawing.Point(0, 0);
            this.categorypb.Name = "categorypb";
            this.categorypb.Size = new System.Drawing.Size(37, 35);
            this.categorypb.TabIndex = 1;
            this.categorypb.TabStop = false;
            this.categorypb.Click += new System.EventHandler(this.OnCategoryClick);
            this.categorypb.MouseEnter += new System.EventHandler(this.OnCategoryMouseEnter);
            this.categorypb.MouseLeave += new System.EventHandler(this.OnCategoryMouseLeave);
            // 
            // pindividual
            // 
            this.pindividual.Controls.Add(this.individuallb);
            this.pindividual.Controls.Add(this.individualmid);
            this.pindividual.Controls.Add(this.individualpb);
            this.pindividual.Dock = System.Windows.Forms.DockStyle.Top;
            this.pindividual.Location = new System.Drawing.Point(0, 0);
            this.pindividual.Name = "pindividual";
            this.pindividual.Size = new System.Drawing.Size(269, 35);
            this.pindividual.TabIndex = 0;
            // 
            // individuallb
            // 
            this.individuallb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.individuallb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.individuallb.Location = new System.Drawing.Point(53, 0);
            this.individuallb.Name = "individuallb";
            this.individuallb.Size = new System.Drawing.Size(216, 35);
            this.individuallb.TabIndex = 4;
            this.individuallb.Text = "View Individual Transaction";
            this.individuallb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.individuallb.Click += new System.EventHandler(this.OnIndividualClick);
            this.individuallb.MouseEnter += new System.EventHandler(this.OnIndividualMouseEnter);
            this.individuallb.MouseLeave += new System.EventHandler(this.OnIndividualMouseLeave);
            // 
            // individualmid
            // 
            this.individualmid.Dock = System.Windows.Forms.DockStyle.Left;
            this.individualmid.Location = new System.Drawing.Point(37, 0);
            this.individualmid.Name = "individualmid";
            this.individualmid.Size = new System.Drawing.Size(16, 35);
            this.individualmid.TabIndex = 1;
            this.individualmid.Click += new System.EventHandler(this.OnIndividualClick);
            this.individualmid.MouseEnter += new System.EventHandler(this.OnIndividualMouseEnter);
            this.individualmid.MouseLeave += new System.EventHandler(this.OnIndividualMouseLeave);
            // 
            // individualpb
            // 
            this.individualpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("individualpb.BackgroundImage")));
            this.individualpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.individualpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.individualpb.Location = new System.Drawing.Point(0, 0);
            this.individualpb.Name = "individualpb";
            this.individualpb.Size = new System.Drawing.Size(37, 35);
            this.individualpb.TabIndex = 0;
            this.individualpb.TabStop = false;
            this.individualpb.Click += new System.EventHandler(this.OnIndividualClick);
            this.individualpb.MouseEnter += new System.EventHandler(this.OnIndividualMouseEnter);
            this.individualpb.MouseLeave += new System.EventHandler(this.OnIndividualMouseLeave);
            // 
            // SelectCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pselectcategorytransaction);
            this.Name = "SelectCategory";
            this.Size = new System.Drawing.Size(271, 107);
            this.Load += new System.EventHandler(this.OnSelectTypeLoad);
            this.VisibleChanged += new System.EventHandler(this.OnSelectTypeVisibilityChanged);
            this.pselectcategorytransaction.ResumeLayout(false);
            this.ptransaction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.transactionpb)).EndInit();
            this.pcategory.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.categorypb)).EndInit();
            this.pindividual.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.individualpb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pselectcategorytransaction;
        private System.Windows.Forms.Panel ptransaction;
        private System.Windows.Forms.Label transactionlb;
        private System.Windows.Forms.Panel transactonmid;
        private System.Windows.Forms.PictureBox transactionpb;
        private System.Windows.Forms.Panel pcategory;
        private System.Windows.Forms.Label categorylb;
        private System.Windows.Forms.Panel categorymid;
        private System.Windows.Forms.PictureBox categorypb;
        private System.Windows.Forms.Panel pindividual;
        private System.Windows.Forms.Label individuallb;
        private System.Windows.Forms.Panel individualmid;
        private System.Windows.Forms.PictureBox individualpb;
    }
}
