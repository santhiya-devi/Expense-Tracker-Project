using ExpenseTracker;
using ExpenseTrackerDS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    static class TransactionEditor
    {

        //Panel Paint Events        

        public static void PaintOperation(object sender, PaintEventArgs e, Color borderColor, Color backcolor, int width, int height,int borderWidth, int borderRadius)
        {
            using (Pen borderPen = new Pen(borderColor, borderWidth))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                GraphicsPath borderPath = CreateRoundedRectanglePath(new Rectangle(borderWidth / 2, borderWidth / 2, width - borderWidth, height - borderWidth), borderRadius);
                e.Graphics.DrawPath(borderPen, borderPath);
                e.Graphics.FillPath(new SolidBrush(backcolor), borderPath);
            }
        }

        public static void PaintButtonOperation(object sender, PaintEventArgs e, int width, int height)
        {
            Graphics graphics = e.Graphics;
            Rectangle rectangle = new Rectangle(0, 0, width - 1, height - 1);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using (GraphicsPath roundedRectangle = CreateRoundedRectanglePath(rectangle, 10))
            using (Pen pen = new Pen(GUIStyles.primaryColor, 4))
            {
                graphics.DrawPath(pen, roundedRectangle);
            }
        }

        public static GraphicsPath CreateRoundedRectanglePath(Rectangle rectangle, int cornerRadius)
        {
            int diameter = cornerRadius * 2;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rectangle.X, rectangle.Y, diameter, diameter, 180, 90);
            path.AddArc(rectangle.Right - diameter, rectangle.Y, diameter, diameter, 270, 90);
            path.AddArc(rectangle.Right - diameter, rectangle.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rectangle.X, rectangle.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            return path;
        }

        //Add Button Details

        public static List<String> viewday = new List<string>();
        public static List<String> viewweek = new List<string>();
        public static List<String> viewmonth = new List<string>();
        public static List<String> viewquarter = new List<string>();
        public static List<String> viewyear = new List<string>();
        public static List<String> viewcategory = new List<string>();
        public static List<String> viewoption = new List<string>();

        public static void AddDay()
        {
            if (viewday.Count == 0)
            {
                DateTime dt = DateTime.Now;
                for (int i = 0; i < 15; i++)
                {
                    String str = dt.ToString("dd") + "/" + dt.ToString("MM") + "/" + dt.ToString("yyyy");
                    if (i > 1)
                    {
                        viewday.Insert(0, str);
                    }
                    dt = dt.AddDays(-1);
                }
                viewday.Add("Yesterday");
                viewday.Add("Today");
                viewday.Add("Future");
            }
        }

        public static void AddWeek()
        {
            if (viewweek.Count == 0)
            {
                DateTime dt = DateTime.Now;
                for (int i = 0; i < 15; i++)
                {
                    int start = (int)dt.DayOfWeek;
                    int end = 6 - start;
                    DateTime startdate = dt.AddDays(-start);
                    String str = startdate.ToString("dd") + "/" + startdate.ToString("MM") + "/" + startdate.ToString("yyyy") + " - ";
                    DateTime endDate = dt.AddDays(+end);
                    str += endDate.ToString("dd") + "/" + endDate.ToString("MM") + "/" + endDate.ToString("yyyy");
                    if (i > 1)
                    {
                        viewweek.Insert(0, str);
                    }
                    dt = dt.AddDays(-7);
                }
                viewweek.Add("LastWeek");
                viewweek.Add("ThisWeek");
                viewweek.Add("Future");
            }
        }

        public static void AddMonth()
        {
            if (viewmonth.Count == 0)
            {
                DateTime dt = DateTime.Now;
                for (int i = 0; i < 15; i++)
                {
                    String str = dt.ToString("MM") + "/" + dt.ToString("yyyy");
                    if (i > 1)
                    {
                        viewmonth.Insert(0, str);
                    }
                    dt = dt.AddMonths(-1);
                }
                viewmonth.Add("LastMonth");
                viewmonth.Add("ThisMonth");
                viewmonth.Add("Future");
            }
        }

        public static void AddQuarter()
            {
            if (viewquarter.Count == 0)
            {
                DateTime dt = DateTime.Now;
                for (int i = 0; i < 15; i++)
                {
                    String str = "";
                    int month = int.Parse(dt.ToString("MM"));
                    if (month <= 3)
                    {
                        str = "Q1-" + dt.ToString("yyyy");
                    }
                    else if (month <= 6)
                    {
                        str = "Q2-" + dt.ToString("yyyy");
                    }
                    else if (month <= 9)
                    {
                        str = "Q3-" + dt.ToString("yyyy");
                    }
                    else
                    {
                        str = "Q4-" + dt.ToString("yyyy");
                    }
                    viewquarter.Insert(0, str);
                    dt = dt.AddMonths(-3);
                }
                viewquarter.Add("Future");
            }
        }

        public static void AddYear()
        {
            if (viewyear.Count == 0)
            {
                DateTime dt = DateTime.Now;
                for (int i = 0; i < 15; i++)
                {
                    String str = dt.ToString("yyyy");
                    if (i > 1)
                    {
                        viewyear.Insert(0, str);
                    }
                    dt = dt.AddYears(-1);
                }
                viewyear.Add("LastYear");
                viewyear.Add("ThisYear");
                viewyear.Add("Future");
            }
        }

        public static void AddViewOption()
        {
            viewoption.Add("View by Day");
            viewoption.Add("View by Week");
            viewoption.Add("View by Month");
            viewoption.Add("View by Quarter");
            viewoption.Add("View by Year");
            viewoption.Add("View All");
            viewoption.Add("Custom");
            viewcategory.Add("Individual Transaction");
            viewcategory.Add("View By Transaction");
            viewcategory.Add("View By Category");
        }

        //Call Show Functions

        public static DateTime FindDay(String str)
        {
            DateTime dt = DateTime.Now;
            if (str == "Today")
            {
                dt = DateTime.Now;
            }
            else if (str == "Yesterday")
            {
                dt = dt.AddDays(-1);
            }
            else
            {
                dt = DateTime.Parse(str.Substring(3, 2) + "/" + str.Substring(6, 4) + "/" + str.Substring(0, 2));
            }
            return dt;
        }

        public static DateTime FindWeek(String str)
        {
            DateTime dt = DateTime.Now;
            if (str == "ThisWeek")
            {
                dt = DateTime.Now;
            }
            else if (str == "LastWeek")
            {
                dt = dt.AddDays(-7);
            }
            else
            {
                dt = DateTime.Parse(str.Substring(3, 2) + "/" + str.Substring(6, 4) + "/" + str.Substring(0, 2));
            }
            return dt;
        }

        public static DateTime FindMonth(String str)
        {
            DateTime dt = DateTime.Now;
            if (str == "ThisMonth")
            {
                dt = DateTime.Now;
            }
            else if (str == "LastMonth")
            {
                dt = dt.AddMonths(-1);
            }
            else
            {
                dt = DateTime.Parse(str+ "/01");
            }
            return dt;
        }

        public static DateTime FindQuarter(String str)
        {
            DateTime dt = DateTime.Now;
            if (str.Substring(0, 2) == "Q1")
            {
                dt = DateTime.Parse("01/01/" + str.Substring(3, 4));
            }
            else if (str.Substring(0, 2) == "Q2")
            {
                dt = DateTime.Parse("01/04/" + str.Substring(3, 4));
            }
            else if (str.Substring(0, 2) == "Q3")
            {
                dt = DateTime.Parse("01/07/" + str.Substring(3, 4));
            }
            else if (str.Substring(0, 2) == "Q4")
            {
                dt = DateTime.Parse("01/10/" + str.Substring(3, 4));
            }
            else
            {
                dt = DateTime.Parse(str);
            }
            return dt;
        }

        public static DateTime FindYear(String str)
        {
            DateTime dt = DateTime.Now;
            if (str == "ThisYear")
            {
                dt = DateTime.Now;
            }
            else if (str == "LastYear")
            {
                dt = dt.AddYears(-1);
            }
            else
            {
                dt = DateTime.Parse("01/01/" + str);
            }
            return dt;
        }

        //Caluculator Function

        public static string CalcOperation(string str)
        {
            string data = str;
            string ndata = "";
            List<char> lisign = new List<char>();
            List<float> linum = new List<float>();
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 'E')
                {
                    linum.Add(CheckFloat(ndata)); ndata = "";
                    break;
                }
                else if (data[i] == '/' && i < data.Length - 1)
                {
                    linum.Add(CheckFloat(ndata));
                    lisign.Add('/'); ndata = "";
                }
                else if (data[i] == '*' && i < data.Length - 1)
                {
                    linum.Add(CheckFloat(ndata));
                    lisign.Add('*'); ndata = "";
                }
                else if (data[i] == '+' && i < data.Length - 1)
                {
                    linum.Add(CheckFloat(ndata));
                    lisign.Add('+'); ndata = "";
                }
                else if (data[i] == '-' && i < data.Length - 1)
                {
                    linum.Add(CheckFloat(ndata));
                    lisign.Add('-'); ndata = "";
                }
                else
                {
                    if (data[i] != '/' && data[i] != '*' && data[i] != '+' && data[i] != '-')
                    {
                        ndata += data[i];
                    }
                }
            }
            if (ndata.Length > 0)
            {
                linum.Add(CheckFloat(ndata));
            }
            while (lisign.Count > 0)
            {
                for (int i = 0; i < lisign.Count; i++)
                {
                    if (lisign[i] == '/')
                    {
                        linum[i] = linum[i] / linum[i + 1];
                        linum.RemoveAt(i + 1);
                        lisign.RemoveAt(i);
                        i--;
                    }
                    if (i >= 0 && lisign[i] == '*')
                    {
                        linum[i] = linum[i] * linum[i + 1];
                        linum.RemoveAt(i + 1);
                        lisign.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < lisign.Count; i++)
                {
                    if (lisign[i] == '+')
                    {
                        linum[i] = linum[i] + linum[i + 1];
                        linum.RemoveAt(i + 1);
                        lisign.RemoveAt(i);
                        i--;
                    }
                    if (i >= 0 && lisign[i] == '-')
                    {
                        linum[i] = linum[i] - linum[i + 1];
                        linum.RemoveAt(i + 1);
                        lisign.RemoveAt(i);
                        i--;
                    }
                }
            }
            return linum[0].ToString();
        }

        public static float CheckFloat(String val)
        {
            bool check = false;
            float value = 0;
            check = float.TryParse(val, out value);
            if (check == false)
            {
                return 0;
            }
            return value;
        }

        public static string ChechInfinity(string data)
        {
            if (data == "∞" || data == "NaN" || data == "0")
            {
                data = "";
            }
            return data;
        }

        public static bool CheckDot(string data)
        {
            String totdata = data;
            for (int i = totdata.Length - 1; i >= 0; i--)
            {
                if (totdata[i] == '/' || totdata[i] == '*' || totdata[i] == '+' || totdata[i] == '-')
                {
                    return true;
                }
                else if (totdata[i] == '.')
                {
                    return false;
                }
            }
            return true;
        }

        //Interest Calculator Functions

        public static double FindAnswer(float principal, float rate, float time, string strtext)
        {
            double answer = 0;
            if (strtext == "Yearly")
                answer = (principal * (Math.Pow((1 + rate), time))) - principal;
            else if (strtext == "Haly-Yearly")
                answer = (principal * (Math.Pow((1 + (rate / 2)), (2 * time)))) - principal;
            else if (strtext == "Quarterly")
                answer = (principal * (Math.Pow((1 + (rate / 4)), (4 * time)))) - principal;
            else if (strtext == "Monthly")
                answer = (principal * (Math.Pow((1 + (rate / 12)), (12 * time)))) - principal;
            else if (strtext == "Weekly")
                answer = (principal * (Math.Pow((1 + (rate / 52)), (52 * time)))) - principal;
            else if (strtext == "Daily")
                answer = (principal * (Math.Pow((1 + (rate / 365)), (365 * time)))) - principal;
            return answer;
        }

        public static float FindTime(float time, string strtime)
        {
            if (strtime == "Quaters")
                time = time / 4;
            else if (strtime == "Months")
                time = time / 12;
            else if (strtime == "Weeks")
                time = time / 52;
            else if (strtime == "Days")
                time = time / 365;
            return time;
        }
    }
}