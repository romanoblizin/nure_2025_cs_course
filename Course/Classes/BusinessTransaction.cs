using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class BusinessTransaction : Transaction
    {
        public string OwnerFullName { get; set; }

        public BusinessTransaction(string number, DateTime date, double amount, string? target, string description, TransactionType type, string ownerFullName) : base(number, date, amount, target, description, type)
        {
            OwnerFullName = ownerFullName;
        }
        public BusinessTransaction(string number, double amount, string? target, string description, TransactionType type, string ownerFullName) : base(number, amount, target, description, type)
        {
            OwnerFullName = ownerFullName;
        }
    }
}
