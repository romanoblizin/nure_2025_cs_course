using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class PersonalAccount : Account
    {
        public override double Balance
        {
            get => Balance;
            set
            {
                if (Card is CreditCard creditCard)
                {
                    if (creditCard.CreditLimit != creditCard.CreditLeft)
                    {
                        creditCard.CreditLeft += value;

                        if (creditCard.CreditLeft >= creditCard.CreditLimit)
                        {
                            Balance = creditCard.CreditLeft - creditCard.CreditLimit;
                            creditCard.CreditLeft = creditCard.CreditLimit;
                            creditCard.CreditTriggered = null;
                        }
                        else if (creditCard.CreditTriggered != null)
                        {
                            creditCard.CreditTriggered = DateTime.Today;
                        }
                    }
                }

                Balance = value;
            }
        }
        public BankCard Card { get; set; }

        public PersonalAccount(string number, double balance, string? blocked, List<Transaction> transactions, BankCard card) : base(number, balance, blocked, transactions)
        {
            Card = card;
        }
        public PersonalAccount(string number, BankCard card) : base(number)
        {
            Card = card;
        }

        public override bool IsAvailable()
        {
            return base.IsAvailable() && !Card.IsExpired();
        }

        public override bool IsPaymentAvailable(double amount)
        {
            return (Card.IsPaymentAvailable(amount));
        }
    }
}
