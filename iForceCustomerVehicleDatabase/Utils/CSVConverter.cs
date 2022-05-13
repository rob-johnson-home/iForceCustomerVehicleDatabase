using iForceCustomerVehicleDatabase.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Utils
{
    public class CSVConverter : IDataSetConverter
    {
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
            var c = new Customer(values);
            return c;
        }
    }
}
