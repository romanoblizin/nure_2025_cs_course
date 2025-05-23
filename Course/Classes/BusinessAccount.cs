namespace Course.Classes
{
    /// <summary>
    /// Клас BusinessAccount представляє корпоративний рахунок компанії.
    /// Дозволяє відкривати бізнес-картки, обробляти транзакції та зберігати інформацію про компанію.
    /// </summary>
    public class BusinessAccount : Account
    {
        /// <summary>Назва компанії, якій належить рахунок.</summary>
        public string CompanyName { get; set; }

        /// <summary>Ідентифікаційний номер компанії (ІПН або ЄДРПОУ).</summary>
        public string CompanyNumber { get; set; }

        /// <summary>Список бізнес-карток, прив’язаних до рахунку.</summary>
        public List<BusinessCard> Cards { get; set; }


        private BusinessAccount(string number, double balance, string? blocked, bool premium, List<Transaction> transactions, string companyName, string companyNumber, List<BusinessCard> cards) : base(number, balance, blocked, premium, transactions)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Cards = cards;
        }

        /// <summary>
        /// Створює новий корпоративний рахунок з початковим номером, назвою компанії та її номером.
        /// </summary>
        public BusinessAccount(string number, string companyName, string companyNumber) : base(number)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Cards = new List<BusinessCard>();
        }


        /// <summary>
        /// Відкриває нову бізнес-картку для власника з іменем ownerFullName.
        /// </summary>
        public BusinessCard OpenBusinessCard(PaymentSystem paymentSystem, string ownerFullName)
        {
            BusinessCard card = new BusinessCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, this, ownerFullName);

            Cards.Add(card);

            return card;
        }


        /// <summary>
        /// Додає бізнес-транзакцію до історії транзакцій цього рахунку.
        /// </summary>
        public override void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new BusinessTransaction(transactionNumber, amount, target, comment, type, CompanyName));
        }


        /// <summary>
        /// Зберігає інформацію про рахунок та всі картки у файл.
        /// </summary>
        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(CompanyName);
            sw.WriteLine(CompanyNumber);

            sw.WriteLine(Cards.Count.ToString());
            foreach (BusinessCard card in Cards)
            {
                sw.WriteLine(card.GetType().Name);
                card.SaveToFile(sw);
            }
        }
        
        private static List<BusinessCard> LoadCards(StreamReader sr)
        {
            List<BusinessCard> cards = new List<BusinessCard>();
            int amount = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                cards.Add((BusinessCard)LoadCard(sr));
            }

            return cards;
        }

        /// <summary>
        /// Завантажує корпоративний рахунок з файла.
        /// </summary>
        public static BusinessAccount LoadFromFile(StreamReader sr)
        {
            BusinessAccount businessAccount = new BusinessAccount(
                sr.ReadLine(),
                Convert.ToDouble(sr.ReadLine()),
                sr.ReadLine(),
                Convert.ToBoolean(sr.ReadLine()),
                LoadTransactions(sr),
                sr.ReadLine(),
                sr.ReadLine(),
                LoadCards(sr)
            );

            foreach (BusinessCard card in businessAccount.Cards)
            {
                card.Account = businessAccount;
            }

            return businessAccount;
        }


        /// <summary>
        /// Повертає рядок "Корпоративний".
        /// </summary>
        public override string GetAccountType() => "Корпоративний";
    }
}
