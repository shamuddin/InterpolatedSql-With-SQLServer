using InterpolatedSqlDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace InterpolatedSqlDemo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
    }
}
