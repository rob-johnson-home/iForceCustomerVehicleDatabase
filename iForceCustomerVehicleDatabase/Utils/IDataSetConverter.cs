using iForceCustomerVehicleDatabase.Model;
using System.Collections.Generic;
using System.IO;

namespace iForceCustomerVehicleDatabase.Utils
{
    public interface IDataSetConverter
    {
        public List<Customer> ReadAndDigestCustomersFromData(Stream inputStream);
    }
}