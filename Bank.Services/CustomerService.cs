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
        public CustomerModel CustomerById(int custId)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var newCustomer = CustomerById(context, custId);
                if (newCustomer == null)
                {
                    return null;
                }
                return new CustomerModel
                {
                    CustomerID = newCustomer.CustomerID,
                    FirstName = newCustomer.FirstName,
                    LastName = newCustomer.LastName
                };
            }
        }

        private Customers CustomerById(Bank_LibraryEntities context, int custId)
        {
            return
                context
                    .Customers
                    .SingleOrDefault(e => e.CustomerID == custId);
        }


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
