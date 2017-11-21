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
