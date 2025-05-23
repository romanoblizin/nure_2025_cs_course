namespace Course.Classes
{
    /// <summary>
    /// Клас DepositClass представляє інформацію про окремий депозит користувача:
    /// початкову суму, ставку, дату відкриття та тривалість у місяцях.
    /// </summary>
    public class DepositClass
    {
        private double Amount { get; set; }
        private double Rate { get; set; }
        private DateTime OpenDate {  get; set; }
        private int Months { get; set; }


        /// <summary>
        /// Конструктор, який створює новий депозит із заданими параметрами.
        /// </summary>
        public DepositClass(double amount, double rate, DateTime openDate, int months)
        {
            Amount = amount;
            Rate = rate;
            OpenDate = openDate;
            Months = months;
        }


        /// <summary>
        /// Повертає суму, яка буде доступна після завершення депозиту з урахуванням нарахованих відсотків.
        /// </summary>
        public double GetTotalValue()
        {
            return Math.Round(Amount + (Amount * Rate * (Months / 12.0)), 2);
        }

        /// <summary>
        /// Зберігає дані депозиту у файл.
        /// </summary>
        public void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Amount.ToString());
            sw.WriteLine(Rate.ToString());
            sw.WriteLine(OpenDate.ToString());
            sw.WriteLine(Months.ToString());
        }

        /// <summary>
        /// Завантажує об'єкт депозиту з файла.
        /// </summary>
        public static DepositClass LoadFromFile(StreamReader sr)
        {
            return new DepositClass(
                Convert.ToDouble(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                DateTime.Parse(sr.ReadLine()),
                Convert.ToInt32(sr.ReadLine())
            );
        }


        /// <summary>
        /// Перевіряє, чи завершився термін дії депозиту на вказану дату.
        /// </summary>
        public bool IsExpired(DateTime now)
        {
            return now >= OpenDate.AddMonths(Months);
        }
    }


    /// <summary>
    /// Клас DebitCard представляє дебетову картку.
    /// Вона дозволяє відкривати депозитів та на неї нараховуютья відсотки.
    /// </summary>
    class DebitCard : BankCard
    {
        /// <summary>Процентна ставка, що нараховується щомісяця на залишок по рахунку.</summary>
        public double InterestRate { get; set; }

        /// <summary>Список активних депозитів, відкритих через цю картку.</summary>
        public List<DepositClass> Deposits { get; set; }

        private DebitCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, double interestRate, List<DepositClass> deposits): base(number, expirationDate, cvv, paymentSystem)
        {
            InterestRate = interestRate;
            Deposits = deposits;
        }

        /// <summary>
        /// Створює нову дебетову картку з заданими параметрами рахунку.
        /// </summary>
        public DebitCard(string number, PaymentSystem paymentSystem, string accountNumber, double interestRate) : base(number, paymentSystem, accountNumber)
        {
            InterestRate = interestRate;
            Deposits = new List<DepositClass>();
        }

        /// <summary>
        /// Створює нову дебетову картку, прив’язану до існуючого рахунку та списку депозитів.
        /// </summary>
        public DebitCard(string number, PaymentSystem paymentSystem, Account account, double interestRate, List<DepositClass> deposits) : base(number, paymentSystem, account)
        {
            InterestRate = interestRate;
            Deposits = deposits;
        }


        /// <summary>
        /// Нараховує щомісячний відсоток на залишок по рахунку та додає відповідну транзакцію.
        /// </summary>
        public double ApplyMonthlyInterest()
        {
            double interest = Account.Balance * InterestRate - Account.Balance;
            Account.Balance += interest;

            if (interest > 0)
                Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), interest, null, "", TransactionType.Interest));

            return interest;
        }

        /// <summary>
        /// Відкриває новий депозит за вказаними умовами.
        /// </summary>
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

        /// <summary>
        /// Закриває депозит і зараховує накопичену суму на рахунок.
        /// </summary>
        public void CloseDeposit(DepositClass deposit)
        {
            double amount = deposit.GetTotalValue();

            Account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), amount, null, "", TransactionType.DepositClose));
            Deposits.Remove(deposit);
        }


        /// <summary>
        /// Випускає нову картку замість поточної, зберігаючи відсоткову ставку та депозити.
        /// </summary>
        public override void RenewCard()
        {
            ((PersonalAccount)Account).Card = new DebitCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, InterestRate, Deposits);
        }


        /// <summary>
        /// Зберігає картку та інформацію про депозити до файлу.
        /// </summary>
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

        /// <summary>
        /// Завантажує нову картку з файла.
        /// </summary>
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
