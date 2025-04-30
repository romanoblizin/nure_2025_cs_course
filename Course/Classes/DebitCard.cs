using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class DebitCard : BankCard
    {
        public double InterestRate { get; set; }

        public DebitCard(string number, double balance, DateTime expirationDate, string cvv, CardType type, double interestRate): base(number, balance, expirationDate, cvv, type)
        {
            InterestRate = interestRate;
        }

        public DebitCard(string number, CardType type, double interestRate) : base(number, type)
        {
            InterestRate = interestRate;
        }

        public double ApplyMonthlyInterest()
        {
            double interest = Balance * InterestRate - Balance;
            Balance += interest;
            return interest; // check later if == 0

            // new Transaction(null, interest, "Відсотки за місяць", TransactionType.Interest);
        }

        public void OpenDeposit(double amount, double rate, int months)
        {
            if (amount > Balance)
            {
                return;
            }

            Balance -= amount;

            // это надо куда-т сохраянть чтобы при перезапуске клиент не стал бомжиком =)
            // new Transaction(null, -amount, "Відкриття депозиту", TransactionType.DepositPayment);
        }
    }
}
