using System.Text;

namespace Course.Classes
{
    public enum TransactionType
    {
        Transfer,
        Deposit,
        Withdraw,
        Payment,
        ServicePayment,
        Interest,
        Payout,
        DepositOpen,
        DepositClose
    }

    class Transaction
    {
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string? Target { get; set; }
        public string Description { get; set; }
        public TransactionType Type { get; set; }

        public Transaction(string number, DateTime date, double amount, string? target, string description, TransactionType type)
        {
            Number = number;
            Date = date;
            Amount = amount;
            Target = target;
            Description = description;
            Type = type;
        }
        public Transaction(string number, double amount, string? target, string description, TransactionType type)
        {
            Number = number;
            Date = DateTime.Now;
            Amount = amount;
            Target = target;
            Description = description;
            Type = type;
        }

        public string GetReceipt(Account account)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Квитанція № {Number}");
            sb.AppendLine();
            sb.AppendLine($"Відправник: {account.IBAN}");
            sb.AppendLine($"Отримувач: {Target}");
            sb.AppendLine();
            sb.AppendLine($"Сума (грн): {Math.Abs(Amount)}");
            sb.AppendLine($"Призначення платежу: {GetTranslatedType(Type)}");
            sb.AppendLine($"Дата і час операції: {Date.ToString("dd.MM.yyyy HH:mm")}");
            if (Description.Length > 0)
                sb.AppendLine($"Коментар: {Description}");
            sb.AppendLine();
            sb.AppendLine();
            sb.AppendLine("Операційний директор: Облізін Р. Г.");

            return sb.ToString();
        }

        public static string GetTranslatedType(TransactionType type)
        {
            switch (type)
            {
                case TransactionType.Transfer:
                    return "Переказ коштів";
                case TransactionType.Deposit:
                    return "Поповнення балансу";
                case TransactionType.Withdraw:
                    return "Зняття готівки";
                case TransactionType.Payment:
                    return "Оплата картою";
                case TransactionType.ServicePayment:
                    return "Оплата послуги";
                case TransactionType.Interest:
                    return "Відсотки за місяць";
                case TransactionType.Payout:
                    return "Виплата";
                case TransactionType.DepositOpen:
                    return "Відкриття депозиту";
                case TransactionType.DepositClose:
                    return "Закриття депозиту";
                default:
                    return "Невідома операція";
            }
        }
    }
}
