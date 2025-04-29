using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Course.Classes
{
    public enum TransactionType
    {
        Transfer,
        Deposit,
        Withdraw,
        Payment
    } // открытие кредита, депозита и тд

    class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(int id, DateTime date, float amount, string description, TransactionType type)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
            Type = type;
        }
        public Transaction(int id, float amount, string description, TransactionType type)
        {
            Id = id;
            Date = DateTime.Now;
            Amount = amount;
            Description = description;
            Type = type;
        }
    }
}
