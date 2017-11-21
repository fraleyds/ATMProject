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
            var foo = new CustomerService();
            foo.CreateCustomer("Soprano", "Tony");

        }
    }
}
