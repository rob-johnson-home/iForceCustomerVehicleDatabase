using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iForceCustomerVehicleDatabase.Model
{

    /// <summary>
    /// Stores the model of the customer vehicle, link to Manufacturer
    /// </summary>
    [Table("Model")]
    public class Model
    {

        public Model()
        {
        }

        public Model(string manufacturer, string model, string engineSize)
        {
            EngineSize = engineSize;
            Name = model;
            this.Manufacturer = new Manufacturer(manufacturer);
        }

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;

        [ForeignKey("Manufacurer")]
        public long ManufacturerId;
        public Manufacturer Manufacturer;

        [Column(TypeName = "varchar(255)")]
        public string Name;

        [Column(TypeName = "varchar(255)")]
        public string EngineSize;

        public List<Colour> AvailableColours;
    }
}
