using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iForceCustomerVehicleDatabase.Repository
{
    public class VehicleRepo : IVehicleRepo
    {
        private CustomerVehicleDatabaseDbContext _dbContext;

        public VehicleRepo(CustomerVehicleDatabaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Vehicle> GetVehicles()
        {
            var v = _dbContext.Set<Vehicle>().ToList();
            return v;
        }
        public Vehicle GetVehicleById(long id)
        {
            var v = _dbContext.Find<Vehicle>(id);
            return v;
        }


    }
}