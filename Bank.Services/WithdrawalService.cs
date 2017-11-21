using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class WithdrawalService
    {
        public bool CreateWithdrawal(Nullable<decimal> amount, int transactionId)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var newWithdrawal =
                    new Withdrawals
                    {
                        Amount = amount,
                        TransactionID = transactionId
                    };
                context.Withdrawals.Add(newWithdrawal);

                return context.SaveChanges() == 1;
            }
        }
    }
}
