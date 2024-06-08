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
    public partial class SelectCategory : UserControl
    {
        public SelectCategory()
        {
            InitializeComponent();
        }

        //EventCreation

        public delegate void TypeSelection(object sender, string e);
        public event TypeSelection TypeSelected;

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

        private void OnSelectTypeLoad(object sender, EventArgs e)
        {
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            individuallb.ForeColor = categorylb.ForeColor = transactionlb.ForeColor = GUIStyles.blackColor;
            individualpb.BackColor = individualmid.BackColor = individuallb.BackColor = GUIStyles.backColor;
            categorypb.BackColor = categorymid.BackColor = categorylb.BackColor = GUIStyles.backColor;
            transactionpb.BackColor = transactonmid.BackColor = transactionlb.BackColor = GUIStyles.backColor;
            if (GUIStyles.colorName == "blue")
            {
                individualpb.BackgroundImage = categorypb.BackgroundImage = transactionpb.BackgroundImage = Image.FromFile(@".\Images\viewcatblue.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                individualpb.BackgroundImage = categorypb.BackgroundImage = transactionpb.BackgroundImage = Image.FromFile(@".\Images\viewcatred.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                individualpb.BackgroundImage = categorypb.BackgroundImage = transactionpb.BackgroundImage = Image.FromFile(@".\Images\viewcatorange.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                individualpb.BackgroundImage = categorypb.BackgroundImage = transactionpb.BackgroundImage = Image.FromFile(@".\Images\viewcatpink.png");
            }
            else
            {
                individualpb.BackgroundImage = categorypb.BackgroundImage = transactionpb.BackgroundImage = Image.FromFile(@".\Images\viewcatblack.png");
            }
        }

        private void OnSelectTypeVisibilityChanged(object sender, EventArgs e)
        {
            pselectcategorytransaction.BackColor = GUIStyles.backColor;
        }

        //Mouse Click Events

        private void OnIndividualClick(object sender, EventArgs e)
        {
            TypeSelected?.Invoke(sender, "View Individual Transaction");
        }

        private void OnCategoryClick(object sender, EventArgs e)
        {
            TypeSelected?.Invoke(sender, "View by Category");
        }

        private void OnTransactionClick(object sender, EventArgs e)
        {
            TypeSelected?.Invoke(sender, "View by Transaction");
        }

        //Mouse Enter Events

        private void OnIndividualMouseEnter(object sender, EventArgs e)
        {
            individualpb.BackColor = individualmid.BackColor = individuallb.BackColor = GUIStyles.terenaryColor;
            individuallb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnIndividualMouseLeave(object sender, EventArgs e)
        {
            individualpb.BackColor = individualmid.BackColor = individuallb.BackColor = GUIStyles.backColor;
            individuallb.ForeColor = GUIStyles.blackColor;
        }

        private void OnCategoryMouseEnter(object sender, EventArgs e)
        {
            categorypb.BackColor = categorymid.BackColor = categorylb.BackColor = GUIStyles.terenaryColor;
            categorylb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnCategoryMouseLeave(object sender, EventArgs e)
        {
            categorypb.BackColor = categorymid.BackColor = categorylb.BackColor = GUIStyles.backColor;
            categorylb.ForeColor = GUIStyles.blackColor;
        }

        private void OnTransactionMouseEnter(object sender, EventArgs e)
        {
            transactionpb.BackColor = transactonmid.BackColor = transactionlb.BackColor = GUIStyles.terenaryColor;
            transactionlb.ForeColor = GUIStyles.whiteColor;
        }

        private void OnTransactionMouseLeave(object sender, EventArgs e)
        {
            transactionpb.BackColor = transactonmid.BackColor = transactionlb.BackColor = GUIStyles.backColor;
            transactionlb.ForeColor = GUIStyles.blackColor;
        }
    }
}
