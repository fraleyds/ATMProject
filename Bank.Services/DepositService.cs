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


        public bool CreateDeposit(AccountModel account, Nullable<decimal> amount, int transactionId)
        {
            var acctService = new AccountService();
            using (var context = new Bank_LibraryEntities())
            {
                var newDeposit =
                    new Deposits
                    {
                        Amount = amount,
                        TransactionID = transactionId
                    };
                context.Deposits.Add(newDeposit);

                acctService.DepositToAccount(context, account, amount);

                return context.SaveChanges() == 1;
            }
        }
    }
}
