using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class AccountService
    {
        // Methods

        private Accounts AccountByNumber(Bank_LibraryEntities context, int numberInput)
        {

        }
            
        public void AccountLogin(int numberInput, int pinInput)
        {
            using (var context = new Bank_LibraryEntities())
            {

            }
        }

        public bool CreateAccount(int custId, int acctNum, string type, int pin, Nullable<decimal> balance, string lastName, string firstName)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var newAccount =
                    new Accounts
                    {
                        CustomerID = custId,
                        AccountNum = acctNum,
                        AccountType = type,
                        PIN = pin,
                        Balance = balance,
                        LastName2 = lastName,
                        FirstName2 = firstName
                    };
                context.Accounts.Add(newAccount);

                return context.SaveChanges() == 1;
            }
        }
    }
}
