using AutoMapper;
using iForceCustomerVehicleDatabase.Model;
using iForceCustomerVehicleDatabase.Repository;
using iForceCustomerVehicleDatabase.Utils;
using iForceCustomerVehicleDatabase.ViewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Service
{
    public class CustomerVehicleService : ICustomerVehicleService
    {
        private readonly ICustomerVehicleRepo _customerVehicleRepo;
        private readonly IMapper _mapper;

        public CustomerVehicleService(ICustomerVehicleRepo customerVehicleRepo, IMapper mapper)
        {
            _customerVehicleRepo = customerVehicleRepo;
            _mapper = mapper;
        }

        public async Task<List<CustomerVM>> GetCustomers()
        {

            var customers = _customerVehicleRepo.GetCustomers();
            // TODO Mapping!!
            return _mapper.Map<List<CustomerVM>>(customers);
        }

        public async Task<bool> LoadCustomerVehicleDataSet(IFormFile file)
        {
            try
            {
                List<Customer> customers;

                IDataSetConverter converter = new CSVConverter();
                using (var stream = file.OpenReadStream())
                    customers = converter.ReadAndDigestCustomersFromData(stream);

                // now we have a set of datat that's a usable : try to save it

                return true;

            } catch (Exception e)
            {
                return false;
            }
            

        }

        public async Task<bool> TrySaveNewCustomerList(List<Customer> customers)
        {
            
            foreach (var customer in customers)
            {
                // manufacturers
                var newManufacturerId = customer.Vehicle.Model.Manufacturer.Id;
                if (_customerVehicleRepo.GetManufacturerById(newManufacturerId) == null)
                {
                    // save a new one
                }
            }
            // models
            // model colour
            // registrations
            // vehicles
            // customers
        }

    }
}
