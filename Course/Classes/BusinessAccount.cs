using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace Course.Classes
{
    class BusinessAccount : Account
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public List<BusinessCard> Cards { get; set; }

        public BusinessAccount(string number, double balance, string? blocked, List<Transaction> transactions, string companyName, string companyNumber, List<BusinessCard> cards) : base(number, balance, blocked, transactions)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Cards = cards;
        }
        public BusinessAccount(string number, string companyName, string companyNumber) : base(number)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            Cards = new List<BusinessCard>();
        }

        public BusinessCard OpenBusinessCard(PaymentSystem paymentSystem, string ownerFullName)
        {
            BusinessCard card = new BusinessCard(Bank.GenerateCardNumber(paymentSystem), paymentSystem, this, ownerFullName);

            Cards.Add(card);

            return card;
        }

        public override void AddTransaction(string transactionNumber, double amount, string? target, string comment, TransactionType type)
        {
            Transactions.Add(new BusinessTransaction(transactionNumber, amount, target, comment, type, CompanyName));
        }

        public bool IsIPN()
        {
            return CompanyNumber.Length == 8;
        }
        public bool IsEDRPOU()
        {
            return CompanyNumber.Length == 10;
        }
    }
}
