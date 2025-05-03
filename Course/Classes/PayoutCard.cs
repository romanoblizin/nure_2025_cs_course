namespace Course.Classes
{
    class PayoutCard : BankCard
    {
        private PayoutCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem) : base(number, expirationDate, cvv, paymentSystem) { }
        public PayoutCard(string number, PaymentSystem paymentSystem, string accountNumber) : base(number, paymentSystem, accountNumber) { }
        public PayoutCard(string number, PaymentSystem paymentSystem, Account account) : base(number, paymentSystem, account) { }

        public override bool Deposit(double amount)
        {
            return false;
        }

        public void Payout(string transactionNumber, double amount, string comment)
        {
            Account.Balance += amount;
            AddTransaction(transactionNumber, amount, null, comment, TransactionType.Payout);
        }

        public override void RenewCard()
        {
            if (!IsExpired())
            {
                return;
            }

            ((PersonalAccount)Account).Card = new PayoutCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account);
        }

        public static PayoutCard LoadFromFile(StreamReader sr)
        {
            return new PayoutCard(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                sr.ReadLine(),
                (PaymentSystem)Enum.Parse(typeof(PaymentSystem), sr.ReadLine())
            );
        }
    }
}
