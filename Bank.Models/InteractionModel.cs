﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models
{
    public abstract class InteractionModel
    {
        public int TransactionID { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
