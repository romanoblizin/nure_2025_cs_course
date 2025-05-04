namespace Course.Classes
{
    public class BusinessTransaction : Transaction
    {
        public string OwnerFullName { get; set; }

        private BusinessTransaction(string number, DateTime date, double amount, string? target, string description, TransactionType type, string ownerFullName) : base(number, date, amount, target, description, type)
        {
            OwnerFullName = ownerFullName;
        }
        public BusinessTransaction(string number, double amount, string? target, string description, TransactionType type, string ownerFullName) : base(number, amount, target, description, type)
        {
            OwnerFullName = ownerFullName;
        }

        public override void SaveToFile(StreamWriter sw)
        {
            base.SaveToFile(sw);
            sw.WriteLine(OwnerFullName);
        }

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
