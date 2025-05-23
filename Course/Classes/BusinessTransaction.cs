namespace Course.Classes
{
    /// <summary>
    /// Клас BusinessTransaction розширює звичайну транзакцію, додаючи ПІБ корпоративної картки.
    /// Використовується для корпоративних рахунків, щоб ідентифікувати відповідальну особу.
    /// </summary>
    public class BusinessTransaction : Transaction
    {
        /// <summary>ПІБ власника картки, який здійснив транзакцію.</summary>
        public string OwnerFullName { get; set; }

        private BusinessTransaction(string number, DateTime date, double amount, string? target, string description, TransactionType type, string ownerFullName) : base(number, date, amount, target, description, type)
        {
            OwnerFullName = ownerFullName;
        }

        /// <summary>
        /// Конструктор для повної транзакції з фіксованою датою, включаючи ім’я власника.
        /// </summary>
        public BusinessTransaction(string number, double amount, string? target, string description, TransactionType type, string ownerFullName) : base(number, amount, target, description, type)
        {
            OwnerFullName = ownerFullName;
        }

        /// <summary>
        /// Зберігає всі дані про транзакцію у файл, включаючи ПІБ власника.
        /// </summary>
        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(OwnerFullName);
        }

        /// <summary>
        /// Завантажує корпоративну транзакцію з файла.
        /// </summary>
        public static BusinessTransaction LoadFromFile(StreamReader sr)
        {
            return new BusinessTransaction(
                sr.ReadLine(),
                DateTime.Parse(sr.ReadLine()),
                Convert.ToDouble(sr.ReadLine()),
                sr.ReadLine(),
                sr.ReadLine(),
                (TransactionType)Enum.Parse(typeof(TransactionType), sr.ReadLine()),
                sr.ReadLine()
            );
        }
    }
}
