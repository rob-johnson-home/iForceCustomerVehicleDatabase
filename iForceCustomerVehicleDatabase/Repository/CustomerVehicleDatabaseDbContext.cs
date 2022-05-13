using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Repository
{
    public class CustomerVehicleDatabaseDbContext: DbContext
    {

        public CustomerVehicleDatabaseDbContext(DbContextOptions<CustomerVehicleDatabaseDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            iForceCustomerVehicleDatabaseModelBuilder.Build(modelBuilder);
        }
    }
}
