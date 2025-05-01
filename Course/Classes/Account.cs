using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    abstract class Account
    {
        public string Number { get; set; }
        public virtual double Balance { get; set; }
        public string? Blocked { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account(string number, double balance, string? blocked, List<Transaction> transactions)
        {
            Number = number;
            Balance = balance;
            Blocked = blocked;
            Transactions = transactions;
        }
        public Account(string number)
        {
            Number = number;
            Balance = 0;
            Blocked = null;
            Transactions = new List<Transaction>();
        }

        public virtual void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new Transaction(transactionNumber, amount, target, comment, type));
        }

        public bool IsBlocked()
        {
            return Blocked == null;
        }
        public virtual bool IsAvailable()
        {
            return !IsBlocked();
        }
    }
}
