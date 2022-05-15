using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Repository
{
    public interface IUnitOfWork
    {

        public ICustomerRepo GetCustomerRepository();
        public IVehicleRepo GetVehicleRepository();

    }
}
