using iForceCustomerVehicleDatabase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Repository
{


    public class CustomerVehicleRepo :ICustomerVehicleRepo
    {
        private CustomerVehicleDatabaseDbContext _dbContext;

        public CustomerVehicleRepo(CustomerVehicleDatabaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Customer> GetCustomers()
        {
            var c = _dbContext.Set<Customer>().ToList();
            return c;
        }
    }
}
