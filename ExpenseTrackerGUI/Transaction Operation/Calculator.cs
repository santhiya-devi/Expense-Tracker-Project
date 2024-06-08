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
    public partial class Calculator : UserControl
    {
        public Calculator()
        {
            InitializeComponent();
        }

        //Paint Operation

        private void OnMessagePaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.blackColor, GUIStyles.whiteColor, pmessage.Width, pmessage.Height, 5, 10);
        }

        //Property

        float answer = 0;
        int time = 0;

        public float Answer
        {
            get => answer;
            set
            {
                answer = value;
                datatb.Text = answer.ToString();
            }
        }

        //Event Creation

        public delegate void CalculatorClose(object sender, bool closed);
        public event CalculatorClose CalculatorClosed;

        //Calculator Load and Timer

        private void OnCalculatorLoad(object sender, EventArgs e)
        {
            pmessage.Location = new Point(60, 100);
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
            p5.Width = p1.Width;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            AddColor();
        }

        private void OnCalculatorVisibilityChanged(object sender, EventArgs e)
        {
            AddColor();
        }

        private void AddColor()
        {
            pmessage.Invalidate();
            pback.BackColor = GUIStyles.primaryColor;
            rupeelb.BackColor = clearbt.BackColor = dividebt.BackColor = multiplybt.BackColor = addbt.BackColor = subtractbt.BackColor = GUIStyles.whiteColor;
            deletebt.BackColor = dotbt.BackColor = equaltobt.BackColor = savebt.BackColor = backbt.BackColor = zero1bt.BackColor = onebt.BackColor = GUIStyles.whiteColor;
            twobt.BackColor = threebt.BackColor = fourbt.BackColor = fivebt.BackColor = sixbt.BackColor = sevenbt.BackColor = eightbt.BackColor = ninebt.BackColor = GUIStyles.whiteColor;
            rupeelb.ForeColor = clearbt.ForeColor = dividebt.ForeColor = multiplybt.ForeColor = addbt.ForeColor = subtractbt.ForeColor = dotbt.ForeColor = GUIStyles.blackColor;
            onebt.ForeColor = twobt.ForeColor = threebt.ForeColor = fourbt.ForeColor = fivebt.ForeColor = sixbt.ForeColor = sevenbt.ForeColor = eightbt.ForeColor = ninebt.ForeColor = zero1bt.ForeColor = GUIStyles.blackColor;
        }

        //Timer Operation

        private void OnTimerStart(object sender, EventArgs e)
        {
            time++;
            if (time == 10)
            {
                time = 0;
                savebt.BackgroundImage = Image.FromFile(@".\Images\TickCalc.png");
                calctimer.Stop();
            }
        }

        private void OnTimer(object sender, EventArgs e)
        {
            pmessage.Visible = true;
            pback.Enabled = false;
            time++;
            if (time == 20)
            {
                time = 0;
                pback.Enabled = true;
                pmessage.Visible = false;
                datatb.Text = answer.ToString();
                Timer.Stop();
            }
        }

        //Sign Button Click

        private void OnDivideBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            if (datatb.TextLength > 0)
            {
                char txt = datatb.Text[datatb.TextLength - 1];
                if (txt == '/' || txt == '*' || txt == '+' || txt == '-' || txt == '.')
                {
                    datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1) + "/";
                }
                else
                {
                    datatb.Text += "/";
                }
            }
        }

        private void OnMultiplyBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            if (datatb.TextLength > 0)
            {
                char txt = datatb.Text[datatb.TextLength - 1];
                if (txt == '/' || txt == '*' || txt == '+' || txt == '-' || txt == '.')
                {
                    datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1) + "*";
                }
                else
                {
                    datatb.Text += "*";
                }
            }
        }

        private void OnSubtractBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            if (datatb.TextLength > 0)
            {
                char txt = datatb.Text[datatb.TextLength - 1];
                if (txt == '/' || txt == '*' || txt == '+' || txt == '-' || txt == '.')
                {
                    datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1) + "-";
                }
                else
                {
                    datatb.Text += "-";
                }
            }
        }

        private void OnAddBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            if (datatb.TextLength > 0)
            {
                char txt = datatb.Text[datatb.TextLength - 1];
                if (txt == '/' || txt == '*' || txt == '+' || txt == '-' || txt == '.')
                {
                    datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1) + "+";
                }
                else
                {
                    datatb.Text += "+";
                }
            }
        }

        private void OnDotBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            if (datatb.TextLength > 0 && TransactionEditor.CheckDot(datatb.Text) == true)
            {
                char txt = datatb.Text[datatb.TextLength - 1];
                if (txt == '/' || txt == '*' || txt == '+' || txt == '-')
                {
                    datatb.Text += "0.";
                }
                else if(txt == '.')
                {
                    datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1) + ".";
                }
                else
                {
                    datatb.Text += ".";
                }
            }
            else if(datatb.TextLength==0)
            {
                datatb.Text += "0.";
            }
        }

        private void OnDeleteBtClick(object sender, EventArgs e)
        {
            if (datatb.TextLength > 0)
            {
                datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1);
            }
        }

        private void OnClearBtClick(object sender, EventArgs e)
        {
            datatb.Text = "";
        }

        private void OnEqualToBtClick(object sender, EventArgs e)
        {
            if (datatb.Text.Length > 0)
            {
                string str = TransactionEditor.CalcOperation(datatb.Text);
                if (float.Parse(str) > 0)
                {
                    datatb.Text = str;
                }
                else
                {
                    datatb.Text = answer.ToString();
                    Timer.Start();
                }
            }
        }

        private void OnSaveBtClick(object sender, EventArgs e)
        {
            if (ValidateFloat() == true)
            {
                OnEqualToBtClick(sender, e);
                if (ValidateFloat() == true)
                {
                    answer = float.Parse(datatb.Text);
                }
                else
                {
                    datatb.Text = answer.ToString();
                }
                //answer = float.Parse(datatb.Text);
            }
            else
            {
                datatb.Text = answer.ToString();
            }
            //OnEqualToBtClick(sender, e);
            savebt.BackgroundImage = Image.FromFile(@".\Images\TickCalcGreen.png");
            calctimer.Start();
        }

        private void OnBackBtClick(object sender, EventArgs e)
        {
            CalculatorClosed?.Invoke(sender, true);
        }

        //Validate Functions        

        private bool ValidateFloat()
        {
            if (datatb.Text == "∞" || datatb.Text == "NaN" || datatb.Text == "0" || datatb.Text == "")
            {
                Timer.Start();
                return false; ;
            }
            for (int i = 0; i < datatb.Text.Length; i++)
            {
                if (datatb.Text[i] == 'E')
                {
                    Timer.Start();
                    return false;
                }
            }
            return true;
        }

        private void OnDataBtKeyPress(object sender, KeyPressEventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else if(e.KeyChar == (char)43 || e.KeyChar == (char)45 || e.KeyChar == (char)42 || e.KeyChar == (char)47)
            {
                if (datatb.TextLength > 0)
                {
                    char txt = datatb.Text[datatb.TextLength - 1];
                    if (txt == '/' || txt == '*' || txt == '+' || txt == '-' || txt == '.')
                    {
                        datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1);
                    }
                }
                else
                {
                    e.Handled = true;
                }
                datatb.SelectionStart = datatb.TextLength;
            }
            else if (e.KeyChar == (char)46)
            {                
                if(datatb.TextLength==0)
                {
                    datatb.Text += "0";
                }
                else if (datatb.TextLength > 0 && TransactionEditor.CheckDot(datatb.Text) == true)
                {
                    char txt = datatb.Text[datatb.TextLength - 1];
                    if (txt == '/' || txt == '*' || txt == '+' || txt == '-')
                    {
                        datatb.Text += "0";
                        datatb.SelectionStart = datatb.TextLength;
                    }
                    else if (txt == '.')
                    {
                        datatb.Text = datatb.Text.Substring(0, datatb.TextLength - 1);
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
            else if (e.KeyChar == (char)13)
            {
                OnEqualToBtClick(sender, EventArgs.Empty);
                datatb.SelectionStart = datatb.TextLength;
            }
            else
            {
                e.Handled = true;
            }
        }

        //Number Button Click

        private void OnOneBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "1";
        }

        private void OnTwoBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "2";
        }

        private void OnThreeBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "3";
        }

        private void OnFourBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "4";
        }

        private void OnFiveBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "5";
        }

        private void OnSixBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "6";
        }

        private void OnSevenBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "7";
        }

        private void OnEightBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "8";
        }

        private void OnNineBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "9";
        }

        private void OnZeroBtClick(object sender, EventArgs e)
        {
            datatb.Text = TransactionEditor.ChechInfinity(datatb.Text);
            datatb.Text += "0";
        }
    }
}