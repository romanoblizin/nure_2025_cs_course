using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    public enum CardType
    {
        Visa,
        Mastercard
    }

    abstract class BankCard
    {
        public string Number { get; set; }
        public double Balance { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public CardType Type { get; set; }

        public BankCard(string number, double balance, DateTime expirationDate, string cvv, CardType type)
        {
            Number = number;
            Balance = balance;
            ExpirationDate = expirationDate;
            CVV = cvv;
            Type = type;
        }
        public BankCard(string number, CardType type)
        {
            Number = number;
            Balance = 0;
            Type = type;

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
            Balance += amount;
        }

        public bool IsExpired
        {
            get => DateTime.Today > ExpirationDate;
        }

    }
}
