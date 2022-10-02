using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookEntitiesLib
{
    public class Contact
    {
        public int ContactID { get; set; }

        public int PhoneBookID { get; set; }

        public string Surname { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? Description { get; set; }
    }
}
