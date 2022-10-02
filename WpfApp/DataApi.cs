using Newtonsoft.Json;
using PhoneBookEntitiesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp
{
    internal class DataApi
    {
        private HttpClient httpClient { get; set; }

        public DataApi()
        {
            httpClient = new HttpClient();
        }

        public IEnumerable<PhoneBook> GetPhoneBooks()
        {
            string url = @"https://localhost:5001/api/PhoneBooks";

            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<PhoneBook>>(json);

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
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);

        }

        public IEnumerable<Contact> GetContactsByIdPb(int idPb)
        {
            string url = $@"https://localhost:5001/api/Contacts?phoneBookID={idPb}";

            string json = httpClient.GetStringAsync(url).Result;
            return JsonConvert.DeserializeObject<IEnumerable<Contact>>(json);

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
    }
}
