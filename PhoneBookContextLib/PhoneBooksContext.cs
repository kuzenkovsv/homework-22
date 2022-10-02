using Microsoft.EntityFrameworkCore;
using PhoneBookEntitiesLib;

namespace PhoneBookContextLib
{
    public class PhoneBooksContext : DbContext
    {
        public PhoneBooksContext(DbContextOptions options) : base(options) { }

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