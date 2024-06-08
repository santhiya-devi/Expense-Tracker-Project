using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseTracker
{
    internal class PlaceHolderTextBox:TextBox
    {
        public PlaceHolderTextBox()
        {
            TextChanged += PlaceHolderTextBox_TextChanged;
        }

        private string placeHolderText="";

        private Color tempForColor=Color.Black;

        public bool isPlaceholder = false;

        public Color PlaceHolderColor { get; set; } = Color.FromArgb(97, 97, 97);

        public string PlaceHolderText
        {
            get
            {
                return placeHolderText;
            }
            set
            {
                Text = value;
                placeHolderText = value;
                isPlaceholder= true;
            }
        }

        public bool IsPassword { set; get; }

        public void OnLostFocusMethod()
        {
            OnLostFocus(EventArgs.Empty);
        }

        public override Color ForeColor {
            get 
            { 
                return base.ForeColor;
            }  
            set {
                base.ForeColor = value;
                if(value != PlaceHolderColor) 
                tempForColor = value;
            }
        }
        
        protected override void OnGotFocus(EventArgs e)
        {
          
                    if (Text == PlaceHolderText)
                    {
                        
                        if (IsPassword)
                            PasswordChar = '*';
                        Text = "";
                        ForeColor = tempForColor;
                isPlaceholder= false;
                    }

                
            base.OnGotFocus(e);

        }

        protected override void OnLostFocus(EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(Text))
            {
                if (IsPassword)
                    PasswordChar = '\0';
                ForeColor = PlaceHolderColor;
                Text = PlaceHolderText;
                isPlaceholder = true;


            }   
            base.OnLostFocus(e);
        }

        private void PlaceHolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Text ==null)
            {
                OnLostFocus(EventArgs.Empty);
            }
        }
    }
}
