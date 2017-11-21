using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class CustomerService
    {
        public bool CreateCustomer(string lastName, string firstName)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var newCustomer =
                    new Customers
                    {
                        LastName = lastName,
                        FirstName = firstName
                    };
                context.Customers.Add(newCustomer);

                return context.SaveChanges() == 1;
            }
        }
    }
}
