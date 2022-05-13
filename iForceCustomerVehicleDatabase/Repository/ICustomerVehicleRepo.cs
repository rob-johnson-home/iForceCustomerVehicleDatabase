using iForceCustomerVehicleDatabase.Model;
using System.Collections.Generic;

namespace iForceCustomerVehicleDatabase.Repository
{
    public interface ICustomerVehicleRepo
    {
        List<Customer> GetCustomers();
    }
}