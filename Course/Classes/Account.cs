using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    abstract class Account
    {
        public string Number { get; set; }
        public string? Blocked { get; set; }
        public List<Transaction> Transactions { get; set; }

        public Account(string number, string? blocked, List<Transaction> transactions)
        {
            Number = number;
            Blocked = blocked;
            Transactions = transactions;
        }
        public Account(string number)
        {
            Number = number;
            Blocked = null;
            Transactions = new List<Transaction>();
        }
        
        public bool IsBlocked 
        {
            get => (Blocked == null);
            set
            {
                if (value == IsBlocked) return;

                Blocked = value ? "Причина не вказана" : null;
            } 
        }
    }
}
