// WindowsFormsApp1

namespace WindowsFormsApp1
{
    #region Using Directives
    using System;
    using System.Windows.Forms;
    using ClassLibrary1;
    #endregion

    internal static class Program
    {
        static int HandleConfiguration(string[] args)
        {
            if (args.Length != 2 || args[0] != "-customer" || string.IsNullOrWhiteSpace(args[1]))
            {
                return -1;
            }

            try
            {
                Class1.SetCustomer(args[1]);

                return 0;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -2;
            }
        }

        /// <summary>
        ///     The main entry point for the application.
        /// </summary>
        [STAThread]
        static int Main(string[] args)
        {
            if (args.Length > 0)
            {
                return HandleConfiguration(args);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            return 0;
        }
    }
}