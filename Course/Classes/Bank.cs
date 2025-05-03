// todo
/*
 * файловая система
 * поиски по критериям
 * изменение личных данных (профильных)
 * 
 * системные часы
*/

namespace Course.Classes
{
    class Bank
    {
        public const string bankCode = "111111";
        private const double premiumCost = 300;
        private static readonly Dictionary<PaymentSystem, (int MinValue, int MaxValue)> paymentSystemRanges = new()
        {
            { PaymentSystem.Visa, (400000, 499999) },
            { PaymentSystem.Mastercard, (510000, 559999) }
        };
        private static HashSet<string> accountNumbers = new HashSet<string>();
        private static HashSet<string> cardNumbers = new HashSet<string>();
        private static HashSet<string> transactionNumbers = new HashSet<string>();
        private static List<User> Users { get; set; } = new List<User>();

        public Bank() { }

        public User? Register(string name, string surname, string phone, string password, string? email)
        {
            if (name.Length < 2 || surname.Length < 2 || !User.ValidatePhone(phone) || email != null && !User.ValidateEmail(email) || password.Length < 8)
            {
                return null;
            }

            if (IsPhoneAvailable(phone) || email != null && IsEmailAvailable(email))
            {
                return null;
            }

            User user = new User(name, surname, phone, password, email);
            Users.Add(user);

            return user;
        }

        public User? LogIn(string login, string password)
        {
            if (User.ValidateEmail(login))
            {
                return Users.FirstOrDefault(u => u.Phone == login && u.Password == password);
            }
            else if (User.ValidatePhone(login))
            {
                return Users.FirstOrDefault(u => u.Phone == login && u.Password == password);
            }
            else
            {
                return null;
            }
        }

        public bool TransferToBusinessAccount(Account accountFrom, BusinessAccount accountTo, double amount, string comment)
        {
            if (accountFrom == accountTo)
            {
                return false;
            }

            if (!accountTo.IsAvailable())
            {
                return false;
            }

            if (!accountFrom.IsPaymentAvailable(amount))
                return false;

            accountFrom.Balance -= amount;
            accountTo.Balance += accountFrom.GetTransferAmount(amount);

            Transaction transaction = new Transaction(GenerateTransactionNumber(), -amount, accountTo.CompanyNumber, comment, TransactionType.Transfer);
            accountFrom.Transactions.Add(transaction);
            accountTo.Transactions.Add(new BusinessTransaction(transaction.Number, accountFrom.GetTransferAmount(amount), transaction.Target, transaction.Description, transaction.Type, accountTo.CompanyName));

            return true;
        }

        public bool TransferToCard(Account accountFrom, BankCard cardTo, double amount, string comment)
        {
            if (accountFrom == cardTo.Account)
            {
                return false;
            }

            if (!cardTo.IsAvailable() || cardTo is PayoutCard)
            {
                return false;
            }

            if (!accountFrom.IsPaymentAvailable(amount))
                return false;

            accountFrom.Balance -= amount;
            cardTo.Account.Balance += accountFrom.GetTransferAmount(amount);

            Transaction transaction = new Transaction(GenerateTransactionNumber(), -amount, cardTo.Number, comment, TransactionType.Transfer);
            accountFrom.Transactions.Add(transaction);

            if (cardTo is BusinessCard businessCardTo)
            {
                cardTo.Account.Transactions.Add(new BusinessTransaction(transaction.Number, accountFrom.GetTransferAmount(amount), transaction.Target, transaction.Description, transaction.Type, businessCardTo.OwnerFullName));
            }
            else
            {
                transaction.Amount = accountFrom.GetTransferAmount(amount);
                cardTo.Account.Transactions.Add(transaction);
            }            
            
            return true;
        }

        public bool TransferToCard(Account accountFrom, string cardNumberToStr, double amount, string comment)
        {
            BankCard? cardTo = GetCardByNumber(cardNumberToStr);

            if (cardTo != null)
            {
                return TransferToCard(accountFrom, cardTo, amount, comment);
            }

            if (!accountFrom.IsPaymentAvailable(amount))
                return false;

            accountFrom.Balance -= amount;
            accountFrom.AddTransaction(GenerateTransactionNumber(), -amount, cardNumberToStr, comment, TransactionType.Transfer);

            return true;
        }

        public bool TransferToIBAN(Account accountFrom, string iban, double amount, string comment)
        {
            Account? accountTo = GetAccountByIBAN(iban);
            if (accountTo != null)
            {
                if (accountTo is PersonalAccount personalAccountTo)
                {
                    return TransferToCard(accountFrom, personalAccountTo.Card, amount, comment);
                }
                else if (accountTo is BusinessAccount businessAccountTo)
                {
                    return TransferToBusinessAccount(accountFrom, businessAccountTo, amount, comment);
                }
            }

            if (!accountFrom.IsPaymentAvailable(amount))
                return false;

            accountFrom.Balance -= amount;
            accountFrom.AddTransaction(GenerateTransactionNumber(), -amount, iban, comment, TransactionType.Transfer);

            return true;
        }

        public void NewDay(DateTime now)
        {
            
            if (now.Day == 1)
            {
                List<BankCard> debitCards = GetCardsByType(typeof(DebitCard));

                foreach (DebitCard card in debitCards)
                {
                    card.ApplyMonthlyInterest();

                    foreach (Deposit deposit in card.Deposits)
                    {
                        if (deposit.IsExpired(now))
                        {
                            card.CloseDeposit(deposit);
                        }
                    }
                }

                foreach (User user in Users)
                {
                    foreach (Account account in user.Accounts)
                    {
                        if (account.Premium)
                        {
                            if (account.Balance >= premiumCost)
                            {
                                account.Balance -= premiumCost;
                                account.Transactions.Add(new Transaction(GenerateTransactionNumber(), -premiumCost, null, "", TransactionType.Premium));
                            }
                            else
                            {
                                account.Premium = false;
                            }
                        }
                    }
                }
            }

            List<BankCard> creditCards = GetCardsByType(typeof(DebitCard));

            foreach (CreditCard card in creditCards)
            {
                if (card.CreditTriggered != null)
                {
                    if (card.CreditTriggered.Value - now >= TimeSpan.FromDays(5))
                    {
                        double interest = Math.Round((card.CreditLimit - card.CreditLeft) * 0.36 / 365, 2);
                        card.CreditLeft -= interest;
                        card.Account.AddTransaction(GenerateTransactionNumber(), -interest, null, "", TransactionType.CreditInterest);
                    }
                }
            }
        }

        public void NewDay()
        {
            NewDay(DateTime.Today);
        }

        public static string GenerateAccountNumber()
        {
            string result;
            Random rnd = new Random();

            do
            {
                result = new string(Enumerable.Range(0, 16)
                    .Select(_ => rnd.Next(10).ToString()[0])
                    .ToArray());
            } while (transactionNumbers.Contains(result));

            accountNumbers.Add(result);
            return result;
        }
        public static string GenerateCardNumber(PaymentSystem paymentSystem)
        {
            string result;
            Random rnd = new Random();

            if (paymentSystemRanges.TryGetValue(paymentSystem, out var paymentSystemRange))
                result = rnd.Next(paymentSystemRange.MinValue, paymentSystemRange.MaxValue + 1).ToString();
            else
                result = "000000";

            do
            {
                result += new string(Enumerable.Range(0, 9)
                    .Select(_ => rnd.Next(10).ToString()[0])
                    .ToArray());
            } while (transactionNumbers.Contains(result));

            result += GetLuhnDigit(result);

            cardNumbers.Add(result);
            return result;
        }
        public static string GenerateTransactionNumber()
        {
            string result;
            Random rnd = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            do
            {
                result = new string(Enumerable.Repeat(chars, 16)
                    .Select(s => s[rnd.Next(s.Length)])
                    .ToArray());
            } while (transactionNumbers.Contains(result));

            transactionNumbers.Add(result);
            return result;
        }

        public BankCard? GetCardByNumber(string number)
        {
            List<BankCard> Cards = GetCardsByType(typeof(BankCard));

            return Cards.FirstOrDefault(x => x.Number == number);
        }
        public Account? GetAccountByIBAN(string iban)
        {
            foreach (User user in Users)
            {
                foreach (Account account in user.Accounts)
                {
                    if (account.IBAN == iban)
                        return account;
                }
            }

            return null;
        }

        private List<BankCard> GetCardsByType(Type cardType)
        {
            Type accountType;
            List<BankCard> Cards = new List<BankCard> ();

            if (cardType == typeof(BusinessCard))
                accountType = typeof(BusinessAccount);
            else if (cardType == typeof(DebitCard) || cardType == typeof(CreditCard) || cardType == typeof(PayoutCard))
                accountType = typeof(PersonalAccount);
            else if (cardType == typeof(BankCard))
                accountType = typeof(Account);
            else
                return Cards;

            foreach (User user in Users)
            {
                foreach (Account account in user.Accounts)
                {
                    if (accountType.IsAssignableFrom(account.GetType()))
                    {
                        if (accountType == typeof(PersonalAccount))
                        {
                            PersonalAccount personalAccount = (PersonalAccount)account;
                            Cards.Add(personalAccount.Card);
                        }
                        else
                        {
                            BusinessAccount businessAccount = (BusinessAccount)account;

                            foreach (BusinessCard card in businessAccount.Cards)
                            {
                                Cards.Add(card);
                            }
                        }
                    }
                    
                }
            }

            return Cards;
        }

        public static User? GetUserByAccount(Account account)
        {
            foreach (User user in Users)
            {
                foreach (Account acc in user.Accounts)
                {
                    if (account == acc)
                    {
                        return user;
                    }
                }
            }

            return null;
        }

        public bool IsPhoneAvailable(string phone)
        {
            foreach (User user in Users)
            {
                if (user.Phone == phone)
                    return false;
            }

            return true;
        }
        public bool IsEmailAvailable(string email)
        {
            foreach (User user in Users)
            {
                if (user.Email == email)
                    return false;
            }

            return true;
        }

        public static string GetLuhnDigit(string number)
        {
            int sum = 0;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(number[i].ToString());

                if (i % 2 == 0)
                {
                    digit *= 2;
                    if (digit > 9)
                        digit -= 9;
                }

                sum += digit;
            }

            int checkDigit = (10 - (sum % 10)) % 10;
            return checkDigit.ToString();
        }
    }
}
