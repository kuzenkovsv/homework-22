using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using PhoneBookEntitiesLib;
using WebApp.ContextFolder;
using WebApp.Data;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private string Dayname;
        private int PhBookID;
        private PhoneBook pb;
        private Contact cont;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.PhoneBooks = new PhoneBooksContext().PhoneBooks;

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Administrators, RegisteredUser")]
        public IActionResult AddPhoneBook()
        {
            return View();
        }


        [HttpPost]
        [Authorize(Roles = "Administrators, RegisteredUser")]
        public IActionResult PbGetDataFromViewField(string ownerPhoneBook)
        {
            using (var db = new PhoneBooksContext())
            {
                db.PhoneBooks.Add(
                    new PhoneBook()
                    {
                        OwnerPhoneBook = ownerPhoneBook
                    });

                db.SaveChanges();
            }
            return Redirect("~/");
        }


        public IActionResult SomePhoneBook(int? id)
        {
            ViewBag.Contacts = new PhoneBooksContext().Contacts;

            using (var db = new PhoneBooksContext())
            {
                foreach (var item in db.PhoneBooks)
                {
                    if (id == item.PhoneBookID)
                    {
                        pb = item;
                    }
                }

            }

            var model = new PhoneBooksViewModel
            {
                Item = pb
            };

            return View(model);

        }

        [HttpGet]
        [Authorize(Roles = "Administrators, RegisteredUser")]
        public IActionResult AddContact(int id)
        {
            var model = new AddContactViewModel
            {
                IdPhBook = id
            };
            return View(model);
        }

        [HttpPost] 
        [Authorize(Roles = "Administrators, RegisteredUser")]
        public IActionResult ContGetDataFromViewField(int PhoneBookID, string Surname, string Name,
           string MiddleName, string PhoneNumber, string Address, string Description)
        {
            using (var db = new PhoneBooksContext())
            {
                db.Contacts.Add(
                    new Contact()
                    {
                        PhoneBookID = PhoneBookID,
                        Surname = Surname,
                        Name = Name,
                        MiddleName = MiddleName,
                        PhoneNumber = PhoneNumber,
                        Address = Address,
                        Description = Description
                    });

                db.SaveChanges();
            }
            return Redirect($"SomePhoneBook/{PhoneBookID}");
        }

        public IActionResult ContactDetail(int? id)
        {
            ViewBag.Contacts = new PhoneBooksContext().Contacts;
            foreach (var item in ViewBag.Contacts)
            {
                if (id == item.ContactID)
                {
                    cont = item;
                }
            }

            var model = new ContactDetailsViewModel
            {
                Item = cont
            };

            return View(model);
        }
        
        [Authorize(Roles = "Administrators")]
        public IActionResult EditingContact(int? id)
        {
            ViewBag.Contacts = new PhoneBooksContext().Contacts;
            foreach (var item in ViewBag.Contacts)
            {
                if (id == item.ContactID)
                {
                    cont = item;
                }
            }

            var model = new EditingContactViewModel
            {
                Item = cont
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public IActionResult EditingCont(int ContactID, int PhoneBookID, string Surname, string Name,
          string MiddleName, string PhoneNumber, string Address, string Description)
        {
            using (var db = new PhoneBooksContext())
            {
                foreach (var item in db.Contacts)
                {
                    if (item.ContactID == ContactID)
                    {
                        item.Surname = Surname;
                        item.Name = Name;
                        item.MiddleName = MiddleName;
                        item.PhoneNumber = PhoneNumber;
                        item.Address = Address;
                        item.Description = Description;

                        db.Contacts.Update(item);
                    }
                }

                db.SaveChanges();

            }
            return Redirect($"ContactDetail/{ContactID}");
        }

        [HttpPost]
        [Authorize(Roles = "Administrators")]
        public IActionResult DeleteContact(int ContactID)
        {
            using (var db = new PhoneBooksContext())
            {
                foreach (var item in db.Contacts)
                {
                    if (item.ContactID == ContactID)
                    {
                        cont = item;
                    }
                }
                PhBookID = cont.PhoneBookID;
                db.Contacts.Remove(cont);

                db.SaveChanges();
            }
            return Redirect($"SomePhoneBook/{PhBookID}");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}