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
        public string AccountNumber { get; set; }
        public double Balance { get; set; }
        public long CardNumber { get; set; }
        public DateOnly ExpirationDate { get; set; }
        public int CVV { get; set; }
        public AccountType Type { get; set; }
        public bool Blocked { get; set; }
        public List<Transaction> Transactions { get; set; }


    }
}
