using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    public enum CardType
    {
        Debit,
        Credit,
        Payout,
        Business
    }

    public enum PaymentSystem
    {
        Visa,
        Mastercard
    }

    abstract class BankCard
    {
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public PaymentSystem PaymentSystem { get; set; }
        public Account Account { get; set; }

        public BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem type, BusinessAccount account)
        {
            Number = number;
            ExpirationDate = expirationDate;
            CVV = cvv;
            PaymentSystem = type;
            Account = account;
        }
        public BankCard(string number, PaymentSystem type, BusinessAccount account)
        {
            Number = number;
            PaymentSystem = type;
            Account = account;

            DateTime today = DateTime.Today;
            ExpirationDate = new DateTime(today.Year, today.Month, 1).AddMonths(60).AddDays(-1);

            CVV = "";
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                CVV += rnd.Next(10).ToString();
            }
        }
        public BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem type, string accountNumber)
        {
            Number = number;
            ExpirationDate = expirationDate;
            CVV = cvv;
            PaymentSystem = type;
            Account = new PersonalAccount(accountNumber, this);
        }
        public BankCard(string number, PaymentSystem type, string accountNumber)
        {
            Number = number;
            PaymentSystem = type;
            Account = new PersonalAccount(accountNumber, this);

            DateTime today = DateTime.Today;
            ExpirationDate = new DateTime(today.Year, today.Month, 1).AddMonths(60).AddDays(-1);

            CVV = "";
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                CVV += rnd.Next(10).ToString();
            }
        }

        public virtual void Deposit(double amount)
        {
            Account.Balance += amount;
        }

        public bool IsExpired
        {
            get => DateTime.Today > ExpirationDate;
        }

    }
}
