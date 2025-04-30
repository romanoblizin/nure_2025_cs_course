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

        public BusinessAccount(string number, string? blocked, List<Transaction> transactions, string companyName, string companyNumber, List<BusinessCard> cards) : base(number, blocked, transactions)
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

        public bool IsIPN
        {
            get => CompanyNumber.Length == 8;
        }
        public bool IsEDRPOU
        {
            get => CompanyNumber.Length == 10;
        }
    }
}
