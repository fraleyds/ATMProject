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

        public AccountModel Login(int numberInput, int pinInput)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var loginSession = LoginBack(context, numberInput, pinInput);
                if (loginSession == null)
                {
                    return null;
                }
                Console.WriteLine("You logged in!");
                return new AccountModel
                {
                    AccountID = loginSession.AccountID,
                    CustomerID = loginSession.CustomerID,
                    AccountNum = loginSession.AccountNum,
                    AccountType = loginSession.AccountType,
                    PIN = loginSession.PIN,
                    Balance = loginSession.Balance,
                    LastName2 = loginSession.LastName2,
                    FirstName2 = loginSession.FirstName2
                };
            }
        }
        
        private Accounts LoginBack(Bank_LibraryEntities context, int numberInput, int pinInput)
        {
            return
                context
                    .Accounts
                    .SingleOrDefault(e => e.AccountNum == numberInput && e.PIN == pinInput);
        }

        private IEnumerable<AccountModel> GetAccount(Bank_LibraryEntities ctx, int numberInput)
        {
            return
                ctx
                    .Accounts
                    .Where(e => e.AccountNum == numberInput)
                    .Select(
                        e =>
                            new AccountModel
                            {
                                AccountID = e.AccountID,
                                CustomerID = e.CustomerID,
                                AccountNum = e.AccountNum,
                                AccountType = e.AccountType,
                                PIN = e.PIN,
                                Balance = e.Balance,
                                LastName2 = e.LastName2,
                                FirstName2 = e.FirstName2
                            })
                    .ToArray();
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

        public bool DepositToAccount(Bank_LibraryEntities context, AccountModel account, Nullable<decimal> amount)
        {
            Accounts realAccount;

            realAccount =
                context
                    .Accounts
                    .SingleOrDefault(e => e.AccountID == account.AccountID);

            if (realAccount == null) return false;
            realAccount.Balance = realAccount.Balance + amount;

            return context.SaveChanges() == 1;
        }
    }
}
