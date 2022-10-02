using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PhoneBookEntitiesLib;
using WebApp.Data;

namespace WebApp.ContextFolder
{
    public class PhoneBooksContext : IdentityDbContext
    {
        //public PhoneBooksContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PhoneBook> PhoneBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB; 
                  Initial Catalog = PhoneBooksDb; 
                  Trusted_Connection=True;");
        }
    }
}
