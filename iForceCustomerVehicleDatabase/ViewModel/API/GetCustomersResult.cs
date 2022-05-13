using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iForceCustomerVehicleDatabase.ViewModel.API
{
    public class GetCustomersResult : BaseResult
    {
        public List<CustomerVM> customers { get; set; }
    }
}
