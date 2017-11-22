using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class AccountModel
    {
        public int AccountID { get; set; }
        public int CustomerID { get; set; }
        public int AccountNum { get; set; }
        public string AccountType { get; set; }
        public int PIN { get; set; }
        public Nullable<decimal> Balance { get; set; }
        public string LastName2 { get; set; }
        public string FirstName2 { get; set; }
    }
}
