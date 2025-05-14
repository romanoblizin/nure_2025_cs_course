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
        CreditInterest,
        DepositOpen,
        DepositClose,
        Premium,
        Cashback
    }

    public class Transaction
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

        public virtual void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(Number);
            sw.WriteLine(Date.ToString());
            sw.WriteLine(Amount.ToString());
            sw.WriteLine(Target);
            sw.WriteLine(Description);
            sw.WriteLine(Type.ToString());
        }

        public static Transaction LoadFromFile(StreamReader sr)
        {
            return new Transaction(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                sr.ReadLine(),
                sr.ReadLine(),
                (TransactionType)Enum.Parse(typeof(TransactionType), sr.ReadLine())
            );
        }

        public string GetReceipt(Account account)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Квитанція #{Number}");
            sb.AppendLine();

            TransactionType[] sendTypes = { TransactionType.Transfer, TransactionType.Withdraw, TransactionType.Payment, TransactionType.ServicePayment, TransactionType.DepositOpen, TransactionType.CreditInterest, TransactionType.Premium };

            sb.AppendLine($"Відправник: {(Amount < 0 && sendTypes.Contains(Type) ? account.IBAN : (String.IsNullOrEmpty(Target) ? "Банк" : Target))}");
            sb.AppendLine($"Отримувач: {(Amount > 0 ? account.IBAN : (String.IsNullOrEmpty(Target) ? "Банк" : Target))}");

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
                case TransactionType.CreditInterest:
                    return "Проценти за перевищення кредитного ліміту";
                case TransactionType.Premium:
                    return "Щомісячна оплата преміум картки";
                case TransactionType.Cashback:
                    return "Зняття кешбеку";
                default:
                    return "Невідома операція";
            }
        }
    }
}
