// ConsoleApp1

namespace ConsoleApp1
{
    #region Using Directives
    using System;
    using System.IO;
    using System.Threading;
    using Microsoft.Win32;
    #endregion

    internal class Program
    {
        static string GetCountFilePath()
        {
            try
            {
                var path = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "CountFilePath", null) as string;

                return Path.GetFullPath(path);
            }
            catch
            {
                // ignored
            }

            return Path.Combine(AppContext.BaseDirectory, "WindowsService1.txt");
        }

        static void Main(string[] args)
        {
            var edition  = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition",  null);
            var customer = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null);

            Console.WriteLine($"Welcome to the {edition} ConsoleApp1.");
            Console.WriteLine($"  Registered to our {customer} customer");

            // Episode 25 - Reading from the Service's Output File
            var path    = GetCountFilePath();
            var oldText = string.Empty;

            while (!Console.KeyAvailable)
            {
                string text;

                try
                {
                    text = File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    text = e.Message;
                }

                if (text != oldText)
                {
                    Console.WriteLine(text);
                    oldText = text;
                }

                Thread.Sleep(1000);
            }
        }
    }
}