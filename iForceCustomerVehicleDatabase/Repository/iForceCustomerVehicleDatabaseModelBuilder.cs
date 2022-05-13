using iForceCustomerVehicleDatabase.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Repository
{
    public class iForceCustomerVehicleDatabaseModelBuilder
    {

        public static void Build(ModelBuilder builder)
        {

            builder.Entity<Customer>();
            builder.Entity<Colour>();
            builder.Entity<Manufacturer>();
            builder.Entity<Model.Model>();
            builder.Entity<ModelColour>();
            builder.Entity<Registration>();
            builder.Entity<Vehicle>();

        }
    }
}
