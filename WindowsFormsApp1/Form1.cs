// WindowsFormsApp1

namespace WindowsFormsApp1
{
    #region Using Directives
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using ClassLibrary1;
    using Microsoft.Win32;
    #endregion

    public partial class Form1 : Form
    {
        #region Constants
        internal const int BCM_SETSHIELD = 5644;

        const string BoundsRegistryKey  = @"HKEY_CURRENT_USER\Software\BeltTest";
        const string BoundsRegistryName = "Form1Location";
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

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            var bounds = WindowState == FormWindowState.Normal ? DesktopBounds : RestoreBounds;
            var value  = string.Join(",", (int) WindowState, bounds.X, bounds.Y, bounds.Width, bounds.Height);
            Registry.SetValue(BoundsRegistryKey, BoundsRegistryName, value, RegistryValueKind.String);
        }

        protected override void OnLoad(EventArgs e)
        {
            // Get the last form location and size from the registry, and position the form in the same place
            var value = (string) Registry.GetValue(BoundsRegistryKey, BoundsRegistryName, null);
            var split = value?.Split(',');

            if (split?.Length == 5)
            {
                var numbers = split.Select(int.Parse).ToArray();

                DesktopBounds = new Rectangle(numbers[1], numbers[2], numbers[3], numbers[4]);
                WindowState   = (FormWindowState) numbers[0];
            }

            base.OnLoad(e);
        }
    }
}