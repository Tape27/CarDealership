using CarDealership.Domain.Models;
using CarDealership.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Infrastructure
{
    public class CarDealershipDbContext : DbContext
    {
        public DbSet<CarModel> Cars { get; set; }
        public DbSet<UrlImagesOfCarsModel> UrlImagesOfCars { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<AdminModel> Admins { get; set; }

        public CarDealershipDbContext(DbContextOptions<CarDealershipDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CarConfiguration());
            base.OnModelCreating(modelBuilder);
        }

    }
}