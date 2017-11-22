using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class TransactionModel
    {
        public int TransactionID { get; set; }
        public System.DateTime TransactionTime { get; set; }
        public int AccountID { get; set; }
    }
}
