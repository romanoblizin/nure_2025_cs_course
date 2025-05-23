using System.Text.RegularExpressions;

namespace Course.Classes
{
    /// <summary>
    /// Клас User представляє користувача банківської системи.
    /// Містить особисті дані користувача, облікові записи та логіку взаємодії з картками і кешбеком.
    /// </summary>
    public class User
    {
        /// <summary>Прізвище користувача.</summary>
        public string Surname { get; set; }
        
        /// <summary>Ім’я користувача.</summary>
        public string Name { get; set; }

        /// <summary>По батькові користувача.</summary>
        public string Patronymic { get; set; }

        /// <summary>Адреса електронної пошти користувача.</summary>
        public string Email { get; set; }

        /// <summary>Номер телефону користувача.</summary>
        public string Phone { get; set; }

        /// <summary>Пароль для входу в систему.</summary>
        public string Password { get; set; }

        /// <summary>Накопичений кешбек користувача.</summary>
        public double Cashback {  get; set; }

        /// <summary>Список рахунків користувача.</summary>
        public List<Account> Accounts { get; set; }

        private User(string name, string surname, string patronymic, string phone, string password, string email, double cashback, List<Account> accounts)
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

        /// <summary>
        /// Створює нового користувача з базовими персональними даними. 
        /// Початково кешбек дорівнює нулю, а список рахунків — порожній.
        /// </summary>
        public User(string name, string surname, string patronymic, string phone, string password, string email) : this(name, surname, patronymic, phone, password, email, 0, new List<Account>())
        { }


        /// <summary>
        /// Відкриває дебетову картку для користувача.
        /// </summary>
        public PersonalAccount? OpenDebitCard(PaymentSystem paymentSystem, double interestRate)
        {
            BankCard card = new DebitCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, Bank.GenerateAccountNumber(), interestRate);

            Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        /// <summary>
        /// Відкриває дебетову картку для користувача.
        /// </summary>
        public PersonalAccount? OpenCreditCard(PaymentSystem paymentSystem, double creditLimit)
        {
            BankCard card = new CreditCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, Bank.GenerateAccountNumber(), creditLimit);

            Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        /// <summary>
        /// Відкриває картку для виплат для користувача.
        /// </summary>
        public PersonalAccount? OpenPayoutCard(PaymentSystem paymentSystem)
        {
            BankCard card = new PayoutCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, Bank.GenerateAccountNumber());

            Accounts.Add(card.Account);

            return (PersonalAccount)card.Account;
        }

        /// <summary>
        /// Відкриває корпоративний рахунок для користувача.
        /// </summary>
        public BusinessAccount? OpenBusinessAccount(string companyName, string companyNumber)
        {
            BusinessAccount account = new BusinessAccount(Bank.GenerateAccountNumber(), companyName, companyNumber);

            Accounts.Add(account);

            return account;
        }


        /// <summary>
        /// Перераховує кешбек на рахунок користувача.
        /// </summary>
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
            account.Transactions.Add(new Transaction(Bank.GenerateTransactionNumber(), Cashback * 0.8, "", "Кешбек", TransactionType.Cashback));
            Cashback = 0;
        }


        /// <summary>
        /// Зберігає дані користувача у файл.
        /// </summary>
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
            int amount = Convert.ToInt32(sr.ReadLine());

            for (int i = 0; i < amount; i++)
            {
                if (sr.ReadLine() == "PersonalAccount")
                    accounts.Add(PersonalAccount.LoadFromFile(sr));
                else
                    accounts.Add(BusinessAccount.LoadFromFile(sr));
            }

            return accounts;
        }

        /// <summary>
        /// Завантажує користувача з файлу.
        /// </summary>
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


        /// <summary>
        /// Повертає список усіх рахунків у вигляді рядків, з можливістю показувати або не показувати заблоковані.
        /// </summary>
        public List<string> GetAllAccountsText(bool showBlocked)
        {
            return Accounts.Where(x => (!x.IsBlocked() || showBlocked)).Select(x => $"({x.GetAccountType()}) {x.Number}: {x.Balance}₴").ToList();
        }

        /// <summary>
        /// Перевіряє правильність формату номера телефону.
        /// </summary>
        public static bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(\+380\d{9}|0\d{9})$");
        }

        /// <summary>
        /// Перевіряє правильність формату електронної пошти.
        /// </summary>
        public static bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w\.]+@\w+\.+\w{2,4}$");
        }
    }
}
