using System;

namespace iForceCustomerVehicleDatabase.ViewModel
{
    public class VehicleVM
    {

        public VehicleVM()
        {
        }

        public string Manufacturer;
        public int EngineSize;
        public string Model;
        public string RegistrationNumber;
        public DateTime RegistrationDate;
        public string InteriorColour;


        public long Id;

        public long CustomerId;
        public CustomerVM Customer;


    }
}