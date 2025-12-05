// WindowsFormsApp1

namespace WindowsFormsApp1
{
    #region Using Directives
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using ClassLibrary1;
    #endregion

    public partial class Form1 : Form
    {
        #region Constants
        internal const int BCM_SETSHIELD = 5644;
        #endregion

        #region Constructors
        public Form1()
        {
            InitializeComponent();

            // Ensure the button is drawn by the system so BCM_SETSHIELD can show the shield
            SaveButton.FlatStyle = FlatStyle.System;

            AddShieldToSaveButton();
            EditionValue.Text  = Class1.GetEdition();
            CustomerValue.Text = Class1.GetCustomer();
        }
        #endregion

        [DllImport("user32")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        void AddShieldToSaveButton() => SendMessage(SaveButton.Handle, BCM_SETSHIELD, IntPtr.Zero, new IntPtr(1));

        void Save_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(CustomerValue.Text))
            {
                var executable = typeof(Form1).Assembly.Location;
                var startInfo  = new ProcessStartInfo(executable, $"-customer \"{CustomerValue.Text}\"") {UseShellExecute = true, Verb = "runas"};
                using (var process = Process.Start(startInfo))
                {
                    process.WaitForExit();
                    if (process.ExitCode == 0)
                    {
                        CustomerValue.Text = Class1.GetCustomer();
                    }
                    else
                    {
                        MessageBox.Show($"Something went wrong; Error code {process.ExitCode}");
                    }
                }
            }
        }
    }
}