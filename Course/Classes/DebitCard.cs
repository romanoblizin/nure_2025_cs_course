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

        public DebitCard(string number, DateTime expirationDate, string cvv, PaymentSystem paymentSystem, string accountNumber, double interestRate): base(number, expirationDate, cvv, paymentSystem, accountNumber)
        {
            InterestRate = interestRate;
        }

        public DebitCard(string number, PaymentSystem paymentSystem, string accountNumber, double interestRate) : base(number, paymentSystem, accountNumber)
        {
            InterestRate = interestRate;
        }

        public double ApplyMonthlyInterest()
        {
            double interest = Account.Balance * InterestRate - Account.Balance;
            Account.Balance += interest;
            return interest;

            // if interest > 0: new Transaction(null, interest, "Відсотки за місяць", TransactionType.Interest);
        }

        public void OpenDeposit(double amount, double rate, int months)
        {
            if (amount > Account.Balance)
            {
                return;
            }

            Account.Balance -= amount;

            // это надо куда-т сохраянть чтобы при перезапуске клиент не стал бомжиком =)
            // new Transaction(null, -amount, "Відкриття депозиту", TransactionType.DepositPayment);
        }
    }
}
