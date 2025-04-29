using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    public enum AccountType
    {
        Visa,
        Mastercard
    }
    class Account
    {
        public long Number {  get; set; }
        public double Balance { get; set; }
        public string IBAN {  get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int CVV { get; set; }
        public AccountType Type { get; set; }
        public bool Blocked { get; set; }
        public List<Transaction> Transactions { get; set; }




        //public Account(long number, float balance, AccountType type, List<Transaction> transactions)
        //{
        //    Number = number;
        //    Balance = balance;
        //    Type = type;
        //    Transactions = transactions;
        //}
        //public Account(long number, AccountType type)
        //{
        //    Number = number;
        //    Balance = 0;
        //    Type = type;
        //    Transactions = new List<Transaction>();
        //}
    }
}
