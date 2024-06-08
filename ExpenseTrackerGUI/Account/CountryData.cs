using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseTrackerDS;

namespace ExpenseTrackerGUI
{
    public partial class CountryData : UserControl
    {
        public CountryData()
        {
            InitializeComponent();
        }

        //Event Creation
        public delegate void CountrySelection(object sender, Country e);
        public event CountrySelection CountrySelected;
        Dictionary<string, string> symbol = new Dictionary<string, string>();

        //Preoperty Creation

        Country pcountry=new Country();

        public Country Pcountry
        {
            get => pcountry;
            set
            {
                pcountry = value;
                if (symbol.Count < 35)
                {
                    AddSymbol();
                }
                namelb.Text = pcountry.Name;
                foreach(var sym in symbol)
                {
                    if (sym.Key == pcountry.Name)
                    {
                        symbollb.Text = sym.Value;
                        pcountry.Symbol = sym.Value;
                        break;
                    }
                }
                flagpb.BackgroundImage = new Bitmap(@".\\Images\\" + pcountry.Flag);
            }
        }

        //Load Function

        private void OnCurrencyDataLoad(object sender, EventArgs e)
        {
            GUIStyles.ColorChanged += OnGUIStylesColorChanged;
        }

        private void OnGUIStylesColorChanged(bool e)
        {
            symbollb.ForeColor = namelb.ForeColor = GUIStyles.blackColor;
        }

        private void AddSymbol()
        {
            symbol.Add("Australia", "$");
            symbol.Add("Brazil", "R$");
            symbol.Add("Bulgaria", "$");
            symbol.Add("Canada", "$");
            symbol.Add("China", "¥");
            symbol.Add("Colombia", "$");
            symbol.Add("Egypt", "£");
            symbol.Add("Ethiopia", "$");
            symbol.Add("HongKong", "$");
            symbol.Add("Hungary", "$");
            symbol.Add("India", "₹");
            symbol.Add("Indonesia", "$");
            symbol.Add("Iraq", "$");
            symbol.Add("Italy", "$");
            symbol.Add("Jamaica", "$");
            symbol.Add("Japan", "¥");
            symbol.Add("Kenya", "$");
            symbol.Add("Kuwait", "$");
            symbol.Add("Malaysia", "RM");
            symbol.Add("Mexico", "$");
            symbol.Add("Maldives", "Rf");
            symbol.Add("Nepal", "₨");
            symbol.Add("Netherlands", "$");
            symbol.Add("New Zealand", "$");
            symbol.Add("Nigeria", "$");
            symbol.Add("North Korea", "₩");
            symbol.Add("Pakistan", "₨");
            symbol.Add("Philipines", "$");
            symbol.Add("Russia", "₽");
            symbol.Add("Saudi Arabia", "﷼");
            symbol.Add("Singapore", "$");
            symbol.Add("South Africa", "R");
            symbol.Add("Sri Lanka", "₨");
            symbol.Add("Turkey", "$");
            symbol.Add("Thailand", "$");
            symbol.Add("Ukraine", "$");
            symbol.Add("United Kingdom", "£");
            symbol.Add("United States", "$");
            symbol.Add("Vietnam", "$");
            symbol.Add("Zambia", "ZK");
        }

        //Button Functions

        private void OnCountryDataClick(object sender, EventArgs e)
        {
            CountrySelected?.Invoke(sender, pcountry);
        }

        //Mouse Enter Events

        private void OnCountryDataMouseEnter(object sender, EventArgs e)
        {
            pback.BackColor = GUIStyles.terenaryColor;
        }

        private void OnCountryDataMouseLeave(object sender, EventArgs e)
        {
            pback.BackColor = GUIStyles.whiteColor;
        }
    }
}
