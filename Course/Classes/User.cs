using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Course.Classes
{
    class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? Patronymic { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public List<Account> Accounts { get; set; }

        public User(string name, string surname, string phone, string password)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Password = password;
            Accounts = new List<Account>();
        }
        public User(string name, string surname, string phone, string password, string? email)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Password = password;
            Email = email;
            Accounts = new List<Account>();
        }
        public User(string name, string surname, string phone, string password, string email, List<Account> accounts)
        {
            Name = name;
            Surname = surname;
            Phone = phone;
            Password = password;
            Email = email;
            Accounts = accounts;
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
