// ConsoleApp1

namespace ConsoleApp1
{
    #region Using Directives
    using System;
    using System.IO;
    using System.Threading;
    using ClassLibrary1;
    #endregion

    internal class Program
    {
        static void Main(string[] args)
        {
            // Episode 33: Use Class Library to get Edition and Customer
            var edition  = Class1.GetEdition();
            var customer = Class1.GetCustomer();

            Console.WriteLine($"Welcome to the {edition} ConsoleApp1.");
            Console.WriteLine($"  Registered to our {customer} customer");

            // Episode 25 - Reading from the Service's Output File
            // Episode 31 - Merge the methods from the service and console app into a Library
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