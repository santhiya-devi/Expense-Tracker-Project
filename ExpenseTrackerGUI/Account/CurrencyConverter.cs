using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ExpenseTrackerDS;
using System.Net;
using ExpenseTracker;
using Newtonsoft.Json;

namespace ExpenseTrackerGUI
{
    public partial class CurrencyConverter : UserControl
    { 
        public CurrencyConverter()
        {
            InitializeComponent();
        }

        //Event

        public event EventHandler CurrencyConverterClosed;

        //Paint Operation

        private void OnPBottomPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.backColor, pbottom.Width, pbottom.Height, 10, 10);
        }

        private void OnPCurrencyPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.blackColor, GUIStyles.whiteColor, pcb1.Width, pcb2.Height, 3, 5);
        }

        private void OnpdataPaint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e); DoubleBuffered = true;
            TransactionEditor.PaintOperation(sender, e, GUIStyles.primaryColor, GUIStyles.whiteColor, pdata.Width, pdata.Height, 6, 5);
        }

        //Variable Initialization

        private const string API_URL = "https://open.er-api.com/v6/latest/";
        int locy = 0, locx = 5, type = 0;
        Country cdata1, cdata2;
        static string amt1 = "1.0", amt2 = "1.0";
        static bool status = false, process = false;
        List<Country> licountry = new List<Country>();
        List<CountryData> lidata = new List<CountryData>();

        //Load Operation

        private void OnCurrencyConverterLoad(object sender, EventArgs e)
        {
            ActiveControl = Calculatebt;
            pchoose.Size = new Size(263, 221);
            licountry=Communicator.Manager.FetchCurrency();
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
            if (licountry.Count > 0)
            {
                AddData();
            }
            //Timer.Start();
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            AddColor(); ChangeImage();
        }

        private void AddColor()
        {
            pbottom.Invalidate();pcb1.Invalidate();pcb2.Invalidate();
            pfillback.BackColor = GUIStyles.primaryColor;
            Calculatebt.BackColor = GUIStyles.whiteColor;
            Calculatebt.FlatAppearance.MouseOverBackColor = GUIStyles.cardColor;
            Calculatebt.FlatAppearance.MouseDownBackColor = GUIStyles.backColor;
            phead.BackColor = pleft.BackColor = pright.BackColor = pdown.BackColor = ptop.BackColor = GUIStyles.primaryColor;
            amtlb.ForeColor = amttolb.ForeColor = currencylb.ForeColor = currencytb.ForeColor = symb1.ForeColor = symb2.ForeColor = GUIStyles.blackColor;
            onelb.ForeColor = amountlb.ForeColor = updatedlb.ForeColor = updatedtimelb.ForeColor = GUIStyles.blackColor;            
        }

        private void ChangeImage()
        {
            if (GUIStyles.colorName == "blue")
            {
                converterpb.BackgroundImage = Image.FromFile(@".\Images\countrytoblue.png");
            }
            else if (GUIStyles.colorName == "red")
            {
                converterpb.BackgroundImage = Image.FromFile(@".\Images\countrytored.png");
            }
            else if (GUIStyles.colorName == "orange")
            {
                converterpb.BackgroundImage = Image.FromFile(@".\Images\countrytoorange.png");
            }
            else if (GUIStyles.colorName == "pink")
            {
                converterpb.BackgroundImage = Image.FromFile(@".\Images\countrytopink.png");
            }
            else
            {
                converterpb.BackgroundImage = Image.FromFile(@".\Images\countrytoblack.png");
            }
        }

        //Add Data

        private void AddData()
        {
            for (int i = 0; i < licountry.Count; i++)
            {
                CountryData cd = new CountryData
                {
                    Pcountry = licountry[i],
                    Location = new Point(locx, locy)
                };
                cd.CountrySelected += OnCountryDataSelected;
                locy += cd.Height;
                pmain.Controls.Add(cd);
                lidata.Add(cd);
                if (licountry[i].Name == "India")
                {
                    cdata2 = licountry[i];
                }
                if (licountry[i].Name == "United States")
                {
                    cdata1 = licountry[i];
                }
            }
            if (licountry.Count > 0)
            {
                EditData();
            }
        }

        //Update Data

        public void CurrencyMain(string basecurrency, string convertcurrency, int amt)
        {
            try
            {
                string baseCurrency = basecurrency;
                string targetCurrency = convertcurrency;
                string apiUrl = $"{API_URL}{baseCurrency}";
                string jsonResponse;

                using (WebClient webClient = new WebClient())
                {
                    jsonResponse = webClient.DownloadString(apiUrl);
                }

                dynamic data = JsonConvert.DeserializeObject(jsonResponse);

                decimal exchangeRate = data.rates[targetCurrency];
                status = true;
                Console.WriteLine($"1 {baseCurrency} = {exchangeRate} {targetCurrency}");
                if (amt == 1)
                    amt1 = exchangeRate.ToString();
                else
                    amt2 = exchangeRate.ToString();

            }
            catch (Exception ex)
            {
                status = false;
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private void AddCountry()
        {
            for (int i = 0; i < lidata.Count; i++)
            {
                if (lidata.Count > i)
                {
                    CurrencyMain(licountry[i].Currency, "INR", 1);
                    if (licountry.Count > i)
                        CurrencyMain("INR", licountry[i].Currency, 2);
                    if (licountry.Count > i && status == true)
                    {
                        licountry[i].AmountOthertoIndia = float.Parse(amt1);
                        licountry[i].AmountIndiatoOther = float.Parse(amt2);
                        Communicator.Manager.EditData(licountry[i]);
                    }
                    else
                        break;
                }
                else
                    break;
            }
            process = false;
            Refreshlb.Enabled = pcb1.Enabled = pcb2.Enabled = Closepb.Enabled = Calculatebt.Enabled = pdata.Enabled = true;
            this.Cursor = Cursors.Default;
            UpdateData();
        }

        //Country selected

        private void OnCountryDataSelected(object sender, Country e)
        {
            if (type == 0)
            {
                if (e == cdata2)
                {
                    cdata2 = cdata1;
                }
                cdata1 = e;
            }
            else if (type == 1)
            {
                if (e == cdata1)
                {
                    cdata1 = cdata2;
                }
                cdata2 = e;
            }
            EditData();
            pchoose.Visible = false;
            Refreshlb.Enabled = pcb1.Enabled = pcb2.Enabled = Closepb.Enabled = Calculatebt.Enabled = pdata.Enabled = true;
        }

        private void OnBackClick(object sender, EventArgs e)
        {
            pchoose.Visible = false;
            Refreshlb.Enabled = pcb1.Enabled = pcb2.Enabled = Closepb.Enabled = Calculatebt.Enabled = pdata.Enabled = true;
        }

        private void OnSelectCountry1Click(object sender, EventArgs e)
        {
            type = 0;
            pchoose.Location = new Point(pcb1.Location.X, pcb1.Location.Y + pcb1.Height + 1);
            SelectCountry();
        }

        private void OnSelectCountry2Click(object sender, EventArgs e)
        {
            type = 1;
            pchoose.Location = new Point(pcb2.Location.X, pcb2.Location.Y + pcb2.Height + 1);
            SelectCountry();
        }

        private void SelectCountry()
        {
            Refreshlb.Enabled = pcb1.Enabled = pcb2.Enabled = Closepb.Enabled = Calculatebt.Enabled = pdata.Enabled = false;
            pchoose.Visible = true;
        }

        //Calculate

        private void OnCalculateBtClick(object sender, EventArgs e)
        {
            CheckInputCurrency();
            if (cdata1 != null && cdata2 != null)
            {
                currencylb.Text = ((float.Parse(currencytb.Text)) * cdata1.AmountOthertoIndia * cdata2.AmountIndiatoOther).ToString("F4");
            }
        }

        private void OnClosePbClick(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
            CurrencyConverterClosed?.Invoke(sender, e);
        }

        private void OnCurrencyVisibilityChanged(object sender, EventArgs e)
        {
            AddColor();
        }

        //Refresh Values

        private void OnRefreshlbClick(object sender, EventArgs e)
        {
            if (process == false)
            {
                process = true;
                Refreshlb.Enabled = pcb1.Enabled = pcb2.Enabled = Closepb.Enabled = Calculatebt.Enabled = pdata.Enabled = false;
                this.Cursor = Cursors.WaitCursor;
                AddCountry();
            }
        }

        //Update Values

        private void CheckInputCurrency()
        {
            if (currencytb.TextLength == 0 || currencytb.Text == "." || float.Parse(currencytb.Text) == 0)
            {
                currencytb.Text = "1";
                currencytb.SelectionStart = currencytb.TextLength;
            }
        }

        private void EditData()
        {
            if (cdata1 != null && cdata2 != null)
            {
                flagpb1.BackgroundImage = new Bitmap(@".\\Images\\" + cdata1.Flag);
                symb1.Text = cdata1.Symbol; symbollb1.Text = cdata1.Currency;
                flagpb2.BackgroundImage = new Bitmap(@".\\Images\\" + cdata2.Flag);
                symb2.Text = cdata2.Symbol; symbollb2.Text = cdata2.Currency;
                CheckInputCurrency();
                currencylb.Text = ((float.Parse(currencytb.Text)) * cdata1.AmountOthertoIndia * cdata2.AmountIndiatoOther).ToString("F4");
                amountlb.Text = (cdata1.AmountOthertoIndia * cdata2.AmountIndiatoOther).ToString("F3");
                updatedtimelb.Text = cdata1.Updated_Time.ToString();
            }
        }

        private void UpdateData()
        {
            licountry = Communicator.Manager.FetchCurrency();
            for(int i = 0; i < lidata.Count; i++)
            {
                lidata[i].Pcountry = licountry[i];
                if (licountry[i].Name == cdata1.Name)
                {
                    cdata1 = licountry[i];
                }
                if (licountry[i].Name == cdata2.Name)
                {
                    cdata2 = licountry[i];
                }
            }
            EditData();
        }
        
        //Input KeyPress 

        private void OnCurrencyInputKeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 48 && e.KeyChar <= 57) || e.KeyChar == (char)8)
            {
                e.Handled = false;
            }
            else if (e.KeyChar == (char)46)
            {
                string s = currencytb.Text;
                for(int i = 0; i < s.Length; i++)
                {
                    if (s[i] == '.')
                    {
                        e.Handled = true;
                        return;
                    }
                }
                e.Handled = false;
            }
            else if (e.KeyChar == (char)13)
            {
                OnCalculateBtClick(sender, EventArgs.Empty);
                e.Handled = true;
            }
            else
            {
                e.Handled = true;
            }
        }
    }
}
