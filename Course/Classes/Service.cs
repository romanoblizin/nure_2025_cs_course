using static System.Runtime.InteropServices.JavaScript.JSType;

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
            sw.WriteLine(CompanyName);
            sw.WriteLine(CompanyNumber);
            sw.WriteLine(OwnerFullName);
            sw.WriteLine(IBAN);
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

        public static bool operator ==(Service? a, Service? b)
        {
            if (a is null || b is null) return false;
            return a.CompanyNumber == b.CompanyNumber;
        }
        public static bool operator !=(Service? a, Service? b)
        {
            return !(a == b);
        }
        public override bool Equals(object? obj)
        {
            if (obj is not Service)
            {
                return false;
            }

            return CompanyNumber == ((Service)obj).CompanyNumber;
        }
        public override int GetHashCode()
        {
            return CompanyNumber.GetHashCode();
        }
    }
}
