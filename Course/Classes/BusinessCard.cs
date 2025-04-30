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

        public BusinessCard(string number, double balance, DateTime expirationDate, string cvv, CardType type, string ownerFullName) : base(number, balance, expirationDate, cvv, type)
        {
            OwnerFullName = ownerFullName;
        }

        public BusinessCard(string number, CardType type, string ownerFullName) : base(number, type)
        {
            OwnerFullName = ownerFullName;
        }
    }
}
