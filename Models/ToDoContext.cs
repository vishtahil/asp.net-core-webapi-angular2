using System.IO;
using Microsoft.EntityFrameworkCore;


namespace TodoApi.Models
{
    public class ToDoContext : DbContext
    {
        public DbSet<TodoItem> ToDoItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dir =Directory.GetCurrentDirectory();
            string connection = "Filename=" + Path.Combine(dir, "ToDoItem.db");
            optionsBuilder.UseSqlite(connection);
        }
    }
}