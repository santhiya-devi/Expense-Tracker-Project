namespace ExpenseTrackerGUI.Home
{
    partial class TransactionShowControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionShowControl));
            this.trans3 = new System.Windows.Forms.Panel();
            this.date3 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.trans3PictureBox = new System.Windows.Forms.PictureBox();
            this.amount3 = new System.Windows.Forms.Label();
            this.des3 = new System.Windows.Forms.Label();
            this.trans3Label = new System.Windows.Forms.Label();
            this.trans2 = new System.Windows.Forms.Panel();
            this.date2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.trans2PictureBox = new System.Windows.Forms.PictureBox();
            this.amount2 = new System.Windows.Forms.Label();
            this.des2 = new System.Windows.Forms.Label();
            this.trans2Label = new System.Windows.Forms.Label();
            this.trans1 = new System.Windows.Forms.Panel();
            this.date1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.trans1PictureBox = new System.Windows.Forms.PictureBox();
            this.amount1 = new System.Windows.Forms.Label();
            this.des1 = new System.Windows.Forms.Label();
            this.trans1Label = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trans4 = new System.Windows.Forms.Panel();
            this.date4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.trans4PictureBox = new System.Windows.Forms.PictureBox();
            this.amount4 = new System.Windows.Forms.Label();
            this.des4 = new System.Windows.Forms.Label();
            this.trans4Label = new System.Windows.Forms.Label();
            this.transShowCardPanel = new ExpenseTrackerGUI.Home.CardPanel();
            this.trans3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trans3PictureBox)).BeginInit();
            this.trans2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trans2PictureBox)).BeginInit();
            this.trans1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trans1PictureBox)).BeginInit();
            this.trans4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trans4PictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // trans3
            // 
            this.trans3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.trans3.Controls.Add(this.date3);
            this.trans3.Controls.Add(this.label3);
            this.trans3.Controls.Add(this.label4);
            this.trans3.Controls.Add(this.trans3PictureBox);
            this.trans3.Controls.Add(this.amount3);
            this.trans3.Controls.Add(this.des3);
            this.trans3.Controls.Add(this.trans3Label);
            this.trans3.Location = new System.Drawing.Point(54, 330);
            this.trans3.Margin = new System.Windows.Forms.Padding(20);
            this.trans3.Name = "trans3";
            this.trans3.Padding = new System.Windows.Forms.Padding(20);
            this.trans3.Size = new System.Drawing.Size(220, 153);
            this.trans3.TabIndex = 36;
            this.trans3.Paint += new System.Windows.Forms.PaintEventHandler(this.trans1_Paint);
            this.trans3.MouseEnter += new System.EventHandler(this.trans3_MouseEnter);
            this.trans3.MouseLeave += new System.EventHandler(this.trans3_MouseLeave);
            // 
            // date3
            // 
            this.date3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date3.Location = new System.Drawing.Point(23, 58);
            this.date3.Name = "date3";
            this.date3.Size = new System.Drawing.Size(179, 16);
            this.date3.TabIndex = 44;
            this.date3.Text = "2024/02/13";
            this.date3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 52);
            this.label3.TabIndex = 43;
            this.label3.Text = "Start new payment by tapping the new Transaction icon\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.Location = new System.Drawing.Point(7, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 30);
            this.label4.TabIndex = 42;
            this.label4.Text = "No Transactions yet";
            // 
            // trans3PictureBox
            // 
            this.trans3PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("trans3PictureBox.Image")));
            this.trans3PictureBox.Location = new System.Drawing.Point(11, 15);
            this.trans3PictureBox.Name = "trans3PictureBox";
            this.trans3PictureBox.Size = new System.Drawing.Size(39, 32);
            this.trans3PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trans3PictureBox.TabIndex = 36;
            this.trans3PictureBox.TabStop = false;
            this.trans3PictureBox.MouseEnter += new System.EventHandler(this.trans3_MouseEnter);
            this.trans3PictureBox.MouseLeave += new System.EventHandler(this.trans3_MouseLeave);
            // 
            // amount3
            // 
            this.amount3.BackColor = System.Drawing.Color.Transparent;
            this.amount3.Dock = System.Windows.Forms.DockStyle.Top;
            this.amount3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount3.ForeColor = System.Drawing.Color.White;
            this.amount3.Location = new System.Drawing.Point(20, 117);
            this.amount3.Name = "amount3";
            this.amount3.Size = new System.Drawing.Size(180, 25);
            this.amount3.TabIndex = 35;
            this.amount3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.amount3.MouseEnter += new System.EventHandler(this.trans3_MouseEnter);
            this.amount3.MouseLeave += new System.EventHandler(this.trans3_MouseLeave);
            // 
            // des3
            // 
            this.des3.BackColor = System.Drawing.Color.Transparent;
            this.des3.Dock = System.Windows.Forms.DockStyle.Top;
            this.des3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.des3.ForeColor = System.Drawing.Color.White;
            this.des3.Location = new System.Drawing.Point(20, 47);
            this.des3.Name = "des3";
            this.des3.Size = new System.Drawing.Size(180, 70);
            this.des3.TabIndex = 34;
            this.des3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.des3.MouseEnter += new System.EventHandler(this.trans3_MouseEnter);
            this.des3.MouseLeave += new System.EventHandler(this.trans3_MouseLeave);
            // 
            // trans3Label
            // 
            this.trans3Label.BackColor = System.Drawing.Color.Transparent;
            this.trans3Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.trans3Label.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trans3Label.ForeColor = System.Drawing.Color.White;
            this.trans3Label.Location = new System.Drawing.Point(20, 20);
            this.trans3Label.Name = "trans3Label";
            this.trans3Label.Size = new System.Drawing.Size(180, 27);
            this.trans3Label.TabIndex = 32;
            this.trans3Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.trans3Label.MouseEnter += new System.EventHandler(this.trans3_MouseEnter);
            this.trans3Label.MouseLeave += new System.EventHandler(this.trans3_MouseLeave);
            // 
            // trans2
            // 
            this.trans2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.trans2.Controls.Add(this.date2);
            this.trans2.Controls.Add(this.label2);
            this.trans2.Controls.Add(this.label1);
            this.trans2.Controls.Add(this.trans2PictureBox);
            this.trans2.Controls.Add(this.amount2);
            this.trans2.Controls.Add(this.des2);
            this.trans2.Controls.Add(this.trans2Label);
            this.trans2.Location = new System.Drawing.Point(54, 121);
            this.trans2.Margin = new System.Windows.Forms.Padding(20);
            this.trans2.Name = "trans2";
            this.trans2.Padding = new System.Windows.Forms.Padding(20);
            this.trans2.Size = new System.Drawing.Size(220, 153);
            this.trans2.TabIndex = 35;
            this.trans2.Paint += new System.Windows.Forms.PaintEventHandler(this.trans1_Paint);
            this.trans2.MouseEnter += new System.EventHandler(this.trans2_MouseEnter);
            this.trans2.MouseLeave += new System.EventHandler(this.trans2_MouseLeave);
            // 
            // date2
            // 
            this.date2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date2.Location = new System.Drawing.Point(23, 58);
            this.date2.Name = "date2";
            this.date2.Size = new System.Drawing.Size(179, 16);
            this.date2.TabIndex = 42;
            this.date2.Text = "2024/02/13";
            this.date2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 52);
            this.label2.TabIndex = 41;
            this.label2.Text = "Start new payment by tapping the new Transaction icon\r\n\r\n";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label1.Location = new System.Drawing.Point(7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 30);
            this.label1.TabIndex = 40;
            this.label1.Text = "No Transactions yet";
            // 
            // trans2PictureBox
            // 
            this.trans2PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("trans2PictureBox.Image")));
            this.trans2PictureBox.Location = new System.Drawing.Point(11, 15);
            this.trans2PictureBox.Name = "trans2PictureBox";
            this.trans2PictureBox.Size = new System.Drawing.Size(39, 32);
            this.trans2PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trans2PictureBox.TabIndex = 35;
            this.trans2PictureBox.TabStop = false;
            this.trans2PictureBox.MouseEnter += new System.EventHandler(this.trans2_MouseEnter);
            this.trans2PictureBox.MouseLeave += new System.EventHandler(this.trans2_MouseLeave);
            // 
            // amount2
            // 
            this.amount2.BackColor = System.Drawing.Color.Transparent;
            this.amount2.Dock = System.Windows.Forms.DockStyle.Top;
            this.amount2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount2.ForeColor = System.Drawing.Color.White;
            this.amount2.Location = new System.Drawing.Point(20, 117);
            this.amount2.Name = "amount2";
            this.amount2.Size = new System.Drawing.Size(180, 25);
            this.amount2.TabIndex = 34;
            this.amount2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.amount2.MouseEnter += new System.EventHandler(this.trans2_MouseEnter);
            this.amount2.MouseLeave += new System.EventHandler(this.trans2_MouseLeave);
            // 
            // des2
            // 
            this.des2.BackColor = System.Drawing.Color.Transparent;
            this.des2.Dock = System.Windows.Forms.DockStyle.Top;
            this.des2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.des2.ForeColor = System.Drawing.Color.White;
            this.des2.Location = new System.Drawing.Point(20, 47);
            this.des2.Name = "des2";
            this.des2.Size = new System.Drawing.Size(180, 70);
            this.des2.TabIndex = 33;
            this.des2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.des2.MouseEnter += new System.EventHandler(this.trans2_MouseEnter);
            this.des2.MouseLeave += new System.EventHandler(this.trans2_MouseLeave);
            // 
            // trans2Label
            // 
            this.trans2Label.BackColor = System.Drawing.Color.Transparent;
            this.trans2Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.trans2Label.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trans2Label.ForeColor = System.Drawing.Color.White;
            this.trans2Label.Location = new System.Drawing.Point(20, 20);
            this.trans2Label.Name = "trans2Label";
            this.trans2Label.Size = new System.Drawing.Size(180, 27);
            this.trans2Label.TabIndex = 32;
            this.trans2Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.trans2Label.MouseEnter += new System.EventHandler(this.trans2_MouseEnter);
            this.trans2Label.MouseLeave += new System.EventHandler(this.trans2_MouseLeave);
            // 
            // trans1
            // 
            this.trans1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.trans1.Controls.Add(this.date1);
            this.trans1.Controls.Add(this.label8);
            this.trans1.Controls.Add(this.label7);
            this.trans1.Controls.Add(this.trans1PictureBox);
            this.trans1.Controls.Add(this.amount1);
            this.trans1.Controls.Add(this.des1);
            this.trans1.Controls.Add(this.trans1Label);
            this.trans1.Location = new System.Drawing.Point(54, -85);
            this.trans1.Margin = new System.Windows.Forms.Padding(20);
            this.trans1.Name = "trans1";
            this.trans1.Padding = new System.Windows.Forms.Padding(20);
            this.trans1.Size = new System.Drawing.Size(220, 153);
            this.trans1.TabIndex = 34;
            this.trans1.Paint += new System.Windows.Forms.PaintEventHandler(this.trans1_Paint);
            this.trans1.MouseEnter += new System.EventHandler(this.trans1_MouseEnter);
            this.trans1.MouseLeave += new System.EventHandler(this.trans1_MouseLeave);
            // 
            // date1
            // 
            this.date1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date1.Location = new System.Drawing.Point(23, 58);
            this.date1.Name = "date1";
            this.date1.Size = new System.Drawing.Size(179, 16);
            this.date1.TabIndex = 47;
            this.date1.Text = "2024/02/13";
            this.date1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label8.Location = new System.Drawing.Point(13, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(210, 24);
            this.label8.TabIndex = 45;
            this.label8.Text = "No Transactions yet";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label7.Location = new System.Drawing.Point(14, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 52);
            this.label7.TabIndex = 46;
            this.label7.Text = "Start new payment by tapping the new Transaction icon\r\n\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // trans1PictureBox
            // 
            this.trans1PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("trans1PictureBox.Image")));
            this.trans1PictureBox.Location = new System.Drawing.Point(11, 15);
            this.trans1PictureBox.Name = "trans1PictureBox";
            this.trans1PictureBox.Size = new System.Drawing.Size(39, 32);
            this.trans1PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trans1PictureBox.TabIndex = 36;
            this.trans1PictureBox.TabStop = false;
            this.trans1PictureBox.MouseEnter += new System.EventHandler(this.trans1_MouseEnter);
            this.trans1PictureBox.MouseLeave += new System.EventHandler(this.trans1_MouseLeave);
            // 
            // amount1
            // 
            this.amount1.BackColor = System.Drawing.Color.Transparent;
            this.amount1.Dock = System.Windows.Forms.DockStyle.Top;
            this.amount1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount1.ForeColor = System.Drawing.Color.White;
            this.amount1.Location = new System.Drawing.Point(20, 117);
            this.amount1.Name = "amount1";
            this.amount1.Size = new System.Drawing.Size(180, 25);
            this.amount1.TabIndex = 35;
            this.amount1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.amount1.MouseEnter += new System.EventHandler(this.trans1_MouseEnter);
            this.amount1.MouseLeave += new System.EventHandler(this.trans1_MouseLeave);
            // 
            // des1
            // 
            this.des1.BackColor = System.Drawing.Color.Transparent;
            this.des1.Dock = System.Windows.Forms.DockStyle.Top;
            this.des1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.des1.ForeColor = System.Drawing.Color.White;
            this.des1.Location = new System.Drawing.Point(20, 47);
            this.des1.Name = "des1";
            this.des1.Size = new System.Drawing.Size(180, 70);
            this.des1.TabIndex = 34;
            this.des1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.des1.MouseEnter += new System.EventHandler(this.trans1_MouseEnter);
            this.des1.MouseLeave += new System.EventHandler(this.trans1_MouseLeave);
            // 
            // trans1Label
            // 
            this.trans1Label.BackColor = System.Drawing.Color.Transparent;
            this.trans1Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.trans1Label.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trans1Label.ForeColor = System.Drawing.Color.White;
            this.trans1Label.Location = new System.Drawing.Point(20, 20);
            this.trans1Label.Name = "trans1Label";
            this.trans1Label.Size = new System.Drawing.Size(180, 27);
            this.trans1Label.TabIndex = 32;
            this.trans1Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.trans1Label.MouseEnter += new System.EventHandler(this.trans1_MouseEnter);
            this.trans1Label.MouseLeave += new System.EventHandler(this.trans1_MouseLeave);
            // 
            // timer1
            // 
            this.timer1.Interval = 150;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trans4
            // 
            this.trans4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(55)))), ((int)(((byte)(149)))));
            this.trans4.Controls.Add(this.date4);
            this.trans4.Controls.Add(this.label5);
            this.trans4.Controls.Add(this.label6);
            this.trans4.Controls.Add(this.trans4PictureBox);
            this.trans4.Controls.Add(this.amount4);
            this.trans4.Controls.Add(this.des4);
            this.trans4.Controls.Add(this.trans4Label);
            this.trans4.Location = new System.Drawing.Point(54, 541);
            this.trans4.Margin = new System.Windows.Forms.Padding(20);
            this.trans4.Name = "trans4";
            this.trans4.Padding = new System.Windows.Forms.Padding(20);
            this.trans4.Size = new System.Drawing.Size(220, 153);
            this.trans4.TabIndex = 37;
            this.trans4.Paint += new System.Windows.Forms.PaintEventHandler(this.trans1_Paint);
            this.trans4.MouseEnter += new System.EventHandler(this.trans4_MouseEnter);
            this.trans4.MouseLeave += new System.EventHandler(this.trans4_MouseLeave);
            // 
            // date4
            // 
            this.date4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date4.Location = new System.Drawing.Point(23, 58);
            this.date4.Name = "date4";
            this.date4.Size = new System.Drawing.Size(179, 16);
            this.date4.TabIndex = 46;
            this.date4.Text = "2024/02/13";
            this.date4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label5.Location = new System.Drawing.Point(14, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(188, 52);
            this.label5.TabIndex = 45;
            this.label5.Text = "Start new payment by tapping the new Transaction icon\r\n\r\n";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label6.Location = new System.Drawing.Point(7, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(210, 30);
            this.label6.TabIndex = 44;
            this.label6.Text = "No Transactions yet";
            // 
            // trans4PictureBox
            // 
            this.trans4PictureBox.Image = ((System.Drawing.Image)(resources.GetObject("trans4PictureBox.Image")));
            this.trans4PictureBox.Location = new System.Drawing.Point(11, 15);
            this.trans4PictureBox.Name = "trans4PictureBox";
            this.trans4PictureBox.Size = new System.Drawing.Size(39, 32);
            this.trans4PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trans4PictureBox.TabIndex = 36;
            this.trans4PictureBox.TabStop = false;
            this.trans4PictureBox.MouseEnter += new System.EventHandler(this.trans4_MouseEnter);
            this.trans4PictureBox.MouseLeave += new System.EventHandler(this.trans4_MouseLeave);
            // 
            // amount4
            // 
            this.amount4.BackColor = System.Drawing.Color.Transparent;
            this.amount4.Dock = System.Windows.Forms.DockStyle.Top;
            this.amount4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amount4.ForeColor = System.Drawing.Color.White;
            this.amount4.Location = new System.Drawing.Point(20, 117);
            this.amount4.Name = "amount4";
            this.amount4.Size = new System.Drawing.Size(180, 25);
            this.amount4.TabIndex = 35;
            this.amount4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.amount4.MouseEnter += new System.EventHandler(this.trans4_MouseEnter);
            this.amount4.MouseLeave += new System.EventHandler(this.trans4_MouseLeave);
            // 
            // des4
            // 
            this.des4.BackColor = System.Drawing.Color.Transparent;
            this.des4.Dock = System.Windows.Forms.DockStyle.Top;
            this.des4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.des4.ForeColor = System.Drawing.Color.White;
            this.des4.Location = new System.Drawing.Point(20, 47);
            this.des4.Name = "des4";
            this.des4.Size = new System.Drawing.Size(180, 70);
            this.des4.TabIndex = 34;
            this.des4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.des4.MouseEnter += new System.EventHandler(this.trans4_MouseEnter);
            this.des4.MouseLeave += new System.EventHandler(this.trans4_MouseLeave);
            // 
            // trans4Label
            // 
            this.trans4Label.BackColor = System.Drawing.Color.Transparent;
            this.trans4Label.Dock = System.Windows.Forms.DockStyle.Top;
            this.trans4Label.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trans4Label.ForeColor = System.Drawing.Color.White;
            this.trans4Label.Location = new System.Drawing.Point(20, 20);
            this.trans4Label.Name = "trans4Label";
            this.trans4Label.Size = new System.Drawing.Size(180, 27);
            this.trans4Label.TabIndex = 32;
            this.trans4Label.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.trans4Label.MouseEnter += new System.EventHandler(this.trans4_MouseEnter);
            this.trans4Label.MouseLeave += new System.EventHandler(this.trans4_MouseLeave);
            // 
            // transShowCardPanel
            // 
            this.transShowCardPanel.BackColor = System.Drawing.Color.Transparent;
            this.transShowCardPanel.CardBackColor = System.Drawing.Color.White;
            this.transShowCardPanel.CardBorderColor = System.Drawing.Color.Gray;
            this.transShowCardPanel.CardFlickerColor = System.Drawing.Color.White;
            this.transShowCardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.transShowCardPanel.Location = new System.Drawing.Point(0, 0);
            this.transShowCardPanel.Name = "transShowCardPanel";
            this.transShowCardPanel.Size = new System.Drawing.Size(332, 620);
            this.transShowCardPanel.TabIndex = 19;
            // 
            // TransactionShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.trans1);
            this.Controls.Add(this.trans4);
            this.Controls.Add(this.trans3);
            this.Controls.Add(this.trans2);
            this.Controls.Add(this.transShowCardPanel);
            this.Name = "TransactionShowControl";
            this.Size = new System.Drawing.Size(332, 620);
            this.trans3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trans3PictureBox)).EndInit();
            this.trans2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trans2PictureBox)).EndInit();
            this.trans1.ResumeLayout(false);
            this.trans1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trans1PictureBox)).EndInit();
            this.trans4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.trans4PictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CardPanel transShowCardPanel;
        private System.Windows.Forms.Panel trans3;
        private System.Windows.Forms.Label trans3Label;
        private System.Windows.Forms.Panel trans2;
        private System.Windows.Forms.Label trans2Label;
        private System.Windows.Forms.Panel trans1;
        private System.Windows.Forms.Label trans1Label;
        private System.Windows.Forms.Panel trans4;
        private System.Windows.Forms.Label trans4Label;
        private System.Windows.Forms.Label amount3;
        private System.Windows.Forms.Label des3;
        private System.Windows.Forms.Label amount2;
        private System.Windows.Forms.Label des2;
        private System.Windows.Forms.Label amount1;
        private System.Windows.Forms.Label des1;
        private System.Windows.Forms.Label amount4;
        private System.Windows.Forms.Label des4;
        internal System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox trans3PictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox trans2PictureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox trans1PictureBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox trans4PictureBox;
        private System.Windows.Forms.Label date3;
        private System.Windows.Forms.Label date2;
        private System.Windows.Forms.Label date1;
        private System.Windows.Forms.Label date4;
    }
}
