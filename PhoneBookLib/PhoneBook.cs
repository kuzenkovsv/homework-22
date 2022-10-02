using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookEntitiesLib
{
    public class PhoneBook
    {
        public int PhoneBookID { get; set; }

        public string OwnerPhoneBook { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
