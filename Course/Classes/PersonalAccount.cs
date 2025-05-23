namespace Course.Classes
{
    /// <summary>
    /// Клас PersonalAccount представляє особистий рахунок користувача, прив’язаний до однієї банківської картки.
    /// Підтримує також обробку балансу з урахуванням кредитної логіки (для кредитних карток).
    /// </summary>
    public class PersonalAccount : Account
    {
        private double balance;

        /// <summary>
        /// Перевизначений баланс рахунку, який додатково обробляє логіку кредитного ліміту, якщо картка є кредитною.
        /// </summary>
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

        /// <summary>Банківська картка, прив’язана до цього особистого рахунку.</summary>
        public BankCard Card { get; set; }


        private PersonalAccount(string number, double balance, string? blocked, bool premium, List<Transaction> transactions, BankCard card) : base(number, balance, blocked, premium, transactions)
        {
            Card = card;
        }

        /// <summary>
        /// Створює новий особистий рахунок з нульовим балансом і прив’язаною карткою.
        /// </summary>
        public PersonalAccount(string number, BankCard card) : base(number)
        {
            Card = card;
        }


        /// <summary>
        /// Зберігає дані про рахунок і прив’язану картку у файл.
        /// </summary>
        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(Card.GetType().Name);
            Card.SaveToFile(sw);
        }

        /// <summary>
        /// Завантажує особистий рахунок з файла.
        /// </summary>
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


        /// <summary>
        /// Повертає тип особистого рахунку у вигляді тексту.
        /// </summary>
        public override string GetAccountType()
        {
            switch (Card)
            {
                case DebitCard:
                    return "Дебетовий";
                case CreditCard:
                    return "Кредитний";
                case PayoutCard:
                    return "Для виплат";
                default:
                    return "Невідомий";
            }
        }


        /// <summary>
        /// Перевіряє, чи рахунок активний (не заблокований) і чи не закінчився термін дії картки.
        /// </summary>
        public override bool IsAvailable()
        {
            return base.IsAvailable() && !Card.IsExpired();
        }

        /// <summary>
        /// Перевіряє можливість здійснення оплати з рахунку через прив’язану картку.
        /// </summary>
        public override bool IsPaymentAvailable(double amount)
        {
            return (Card.IsPaymentAvailable(amount));
        }
    }
}
