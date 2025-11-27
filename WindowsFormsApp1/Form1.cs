// WindowsFormsApp1

namespace WindowsFormsApp1
{
    #region Using Directives
    using System.Windows.Forms;
    using ClassLibrary1;
    #endregion

    public partial class Form1 : Form
    {
        #region Constructors
        public Form1()
        {
            InitializeComponent();

            EditionValue.Text  = Class1.GetEdition();
            CustomerValue.Text = Class1.GetCustomer();
        }
        #endregion
    }
}