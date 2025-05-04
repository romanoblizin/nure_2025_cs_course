namespace Course.Classes
{
    public class CreditCard : BankCard
    {
        public double CreditLimit { get; set; }
        public double CreditLeft { get; set; }
        public DateTime? CreditTriggered { get; set; }

        private CreditCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, double сreditLimit, double creditLeft, DateTime? creditTriggered) : base(number, expirationDate, cvv, paymentSystem)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
            CreditTriggered = creditTriggered;
        }
        public CreditCard(string number, PaymentSystem paymentSystem, string accountNumber, double сreditLimit) : base(number, paymentSystem, accountNumber)
        {
            CreditLimit = сreditLimit;
            CreditLeft = CreditLimit;
        }
        public CreditCard(string number, PaymentSystem paymentSystem, Account account, double сreditLimit, double creditLeft, DateTime? creditTriggered) : base(number, paymentSystem, account)
        {
            CreditLimit = сreditLimit;
            CreditLeft = creditLeft;
            CreditTriggered = creditTriggered;
        }

        public override void RenewCard()
        {
            if (!IsExpired())
            {
                return;
            }

            ((PersonalAccount)Account).Card = new CreditCard(Bank.GenerateCardNumber(PaymentSystem), PaymentSystem, Account, CreditLimit, CreditLeft, CreditTriggered);
        }

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
        public static CreditCard LoadFromFile(StreamReader sr)
        {
            return new CreditCard(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                sr.ReadLine(),
                (PaymentSystem)Enum.Parse(typeof(PaymentSystem), sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                LoadDateTime(sr)
            );
        }

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
