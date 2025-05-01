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
        public double CreditLeft { get; set; }

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
        public CreditCard(string number, PaymentSystem paymentSystem, Account account, double сreditLimit, double creditLeft) : base(number, paymentSystem, account)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
        }

        public override void RenewCard()
        {
            if (!IsExpired())
            {
                return;
            }

            ((PersonalAccount)Account).Card = new CreditCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, CreditLimit, CreditLeft);
        }

        public override bool IsPaymentAvailable(double amount)
        {
            if (amount < 0)
            {
                return false;
            }

            if (!IsAvailable())
            {
                return false;
            }

            if (Account.Balance < amount)
            {
                if (CreditLeft + Account.Balance >= amount)
                {
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}
