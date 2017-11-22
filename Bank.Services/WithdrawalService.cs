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
        public IEnumerable<WithdrawalModel> GetWithdrawals(int transactionId)
        {
            using (var context = new Bank_LibraryEntities())
            {
                return
                    context
                        .Withdrawals
                        .Where(e => e.TransactionID == transactionId)
                        .Select(
                            e =>
                                new WithdrawalModel
                                {
                                    TransactionID = e.TransactionID,
                                    Amount = e.Amount,
                                    WithdrawalID = e.WithdrawalID
                                })
                        .ToArray();
            }
        }


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
