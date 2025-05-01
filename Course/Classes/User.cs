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
