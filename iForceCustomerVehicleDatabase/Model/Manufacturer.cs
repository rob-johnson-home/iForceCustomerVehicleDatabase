using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.Model
{

    /// <summary>
    /// Recordds the Manufacturer of the vehicle
    /// </summary>
    [Table("Manufacturer")]
    public class Manufacturer
    {

        public Manufacturer()
        {
        }

        public Manufacturer(string manufacturer)
        {
            this.Name = manufacturer;
        }

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;

        [Column(TypeName = "varchar(255)")]
        public string Name;

    }
}