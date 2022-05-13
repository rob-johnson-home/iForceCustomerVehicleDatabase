using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.Model
{

    [Table("Vehicle")]
    public class Vehicle
    {

        public Vehicle()
        {
        }

        public Vehicle(Customer customer,long vehicleId, string registrationNumber, string registationDate, 
            string manufacturer,
            string model, string engineSize, string interiorColour)
        {
            this.Customer = customer;
            this.Id = vehicleId;
            this.Model = new Model(manufacturer, model, engineSize);
            this.Registration = new Registration(registrationNumber, registationDate);
            this.InteriorColour = new Colour(interiorColour);
        }

  

        [ForeignKey("Model")]
        public long ModelId;
        public Model Model;

        [ForeignKey("Registration")]
        public long RegistrationId;
        public Registration Registration;

        [ForeignKey("InteriorColour")]
        public long InteriorColourId;
        public Colour InteriorColour;

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;

        [ForeignKey("Customer")]
        public long CustomerId;
        public Customer Customer;

    }
}