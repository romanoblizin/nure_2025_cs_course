namespace Course.Classes
{
    /// <summary>
    /// Абстрактний клас Account представляє банківський рахунок користувача або компанії.
    /// Містить основні властивості та методи для роботи з балансом, транзакціями та статусом рахунку.
    /// </summary>
    public abstract class Account
    {
        /// <summary>Вартість підписки на преміум обслуговування.</summary>
        public const double PremiumCost = 300;

        /// <summary>Унікальний номер рахунку.</summary>
        public string Number { get; set; }

        /// <summary>Баланс рахунку в гривнях.</summary>
        public virtual double Balance { get; set; }

        /// <summary>Дата блокування рахунку або null, якщо рахунок активний.</summary>
        public string? Blocked { get; set; }

        /// <summary>Чи має рахунок преміум-статус.</summary>
        public bool Premium { get; set; }

        /// <summary>Список транзакцій, пов’язаних із рахунком.</summary>
        public List<Transaction> Transactions { get; set; }

        /// <summary>IBAN, сформований на основі коду банку та номеру рахунку.</summary>
        public string IBAN
        {
            get => $"UA00{Bank.bankCode}{Number}";
        }


        /// <summary>
        /// Конструктор для завантаження рахунку з файла з усіма властивостями.
        /// </summary>
        protected Account(string number, double balance, string? blocked, bool premium, List<Transaction> transactions)
        {
            Number = number;
            Balance = balance;
            Blocked = blocked;
            Premium = premium;
            Transactions = transactions;
        }

        /// <summary>
        /// Базовий конструктор для створення нового рахунку з нульовим балансом.
        /// </summary>
        public Account(string number)
        {
            Number = number;
            Balance = 0;
            Blocked = null;
            Premium = false;
            Transactions = new List<Transaction>();
        }

        /// <summary>
        /// Додає транзакцію до списку транзакцій рахунку.
        /// </summary>
        public virtual void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new Transaction(transactionNumber, amount, target, comment, type));
        }

        /// <summary>
        /// Активує преміум-підписку, якщо на рахунку достатньо коштів.
        /// </summary>
        public bool SubscribePremium()
        {
            if (Balance >= PremiumCost)
            {
                Balance -= PremiumCost;
                Premium = true;
                Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), -PremiumCost, null, "", TransactionType.Premium));
                return true;
            }
            else
            {
                Premium = false;
                return false;
            }
        }


        /// <summary>
        /// Виконує оплату сервісу з рахунку.
        /// </summary>
        public bool PayService(double amount, Service service, string comment)
        {
            if (!IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку не вистачає коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Balance -= amount;
            AddTransaction(Bank.GenerateTransactionNumber(), -amount, service.CompanyName, comment, TransactionType.ServicePayment);

            return true;
        }


        /// <summary>
        /// Зберігає інформацію про рахунок до файлу.
        /// </summary>
        public virtual void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Number);
            sw.WriteLine(Balance.ToString());
            sw.WriteLine(Blocked);
            sw.WriteLine(Premium.ToString());

            sw.WriteLine(Transactions.Count);
            foreach (Transaction transaction in Transactions)
            {
                sw.WriteLine(transaction.GetType().Name);
                transaction.SaveToFile(sw);
            }
        }

        /// <summary>
        /// Завантажує список транзакцій з файлу.
        /// </summary>
        protected static List<Transaction> LoadTransactions(StreamReader sr)
        {
            List<Transaction> transactions = new List<Transaction>();
            int amount = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                if (sr.ReadLine() == "Transaction")
                    transactions.Add(Transaction.LoadFromFile(sr));
                else
                    transactions.Add(BusinessTransaction.LoadFromFile(sr));
            }

            return transactions;
        }

        /// <summary>
        /// Завантажує банківську картку відповідного типу з файлу.
        /// </summary>
        protected static BankCard LoadCard(StreamReader sr)
        {
            var line = sr.ReadLine();
            switch (line)
            {
                case "DebitCard":
                    return DebitCard.LoadFromFile(sr);
                case "CreditCard":
                    return CreditCard.LoadFromFile(sr);
                case "PayoutCard":
                    return PayoutCard.LoadFromFile(sr);
                case "BusinessCard":
                    return BusinessCard.LoadFromFile(sr);
                default:
                    throw new Exception();
            }
        }

        /// <summary>
        /// Повертає суму, яка буде зарахована при переказі, після віднімання комісії.
        /// </summary>
        public double GetTransferAmount(double amount)
        {
            return Math.Round(amount * (Premium ? 1 : 0.95), 2);
        }

        /// <summary>
        /// Перевіряє, чи рахунок активний і доступний для операцій.
        /// </summary>
        public bool IsBlocked()
        {
            return !String.IsNullOrEmpty(Blocked);
        }

        /// <summary>
        /// Перевіряє, чи рахунок активний і доступний для операцій.
        /// </summary>
        public virtual bool IsAvailable()
        {
            return !IsBlocked();
        }

        /// <summary>
        /// Перевіряє, чи достатньо коштів для оплати з рахунку.
        /// </summary>
        public virtual bool IsPaymentAvailable(double amount)
        {
            if (IsBlocked())
            {
                return false;
            }

            if (Balance < amount)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Повертає тип рахунку як текст.
        /// </summary>
        public abstract string GetAccountType();

        /// <summary>
        /// Перевантаження оператора порівняння "==", порівнює рахунки за номером.
        /// </summary>
        public static bool operator ==(Account? a, Account? b)
        {
            if (a is null || b is null) return false;
            return a.Number == b.Number;
        }

        /// <summary>
        /// Перевантаження оператора порівняння "!=", порівнює рахунки за номером.
        /// </summary>
        public static bool operator !=(Account? a, Account? b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Перевизначення методу Equals, порівнює рахунки за номером.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not Account)
            {
                return false;
            }

            return Number == ((Account)obj).Number;
        }

        /// <summary>
        /// Повертає хеш-код рахунку, на основі номера.
        /// </summary>
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
