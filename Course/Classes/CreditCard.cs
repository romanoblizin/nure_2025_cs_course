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

        public CreditCard(string number, double balance, DateTime expirationDate, string cvv, CardType type, double сreditLimit, double creditLeft) : base(number, balance, expirationDate, cvv, type)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
        }

        public CreditCard(string number, CardType type, double сreditLimit) : base(number, type)
        {
            CreditLimit = сreditLimit;
            CreditLeft = CreditLimit;
        }

        // + override all payment funcs
    }
}
