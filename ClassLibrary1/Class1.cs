using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        private static string _path;
        public static string GetCountFilePath()
        {
            try
            {
                var path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFilePath", null) as string;

                _path = Path.GetFullPath(path);
            }
            catch (Exception)
            {
                // ignored
            }

            if (string.IsNullOrEmpty(_path))
            {
                _path = Path.Combine(AppContext.BaseDirectory, "WindowsService1.txt");
            }

            Directory.CreateDirectory(Path.GetDirectoryName(_path) ?? Path.GetTempPath());
            return _path;
        }

    }
}
