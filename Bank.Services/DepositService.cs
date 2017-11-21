using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class DepositService
    {
        public bool CreateDeposit(Nullable<decimal> amount, int transactionId)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var newDeposit =
                    new Deposits
                    {
                        Amount = amount,
                        TransactionID = transactionId
                    };
                context.Deposits.Add(newDeposit);

                return context.SaveChanges() == 1;
            }
        }
    }
}
