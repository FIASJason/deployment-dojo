// ClassLibrary1

namespace ClassLibrary1
{
    #region Using Directives
    using System;
    using System.IO;
    using Microsoft.Win32;
    #endregion

    public class Class1
    {
        #region Fields
        static string _path;
        #endregion

        public static string GetCountFilePath()
        {
            if (!string.IsNullOrWhiteSpace(_path))
            {
                return _path;
            }

            var folder   = string.Empty;
            var filename = string.Empty;

            try
            {
                folder = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFileFolder", null) as string ?? AppContext.BaseDirectory;
            }
            catch (Exception)
            {
                // ignored
            }

            try
            {
                filename = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFileName", null) as string ?? "WindowsService1.txt";
            }
            catch (Exception)
            {
                // ignored
            }

            folder = Path.GetFullPath(folder);
            Directory.CreateDirectory(folder);
            _path = Path.Combine(folder, filename);

            return _path;
        }

        public static string GetCustomer() => (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null) ?? "Default";

        public static string GetEdition() => (string) Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition", null) ?? "Default";

        public static void SetCustomer(string customer) => Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", customer);
    }
}