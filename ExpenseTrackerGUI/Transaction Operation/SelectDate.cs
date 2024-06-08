using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class SelectDate : UserControl
    {
        public SelectDate()
        {
            InitializeComponent();
        }

        //Event Creation
        public delegate void DaySelection(object sender, string e);
        public event DaySelection DaySelected;

        //Property 

        bool colorchanged = false;
        public bool ColorChanged
        {
            get => colorchanged;
            set
            {
                colorchanged = value;
                if (colorchanged == true)
                {
                    OnGUIStylesColorChanged(true);
                }
            }
        }

        //Load Operation

        private void OnSelectDateLoad(object sender, EventArgs e)
        {
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            daylb.ForeColor = weeklb.ForeColor = monthlb.ForeColor = quarterlb.ForeColor = yearlb.ForeColor = alllb.ForeColor = customlb.ForeColor = GUIStyles.blackColor;
            daypb.BackColor = daymid.BackColor = daylb.BackColor = GUIStyles.backColor; weekpb.BackColor = weekmid.BackColor = weeklb.BackColor = GUIStyles.backColor;
            monthpb.BackColor = monthmid.BackColor = monthlb.BackColor = GUIStyles.backColor; quarterpb.BackColor = quartermid.BackColor = quarterlb.BackColor = GUIStyles.backColor;
            yearpb.BackColor = yearmid.BackColor = yearlb.BackColor = GUIStyles.backColor; allpb.BackColor = allmid.BackColor = alllb.BackColor = GUIStyles.backColor;
            custompb.BackColor = custommid.BackColor = customlb.BackColor = GUIStyles.backColor;
            if (GUIStyles.colorName == "blue")
            {
                daypb.BackgroundImage = weekpb.BackgroundImage = monthpb.BackgroundImage = quarterpb.BackgroundImage = yearpb.BackgroundImage = allpb.BackgroundImage = custompb.BackgroundImage = Image.FromFile(@".\Images\viewdayblue.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                daypb.BackgroundImage = weekpb.BackgroundImage = monthpb.BackgroundImage = quarterpb.BackgroundImage = yearpb.BackgroundImage = allpb.BackgroundImage = custompb.BackgroundImage = Image.FromFile(@".\Images\viewdayred.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                daypb.BackgroundImage = weekpb.BackgroundImage = monthpb.BackgroundImage = quarterpb.BackgroundImage = yearpb.BackgroundImage = allpb.BackgroundImage = custompb.BackgroundImage = Image.FromFile(@".\Images\viewdayorange.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                daypb.BackgroundImage = weekpb.BackgroundImage = monthpb.BackgroundImage = quarterpb.BackgroundImage = yearpb.BackgroundImage = allpb.BackgroundImage = custompb.BackgroundImage = Image.FromFile(@".\Images\viewdaypink.png");
            }
            else
            {
                daypb.BackgroundImage = weekpb.BackgroundImage = monthpb.BackgroundImage = quarterpb.BackgroundImage = yearpb.BackgroundImage = allpb.BackgroundImage = custompb.BackgroundImage = Image.FromFile(@".\Images\viewdayblack.png");
            }
        }

        private void OnSelectDateVisibilityChanged(object sender, EventArgs e)
        {
            pselectviewtype.BackColor = GUIStyles.backColor;
        }

        //Mouse Click Events

        private void OnDayClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "View by Day");
        }

        private void OnWeekClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "View by Week");
        }

        private void OnMonthClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "View by Month");
        }

        private void OnQuarterClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "View by Quarter");
        }

        private void OnYearClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "View by Year");
        }

        private void OnViewAllClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "View All");
        }

        private void OnCustomClick(object sender, EventArgs e)
        {
            DaySelected?.Invoke(sender, "Custom");
        }

        //Mouse Enter Events

        private void OnDayMouseEnter(object sender, EventArgs e)
        {
            daypb.BackColor = daymid.BackColor = daylb.BackColor = GUIStyles.terenaryColor;
            daylb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnDayMouseLeave(object sender, EventArgs e)
        {
            daypb.BackColor = daymid.BackColor = daylb.BackColor = GUIStyles.backColor;
            daylb.ForeColor = GUIStyles.blackColor;
        }

        private void OnWeekMouseEnter(object sender, EventArgs e)
        {
            weekpb.BackColor = weekmid.BackColor = weeklb.BackColor = GUIStyles.terenaryColor;
            weeklb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnWeekMouseLeave(object sender, EventArgs e)
        {
            weekpb.BackColor = weekmid.BackColor = weeklb.BackColor = GUIStyles.backColor;
            weeklb.ForeColor = GUIStyles.blackColor;
        }

        private void OnMonthMouseEnter(object sender, EventArgs e)
        {
            monthpb.BackColor = monthmid.BackColor = monthlb.BackColor = GUIStyles.terenaryColor;
            monthlb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnMonthMouseLeave(object sender, EventArgs e)
        {
            monthpb.BackColor = monthmid.BackColor = monthlb.BackColor = GUIStyles.backColor;
            monthlb.ForeColor = GUIStyles.blackColor;
        }

        private void OnQuarterMouseEnter(object sender, EventArgs e)
        {
            quarterpb.BackColor = quartermid.BackColor = quarterlb.BackColor = GUIStyles.terenaryColor;
            quarterlb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnQuarterMouseLeave(object sender, EventArgs e)
        {
            quarterpb.BackColor = quartermid.BackColor = quarterlb.BackColor = GUIStyles.backColor;
            quarterlb.ForeColor = GUIStyles.blackColor;
        }

        private void OnYearMouseEnter(object sender, EventArgs e)
        {
            yearpb.BackColor = yearmid.BackColor = yearlb.BackColor = GUIStyles.terenaryColor;
            yearlb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnYearMouseLeave(object sender, EventArgs e)
        {
            yearpb.BackColor = yearmid.BackColor = yearlb.BackColor = GUIStyles.backColor;
            yearlb.ForeColor = GUIStyles.blackColor;
        }

        private void OnViewAllMouseEnter(object sender, EventArgs e)
        {
            allpb.BackColor = allmid.BackColor = alllb.BackColor = GUIStyles.terenaryColor;
            alllb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnViewAllMouseLeave(object sender, EventArgs e)
        {
            allpb.BackColor = allmid.BackColor = alllb.BackColor = GUIStyles.backColor;
            alllb.ForeColor = GUIStyles.blackColor;
        }

        private void OnCustomMouseEnter(object sender, EventArgs e)
        {
            custompb.BackColor = custommid.BackColor = customlb.BackColor = GUIStyles.terenaryColor;
            customlb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnCustomMouseLeave(object sender, EventArgs e)
        {
            custompb.BackColor = custommid.BackColor = customlb.BackColor = GUIStyles.backColor;
            customlb.ForeColor = GUIStyles.blackColor;
        }
    }
}
