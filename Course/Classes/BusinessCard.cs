namespace Course.Classes
{
    public class BusinessCard : BankCard
    {
        public string OwnerFullName { get; set; }

        private BusinessCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string ownerFullName) : base(number, expirationDate, cvv, paymentSystem)
        {
            OwnerFullName = ownerFullName;
        }
        public BusinessCard(string number, PaymentSystem paymentSystem, string accountNumber, string ownerFullName) : base(number, paymentSystem, accountNumber)
        {
            OwnerFullName = ownerFullName;
        }
        public BusinessCard(string number, PaymentSystem paymentSystem, Account account, string ownerFullName) : base(number, paymentSystem, account)
        {
            OwnerFullName = ownerFullName;
        }

        public override void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Account.Transactions.Add(new BusinessTransaction(transactionNumber, amount, target, comment, type, OwnerFullName));
        }

        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(OwnerFullName);
        }
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

        public override void RenewCard()
        {
            ((BusinessAccount)Account).Cards.Remove(this);
            ((BusinessAccount)Account).Cards.Add(new BusinessCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, OwnerFullName));
        }
    }
}