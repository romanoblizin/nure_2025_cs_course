using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class PayoutCard : BankCard // на нее нельзя перечислять средства и пополнять из банкомата !!
    {
        public PayoutCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber) : base(number, expirationDate, cvv, paymentSystem, accountNumber) { }
        public PayoutCard(string number, PaymentSystem paymentSystem, string accountNumber) : base(number, paymentSystem, accountNumber) { }

        public override void Deposit(double amount)
        {
            return;
        }
    }
}
