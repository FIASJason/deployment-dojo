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
            var type = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Dojo", "Type", "Unknown");
            Console.WriteLine($"Welcome to the {type} ConsoleApp1.");
            Console.ReadKey();
        }
    }
}