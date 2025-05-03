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
        public bool Premium { get; set; }
        public string IBAN
        {
            get => $"UA00{Bank.bankCode}{Number}";
        }
        public List<Transaction> Transactions { get; set; }

        public Account(string number, double balance, string? blocked, bool premium, List<Transaction> transactions)
        {
            Number = number;
            Balance = balance;
            Blocked = blocked;
            Premium = premium;
            Transactions = transactions;
        }
        public Account(string number)
        {
            Number = number;
            Balance = 0;
            Blocked = null;
            Premium = false;
            Transactions = new List<Transaction>();
        }

        public virtual void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new Transaction(transactionNumber, amount, target, comment, type));
        }

        public double GetTransferAmount(double amount)
        {
            return Math.Round(amount * (Premium ? 1 : 0.95), 2);
        }
        public bool IsBlocked()
        {
            return Blocked == null;
        }
        public virtual bool IsAvailable()
        {
            return !IsBlocked();
        }
        public virtual bool IsPaymentAvailable(double amount)
        {
            if (IsBlocked())
            {
                return false;
            }

            if (Balance < amount)
            {
                return false;
            }

            return true;
        }

        public static bool operator ==(Account? a, Account? b)
        {
            if (a is null || b is null) return false;
            return a.Number == b.Number;
        }
        public static bool operator !=(Account? a, Account? b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Account)
            {
                return false;
            }

            return Number == ((Account)obj).Number;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
