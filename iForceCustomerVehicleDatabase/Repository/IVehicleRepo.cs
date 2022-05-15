using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using System.Collections.Generic;

namespace iForceCustomerVehicleDatabase.Repository
{
    public interface IVehicleRepo
    {
        List<Vehicle> GetVehicles();
        Vehicle GetVehicleById(long id);
    }
}