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
    public partial class HistoryBox : UserControl
    {
        public HistoryBox()
        {
            InitializeComponent();
        }

        //Paint Operation
        
        private void OnPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, BoxBackColor, pbottom.Width, pbottom.Height, 10, 10);
        }

        //Event Creation

        public delegate void IndexSelection(object sender, string e);
        public event IndexSelection IndexSelected;

        //Variables And Properties

        string hname = "Expense";
        Color BoxBackColor = GUIStyles.backColor;
        Dictionary<string, int> dic = new Dictionary<string, int>();

        bool colorchanged = false, indexdeselect = false, controlenabled = false;

        public bool IndexDeselect
        {
            get => indexdeselect;
            set
            {
                indexdeselect = value;
                if (indexdeselect == true)
                {
                    transactiondata.ClearSelected();
                }
            }
        }

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

        public bool ControlEnabled
        {
            get => controlenabled;
            set
            {
                controlenabled = value;
                if (controlenabled == true)
                {
                    this.Enabled = true;
                }
                else
                {
                    this.Enabled = false;
                }
            }
        }

        public string Hname
        {
            get => hname;
            set
            {
                hname = value;
                headlb.Text = hname;
                if (!DesignMode)
                {
                    if (hname == "Income")
                    {
                        transactiondata.ForeColor = GUIStyles.incomeColor;
                        incomepb.Visible = true;
                        expensepb.Visible = false;
                    }
                    else
                    {
                        incomepb.Visible = false;
                        expensepb.Visible = true;
                        transactiondata.ForeColor = GUIStyles.expenseColor;
                    }
                }
            }
        }

        public Dictionary<string, int> Dic
        {
            get => dic;
            set
            {
                transactiondata.Items.Clear();
                dic = value;
                transactiondata.Visible = true;
                for (int i = 0; i < dic.Count; i++)
                {
                    transactiondata.Items.Add(dic.ElementAt(i).Value + "   " + dic.ElementAt(i).Key);
                }
                if (dic.Count == 0)
                {
                    transactiondata.Visible = false;
                }
            }
        }

        //Load Operation

        private void OnHistoryDataLoad(object sender, EventArgs e)
        {
            AddColor();
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
            transactiondata.Width = pbottom.Width * 90 / 100; 
            transactiondata.Height = pbottom.Height * 90 / 100; 
            transactiondata.Location = new Point(pbottom.Width / 2 - transactiondata.Width / 2, pbottom.Height / 2 - transactiondata.Height / 2);
            
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            AddColor();
        }

        private void AddColor()
        {
            BoxBackColor = transactiondata.BackColor = GUIStyles.backColor;
            phead.BackColor = pback.BackColor = GUIStyles.primaryColor;
            pmid.BackColor = GUIStyles.whiteColor;
        }

        //Mouse Click and Enter Events

        private void OntransactiondataSelectedIndexChanged(object sender, EventArgs e)
        {  
            if (transactiondata.SelectedIndex >= 0)
            {
                string val = transactiondata.Text;
                for (int i = 1; i < val.Length; i++)
                {
                    if (val[i - 1] == ' ' && (val[i] >= 65 && val[i] <= 90))
                    {
                        val = val.Substring(i);
                        break;
                    }
                }
                IndexSelected?.Invoke(sender, val);
            }
        }

        private void OnHistoryBoxMouseEnter(object sender, EventArgs e)
        {
            BoxBackColor = GUIStyles.cardColor; transactiondata.BackColor = BoxBackColor; pbottom.Invalidate();
        }

        private void OnHistoryBoxMouseLeave(object sender, EventArgs e)
        {
            BoxBackColor = GUIStyles.backColor; transactiondata.BackColor = BoxBackColor; pbottom.Invalidate();
        }
    }
}
