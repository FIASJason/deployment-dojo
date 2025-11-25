// WindowsFormsApp1

namespace WindowsFormsApp1
{
    #region Using Directives
    using System.Windows.Forms;
    using Microsoft.Win32;
    #endregion

    public partial class Form1 : Form
    {
        #region Constructors
        public Form1()
        {
            InitializeComponent();

            EditionValue.Text  = Registry.GetValue(@"HKEY_LOCAL_MACHINE\software\BeltTest", "Edition",  "")?.ToString();
            CustomerValue.Text = Registry.GetValue(@"HKEY_LOCAL_MACHINE\software\BeltTest", "Customer", "")?.ToString();
        }
        #endregion
    }
}