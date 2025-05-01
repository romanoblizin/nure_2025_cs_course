using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class BusinessCard : BankCard
    {
        public string OwnerFullName { get; set; }

        public BusinessCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber, string ownerFullName) : base(number, expirationDate, cvv, paymentSystem, accountNumber)
        {
            OwnerFullName = ownerFullName;
        }
        public BusinessCard(string number, PaymentSystem paymentSystem, string accountNumber, string ownerFullName) : base(number, paymentSystem, accountNumber)
        {
            OwnerFullName = ownerFullName;
        }
        public BusinessCard(string number, PaymentSystem paymentSystem, Account account, string ownerFullName) : base(number, paymentSystem, account)
        {
            OwnerFullName = ownerFullName;
        }

        public override void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Account.Transactions.Add(new BusinessTransaction(transactionNumber, amount, target, comment, type, OwnerFullName));
        }

        public override void RenewCard()
        {
            if (!IsExpired())
            {
                return;
            }

            ((BusinessAccount)Account).Cards.Remove(this);
            ((BusinessAccount)Account).Cards.Add(new BusinessCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, OwnerFullName));
        }
    }
}