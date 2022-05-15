using AutoMapper;
using iForceCustomerVehicleDatabase.CustomerVehicleModel;
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
        private readonly ICustomerRepo _customerRepo;
        private readonly IVehicleRepo _vehicleRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CustomerVehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<CustomerVM>> GetCustomers()
        {

            var customers = _unitOfWork.GetCustomerRepository().GetCustomers();
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
                    customers = converter.ReadAndDigestCustomersFromCsv(stream);

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
                
            }

            return true;
            // models
            // model colour
            // registrations
            // vehicles
            // customers
        }

        public long AddCustomer(Customer c)
        {
            throw new NotImplementedException();
        }

        public long AddVehicle(Vehicle v)
        {
            throw new NotImplementedException();
        }
    }
}
