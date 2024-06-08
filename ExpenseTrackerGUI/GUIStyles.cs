using ExpenseTracker;
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
    public static class GUIStyles
    {
        public static Color primaryColor = Color.FromArgb(54, 55, 149);
        public static Color secondaryColor = Color.MediumSlateBlue;
        public static Color terenaryColor= Color.FromArgb(192, 192, 255);
        public static Color cardColor = Color.Lavender;
        public static Color backColor = Color.GhostWhite;
        public static Color whiteColor = Color.White;
        public static Color blackColor = Color.Black;
        public static Color incomeColor= Color.FromArgb(0, 192, 0);
        public static Color expenseColor = Color.Red;
        public static string colorName = "blue";

        public delegate void ColorChange(bool e);
        public static event ColorChange ColorChanged;

        public static void ChangeColor(string color)
        {
            if (color == "black")
            {
                colorName = "black";
                primaryColor = Color.FromArgb(0, 0, 0);
                secondaryColor = Color.FromArgb(89, 89, 89);
                terenaryColor = Color.FromArgb(140, 140, 140);
                cardColor = Color.FromArgb(204, 204, 204);
                backColor = Color.FromArgb(199, 200, 204);
            }
            else if (color == "brown")
            {
                colorName = "brown";
                primaryColor = Color.FromArgb(26, 26, 26);
                secondaryColor = Color.FromArgb(128, 128, 128);
                terenaryColor = Color.FromArgb(179, 179, 179);
                cardColor = Color.FromArgb(204, 204, 204);
                backColor = Color.FromArgb(242, 242, 242);
            }
            else if (color == "blue")
            {
                colorName = "blue";
                primaryColor = Color.FromArgb(54, 55, 149);
                secondaryColor = Color.MediumSlateBlue;
                terenaryColor = Color.FromArgb(192, 192, 255);
                cardColor = Color.Lavender;
                backColor = Color.GhostWhite;
            }
            else if (color == "pink")
            {
                colorName = "pink";
                primaryColor = Color.FromArgb(255, 89, 123);
                secondaryColor = Color.FromArgb(255, 142, 158);
                terenaryColor = Color.FromArgb(249, 181, 208);
                cardColor = Color.FromArgb(238, 238, 238);
                backColor = Color.FromArgb(242, 242, 242);
            }
            else if(color=="red")
            {
                colorName = "red";
                primaryColor = Color.FromArgb(230, 0, 0);
                secondaryColor = Color.FromArgb(255, 51, 51);
                terenaryColor = Color.FromArgb(255, 153, 153);
                cardColor = Color.FromArgb(255, 204, 204);
                backColor = Color.FromArgb(255, 245, 245);
            }
            else if (color == "orange")
            {
                colorName = "orange";
                primaryColor = Color.FromArgb(242, 140, 40);
                secondaryColor = Color.FromArgb(255, 173, 51);
                terenaryColor = Color.FromArgb(255, 204, 128);
                cardColor = Color.FromArgb(255, 235, 204);
                backColor = Color.FromArgb(255, 251, 245);
            }
            whiteColor = Color.White;
            blackColor = Color.Black;
            ColorChanged?.Invoke(true);
        }
    }
}