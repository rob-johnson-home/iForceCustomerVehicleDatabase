using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.Model
{
    /// <summary>
    /// Links models to colour as only some colours available for some models
    /// easy to find appropriate colour cobinations
    /// </summary>
    public class ModelColour
    {

        public ModelColour()
        {
        }

        [ForeignKey("Model")]
        public long ModelId;
        public Model Model;

        [ForeignKey("Colour")]
        public long ColourId;
        public Colour Colour;

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;

        [Column(TypeName = "varchar(255)")]
        public string Name;

    }
}
