using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Utils
{
    public class CSVConverter : IDataSetConverter
    {
        /// <summary>
        /// Creates a basic list of customer/vehicle combinations that exist in any given
        /// csv file with no thought to the existence or otherwise of customer/vehicles already
        /// created.
        /// </summary>
        /// <param name="inputStream"></param>
        /// <returns></returns>
        public List<Customer> ReadAndDigestCustomersFromCsv(Stream inputStream)
        {
            StreamReader stream = new StreamReader(inputStream);
            var data = stream.ReadToEnd().ToString();

            var values = data.Split("\r\n").Skip(1)
                                           .Select(v => CustomerFromCsv(v))
                                           .ToList();
            return values;
        }

        public Customer CustomerFromCsv(string csv)
        {
            string[] values = csv.Split(',');
            var c = new Customer(values[0..4]);
            var v = new Vehicle(values[4..11]);
            c.Vehicles.Add(v);
            return c;
        }
    }
}
