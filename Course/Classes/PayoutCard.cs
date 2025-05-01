using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class PayoutCard : BankCard
    {
        public PayoutCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber) : base(number, expirationDate, cvv, paymentSystem, accountNumber) { }
        public PayoutCard(string number, PaymentSystem paymentSystem, string accountNumber) : base(number, paymentSystem, accountNumber) { }
        public PayoutCard(string number, PaymentSystem paymentSystem, Account account) : base(number, paymentSystem, account) { }

        public override bool Deposit(double amount)
        {
            return false;
        }

        public void Payout(string transactionNumber, double amount, string comment)
        {
            Account.Balance += amount;
            AddTransaction(transactionNumber, amount, null, comment, TransactionType.Payout);
        }
    }
}
