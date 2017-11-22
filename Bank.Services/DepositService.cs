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
        public IEnumerable<DepositModel> GetDeposits(int transactionId)
        {
            using (var context = new Bank_LibraryEntities())
            {
                return
                    context
                        .Deposits
                        .Where(e => e.TransactionID == transactionId)
                        .Select(
                            e =>
                                new DepositModel
                                {
                                    TransactionID = e.TransactionID,
                                    Amount = e.Amount,
                                    DepositID = e.DepositID
                                })
                        .ToArray();
            }
        }


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
