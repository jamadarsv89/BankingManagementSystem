using BankingManagementSystem.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingManagementSystem.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}
