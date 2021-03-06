using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using System.Collections.Generic;
using System.IO;

namespace iForceCustomerVehicleDatabase.Utils
{
    public interface IDataSetConverter
    {
        public List<Customer> ReadAndDigestCustomersFromCsv(Stream inputStream);
    }
}