using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class BusinessCard : BankCard
    {
        public string OwnerFullName { get; set; }

        public BusinessCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber, string ownerFullName) : base(number, expirationDate, cvv, paymentSystem, accountNumber)
        {
            OwnerFullName = ownerFullName;
        }

        public BusinessCard(string number, PaymentSystem paymentSystem, string accountNumber, string ownerFullName) : base(number, paymentSystem, accountNumber)
        {
            OwnerFullName = ownerFullName;
        }
    }
}
