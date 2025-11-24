// ConsoleApp1

namespace ConsoleApp1
{
    #region Using Directives
    using System;
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
        }
    }
}