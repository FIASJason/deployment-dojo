// ConsoleApp1

namespace ConsoleApp1
{
    #region Using Directives
    using System;
    using System.IO;
    using System.Threading;
    using ClassLibrary1;
    using Microsoft.Win32;
    #endregion

    internal class Program
    {

        static void Main(string[] args)
        {
            var edition  = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Edition",  null);
            var customer = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\BeltTest", "Customer", null);

            Console.WriteLine($"Welcome to the {edition} ConsoleApp1.");
            Console.WriteLine($"  Registered to our {customer} customer");

            // Episode 25 - Reading from the Service's Output File
            // Epidose 31 - Merge the methods from the service and console app into a Library
            var path    = Class1.GetCountFilePath();
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