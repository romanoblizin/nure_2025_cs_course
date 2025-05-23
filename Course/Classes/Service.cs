namespace Course.Classes
{
    /// <summary>
    /// Клас Service представляє сервіс (компанію), який можна оплатити з рахунку користувача.
    /// Містить основну інформацію про компанію та її реквізити.
    /// </summary>
    public class Service
    {
        /// <summary>Назва компанії.</summary>
        public string CompanyName { get; set; }

        /// <summary>Ідентифікаційний номер компанії (ІПН або ЄДРПОУ).</summary>
        public string CompanyNumber { get; set; }

        /// <summary>ПІБ власника компанії.</summary>
        public string OwnerFullName { get; set; }

        /// <summary>IBAN компанії для зарахування коштів.</summary>
        public string IBAN { get; set; }

        /// <summary>
        /// Створює сервіс із повним набором параметрів.
        /// </summary>
        public Service(string companyName, string companyNumber, string ownerFullName, string iban)
        {
            CompanyName = companyName;
            CompanyNumber = companyNumber;
            OwnerFullName = ownerFullName;
            IBAN = iban;
        }

        /// <summary>
        /// Зберігає інформацію про сервіс у файл.
        /// </summary>
        public void SaveToFile(StreamWriter sw)
        {
            sw.WriteLine(CompanyName);
            sw.WriteLine(CompanyNumber);
            sw.WriteLine(OwnerFullName);
            sw.WriteLine(IBAN);
        }

        /// <summary>
        /// Завантажує об’єкт сервісу з файла.
        /// </summary>
        public static Service LoadFromFile(StreamReader sr)
        {
            return new Service(
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine(),
                sr.ReadLine()
            );
        }


        /// <summary>
        /// Перевантаження оператора порівняння "==", порівнює сервіси за номером.
        /// </summary>
        public static bool operator ==(Service? a, Service? b)
        {
            if (a is null || b is null) return false;
            return a.CompanyNumber == b.CompanyNumber;
        }

        /// <summary>
        /// Перевантаження оператора порівняння "!=", порівнює сервіси за номером.
        /// </summary>
        public static bool operator !=(Service? a, Service? b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Перевизначення методу Equals, порівнює сервіси за номером.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not Service)
            {
                return false;
            }

            return CompanyNumber == ((Service)obj).CompanyNumber;
        }

        /// <summary>
        /// Повертає хеш-код сервісу, на основі номера.
        /// </summary>
        public override int GetHashCode()
        {
            return CompanyNumber.GetHashCode();
        }
    }
}
