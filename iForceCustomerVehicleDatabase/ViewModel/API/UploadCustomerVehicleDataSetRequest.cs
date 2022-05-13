using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.ViewModel.API
{
    public class UploadCustomerVehicleDataSetRequest : BaseRequest
    {
        public IFormFile file { get; set; }
    }
}
