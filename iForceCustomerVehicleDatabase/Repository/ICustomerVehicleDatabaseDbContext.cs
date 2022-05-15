using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using Microsoft.EntityFrameworkCore;

namespace iForceCustomerVehicleDatabase.Repository
{
    public interface ICustomerVehicleDatabaseDbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}