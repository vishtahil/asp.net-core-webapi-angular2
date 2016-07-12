
using Microsoft.EntityFrameworkCore;


namespace AzureDemo2.Models
{
    public class ContactContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("FileName=./Contact.db");
        }
    }
}