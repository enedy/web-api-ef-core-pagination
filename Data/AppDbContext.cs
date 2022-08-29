using Microsoft.EntityFrameworkCore;
using WebApiEfCorePagination.Models;

namespace WebApiEfCorePagination.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}
