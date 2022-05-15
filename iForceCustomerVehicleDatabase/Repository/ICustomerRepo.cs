using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using System.Collections.Generic;

namespace iForceCustomerVehicleDatabase.Repository
{
    public interface ICustomerRepo
    {
        List<Customer> GetCustomers();

        Customer GetCustomerById(long id);
    }
}