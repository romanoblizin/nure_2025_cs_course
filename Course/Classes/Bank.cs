// todo
/*
 * файловая система
 * поиски по критериям
 * изменение личных данных (профильных)
 * 
 * newDay()
 * депозитная система
 * 
 * снимать проценты за операции
 * премиум карты
 * 
 * кешбек
 * 
 * квитанции
 * системные часы
*/

namespace Course.Classes
{
    class Bank
    {
        private const string bankCode = "111111";
        private HashSet<string> accountNumbers;
        private HashSet<string> cardNumbers;
        private HashSet<string> transactionNumbers;
        public List<User> Users { get; set; }

        public Bank()
        {
            Users = new List<User>();
            accountNumbers = new HashSet<string>();
            cardNumbers = new HashSet<string>();
            transactionNumbers = new HashSet<string>();
        }

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

        public PersonalAccount? OpenDebitCard(User user, PaymentSystem paymentSystem, double interestRate)
        {
            BankCard card = new DebitCard(GenerateCardNumber(paymentSystem), paymentSystem, GenerateAccountNumber(), interestRate);

            user.Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public PersonalAccount? OpenCreditCard(User user, PaymentSystem paymentSystem, double creditLimit)
        {
            BankCard card = new CreditCard(GenerateCardNumber(paymentSystem), paymentSystem, GenerateAccountNumber(), creditLimit);

            user.Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public PersonalAccount? OpenPayoutCard(User user, PaymentSystem paymentSystem)
        {
            BankCard card = new PayoutCard(GenerateCardNumber(paymentSystem), paymentSystem, GenerateAccountNumber());

            user.Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public BusinessAccount? OpenBusinessAccount(User user, string companyName, string companyNumber)
        {
            BusinessAccount account = new BusinessAccount(GenerateAccountNumber(), companyName, companyNumber);

            user.Accounts.Add(account);

            return account;
        }

        public BusinessCard OpenBusinessCard(BusinessAccount account, PaymentSystem paymentSystem, string ownerFullName)
        {
            BusinessCard card = new BusinessCard(GenerateCardNumber(paymentSystem), paymentSystem, account, ownerFullName);

            account.Cards.Add(card);

            return card;
        }

        public bool Deposit(BankCard bankCard, double amount)
        {
            if (!bankCard.IsAvailable())
                return false;

            if (bankCard.Deposit(amount))
            {
                bankCard.AddTransaction(GenerateTransactionNumber(), amount, null, "", TransactionType.Deposit);
                return true;
            }

            return false;
        }

        public bool Pay(BankCard bankCard, double amount, string comment)
        {
            if (!IsPaymentAvailable(bankCard.Account, amount))
                return false;

            bankCard.Account.Balance -= amount;
            bankCard.AddTransaction(GenerateTransactionNumber(), -amount, null, comment, TransactionType.Transfer);

            return true;
        }

        public bool PayService(Account account, double amount, Service service, string comment)
        {
            if (!IsPaymentAvailable(account, amount))
                return false;

            account.Balance -= amount;
            account.AddTransaction(GenerateTransactionNumber(), -amount, service.CompanyName, comment, TransactionType.ServicePayment);

            return true;
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

            if (!IsPaymentAvailable(accountFrom, amount))
                return false;

            accountFrom.Balance -= amount;
            accountTo.Balance += amount;

            Transaction transaction = new Transaction(GenerateTransactionNumber(), -amount, accountTo.CompanyNumber, comment, TransactionType.Transfer);
            accountFrom.Transactions.Add(transaction);
            accountTo.Transactions.Add(new BusinessTransaction(transaction.Number, transaction.Amount, transaction.Target, transaction.Description, transaction.Type, accountTo.CompanyName));

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

            if (!IsPaymentAvailable(accountFrom, amount))
                return false;

            accountFrom.Balance -= amount;
            cardTo.Account.Balance += amount;

            Transaction transaction = new Transaction(GenerateTransactionNumber(), -amount, cardTo.Number, comment, TransactionType.Transfer);
            accountFrom.Transactions.Add(transaction);

            if (cardTo is BusinessCard businessCardTo)
            {
                cardTo.Account.Transactions.Add(new BusinessTransaction(transaction.Number, transaction.Amount, transaction.Target, transaction.Description, transaction.Type, businessCardTo.OwnerFullName));
            }
            else
            {
                transaction.Amount *= -1;
                cardTo.Account.Transactions.Add(transaction);
            }            
            
            return true;
        }

        public bool TransferToCard(Account accountFrom, string accountToStr, double amount, string comment)
        {
            BankCard? cardTo = GetCardByNumber(accountFrom.Number);

            if (cardTo != null)
            {
                return TransferToCard(accountFrom, cardTo, amount, comment);
            }

            if (!IsPaymentAvailable(accountFrom, amount))
                return false;

            accountFrom.Balance -= amount;
            accountFrom.AddTransaction(GenerateTransactionNumber(), -amount, accountToStr, comment, TransactionType.Transfer);

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

            if (!IsPaymentAvailable(accountFrom, amount))
                return false;

            accountFrom.Balance -= amount;
            accountFrom.AddTransaction(GenerateTransactionNumber(), -amount, iban, comment, TransactionType.Transfer);

            return true;
        }

        public void RenewCard(BankCard card)
        {
            if (!card.IsExpired())
            {
                return;
            }

            switch (card)
            {
                case DebitCard debitCard:
                    ((PersonalAccount)debitCard.Account).Card = new DebitCard(GenerateCardNumber(card.PaymentSystem), card.PaymentSystem, card.Account, debitCard.InterestRate);
                    break;
                case CreditCard creditCard:
                    ((PersonalAccount)creditCard.Account).Card = new CreditCard(GenerateCardNumber(card.PaymentSystem), card.PaymentSystem, card.Account, creditCard.CreditLimit, creditCard.CreditLeft);
                    break;
                case PayoutCard payoutCard:
                    ((PersonalAccount)payoutCard.Account).Card = new PayoutCard(GenerateCardNumber(card.PaymentSystem), card.PaymentSystem, card.Account);
                    break;
                case BusinessCard businessCard:
                    ((BusinessAccount)businessCard.Account).Cards.Remove(businessCard);
                    ((BusinessAccount)businessCard.Account).Cards.Add(new BusinessCard(GenerateCardNumber(card.PaymentSystem), card.PaymentSystem, card.Account, businessCard.OwnerFullName));
                    break;
                default:
                    break;
            }
        }

        private string GenerateAccountNumber()
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
        private string GenerateCardNumber(PaymentSystem paymentSystem)
        {
            string result;
            Random rnd = new Random();

            switch (paymentSystem)
            {
                case PaymentSystem.Visa:
                    result = rnd.Next(400000, 500000).ToString();
                    break;
                case PaymentSystem.Mastercard:
                    result = rnd.Next(510000, 560000).ToString();
                    break;
                default:
                    result = "000000";
                    break;
            }

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
        private string GenerateTransactionNumber()
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

        public BankCard? GetCardByNumber(string number)
        {
            foreach (User user in Users)
            {
                foreach (Account account in user.Accounts)
                {
                    if (account is PersonalAccount personalAccount)
                    {
                        if (personalAccount.Card.Number == number)
                        {
                            return personalAccount.Card;
                        }
                    }
                    else
                    {
                        BusinessAccount businessAccount = (BusinessAccount)account;

                        foreach (BusinessCard card in businessAccount.Cards)
                        {
                            if (card.Number == number)
                            {
                                return card;
                            }
                        }
                    }
                }
            }

            return null;
        }
        public Account? GetAccountByIBAN(string iban)
        {
            foreach (User user in Users)
            {
                foreach (Account account in user.Accounts)
                {
                    if (GetIBAN(account) == iban)
                        return account;
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

        public static string GetIBAN(Account account)
        {
            return $"UA00{bankCode}{account.Number}";
        }

        private static bool IsPaymentAvailable(Account account, double amount)
        {
            if (amount < 0)
            {
                return false;
            }

            if (!account.IsAvailable())
            {
                return false;
            }

            if (account.Balance < amount)
            {
                if (account is PersonalAccount personalAccount)
                {
                    if (personalAccount.Card is CreditCard creditCard)
                    {
                        if (creditCard.CreditLeft + personalAccount.Balance >= amount)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            return true;
        }
    }
}
