using car_themed_app_Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace car_themed_app_DataLayer
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Service> ServiceHistory { get; set; }

        public DbSet<Mechanic> Mechanics { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Dealer> Dealers { get; set; }
    }
}
