using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class CreditCard : BankCard
    {
        public double CreditLimit { get; set; }
        public double CreditLeft {  get; set; }

        public CreditCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber, double сreditLimit, double creditLeft) : base(number, expirationDate, cvv, paymentSystem, accountNumber)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
        }

        public CreditCard(string number, PaymentSystem paymentSystem, string accountNumber, double сreditLimit) : base(number, paymentSystem, accountNumber)
        {
            CreditLimit = сreditLimit;
            CreditLeft = CreditLimit;
        }

        // + override all payment funcs
    }
}
