using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.Model
{
    /// <summary>
    /// records vehicle interior/exterior colours
    /// </summary>
    [Table("Colour")]
    public class Colour
    {

        public Colour()
        {
        }

        public Colour(string interiorColour)
        {
            this.Name = interiorColour;
        }

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;
        [Column(TypeName = "varchar(255)")]
        public string Name;


    }
}