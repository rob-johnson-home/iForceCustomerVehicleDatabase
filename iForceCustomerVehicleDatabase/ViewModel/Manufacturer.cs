using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iForceCustomerVehicleDatabase.ViewModel
{
    /// <summary>
    /// Recordds the Manufacturer of the vehicle
    /// </summary>
    public class ManufacturerVM
    {

        public ManufacturerVM()
        {
        }
        public long Id;

        public string Name;

    }
}