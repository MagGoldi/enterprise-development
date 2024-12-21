using BicycleRent.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using System.Reflection.Metadata;

namespace BicycleRent.Domain;

public  class BicycleRentDbContext(DbContextOptions<BicycleRentDbContext> options) : DbContext(options)
{
    public DbSet<BicycleRenter> BicycleRenters { get; set; }

    public DbSet<Bicycle> Bicycles { get; set; }

    public DbSet<BicycleType> BicycleTypes { get; set; }

    public DbSet<Rent> Rents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var seeder = new BicycleRentDataSeeder();


        modelBuilder.Entity<BicycleRenter>().HasData(seeder.Renters);
        modelBuilder.Entity<Bicycle>().HasData(seeder.Bicycles);
        modelBuilder.Entity<BicycleType>().HasData(seeder.BicycleTypes);
        modelBuilder.Entity<Rent>().HasData(seeder.Rents);


        modelBuilder.Entity<Bicycle>(entity =>
            {
                entity.HasOne(e => e.Type)
                        .WithMany()
                        .HasForeignKey(e => e.TypeId)
                        .OnDelete(DeleteBehavior.Cascade);
            }
        );

        modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasOne(e => e.Renter)
                        .WithMany()
                        .HasForeignKey(e => e.RenterId)
                        .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Bicycle)
                        .WithMany()
                        .HasForeignKey(e => e.BicycleId)
                        .OnDelete(DeleteBehavior.Cascade);
            }
        );

        modelBuilder.Entity<BicycleType>()
            .HasKey(s => s.TypeId);

        modelBuilder.Entity<BicycleRenter>()
            .HasKey(s => s.RenterId);
    }
}
