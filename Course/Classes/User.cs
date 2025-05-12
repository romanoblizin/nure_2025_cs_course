using System.Text;
using System.Text.RegularExpressions;

namespace Course.Classes
{
    public class User
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronymic { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public double Cashback {  get; set; }
        public List<Account> Accounts { get; set; }

        public User(string name, string surname, string patronymic, string phone, string password, string email, double cashback, List<Account> accounts)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Phone = phone;
            Password = password;
            Email = email;
            Cashback = cashback;
            Accounts = accounts;
        }
        public User(string name, string surname, string patronymic, string phone, string password, string email) : this(name, surname, patronymic, phone, password, email, 0, new List<Account>())
        { }

        public PersonalAccount? OpenDebitCard(PaymentSystem paymentSystem, double interestRate)
        {
            BankCard card = new DebitCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, Bank.GenerateAccountNumber(), interestRate);

            Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public PersonalAccount? OpenCreditCard(PaymentSystem paymentSystem, double creditLimit)
        {
            BankCard card = new CreditCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, Bank.GenerateAccountNumber(), creditLimit);

            Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public PersonalAccount? OpenPayoutCard(PaymentSystem paymentSystem)
        {
            BankCard card = new PayoutCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, Bank.GenerateAccountNumber());

            Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        public BusinessAccount? OpenBusinessAccount(string companyName, string companyNumber)
        {
            BusinessAccount account = new BusinessAccount(Bank.GenerateAccountNumber(), companyName, companyNumber);

            Accounts.Add(account);

            return account;
        }

        public void GetCashback(Account account)
        {
            if (!Accounts.Contains(account))
            {
                return;
            }

            if (account.IsBlocked())
            {
                return;
            }

            if (Cashback < 100)
            {
                return;
            }

            account.Balance += Cashback * 0.8;
            account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), Cashback * 0.8, "", "", TransactionType.Cashback));
            Cashback = 0;
        }

        public void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Name);
            sw.WriteLine(Surname);
            sw.WriteLine(Patronymic);
            sw.WriteLine(Phone);
            sw.WriteLine(Password);
            sw.WriteLine(Email);
            sw.WriteLine(Cashback.ToString());

            sw.WriteLine(Accounts.Count.ToString());
            foreach (Account account in Accounts)
            {
                sw.WriteLine(account.GetType().Name);
                account.SaveToFile(sw);
            }
        }

        private static List<Account> LoadAccounts(StreamReader sr)
        {
            List<Account> accounts = new List<Account>();

            for (int i = 0; i < Convert.ToInt32(sr.ReadLine()); i++)
            {
                if (sr.ReadLine() == "PersonalAccount")
                    PersonalAccount.LoadFromFile(sr);
                else
                    BusinessAccount.LoadFromFile(sr);
            }

            return accounts;
        }

        public static User LoadFromFile(StreamReader sr)
        {
            return new User(
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine(),
                Convert.ToDouble(sr.ReadLine()),
                LoadAccounts(sr)
            );
        }

        public List<string> GetAllAccountsText(bool showBlocked)
        {
            List<string> accounts = new List<string>();

            foreach (Account account in Accounts)
            {
                if (!account.IsBlocked() || showBlocked)
                    accounts.Add($"{account.Number}: {account.Balance}₴");
            }

            return accounts;
        }

        public static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(\+380\d{9}|0\d{9})$");
        }
        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w\.]+@\w+\.+\w{2,4}$");
        }
    }
}
