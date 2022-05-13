using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.ViewModel
{

    /// <summary>
    /// Stores the model of the customer vehicle, link to Manufacturer
    /// </summary>
    public class ModelVM
    {


        public ModelVM()
        {
        }

        public long Id;

        public ManufacturerVM Manufacturer;

        public long Name;


        public List<ColourVM> AvailableColours;
    }
}