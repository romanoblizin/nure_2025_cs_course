namespace Course.Classes
{
    class BusinessAccount : Account
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public List<BusinessCard> Cards { get; set; }

        private BusinessAccount(string number, double balance, string? blocked, bool premium, List<Transaction> transactions, string companyName, string companyNumber, List<BusinessCard> cards) : base(number, balance, blocked, premium, transactions)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Cards = cards;
        }
        public BusinessAccount(string number, string companyName, string companyNumber) : base(number)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Cards = new List<BusinessCard>();
        }

        public BusinessCard OpenBusinessCard(PaymentSystem paymentSystem, string ownerFullName)
        {
            BusinessCard card = new BusinessCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, this, ownerFullName);

            Cards.Add(card);

            return card;
        }

        public override void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new BusinessTransaction(transactionNumber, amount, target, comment, type, CompanyName));
        }

        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(CompanyName);
            sw.WriteLine(CompanyNumber);

            sw.WriteLine(Cards.Count.ToString());
            foreach (BusinessCard card in Cards)
            {
                sw.WriteLine(card.GetType().ToString());
                card.SaveToFile(sw);
            }
        }
        private static List<BusinessCard> LoadCards(StreamReader sr)
        {
            List<BusinessCard> cards = new List<BusinessCard>();

            for (int i = 0; i < Convert.ToInt32(sr.ReadLine()); i++)
            {
                cards.Add((BusinessCard)LoadCard(sr));
            }

            return cards;
        }
        public static BusinessAccount LoadFromFile(StreamReader sr)
        {
            return new BusinessAccount(
                sr.ReadLine(),
                Convert.ToDouble(sr.ReadLine()),
                sr.ReadLine(),
                Convert.ToBoolean(sr.ReadLine()),
                LoadTransactions(sr),
                sr.ReadLine(),
                sr.ReadLine(),
                LoadCards(sr)
            );
        }

        public bool IsIPN()
        {
            return CompanyNumber.Length == 8;
        }
        public bool IsEDRPOU()
        {
            return CompanyNumber.Length == 10;
        }
    }
}
