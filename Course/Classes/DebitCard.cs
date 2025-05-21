namespace Course.Classes
{
    public class DepositClass
    {
        private double Amount { get; set; }
        private double Rate { get; set; }
        private DateTime OpenDate {  get; set; }
        private int Months { get; set; }

        public DepositClass(double amount, double rate, DateTime openDate, int months)
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

        public void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Amount.ToString());
            sw.WriteLine(Rate.ToString());
            sw.WriteLine(OpenDate.ToString());
            sw.WriteLine(Months.ToString());
        }
        public static DepositClass LoadFromFile(StreamReader sr)
        {
            return new DepositClass(
                Convert.ToDouble(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                DateTime.Parse(sr.ReadLine()),
                Convert.ToInt32(sr.ReadLine())
            );
        }

        public bool IsExpired(DateTime now)
        {
            return now >= OpenDate.AddMonths(Months);
        }
    }

    class DebitCard : BankCard
    {
        public double InterestRate { get; set; }
        public List<DepositClass> Deposits { get; set; }

        private DebitCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, double interestRate, List<DepositClass> deposits): base(number, expirationDate, cvv, paymentSystem)
        {
            InterestRate = interestRate;
            Deposits = deposits;
        }
        public DebitCard(string number, PaymentSystem paymentSystem, string accountNumber, double interestRate) : base(number, paymentSystem, accountNumber)
        {
            InterestRate = interestRate;
            Deposits = new List<DepositClass>();
        }
        public DebitCard(string number, PaymentSystem paymentSystem, Account account, double interestRate, List<DepositClass> deposits) : base(number, paymentSystem, account)
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

        public bool OpenDeposit(double amount, double rate, int months)
        {
            if (!IsPaymentAvailable(amount))
            {
                return false;
            }

            Account.Balance -= amount;
            Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), -amount, null, "", TransactionType.DepositOpen));
            Deposits.Add(new DepositClass(amount, rate, DateTime.Today, months));
            return true;
        }

        public void CloseDeposit(DepositClass deposit)
        {
            double amount = deposit.GetTotalValue();

            Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), amount, null, "", TransactionType.DepositClose));
            Deposits.Remove(deposit);
        }

        public override void RenewCard()
        {
            ((PersonalAccount)Account).Card = new DebitCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, InterestRate, Deposits);
        }

        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(InterestRate.ToString());

            sw.WriteLine(Deposits.Count.ToString());
            foreach (DepositClass deposit in Deposits)
            {
                deposit.SaveToFile(sw);
            }
        }
        private static List<DepositClass> LoadDeposits(StreamReader sr)
        {
            List<DepositClass> deposits = new List<DepositClass>();
            int amount = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                deposits.Add(DepositClass.LoadFromFile(sr));
            }

            return deposits;
        }
        public static DebitCard LoadFromFile(StreamReader sr)
        {
            return new DebitCard(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                sr.ReadLine(),
                PaymentSystemFromText(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                LoadDeposits(sr)
            );
        }
    }
}
