using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class Deposit
    {
        private double Amount { get; set; }
        private double Rate { get; set; }
        private DateTime OpenDate {  get; set; }
        private int Months { get; set; }

        public Deposit(double amount, double rate, DateTime openDate, int months)
        {
            Amount = amount;
            Rate = rate;
            OpenDate = openDate;
            Months = months;
        }

        public double GetTotalValue()
        {
            return Math.Round(Amount + (Amount * Rate * (Months / 12.0)), 2);
        }

        public bool IsExpired(DateTime now)
        {
            return now >= OpenDate.AddMonths(Months);
        }
    }

    class DebitCard : BankCard
    {
        public double InterestRate { get; set; }
        public List<Deposit> Deposits { get; set; }

        public DebitCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber, double interestRate, List<Deposit> deposits): base(number, expirationDate, cvv, paymentSystem, accountNumber)
        {
            InterestRate = interestRate;
            Deposits = deposits;
        }
        public DebitCard(string number, PaymentSystem paymentSystem, string accountNumber, double interestRate) : base(number, paymentSystem, accountNumber)
        {
            InterestRate = interestRate;
            Deposits = new List<Deposit>();
        }
        public DebitCard(string number, PaymentSystem paymentSystem, Account account, double interestRate, List<Deposit> deposits) : base(number, paymentSystem, account)
        {
            InterestRate = interestRate;
            Deposits = deposits;
        }

        public double ApplyMonthlyInterest()
        {
            double interest = Account.Balance * InterestRate - Account.Balance;
            Account.Balance += interest;

            if (interest > 0)
                Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), interest, null, "", TransactionType.Interest));

            return interest;
        }

        public void OpenDeposit(double amount, double rate, int months)
        {
            if (amount <= 0)
            {
                return;
            }

            if (amount > Account.Balance)
            {
                return;
            }

            Account.Balance -= amount;
            Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), -amount, null, "", TransactionType.DepositOpen));
            Deposits.Add(new Deposit(amount, rate, DateTime.Today, months));
        }

        public void CloseDeposit(Deposit deposit)
        {
            double amount = deposit.GetTotalValue();

            Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), amount, null, "", TransactionType.DepositClose));
            Deposits.Remove(deposit);
        }

        public override void RenewCard()
        {
            if (!IsExpired())
            {
                return;
            }

            ((PersonalAccount)Account).Card = new DebitCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, InterestRate, Deposits);
        }
    }
}
