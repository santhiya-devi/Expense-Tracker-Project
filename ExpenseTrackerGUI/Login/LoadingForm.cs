using System.Windows.Forms;

namespace ExpenseTrackerGUI
{
    public partial class LoadingForm : Form
    {
        public LoadingForm()
        {
            InitializeComponent();
            loginLoad1.LoadColor = GUIStyles.primaryColor;
            GUIStyles.ColorChanged += OnColorChanged;
        }

        private void OnColorChanged(bool e)
        {
            loginLoad1.LoadColor = GUIStyles.primaryColor;
        }
    }
}
