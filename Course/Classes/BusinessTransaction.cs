using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class BusinessTransaction : Transaction
    {
        public string CardNumber { get; set; }

        public BusinessTransaction(string number, DateTime date, double amount, string? target, string description, TransactionType type, string cardNumber) : base(number, date, amount, target, description, type)
        {
            CardNumber = cardNumber;
        }
        public BusinessTransaction(string number, double amount, string? target, string description, TransactionType type, string cardNumber) : base(number, amount, target, description, type)
        {
            CardNumber = cardNumber;
        }
    }
}
