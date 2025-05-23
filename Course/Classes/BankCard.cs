namespace Course.Classes
{
    /// <summary>
    /// Перелік підтримуваних платіжних систем.
    /// </summary>
    public enum PaymentSystem
    {
        Visa,
        Mastercard
    }

    /// <summary>
    /// Тип банківської картки, який визначає її функціональність.
    /// </summary>
    public enum BankCardType
    {
        DebitCard,
        CreditCard,
        PayoutCard,
        BusinessCard
    }

    /// <summary>
    /// Абстрактний клас BankCard представляє банківську картку з основною інформацією:
    /// номером, терміном дії, CVV, платіжною системою та прив’язаним до нього рахунком.
    /// Використовується як базовий клас для дебетових, кредитних, корпоративних карток та карток для виплат.
    /// </summary>
    public abstract class BankCard
    {
        /// <summary>Унікальний номер картки.</summary>
        public string Number { get; set; }

        /// <summary>Дата закінчення терміну дії картки.</summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>CVV-код безпеки картки.</summary>
        public string CVV { get; set; }

        /// <summary>Платіжна система картки.</summary>
        public PaymentSystem PaymentSystem { get; set; }

        /// <summary>Рахунок, до якого прив’язана картка.</summary>
        public Account? Account { get; set; }

        protected BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem)
        {
            Number = number;
            ExpirationDate = expirationDate;
            CVV = cvv;
            PaymentSystem = paymentSystem;
        }
        protected BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber) : this(number, expirationDate, cvv, paymentSystem)
        {
            Account = new PersonalAccount(accountNumber, this);
        }
        protected BankCard(string number, PaymentSystem paymentSystem, string accountNumber) : this(number, GenerateExpirationDate(), GenerateCVV(), paymentSystem, accountNumber)
        { }
        protected BankCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, Account account) : this (number, expirationDate, cvv, paymentSystem)
        {
            Account = account;
        }
        protected BankCard(string number, PaymentSystem paymentSystem, Account account) : this(number, GenerateExpirationDate(), GenerateCVV(), paymentSystem, account)
        { }


        /// <summary>
        /// Додає транзакцію до рахунку, прив’язаного до картки.
        /// </summary>
        public virtual void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Account.Transactions.Add(new Transaction(transactionNumber, amount, target, comment, type));
        }


        /// <summary>
        /// Поповнює рахунок через картку.
        /// </summary>
        public virtual bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("Сума повинна бути більше за 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsAvailable())
            {
                MessageBox.Show("Картку заблоковано!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Account.Balance += amount;
            AddTransaction(Bank.GenerateTransactionNumber(), amount, null, "", TransactionType.Deposit);
            return true;
        }

        /// <summary>
        /// Знімає готівку з картки.
        /// </summary>
        public virtual bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                MessageBox.Show("Сума повинна бути більше за 0!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsAvailable())
            {
                MessageBox.Show("Картку заблоковано!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (Account.Balance < amount)
            {
                MessageBox.Show("На рахунку не вистачає коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Account.Balance -= amount;
            AddTransaction(Bank.GenerateTransactionNumber(), -amount, null, "", TransactionType.Withdraw);
            return true;
        }


        /// <summary>
        /// Виконує оплату карткою з урахуванням кешбеку.
        /// </summary>
        public bool Pay(double amount)
        {
            if (!IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку не вистачає коштів або картку заблоковано!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Account.Balance -= amount;
            AddTransaction(Bank.GenerateTransactionNumber(), -amount, null, "", TransactionType.Payment);

            User? user = Bank.GetUserByAccount(Account);
            if (user != null)
            {
                user.Cashback += amount * (Account.Premium ? 0.03 : 0.01);
            }

            return true;
        }


        /// <summary>
        /// Оновлює прострочену картку.
        /// </summary>
        public abstract void RenewCard();


        /// <summary>
        /// Зберігає дані про картку у файл.
        /// </summary>
        public virtual void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Number);
            sw.WriteLine(ExpirationDate.ToString());
            sw.WriteLine(CVV);
            sw.WriteLine(PaymentSystem.ToString());
        }

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


        /// <summary>
        /// Повертає enum платіжної системи з її назви.
        /// </summary>
        public static PaymentSystem PaymentSystemFromText(string text)
        {
            return (PaymentSystem)Enum.Parse(typeof(PaymentSystem), text);
        }

        /// <summary>
        /// Перевіряє, чи картка прострочена на вказану дату.
        /// </summary>
        public bool IsExpired(DateTime now)
        {
            return now > ExpirationDate;
        }
        
        /// <summary>
        /// Перевіряє, чи картка прострочена на поточну дату.
        /// </summary>
        public bool IsExpired()
        {
            return IsExpired(DateTime.Today);
        }

        /// <summary>
        /// Перевіряє, чи картка доступна для операцій (не заблокована і не прострочена).
        /// </summary>
        public bool IsAvailable()
        {
            return !(Account.IsBlocked() || IsExpired());
        }

        /// <summary>
        /// Перевіряє, чи можливе списання заданої суми з картки.
        /// </summary>
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

        /// <summary>
        /// Перевизначення методу Equals, порівнює картки за номером.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is BankCard card)
            {
                return card.Number == this.Number;
            }

            return false;
        }

        /// <summary>
        /// Повертає хеш-код картки, на основі номера.
        /// </summary>
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
