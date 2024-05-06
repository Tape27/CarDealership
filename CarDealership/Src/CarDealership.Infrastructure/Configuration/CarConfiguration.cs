using CarDealership.Domain.Constants;
using CarDealership.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarDealership.Infrastructure.Configuration
{

    public class CarConfiguration : IEntityTypeConfiguration<CarModel>
    {
        public void Configure(EntityTypeBuilder<CarModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();

            builder.Property(x => x.Name)
                .HasMaxLength(CarModelConstants.MAX_NAME_LENGTH)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(CarModelConstants.MAX_DESCRIPTION_LENGTH)
                .IsRequired();

            builder.Property(x => x.Year)
                .HasMaxLength(CarModelConstants.MAX_YEAR)
                .IsRequired();

            builder.Property(x => x.Power)
                .HasMaxLength(CarModelConstants.MAX_POWER)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();

            builder.Property(x => x.Exists)
                .IsRequired();
        }
    }
}