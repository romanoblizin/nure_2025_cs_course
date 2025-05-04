namespace Course.Classes
{
    public class Service
    {
        public string CompanyName { get; set; }
        public string CompanyNumber { get; set; }
        public string OwnerFullName { get; set; }
        public string IBAN { get; set; }

        public Service(string companyName, string companyNumber, string ownerFullName, string iban)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            OwnerFullName = ownerFullName;
            IBAN = iban;
        }

        public void SaveToFile(StreamWriter sw)
        {
            sw.Write(CompanyName);
            sw.Write(CompanyNumber);
            sw.Write(OwnerFullName);
            sw.Write(IBAN);
        }
        public static Service LoadFromFile(StreamReader sr)
        {
            return new Service(
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine()
            );
        }
    }
}
