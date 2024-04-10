using Dealership.Models.DbModels;
using Microsoft.EntityFrameworkCore;

namespace Dealership.DataContext
{
    public class ApplicationContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; } = null!;
        public DbSet<AdminModel> Admins { get; set; } = null!;
        public DbSet<OrderModel> Orders { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
