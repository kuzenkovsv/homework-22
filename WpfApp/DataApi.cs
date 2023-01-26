using Newtonsoft.Json;
using PhoneBookEntitiesLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    internal class DataApi : BindableBase
    {
        private HttpClient httpClient { get; set; }

        private ObservableCollection<PhoneBook> phoneBooks = new ObservableCollection<PhoneBook>();
        public ObservableCollection<PhoneBook> PhoneBooks 
        {
            get
            {
                return phoneBooks;
            }
            set
            {
                phoneBooks = value;
                OnPropertyChanged(nameof(phoneBooks));
            }
        }

        private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        public ObservableCollection<Contact> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
                OnPropertyChanged(nameof(contacts));
            }
        }

        public DataApi()
        {
            httpClient = new HttpClient();
        }

        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            string url = @"https://localhost:5001/api/PhoneBooks";

            string json = httpClient.GetStringAsync(url).Result;
            return PhoneBooks=new ObservableCollection<PhoneBook>(JsonConvert.DeserializeObject<IEnumerable<PhoneBook>>(json));

        }

        public void AddPhoneBook(PhoneBook pb)
        {
            string url = @"https://localhost:5001/api/PhoneBooks";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(pb), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;

        }

        public IEnumerable<Contact> GetContacts()
        {
            string url = @"https://localhost:5001/api/Contacts";

            string json = httpClient.GetStringAsync(url).Result;
            return Contacts = new ObservableCollection<Contact>(JsonConvert.DeserializeObject<IEnumerable<Contact>>(json));

        }

        public IEnumerable<Contact> GetContact(int id)
        {
            string url = $@"https://localhost:5001/api/Contacts/{id}";

            string json = httpClient.GetStringAsync(url).Result;
            return Contacts = new ObservableCollection<Contact>(JsonConvert.DeserializeObject<IEnumerable<Contact>>(json));

        }

        public IEnumerable<Contact> GetContactsByIdPb(int idPb)
        {
            string url = $@"https://localhost:5001/api/Contacts?phoneBookID={idPb}";

            string json = httpClient.GetStringAsync(url).Result;
            return Contacts = new ObservableCollection<Contact>(JsonConvert.DeserializeObject<IEnumerable<Contact>>(json));

        }

      

        public void AddContact(Contact contact)
        {
            string url = @"https://localhost:5001/api/Contacts";

            var r = httpClient.PostAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }


        public void UpdateContact(int id, Contact contact)
        {
            string url = $@"https://localhost:5001/api/Contacts/{id}";

            var r = httpClient.PutAsync(
                requestUri: url,
                content: new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8,
                mediaType: "application/json")
                ).Result;
        }
        





        public void DelContact(int id, int pbId)
        {
            string url = $@"https://localhost:5001/api/Contacts/{id}";

            httpClient.DeleteAsync(requestUri: url);

            GetContactsByIdPb(pbId);

        }
    }
}
