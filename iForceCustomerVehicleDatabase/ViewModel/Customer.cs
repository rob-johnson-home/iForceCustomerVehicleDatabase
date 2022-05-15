
using System;
using System.Collections.Generic;

/// <summary>
/// records the customers
/// </summary>
namespace iForceCustomerVehicleDatabase.ViewModel
{
    public class CustomerVM
    {

        public CustomerVM()
        {
        }

        public string Forename;
        public string Surname;
        public DateTime DOB;
        public long Id;
        public List<VehicleVM> Vehicle;

    }
}