using Bank.Models;
using Bank.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.ATMConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Cool Bank . . .\n\n" +
                "Enter Account Number:");
            var account = Int32.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter PIN:");
            var pinInput = Int32.Parse(Console.ReadLine());


        }
    }
}
