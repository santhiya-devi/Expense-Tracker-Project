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
    public partial class InterestCalculator : UserControl
    {
        public InterestCalculator()
        {
            InitializeComponent();
        }

        //Paint Operation

        private void OnResultPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.whiteColor, GUIStyles.whiteColor, presult1.Width, presult1.Height, 10, 10);
        }

        //Load Operation

        private void OnInterestRateLoad(object sender, EventArgs e)
        {
            pcalculator.Controls.Add(calc);
            calc.Dock = DockStyle.Fill;
            pcalculator.Location = new Point(156, 22);
            pcalculator.Size = new Size(272, 261);
            pcalculator1.Location = new Point(156, 22);
            pcalculator1.Size = new Size(272, 261);
            pbutton.Location = new Point(pbuttonback.Width / 2 - pbutton.Width / 2, pbuttonback.Height / 2 - pbutton.Height / 2);
            AddData();
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            AddColor();
        }

        private void OnInterestVisibilityChanged(object sender, EventArgs e)
        {
            AddColor();
        }

        private void AddColor()
        {
            SIbackcolor = GUIStyles.secondaryColor; CIbackcolor = GUIStyles.backColor;
            SIbt.ForeColor = GUIStyles.whiteColor;CIbt.ForeColor = GUIStyles.blackColor;
            pfillback.BackColor = GUIStyles.primaryColor;
            pCI.Invalidate();pSI.Invalidate();pbottom.Invalidate();
            TabControl.SelectedTab = SItb;
            calculatebt.BackColor = calculate1bt.BackColor = GUIStyles.whiteColor;
            calculatebt.FlatAppearance.MouseOverBackColor = calculate1bt.FlatAppearance.MouseOverBackColor = GUIStyles.cardColor;
            calculatebt.FlatAppearance.MouseDownBackColor = calculate1bt.FlatAppearance.MouseDownBackColor = GUIStyles.backColor;
            SItb.BackColor = CItb.BackColor = GUIStyles.backColor;
            typecb.BackColor = typecb1.BackColor = timetb.BackColor = timetb1.BackColor = ratetb.BackColor = ratetb1.BackColor = compoundcb1.BackColor = GUIStyles.backColor;
            ptop.BackColor = GUIStyles.primaryColor;
            amountbt.ForeColor = ratetb.ForeColor = typecb.ForeColor = timetb.ForeColor = GUIStyles.blackColor;
            amountbt1.ForeColor = ratetb1.ForeColor = typecb1.ForeColor = timetb1.ForeColor = compoundcb1.ForeColor = GUIStyles.blackColor;
            amtlb.ForeColor = ratelb.ForeColor = unitlb.ForeColor = valuelb.ForeColor = amtlb1.ForeColor = ratelb1.ForeColor = unitlb1.ForeColor = valuelb1.ForeColor = compoundlb1.ForeColor = GUIStyles.primaryColor;
            pamount.ForeColor = pamount1.ForeColor = iamountlb.ForeColor = iamountlb1.ForeColor = tamountlb.ForeColor = tamountlb1.ForeColor = GUIStyles.blackColor;
            pamountas.ForeColor = pamountac.ForeColor = iamountas.ForeColor = iamountac.ForeColor = tamountas.ForeColor = tamountac.ForeColor = GUIStyles.primaryColor;
        }

        private void AddData()
        {
            litype.Add("Years");
            litype.Add("Quaters");
            litype.Add("Months");
            litype.Add("Weeks");
            litype.Add("Days");
            typecb.DataSource = litype;
            typecb1.DataSource = litype;
            licompound.Add("Yearly");
            licompound.Add("Haly-Yearly");
            licompound.Add("Quarterly");
            licompound.Add("Monthly");
            licompound.Add("Weekly");
            licompound.Add("Daily");
            compoundcb1.DataSource = licompound;
        }

        //Event Creation

        public event EventHandler InterestCalculatorClosed;

        //Paint Operation

        private void OnSimpleInterestPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, SIbackcolor, SIbt.Width, SIbt.Height, 4, 15);
        }

        private void OnCompoundInterestPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, CIbackcolor, SIbt.Width, SIbt.Height, 4, 15);
        }

        private void OnPbottomPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.backColor, pbottom.Width, pbottom.Height, 10, 10);
        }

        //Variable Initialization

        Color SIbackcolor = GUIStyles.secondaryColor, CIbackcolor = GUIStyles.backColor;
        Calculator calc = new Calculator();
        List<string> litype = new List<string>();
        List<string> licompound = new List<string>();

        //Button Click Events

        private void OnSIbtClick(object sender, EventArgs e)
        {
            CIbackcolor = GUIStyles.backColor;
            SIbackcolor = GUIStyles.secondaryColor;
            SIbt.ForeColor = GUIStyles.whiteColor; CIbt.ForeColor = GUIStyles.blackColor;
            pSI.Invalidate(); pCI.Invalidate();
            TabControl.SelectedTab = SItb;
            OnCalculatebtClick(sender, e);
        }

        private void OnCIbtClick(object sender, EventArgs e)
        {
            CIbackcolor = GUIStyles.secondaryColor;
            SIbackcolor = GUIStyles.backColor;
            SIbt.ForeColor = GUIStyles.blackColor; CIbt.ForeColor = GUIStyles.whiteColor;
            pSI.Invalidate();pCI.Invalidate();
            TabControl.SelectedTab = CItb;
            OnCalculate1btClick(sender, e);
        }
        
        //SI button Click Events

        private void OnAmountbtClick(object sender, EventArgs e)
        {
            pcalculator.Controls.Add(calc);
            pcalculator.BringToFront();
            calc.Answer = float.Parse(amountbt.Text);
            pcalculator.Visible = true;
            pamount.Enabled = ptime.Enabled = ptype.Enabled = prate.Enabled = pbutton.Enabled = presult.Enabled = calculatebt.Enabled = false;
            calc.CalculatorClosed += OnCalculatorClosed;
        }

        private void OnAmount1btClick(object sender, EventArgs e)
        {
            pcalculator1.Controls.Add(calc);
            pcalculator1.BringToFront();
            calc.Answer = float.Parse(amountbt1.Text);
            pcalculator1.Visible = true;
            pamount1.Enabled = ptime1.Enabled = ptype1.Enabled = pcompound1.Enabled = prate1.Enabled = pbutton.Enabled = presult1.Enabled = calculate1bt.Enabled = false;
            calc.CalculatorClosed += OnCalculatorClosed;
        }

        private void OnCalculatorClosed(object sender, bool closed)
        {
            if (TabControl.SelectedTab == SItb)
            {
                amountbt.Text = calc.Answer.ToString();
                pcalculator.Visible = false;
                pamount.Enabled = ptime.Enabled = ptype.Enabled = prate.Enabled = pbutton.Enabled = presult.Enabled = calculatebt.Enabled = true;
                calc.CalculatorClosed -= OnCalculatorClosed;
            }
            else
            {
                amountbt1.Text = calc.Answer.ToString();
                pcalculator1.Visible = false;
                pamount1.Enabled = ptime1.Enabled = ptype1.Enabled = pcompound1.Enabled = prate1.Enabled = pbutton.Enabled = presult1.Enabled = calculate1bt.Enabled = true;
                calc.CalculatorClosed -= OnCalculatorClosed;
            }
        }

        private void OnCalculatebtClick(object sender, EventArgs e)
        {
            if (CheckAmount(amountbt.Text,pamount) == true && CheckRate(ratetb.Text,prate) == true && CheckTime(timetb.Text,ptime) == true)
            {
                float principal = float.Parse(amountbt.Text);
                float rate = float.Parse(ratetb.Text);
                float time = TransactionEditor.FindTime(float.Parse(timetb.Text), typecb.Text);
                float answer = (principal * time * rate) / 100;
                pamountas.Text = "₹ "+principal.ToString("F2");
                iamountas.Text = "₹ " + answer.ToString("F2");
                tamountas.Text = "₹ " + (principal + answer).ToString("F2");
                if (pamountas.Text.Length > 18 || pamountac.Text == "₹ ∞")
                {
                    pamountas.Text = "Infinity";
                }
                if (iamountas.Text.Length > 18 || pamountac.Text == "₹ ∞")
                {
                    iamountas.Text = "Infinity";
                }
                if (tamountas.Text.Length > 18 || pamountac.Text == "₹ ∞")
                {
                    tamountas.Text = "Infinity";
                }
            }
        }

        private void OnCalculate1btClick(object sender, EventArgs e)
        {
            if (CheckAmount(amountbt1.Text,pamount1) == true && CheckRate(ratetb1.Text,prate1) == true && CheckTime(timetb1.Text,ptime1) == true)
            {
                float principal = float.Parse(amountbt1.Text);
                float rate = (float.Parse(ratetb1.Text))/100;
                float time = TransactionEditor.FindTime(float.Parse(timetb1.Text), typecb1.Text);
                double answer = TransactionEditor.FindAnswer(principal, rate, time, compoundcb1.Text);
                pamountac.Text = "₹ " + principal.ToString("F2");
                iamountac.Text = "₹ " + answer.ToString("F2");
                tamountac.Text = "₹ " + (principal + answer).ToString("F2");
                if (pamountac.Text.Length > 18 || pamountac.Text== "₹ ∞")
                {
                    pamountac.Text = "Infinity";
                }
                if (iamountac.Text.Length > 18 || iamountac.Text == "₹ ∞")
                {
                    iamountac.Text = "Infinity";
                }
                if (tamountac.Text.Length > 18 || tamountac.Text == "₹ ∞")
                {
                    tamountac.Text = "Infinity";
                }
            }
        }

        //Validate Functions

        private bool CheckAmount(string amt, Control control)
        {
            if (amt.Length > 0)
            {
                ErrorProvider.SetError(control, "");
                return true;
            }
            ErrorProvider.SetError(control, "Amount is required");
            return false;
        }

        private bool CheckRate(string rate, Control control)
        {
            if (rate == "." || float.Parse(rate) == 0)
            {
                ErrorProvider.SetError(control, "Invalid Data");
                return false;
            }
            else if (rate.Length > 0)
            {
                ErrorProvider.SetError(control, "");
                return true;
            }
            ErrorProvider.SetError(control, "Interest is required");
            return false;
        }

        private bool CheckTime(string time, Control control)
        {
            if (time == "." || float.Parse(time) == 0)
            {
                ErrorProvider.SetError(control, "Invalid Data");
                return false;
            }
            else if (time.Length > 0)
            {
                ErrorProvider.SetError(control, "");
                return true;
            }
            ErrorProvider.SetError(control, "Period Value is required");
            return false;
        }

        private bool CheckDot(string rate)
        {
            for (int i = 0; i < rate.Length; i++)
            {
                if (rate[i] == '.')
                {
                    return false;
                }
            }
            return true;
        }

        //KeyPress Events

        private void OnCloseBtClick(object sender, EventArgs e)
        {
            InterestCalculatorClosed?.Invoke(sender, e);
        }

        private void OnRateKeyPress(object sender, KeyPressEventArgs e)
        {
            bool result = RateTimeKeyPress(e.KeyChar, ratetb);
            if (result == false)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void OnRateKeyPress1(object sender, KeyPressEventArgs e)
        {
            bool result = RateTimeKeyPress(e.KeyChar, ratetb1);
            if (result == false)
            {
                e.Handled = false;
            }
            else 
            {
                e.Handled = true;
            }
        }

        private void OnTimeKeyPress1(object sender, KeyPressEventArgs e)
        {
            bool result = RateTimeKeyPress(e.KeyChar, timetb1);
            if (result == false)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void OnTimeKeyPress(object sender, KeyPressEventArgs e)
        {
            bool result = RateTimeKeyPress(e.KeyChar, timetb);
            if (result == false)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private bool RateTimeKeyPress(char e, Control control)
        {
            if ((e >= 48 && e <= 57) || e == (char)8)
            {
                return false;
            }
            else if (e == (char)46)
            {
                if (CheckDot(control.Text) == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
    }
}
