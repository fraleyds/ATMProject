using Bank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Services
{
    public class TransactionService
    {
        public IEnumerable<TransactionModel> GetTransactions(int accountId)
        {
            using (var context = new Bank_LibraryEntities())
            {
                return
                    context
                        .Transactions
                        .Where(e => e.AccountID == accountId)
                        .Select(
                            e =>
                                new TransactionModel
                                {
                                    TransactionID = e.TransactionID,
                                    TransactionTime = e.TransactionTime,
                                    AccountID = e.AccountID
                                })
                        .ToArray();                               
            }
        }

        public void GetInteractions(int accountId)
        {
            DepositService dServe = new DepositService();
            WithdrawalService wServe = new WithdrawalService();
            IEnumerable<InteractionModel> deposit = null;
            IEnumerable<InteractionModel> withdrawal = null;

            var transaction = GetTransactions(accountId);
            foreach (var t in transaction)
            {
                deposit = dServe.GetDeposits(t.TransactionID);
            }
            foreach (var t in transaction)
            {
                withdrawal = wServe.GetWithdrawals(t.TransactionID);
                foreach (var value in withdrawal)
                {
                    value.Amount = value.Amount * (-1);
                }
            }

            var transList = deposit.Concat(withdrawal);
            var sortedList = transList.OrderBy(e => e.TransactionID);

            using (var context = new Bank_LibraryEntities())
            {
                foreach (var listItem in sortedList)
                {
                    var transact =
                        context
                            .Transactions
                            .SingleOrDefault(e => e.TransactionID == listItem.TransactionID);

                    Console.WriteLine($"{transact.TransactionTime} {listItem.Amount}");
                }
            }
        }

        public bool CreateTransaction(DateTime transactionDateTime)
        {
            using (var context = new Bank_LibraryEntities())
            {
                var newTransaction =
                    new Transactions
                    {
                        TransactionTime = transactionDateTime
                    };
                context.Transactions.Add(newTransaction);

                return context.SaveChanges() == 1;
            }
        }
    }
}
