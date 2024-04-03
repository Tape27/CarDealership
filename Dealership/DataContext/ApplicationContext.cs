using Dealership.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Dealership.DataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; } = null!;
        public DbSet<AdminModel> Admins { get; set; } = null!;
        public DbSet<OrderModel> Orders { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=CompanyDB;Username=postgres;Password=root");
        }
    }
}
