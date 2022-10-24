using GetARide.Entities;
using GetARide.Entities.Identity;
using Microsoft.EntityFrameworkCore;

namespace GetARide.Context
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<Payment>()
            .HasOne<Booking>(b => b.Booking)
            .WithOne(ad => ad.Payment)
            .HasForeignKey<Payment>(ad => ad.BookingId);

            modelBuilder.Entity<Vehicle>()
                .HasOne<Driver>(d => d.Driver)
            .WithMany(v => v.Vehicles)
            .HasForeignKey(d => d.DriverId);

            modelBuilder.Entity<Booking>()
                .HasOne<Driver>(d => d.Driver)
            .WithMany(b => b.Bookings)
            .HasForeignKey(d => d.DriverId);

            modelBuilder.Entity<Booking>()
               .HasOne<Passenger>(p => p.Passenger)
           .WithMany(b => b.Bookings)
           .HasForeignKey(d => d.PassengerId);
        }*/

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
