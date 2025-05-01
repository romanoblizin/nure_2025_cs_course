using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Classes
{
    class Service
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
    }
}
