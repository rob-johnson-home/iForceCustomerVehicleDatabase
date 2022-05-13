using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iForceCustomerVehicleDatabase.Model
{

    /// <summary>
    /// records the customers
    /// </summary>
    [Table("Customer")]
    public class Customer
    {

        public void Setup(long id, string forename, string surname,
            string dateOfBirth, long vehicleId, string registrationNumber, string manufacturer, string model,
            string engineSize, string registationDate, string interiorColour)
        {
            this.Id = id;
            this.Forename = forename;
            this.Surname = surname;
            this.DOB = DateTime.Parse(dateOfBirth);
            this.Vehicle = new Vehicle(this, vehicleId, registrationNumber, registationDate, manufacturer, model, engineSize, interiorColour);
        }

        public Customer(string[] values)
        {
            long customerId, vehicleId;
            if (long.TryParse(values[0], out customerId) && long.TryParse(values[4], out vehicleId))
            {
                Setup(customerId, values[1], values[2], values[3], vehicleId, values[5], values[6], values[7], values[8], values[9], values[10]);
            }
            else
            {
                throw new Exception("Invalid customer id supplied");
            }
        }

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;
        [Column(TypeName = "varchar(255)")]
        public string Forename;
        [Column(TypeName = "varchar(255)")]
        public string Surname;
        [Column(TypeName = "smalldatetime")]
        public DateTime DOB;

        [ForeignKey("Vehicle")]
        public long VehicleId;
        public Vehicle Vehicle;


    }


}