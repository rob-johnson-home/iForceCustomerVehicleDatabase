using iForceCustomerVehicleDatabase.ViewModel;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.Service
{
    /// <summary>
    /// All business goes here. dont return model objects, only DTOs please.
    /// 
    /// </summary>
    public interface ICustomerVehicleService
    {
        Task<List<CustomerVM>> GetCustomers();
        Task<bool> LoadCustomerVehicleDataSet(IFormFile file);
    }
}