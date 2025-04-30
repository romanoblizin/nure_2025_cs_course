using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class PayoutCard : BankCard // на нее нельзя перечислять средства и пополнять из банкомата !!
    {
        public PayoutCard(string number, double balance, DateTime expirationDate, string cvv, CardType type) : base(number, balance, expirationDate, cvv, type) { }
        public PayoutCard(string number, CardType type) : base(number, type) { }

        public override void Deposit(double amount)
        {
            return;
        }
    }
}
