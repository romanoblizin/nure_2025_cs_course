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
*/

namespace Course.Classes
{
    class Bank
    {
        private const string bankCode = "111111";
        public List<User> Users { get; set; }

        public Bank(List<User> users)
        {
            Users = users;
        }
        public Bank()
        {
            Users = new List<User>();
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

        public Account? OpenAccount(User user, AccountType type)
        {
            Account account = new Account();

            user.Accounts.Add(account);

            return account;
        }

        public string GetIBAN(Account account)
        {
            return $"UA00{bankCode}{account.AccountNumber}";
        }

        private bool ValidatePhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(\+380\d{9}|0\d{9})$");
        }
        private bool ValidateEmail(string email)
        {
            return Regex.IsMatch(email, @"^[\w\.]+@\w+\.+\w{2,4}$");
        }
    }

}
