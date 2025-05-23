namespace Course.Classes
{
    /// <summary>
    /// Клас BusinessCard представляє корпоративну банківську картку,
    /// яка пов’язана з корпоративним рахунком і містить інформацію про власника.
    /// </summary>
    public class BusinessCard : BankCard
    {
        /// <summary> ПІБ власника картки (вказується в транзакціях).</summary>
        public string OwnerFullName { get; set; }

        private BusinessCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string ownerFullName) : base(number, expirationDate, cvv, paymentSystem)
        {
            OwnerFullName = ownerFullName;
        }

        /// <summary>
        /// Створює бізнес-картку з прив’язкою до існуючого рахунку.
        /// </summary>
        public BusinessCard(string number, PaymentSystem paymentSystem, Account account, string ownerFullName) : base(number, paymentSystem, account)
        {
            OwnerFullName = ownerFullName;
        }


        /// <summary>
        /// Додає транзакцію, яка зберігає також ПІБ.
        /// </summary>
        public override void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Account.Transactions.Add(new BusinessTransaction(transactionNumber, amount, target, comment, type, OwnerFullName));
        }


        /// <summary>
        /// Зберігає інформацію про корпоративну картку до файлу.
        /// </summary>
        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(OwnerFullName);
        }

        /// <summary>
        /// Завантажує корпоративну картку з файла.
        /// </summary>
        public static BusinessCard LoadFromFile(StreamReader sr)
        {
            return new BusinessCard(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                sr.ReadLine(),
                PaymentSystemFromText(sr.ReadLine()),
                sr.ReadLine()
            );
        }

        /// <summary>
        /// Створює нову картку, замінюючи поточну, зберігаючи ПІБ власника.
        /// </summary>
        public override void RenewCard()
        {
            ((BusinessAccount)Account).Cards.Remove(this);
            ((BusinessAccount)Account).Cards.Add(new BusinessCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, OwnerFullName));
        }
    }
}