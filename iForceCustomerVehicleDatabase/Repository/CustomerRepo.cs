using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Repository
{


    public class CustomerRepo :ICustomerRepo
    {
        private ICustomerVehicleDatabaseDbContext _dbContext;

        public CustomerRepo(ICustomerVehicleDatabaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Customer GetCustomerById(long id)
        {
            var c = _dbContext.Customers.Find(id);
            return c;
        }

        public List<Customer> GetCustomers()
        {
            var c = _dbContext.Customers.ToList();
            return c;
        }
    }
}
