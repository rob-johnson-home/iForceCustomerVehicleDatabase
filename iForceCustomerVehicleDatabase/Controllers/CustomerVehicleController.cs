using iForceCustomerVehicleDatabase.Service;
using iForceCustomerVehicleDatabase.ViewModel;
using iForceCustomerVehicleDatabase.ViewModel.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerVehicleController : ControllerBase
    {
        

        private readonly ILogger<CustomerVehicleController> _logger;
        private readonly ICustomerVehicleService _customerVehicleService;

        public CustomerVehicleController(ILogger<CustomerVehicleController> logger, ICustomerVehicleService customerVehicleService)
        {
            _logger = logger;
            _customerVehicleService = customerVehicleService;
        }

        /// <summary>
        /// get a list of all customers
        /// </summary>
        /// <returns></returns>
        [HttpGet("[action]", Name = "GetCustomers")]
        [Produces("application/json")]
        public async Task<GetCustomersResult> GetCustomers()
        {
            try
            {
                var rv = await _customerVehicleService.GetCustomers();
                return new GetCustomersResult
                {
                    Message = "Success",
                    Success = true,
                    customers = rv

                };
            } catch (Exception e)
            {
                return new GetCustomersResult
                {
                    Message = "Failure",
                    Success = false
                };
            }
            
        }

        /// <summary>
        /// upload a csv containing customer/ vehicle data
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("[action]", Name = "UploadCustomerVehicleDataSet")]
        [Consumes("multipart/form-data"), Produces("application/json")]
        public async Task<UploadCustomerVehicleDataSetResult> UploadCustomerVehicleDataSet(UploadCustomerVehicleDataSetRequest request)
        {
            if (request.file == null || request.file.Length == 0)
            {
                return new UploadCustomerVehicleDataSetResult
                {
                    Message = "Upload failure",
                    Success = false
                };
            }

            try
            {
                await _customerVehicleService.LoadCustomerVehicleDataSet(request.file);

                return new UploadCustomerVehicleDataSetResult
                {
                    Message = "Upload success",
                    Success = true

                };
            } catch (Exception e)
            {
                return new UploadCustomerVehicleDataSetResult
                {
                    Message = "Upload failed",
                    Success = false

                };
            }
            
        }
    }
}
