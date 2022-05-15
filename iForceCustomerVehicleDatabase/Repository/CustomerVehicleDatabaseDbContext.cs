using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using Microsoft.EntityFrameworkCore;


namespace iForceCustomerVehicleDatabase.Repository
{
    public class CustomerVehicleDatabaseDbContext: DbContext, ICustomerVehicleDatabaseDbContext
    {

        public CustomerVehicleDatabaseDbContext(DbContextOptions<CustomerVehicleDatabaseDbContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get ; set; }
        public DbSet<Customer> Customers { get ; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            iForceCustomerVehicleDatabaseModelBuilder.Build(modelBuilder);
        }
    }
}
