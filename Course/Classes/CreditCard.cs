namespace Course.Classes
{
    /// <summary>
    /// Клас CreditCard представляє кредитну картку з фіксованим лімітом кредиту,
    /// можливістю здійснення оплат та накопичення відсотків за використання кредитних коштів.
    /// </summary>
    public class CreditCard : BankCard
    {
        /// <summary>Максимальна сума кредитного ліміту.</summary>
        public double CreditLimit { get; set; }

        /// <summary>Залишок доступного кредиту.</summary>
        public double CreditLeft { get; set; }

        /// <summary>Дата, коли було вперше використано кредитні кошти. Використовується для нарахування відсотків.</summary>
        public DateTime? CreditTriggered { get; set; }

        private CreditCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, double сreditLimit, double creditLeft, DateTime? creditTriggered) : base(number, expirationDate, cvv, paymentSystem)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
            CreditTriggered = creditTriggered;
        }

        /// <summary>
        /// Створює нову кредитну картку, прив’язану до нового рахунку з вказаним лімітом.
        /// </summary>
        public CreditCard(string number, PaymentSystem paymentSystem, string accountNumber, double сreditLimit) : base(number, paymentSystem, accountNumber)
        {
            CreditLimit = сreditLimit;
            CreditLeft = CreditLimit;
        }

        /// <summary>
        /// Створює нову кредитну картку, прив’язану до існуючого рахунку з повним налаштуванням.
        /// </summary>
        public CreditCard(string number, PaymentSystem paymentSystem, Account account, double сreditLimit, double creditLeft, DateTime? creditTriggered) : base(number, paymentSystem, account)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
            CreditTriggered = creditTriggered;
        }


        /// <summary>
        /// Створює нову картку, замінюючи поточну, зберігаючи всі дані про кредит.
        /// </summary>
        public override void RenewCard()
        {
            ((PersonalAccount)Account).Card = new CreditCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, CreditLimit, CreditLeft, CreditTriggered);
        }


        /// <summary>
        /// Зберігає інформацію про кредитну картку до файла.
        /// </summary>
        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(CreditLimit.ToString());
            sw.WriteLine(CreditLeft.ToString());
            sw.WriteLine(CreditTriggered.ToString());
        }
        
        private static DateTime? LoadDateTime(StreamReader sr)
        {
            string? line = sr.ReadLine();
            return String.IsNullOrEmpty(line) ? null : DateTime.Parse(line);
        }

        /// <summary>
        /// Завантажує об’єкт CreditCard з файла.
        /// </summary>
        public static CreditCard LoadFromFile(StreamReader sr)
        {
            return new CreditCard(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                sr.ReadLine(),
                PaymentSystemFromText(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                LoadDateTime(sr)
            );
        }

        /// <summary>
        /// Перевіряє можливість оплати заданої суми з урахуванням залишку кредиту.
        /// </summary>
        public override bool IsPaymentAvailable(double amount)
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
                if (CreditLeft + Account.Balance >= amount)
                {
                    return true;
                }
                return false;
            }

            return true;
        }
    }
}
