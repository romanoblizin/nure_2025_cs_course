namespace Course.Classes
{
    public class PersonalAccount : Account
    {
        private double balance;
        public override double Balance
        {
            get => balance;
            set
            {
                if (Card is CreditCard creditCard)
                {
                    if (creditCard.CreditLimit != creditCard.CreditLeft)
                    {
                        creditCard.CreditLeft += value;

                        if (creditCard.CreditLeft >= creditCard.CreditLimit)
                        {
                            balance = creditCard.CreditLeft - creditCard.CreditLimit;
                            creditCard.CreditLeft = creditCard.CreditLimit;
                            creditCard.CreditTriggered = null;
                        }
                        else if (creditCard.CreditTriggered != null)
                        {
                            creditCard.CreditTriggered = DateTime.Today;
                        }
                    }
                }

                balance = value;
            }
        }
        public BankCard Card { get; set; }

        private PersonalAccount(string number, double balance, string? blocked, bool premium, List<Transaction> transactions, BankCard card) : base(number, balance, blocked, premium, transactions)
        {
            Card = card;
        }
        public PersonalAccount(string number, BankCard card) : base(number)
        {
            Card = card;
        }

        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(Card.GetType().Name);
            Card.SaveToFile(sw);
        }
        public static PersonalAccount LoadFromFile(StreamReader sr)
        {
            PersonalAccount personalAccount = new PersonalAccount(
                sr.ReadLine(),
                Convert.ToDouble(sr.ReadLine()),
                sr.ReadLine(),
                Convert.ToBoolean(sr.ReadLine()),
                LoadTransactions(sr),
                LoadCard(sr)
            );

            personalAccount.Card.Account = personalAccount;

            return personalAccount;
        }

        public override bool IsAvailable()
        {
            return base.IsAvailable() && !Card.IsExpired();
        }

        public override bool IsPaymentAvailable(double amount)
        {
            return (Card.IsPaymentAvailable(amount));
        }
    }
}
