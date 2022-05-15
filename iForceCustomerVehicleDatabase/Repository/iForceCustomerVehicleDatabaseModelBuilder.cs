using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using Microsoft.EntityFrameworkCore;

namespace iForceCustomerVehicleDatabase.Repository
{
    public class iForceCustomerVehicleDatabaseModelBuilder
    {

        public static void Build(ModelBuilder builder)
        {

            builder.Entity<Customer>();
            builder.Entity<Vehicle>();

        }
    }
}
