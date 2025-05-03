using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

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

        private BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem)
        {
            Number = number;
            ExpirationDate = expirationDate;
            CVV = cvv;
            PaymentSystem = paymentSystem;
        }

        public BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber) : this(number, expirationDate, cvv, paymentSystem)
        {
            Account = new PersonalAccount(accountNumber, this);
        }
        public BankCard(string number, PaymentSystem paymentSystem, string accountNumber) : this(number, GenerateExpirationDate(), GenerateCVV(), paymentSystem, accountNumber)
        { }
        public BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, Account account) : this (number, expirationDate, cvv, paymentSystem)
        {
            Account = account;
        }
        public BankCard(string number, PaymentSystem paymentSystem, Account account) : this(number, GenerateExpirationDate(), GenerateCVV(), paymentSystem, account)
        { }

        public virtual void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Account.Transactions.Add(new Transaction(transactionNumber, amount, target, comment, type));
        }

        public virtual bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (!IsAvailable())
            {
                return false;
            }

            Account.Balance += amount;
            AddTransaction(Bank.GenerateTransactionNumber(), amount, null, "", TransactionType.Deposit);
            return true;
        }

        public virtual bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (!IsAvailable())
            {
                return false;
            }

            if (Account.Balance < amount)
            {
                return false;
            }

            Account.Balance -= amount;
            AddTransaction(Bank.GenerateTransactionNumber(), -amount, null, "", TransactionType.Withdraw);
            return true;
        }

        public bool Pay(double amount, string comment)
        {
            if (!IsPaymentAvailable(amount))
                return false;

            Account.Balance -= amount;
            AddTransaction(Bank.GenerateTransactionNumber(), -amount, null, "", TransactionType.Payment);

            User? user = Bank.GetUserByAccount(Account);
            if (user != null)
            {
                user.Cashback += amount * (Account.Premium ? 0.03 : 0.01);
            }

            return true;
        }
        public bool PayService(double amount, Service service, string comment)
        {
            if (!IsPaymentAvailable(amount))
                return false;

            Account.Balance -= amount;
            Account.AddTransaction(Bank.GenerateTransactionNumber(), -amount, service.CompanyName, comment, TransactionType.ServicePayment);

            return true;
        }

        public abstract void RenewCard();

        private static string GenerateCVV()
        {
            string cvv = "";

            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                cvv += rnd.Next(10).ToString();
            }

            return cvv;
        }
        private static DateTime GenerateExpirationDate()
        {
            DateTime today = DateTime.Today;
            return new DateTime(today.Year, today.Month, 1).AddMonths(60).AddDays(-1);
        }

        public bool IsExpired()
        {
            return DateTime.Today > ExpirationDate;
        }
        public bool IsAvailable()
        {
            return !(Account.IsBlocked() || IsExpired());
        }
        public virtual bool IsPaymentAvailable(double amount)
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
                return false;
            }

            return true;
        }

        public override bool Equals(object? obj)
        {
            if (obj is BankCard card)
            {
                return card.Number == this.Number;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
