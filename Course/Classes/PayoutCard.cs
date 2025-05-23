namespace Course.Classes
{
    /// <summary>
    /// Картка для виплат (PayoutCard) призначена **тільки для зарахування коштів**.
    /// Поповнення вручну з неї неможливе. Зв’язана з особистим рахунком користувача.
    /// </summary>
    public class PayoutCard : BankCard
    {
        private PayoutCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem) : base(number, expirationDate, cvv, paymentSystem) { }

        /// <summary>
        /// Створює нову картку для виплат з автоматичною генерацією реквізитів та прив’язкою до нового рахунку.
        /// </summary>
        public PayoutCard(string number, PaymentSystem paymentSystem, string accountNumber) : base(number, paymentSystem, accountNumber) { }

        /// <summary>
        /// Створює картку для виплат, прив’язану до існуючого рахунку.
        /// </summary>
        public PayoutCard(string number, PaymentSystem paymentSystem, Account account) : base(number, paymentSystem, account) { }


        /// <summary>
        /// Забороняє поповнення картки. Завжди повертає false і виводить відповідне повідомлення.
        /// </summary>
        public override bool Deposit(double amount)
        {
            MessageBox.Show("На картку для виплат неможливо покласти кошти!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

        /// <summary>
        /// Виконує зарахування коштів на рахунок, пов’язаний із карткою, та додає відповідну транзакцію.
        /// </summary>
        public void Payout(string transactionNumber, double amount, string comment)
        {
            Account.Balance += amount;
            AddTransaction(transactionNumber, amount, null, comment, TransactionType.Payout);
        }


        /// <summary>
        /// Випускає нову картку замість поточної.
        /// </summary>
        public override void RenewCard()
        {
            ((PersonalAccount)Account).Card = new PayoutCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account);
        }


        /// <summary>
        /// Завантажує картку для виплат із файлу.
        /// </summary>
        public static PayoutCard LoadFromFile(StreamReader sr)
        {
            return new PayoutCard(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                sr.ReadLine(),
                PaymentSystemFromText(sr.ReadLine())
            );
        }
    }
}
