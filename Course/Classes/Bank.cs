using System.Text.RegularExpressions;

// todo
/*
 * перевод средств
 * файловая система
 * поиски по критериям
 * изменение личных данных (профильных)
 * продление карты (если вышел срок)
 * 
 * снимать проценты за операции
 * премиум карты
 * 
 * кешбек
 * квитанции
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
            if (name.Length < 2 || surname.Length < 2 || !ValidatePhone(phone) || email != null && !ValidateEmail(email) || password.Length < 8)
            {
                return null;
            }

            if (Users.FirstOrDefault(u => u.Phone == phone) != null || email != null && Users.FirstOrDefault(u => u.Email == email) != null)
            {
                return null;
            }

            User user = new User(name, surname, phone, password, email);
            Users.Add(user);

            return user;
        }

        public User? LogIn(string login, string password)
        {
            if (ValidateEmail(login))
            {
                return Users.FirstOrDefault(u => u.Phone == login && u.Password == password);
            }
            else if (ValidatePhone(login))
            {
                return Users.FirstOrDefault(u => u.Phone == login && u.Password == password);
            }
            else
            {
                return null;
            }
        }

        public PersonalAccount? OpenDebitCard(User user, CardType type, PaymentSystem paymentSystem, double interestRate)
        {
            BankCard card = new DebitCard(GenerateCardNumber(paymentSystem), paymentSystem, GenerateAccountNumber(), interestRate);

            user.Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public PersonalAccount? OpenCreditCard(User user, CardType type, PaymentSystem paymentSystem, double creditLimit)
        {
            BankCard card = new CreditCard(GenerateCardNumber(paymentSystem), paymentSystem, GenerateAccountNumber(), creditLimit);

            user.Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public PersonalAccount? OpenPayoutCard(User user, CardType type, PaymentSystem paymentSystem)
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

        public string GetIBAN(Account account)
        {
            return $"UA00{bankCode}{account.Number}";
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
        private static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(\+380\d{9}|0\d{9})$");
        }
        private static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w\.]+@\w+\.+\w{2,4}$");
        }
    }

}
