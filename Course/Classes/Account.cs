namespace Course.Classes
{
    public abstract class Account
    {
        public const double PremiumCost = 300;

        public string Number { get; set; }
        public virtual double Balance { get; set; }
        public string? Blocked { get; set; }
        public bool Premium { get; set; }
        public List<Transaction> Transactions { get; set; }
        public string IBAN
        {
            get => $"UA00{Bank.bankCode}{Number}";
        }

        protected Account(string number, double balance, string? blocked, bool premium, List<Transaction> transactions)
        {
            Number = number;
            Balance = balance;
            Blocked = blocked;
            Premium = premium;
            Transactions = transactions;
        }
        public Account(string number)
        {
            Number = number;
            Balance = 0;
            Blocked = null;
            Premium = false;
            Transactions = new List<Transaction>();
        }

        public virtual void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new Transaction(transactionNumber, amount, target, comment, type));
        }

        public bool SubscribePremium()
        {
            if (Balance >= PremiumCost)
            {
                Balance -= PremiumCost;
                Premium = true;
                Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), -PremiumCost, null, "", TransactionType.Premium));
                return true;
            }
            else
            {
                Premium = false;
                return false;
            }
        }

        public bool PayService(double amount, Service service, string comment)
        {
            if (!IsPaymentAvailable(amount))
            {
                MessageBox.Show("На рахунку не вистачає коштів!", "Помилка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            Balance -= amount;
            AddTransaction(Bank.GenerateTransactionNumber(), -amount, service.CompanyName, comment, TransactionType.ServicePayment);

            return true;
        }

        public virtual void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Number);
            sw.WriteLine(Balance.ToString());
            sw.WriteLine(Blocked);
            sw.WriteLine(Premium.ToString());

            sw.WriteLine(Transactions.Count);
            foreach (Transaction transaction in Transactions)
            {
                sw.WriteLine(transaction.GetType().Name);
                transaction.SaveToFile(sw);
            }
        }

        protected static List<Transaction> LoadTransactions(StreamReader sr)
        {
            List<Transaction> transactions = new List<Transaction>();
            int amount = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                if (sr.ReadLine() == "Transaction")
                    transactions.Add(Transaction.LoadFromFile(sr));
                else
                    transactions.Add(BusinessTransaction.LoadFromFile(sr));
            }

            return transactions;
        }
        protected static BankCard LoadCard(StreamReader sr)
        {
            var line = sr.ReadLine();
            switch (line)
            {
                case "DebitCard":
                    return DebitCard.LoadFromFile(sr);
                case "CreditCard":
                    return CreditCard.LoadFromFile(sr);
                case "PayoutCard":
                    return PayoutCard.LoadFromFile(sr);
                case "BusinessCard":
                    return BusinessCard.LoadFromFile(sr);
                default:
                    throw new Exception();
            }
        }

        public double GetTransferAmount(double amount)
        {
            return Math.Round(amount * (Premium ? 1 : 0.95), 2);
        }
        public bool IsBlocked()
        {
            return !String.IsNullOrEmpty(Blocked);
        }
        public virtual bool IsAvailable()
        {
            return !IsBlocked();
        }
        public virtual bool IsPaymentAvailable(double amount)
        {
            if (IsBlocked())
            {
                return false;
            }

            if (Balance < amount)
            {
                return false;
            }

            return true;
        }
        public abstract string GetAccountType();

        public static bool operator ==(Account? a, Account? b)
        {
            if (a is null || b is null) return false;
            return a.Number == b.Number;
        }
        public static bool operator !=(Account? a, Account? b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Account)
            {
                return false;
            }

            return Number == ((Account)obj).Number;
        }
        public override int GetHashCode()
        {
            return Number.GetHashCode();
        }
    }
}
