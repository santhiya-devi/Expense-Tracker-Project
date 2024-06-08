namespace ExpenseTrackerGUI
{
    partial class SelectDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectDate));
            this.pselectviewtype = new System.Windows.Forms.Panel();
            this.pcustomdate = new System.Windows.Forms.Panel();
            this.customlb = new System.Windows.Forms.Label();
            this.custommid = new System.Windows.Forms.Panel();
            this.custompb = new System.Windows.Forms.PictureBox();
            this.pviewall = new System.Windows.Forms.Panel();
            this.alllb = new System.Windows.Forms.Label();
            this.allmid = new System.Windows.Forms.Panel();
            this.allpb = new System.Windows.Forms.PictureBox();
            this.pyear = new System.Windows.Forms.Panel();
            this.yearlb = new System.Windows.Forms.Label();
            this.yearmid = new System.Windows.Forms.Panel();
            this.yearpb = new System.Windows.Forms.PictureBox();
            this.pquarter = new System.Windows.Forms.Panel();
            this.quarterlb = new System.Windows.Forms.Label();
            this.quartermid = new System.Windows.Forms.Panel();
            this.quarterpb = new System.Windows.Forms.PictureBox();
            this.pmonth = new System.Windows.Forms.Panel();
            this.monthlb = new System.Windows.Forms.Label();
            this.monthmid = new System.Windows.Forms.Panel();
            this.monthpb = new System.Windows.Forms.PictureBox();
            this.pweek = new System.Windows.Forms.Panel();
            this.weeklb = new System.Windows.Forms.Label();
            this.weekmid = new System.Windows.Forms.Panel();
            this.weekpb = new System.Windows.Forms.PictureBox();
            this.pday = new System.Windows.Forms.Panel();
            this.daylb = new System.Windows.Forms.Label();
            this.daymid = new System.Windows.Forms.Panel();
            this.daypb = new System.Windows.Forms.PictureBox();
            this.pselectviewtype.SuspendLayout();
            this.pcustomdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.custompb)).BeginInit();
            this.pviewall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.allpb)).BeginInit();
            this.pyear.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yearpb)).BeginInit();
            this.pquarter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quarterpb)).BeginInit();
            this.pmonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.monthpb)).BeginInit();
            this.pweek.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.weekpb)).BeginInit();
            this.pday.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.daypb)).BeginInit();
            this.SuspendLayout();
            // 
            // pselectviewtype
            // 
            this.pselectviewtype.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pselectviewtype.Controls.Add(this.pcustomdate);
            this.pselectviewtype.Controls.Add(this.pviewall);
            this.pselectviewtype.Controls.Add(this.pyear);
            this.pselectviewtype.Controls.Add(this.pquarter);
            this.pselectviewtype.Controls.Add(this.pmonth);
            this.pselectviewtype.Controls.Add(this.pweek);
            this.pselectviewtype.Controls.Add(this.pday);
            this.pselectviewtype.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pselectviewtype.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pselectviewtype.Location = new System.Drawing.Point(0, 0);
            this.pselectviewtype.Name = "pselectviewtype";
            this.pselectviewtype.Size = new System.Drawing.Size(271, 245);
            this.pselectviewtype.TabIndex = 28;
            // 
            // pcustomdate
            // 
            this.pcustomdate.Controls.Add(this.customlb);
            this.pcustomdate.Controls.Add(this.custommid);
            this.pcustomdate.Controls.Add(this.custompb);
            this.pcustomdate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcustomdate.Location = new System.Drawing.Point(0, 210);
            this.pcustomdate.Name = "pcustomdate";
            this.pcustomdate.Size = new System.Drawing.Size(269, 33);
            this.pcustomdate.TabIndex = 6;
            // 
            // customlb
            // 
            this.customlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customlb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.customlb.Location = new System.Drawing.Point(53, 0);
            this.customlb.Name = "customlb";
            this.customlb.Size = new System.Drawing.Size(216, 33);
            this.customlb.TabIndex = 10;
            this.customlb.Text = "Custom Date";
            this.customlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.customlb.Click += new System.EventHandler(this.OnCustomClick);
            this.customlb.MouseEnter += new System.EventHandler(this.OnCustomMouseEnter);
            this.customlb.MouseLeave += new System.EventHandler(this.OnCustomMouseLeave);
            // 
            // custommid
            // 
            this.custommid.Dock = System.Windows.Forms.DockStyle.Left;
            this.custommid.Location = new System.Drawing.Point(37, 0);
            this.custommid.Name = "custommid";
            this.custommid.Size = new System.Drawing.Size(16, 33);
            this.custommid.TabIndex = 2;
            this.custommid.Click += new System.EventHandler(this.OnCustomClick);
            this.custommid.MouseEnter += new System.EventHandler(this.OnCustomMouseEnter);
            this.custommid.MouseLeave += new System.EventHandler(this.OnCustomMouseLeave);
            // 
            // custompb
            // 
            this.custompb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("custompb.BackgroundImage")));
            this.custompb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.custompb.Dock = System.Windows.Forms.DockStyle.Left;
            this.custompb.Location = new System.Drawing.Point(0, 0);
            this.custompb.Name = "custompb";
            this.custompb.Size = new System.Drawing.Size(37, 33);
            this.custompb.TabIndex = 1;
            this.custompb.TabStop = false;
            this.custompb.Click += new System.EventHandler(this.OnCustomClick);
            this.custompb.MouseEnter += new System.EventHandler(this.OnCustomMouseEnter);
            this.custompb.MouseLeave += new System.EventHandler(this.OnCustomMouseLeave);
            // 
            // pviewall
            // 
            this.pviewall.Controls.Add(this.alllb);
            this.pviewall.Controls.Add(this.allmid);
            this.pviewall.Controls.Add(this.allpb);
            this.pviewall.Dock = System.Windows.Forms.DockStyle.Top;
            this.pviewall.Location = new System.Drawing.Point(0, 175);
            this.pviewall.Name = "pviewall";
            this.pviewall.Size = new System.Drawing.Size(269, 35);
            this.pviewall.TabIndex = 5;
            // 
            // alllb
            // 
            this.alllb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.alllb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.alllb.Location = new System.Drawing.Point(53, 0);
            this.alllb.Name = "alllb";
            this.alllb.Size = new System.Drawing.Size(216, 35);
            this.alllb.TabIndex = 9;
            this.alllb.Text = "View All";
            this.alllb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.alllb.Click += new System.EventHandler(this.OnViewAllClick);
            this.alllb.MouseEnter += new System.EventHandler(this.OnViewAllMouseEnter);
            this.alllb.MouseLeave += new System.EventHandler(this.OnViewAllMouseLeave);
            // 
            // allmid
            // 
            this.allmid.Dock = System.Windows.Forms.DockStyle.Left;
            this.allmid.Location = new System.Drawing.Point(37, 0);
            this.allmid.Name = "allmid";
            this.allmid.Size = new System.Drawing.Size(16, 35);
            this.allmid.TabIndex = 2;
            this.allmid.Click += new System.EventHandler(this.OnViewAllClick);
            this.allmid.MouseEnter += new System.EventHandler(this.OnViewAllMouseEnter);
            this.allmid.MouseLeave += new System.EventHandler(this.OnViewAllMouseLeave);
            // 
            // allpb
            // 
            this.allpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("allpb.BackgroundImage")));
            this.allpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.allpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.allpb.Location = new System.Drawing.Point(0, 0);
            this.allpb.Name = "allpb";
            this.allpb.Size = new System.Drawing.Size(37, 35);
            this.allpb.TabIndex = 1;
            this.allpb.TabStop = false;
            this.allpb.Click += new System.EventHandler(this.OnViewAllClick);
            this.allpb.MouseEnter += new System.EventHandler(this.OnViewAllMouseEnter);
            this.allpb.MouseLeave += new System.EventHandler(this.OnViewAllMouseLeave);
            // 
            // pyear
            // 
            this.pyear.Controls.Add(this.yearlb);
            this.pyear.Controls.Add(this.yearmid);
            this.pyear.Controls.Add(this.yearpb);
            this.pyear.Dock = System.Windows.Forms.DockStyle.Top;
            this.pyear.Location = new System.Drawing.Point(0, 140);
            this.pyear.Name = "pyear";
            this.pyear.Size = new System.Drawing.Size(269, 35);
            this.pyear.TabIndex = 4;
            // 
            // yearlb
            // 
            this.yearlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.yearlb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearlb.Location = new System.Drawing.Point(53, 0);
            this.yearlb.Name = "yearlb";
            this.yearlb.Size = new System.Drawing.Size(216, 35);
            this.yearlb.TabIndex = 9;
            this.yearlb.Text = "View by Year";
            this.yearlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.yearlb.Click += new System.EventHandler(this.OnYearClick);
            this.yearlb.MouseEnter += new System.EventHandler(this.OnYearMouseEnter);
            this.yearlb.MouseLeave += new System.EventHandler(this.OnYearMouseLeave);
            // 
            // yearmid
            // 
            this.yearmid.Dock = System.Windows.Forms.DockStyle.Left;
            this.yearmid.Location = new System.Drawing.Point(37, 0);
            this.yearmid.Name = "yearmid";
            this.yearmid.Size = new System.Drawing.Size(16, 35);
            this.yearmid.TabIndex = 2;
            this.yearmid.Click += new System.EventHandler(this.OnYearClick);
            this.yearmid.MouseEnter += new System.EventHandler(this.OnYearMouseEnter);
            this.yearmid.MouseLeave += new System.EventHandler(this.OnYearMouseLeave);
            // 
            // yearpb
            // 
            this.yearpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("yearpb.BackgroundImage")));
            this.yearpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.yearpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.yearpb.Location = new System.Drawing.Point(0, 0);
            this.yearpb.Name = "yearpb";
            this.yearpb.Size = new System.Drawing.Size(37, 35);
            this.yearpb.TabIndex = 1;
            this.yearpb.TabStop = false;
            this.yearpb.Click += new System.EventHandler(this.OnYearClick);
            this.yearpb.MouseEnter += new System.EventHandler(this.OnYearMouseEnter);
            this.yearpb.MouseLeave += new System.EventHandler(this.OnYearMouseLeave);
            // 
            // pquarter
            // 
            this.pquarter.Controls.Add(this.quarterlb);
            this.pquarter.Controls.Add(this.quartermid);
            this.pquarter.Controls.Add(this.quarterpb);
            this.pquarter.Dock = System.Windows.Forms.DockStyle.Top;
            this.pquarter.Location = new System.Drawing.Point(0, 105);
            this.pquarter.Name = "pquarter";
            this.pquarter.Size = new System.Drawing.Size(269, 35);
            this.pquarter.TabIndex = 3;
            // 
            // quarterlb
            // 
            this.quarterlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quarterlb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quarterlb.Location = new System.Drawing.Point(53, 0);
            this.quarterlb.Name = "quarterlb";
            this.quarterlb.Size = new System.Drawing.Size(216, 35);
            this.quarterlb.TabIndex = 6;
            this.quarterlb.Text = "View by Quarter";
            this.quarterlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.quarterlb.Click += new System.EventHandler(this.OnQuarterClick);
            this.quarterlb.MouseEnter += new System.EventHandler(this.OnQuarterMouseEnter);
            this.quarterlb.MouseLeave += new System.EventHandler(this.OnQuarterMouseLeave);
            // 
            // quartermid
            // 
            this.quartermid.Dock = System.Windows.Forms.DockStyle.Left;
            this.quartermid.Location = new System.Drawing.Point(37, 0);
            this.quartermid.Name = "quartermid";
            this.quartermid.Size = new System.Drawing.Size(16, 35);
            this.quartermid.TabIndex = 2;
            this.quartermid.Click += new System.EventHandler(this.OnQuarterClick);
            this.quartermid.MouseEnter += new System.EventHandler(this.OnQuarterMouseEnter);
            this.quartermid.MouseLeave += new System.EventHandler(this.OnQuarterMouseLeave);
            // 
            // quarterpb
            // 
            this.quarterpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quarterpb.BackgroundImage")));
            this.quarterpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.quarterpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.quarterpb.Location = new System.Drawing.Point(0, 0);
            this.quarterpb.Name = "quarterpb";
            this.quarterpb.Size = new System.Drawing.Size(37, 35);
            this.quarterpb.TabIndex = 1;
            this.quarterpb.TabStop = false;
            this.quarterpb.Click += new System.EventHandler(this.OnQuarterClick);
            this.quarterpb.MouseEnter += new System.EventHandler(this.OnQuarterMouseEnter);
            this.quarterpb.MouseLeave += new System.EventHandler(this.OnQuarterMouseLeave);
            // 
            // pmonth
            // 
            this.pmonth.Controls.Add(this.monthlb);
            this.pmonth.Controls.Add(this.monthmid);
            this.pmonth.Controls.Add(this.monthpb);
            this.pmonth.Dock = System.Windows.Forms.DockStyle.Top;
            this.pmonth.Location = new System.Drawing.Point(0, 70);
            this.pmonth.Name = "pmonth";
            this.pmonth.Size = new System.Drawing.Size(269, 35);
            this.pmonth.TabIndex = 2;
            // 
            // monthlb
            // 
            this.monthlb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthlb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthlb.Location = new System.Drawing.Point(53, 0);
            this.monthlb.Name = "monthlb";
            this.monthlb.Size = new System.Drawing.Size(216, 35);
            this.monthlb.TabIndex = 7;
            this.monthlb.Text = "View by Month";
            this.monthlb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.monthlb.Click += new System.EventHandler(this.OnMonthClick);
            this.monthlb.MouseEnter += new System.EventHandler(this.OnMonthMouseEnter);
            this.monthlb.MouseLeave += new System.EventHandler(this.OnMonthMouseLeave);
            // 
            // monthmid
            // 
            this.monthmid.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthmid.Location = new System.Drawing.Point(37, 0);
            this.monthmid.Name = "monthmid";
            this.monthmid.Size = new System.Drawing.Size(16, 35);
            this.monthmid.TabIndex = 2;
            this.monthmid.Click += new System.EventHandler(this.OnMonthClick);
            this.monthmid.MouseEnter += new System.EventHandler(this.OnMonthMouseEnter);
            this.monthmid.MouseLeave += new System.EventHandler(this.OnMonthMouseLeave);
            // 
            // monthpb
            // 
            this.monthpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("monthpb.BackgroundImage")));
            this.monthpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.monthpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthpb.Location = new System.Drawing.Point(0, 0);
            this.monthpb.Name = "monthpb";
            this.monthpb.Size = new System.Drawing.Size(37, 35);
            this.monthpb.TabIndex = 1;
            this.monthpb.TabStop = false;
            this.monthpb.Click += new System.EventHandler(this.OnMonthClick);
            this.monthpb.MouseEnter += new System.EventHandler(this.OnMonthMouseEnter);
            this.monthpb.MouseLeave += new System.EventHandler(this.OnMonthMouseLeave);
            // 
            // pweek
            // 
            this.pweek.Controls.Add(this.weeklb);
            this.pweek.Controls.Add(this.weekmid);
            this.pweek.Controls.Add(this.weekpb);
            this.pweek.Dock = System.Windows.Forms.DockStyle.Top;
            this.pweek.Location = new System.Drawing.Point(0, 35);
            this.pweek.Name = "pweek";
            this.pweek.Size = new System.Drawing.Size(269, 35);
            this.pweek.TabIndex = 1;
            // 
            // weeklb
            // 
            this.weeklb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.weeklb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weeklb.Location = new System.Drawing.Point(53, 0);
            this.weeklb.Name = "weeklb";
            this.weeklb.Size = new System.Drawing.Size(216, 35);
            this.weeklb.TabIndex = 4;
            this.weeklb.Text = "View by Week";
            this.weeklb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.weeklb.Click += new System.EventHandler(this.OnWeekClick);
            this.weeklb.MouseEnter += new System.EventHandler(this.OnWeekMouseEnter);
            this.weeklb.MouseLeave += new System.EventHandler(this.OnWeekMouseLeave);
            // 
            // weekmid
            // 
            this.weekmid.Dock = System.Windows.Forms.DockStyle.Left;
            this.weekmid.Location = new System.Drawing.Point(37, 0);
            this.weekmid.Name = "weekmid";
            this.weekmid.Size = new System.Drawing.Size(16, 35);
            this.weekmid.TabIndex = 2;
            this.weekmid.Click += new System.EventHandler(this.OnWeekClick);
            this.weekmid.MouseEnter += new System.EventHandler(this.OnWeekMouseEnter);
            this.weekmid.MouseLeave += new System.EventHandler(this.OnWeekMouseLeave);
            // 
            // weekpb
            // 
            this.weekpb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("weekpb.BackgroundImage")));
            this.weekpb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.weekpb.Dock = System.Windows.Forms.DockStyle.Left;
            this.weekpb.Location = new System.Drawing.Point(0, 0);
            this.weekpb.Name = "weekpb";
            this.weekpb.Size = new System.Drawing.Size(37, 35);
            this.weekpb.TabIndex = 1;
            this.weekpb.TabStop = false;
            this.weekpb.Click += new System.EventHandler(this.OnWeekClick);
            this.weekpb.MouseEnter += new System.EventHandler(this.OnWeekMouseEnter);
            this.weekpb.MouseLeave += new System.EventHandler(this.OnWeekMouseLeave);
            // 
            // pday
            // 
            this.pday.Controls.Add(this.daylb);
            this.pday.Controls.Add(this.daymid);
            this.pday.Controls.Add(this.daypb);
            this.pday.Dock = System.Windows.Forms.DockStyle.Top;
            this.pday.Location = new System.Drawing.Point(0, 0);
            this.pday.Name = "pday";
            this.pday.Size = new System.Drawing.Size(269, 35);
            this.pday.TabIndex = 0;
            // 
            // daylb
            // 
            this.daylb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.daylb.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.daylb.Location = new System.Drawing.Point(53, 0);
            this.daylb.Name = "daylb";
            this.daylb.Size = new System.Drawing.Size(216, 35);
            this.daylb.TabIndex = 4;
            this.daylb.Text = "View by Day";
            this.daylb.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.daylb.Click += new System.EventHandler(this.OnDayClick);
            this.daylb.MouseEnter += new System.EventHandler(this.OnDayMouseEnter);
            this.daylb.MouseLeave += new System.EventHandler(this.OnDayMouseLeave);
            // 
            // daymid
            // 
            this.daymid.Dock = System.Windows.Forms.DockStyle.Left;
            this.daymid.Location = new System.Drawing.Point(37, 0);
            this.daymid.Name = "daymid";
            this.daymid.Size = new System.Drawing.Size(16, 35);
            this.daymid.TabIndex = 1;
            this.daymid.Click += new System.EventHandler(this.OnDayClick);
            this.daymid.MouseEnter += new System.EventHandler(this.OnDayMouseEnter);
            this.daymid.MouseLeave += new System.EventHandler(this.OnDayMouseLeave);
            // 
            // daypb
            // 
            this.daypb.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("daypb.BackgroundImage")));
            this.daypb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.daypb.Dock = System.Windows.Forms.DockStyle.Left;
            this.daypb.Location = new System.Drawing.Point(0, 0);
            this.daypb.Name = "daypb";
            this.daypb.Size = new System.Drawing.Size(37, 35);
            this.daypb.TabIndex = 0;
            this.daypb.TabStop = false;
            this.daypb.Click += new System.EventHandler(this.OnDayClick);
            this.daypb.MouseEnter += new System.EventHandler(this.OnDayMouseEnter);
            this.daypb.MouseLeave += new System.EventHandler(this.OnDayMouseLeave);
            // 
            // SelectDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pselectviewtype);
            this.Name = "SelectDate";
            this.Size = new System.Drawing.Size(271, 245);
            this.Load += new System.EventHandler(this.OnSelectDateLoad);
            this.VisibleChanged += new System.EventHandler(this.OnSelectDateVisibilityChanged);
            this.pselectviewtype.ResumeLayout(false);
            this.pcustomdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.custompb)).EndInit();
            this.pviewall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.allpb)).EndInit();
            this.pyear.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.yearpb)).EndInit();
            this.pquarter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.quarterpb)).EndInit();
            this.pmonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.monthpb)).EndInit();
            this.pweek.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.weekpb)).EndInit();
            this.pday.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.daypb)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pselectviewtype;
        private System.Windows.Forms.Panel pcustomdate;
        private System.Windows.Forms.Label customlb;
        private System.Windows.Forms.Panel custommid;
        private System.Windows.Forms.PictureBox custompb;
        private System.Windows.Forms.Panel pviewall;
        private System.Windows.Forms.Label alllb;
        private System.Windows.Forms.Panel allmid;
        private System.Windows.Forms.PictureBox allpb;
        private System.Windows.Forms.Panel pyear;
        private System.Windows.Forms.Label yearlb;
        private System.Windows.Forms.Panel yearmid;
        private System.Windows.Forms.PictureBox yearpb;
        private System.Windows.Forms.Panel pquarter;
        private System.Windows.Forms.Label quarterlb;
        private System.Windows.Forms.Panel quartermid;
        private System.Windows.Forms.PictureBox quarterpb;
        private System.Windows.Forms.Panel pmonth;
        private System.Windows.Forms.Label monthlb;
        private System.Windows.Forms.Panel monthmid;
        private System.Windows.Forms.PictureBox monthpb;
        private System.Windows.Forms.Panel pweek;
        private System.Windows.Forms.Label weeklb;
        private System.Windows.Forms.Panel weekmid;
        private System.Windows.Forms.PictureBox weekpb;
        private System.Windows.Forms.Panel pday;
        private System.Windows.Forms.Label daylb;
        private System.Windows.Forms.Panel daymid;
        private System.Windows.Forms.PictureBox daypb;
    }
}
