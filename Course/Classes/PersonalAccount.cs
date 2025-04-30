using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class PersonalAccount : Account
    {
        public BankCard Card { get; set; }

        public PersonalAccount(string number, double balance, string? blocked, List<Transaction> transactions, BankCard card) : base(number, balance, blocked, transactions)
        {
            Card = card;
        }
        public PersonalAccount(string number, BankCard card) : base(number)
        {
            Card = card;
        }
    }
}
