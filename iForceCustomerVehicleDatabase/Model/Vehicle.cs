using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.CustomerVehicleModel
{

    [Table("Vehicle")]
    public class Vehicle
    {

        public void Setup(long id, string registrationNumber, string manufacturer, string model,
            int engineSize, DateTime registationDate, string interiorColour)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.EngineSize = engineSize;
            this.RegistrationNumber = registrationNumber;
            this.RegistrationDate = registationDate;
            this.InteriorColour = interiorColour;
        }

        public Vehicle()
        {

        }

        /// <summary>
        /// Constructor with simple validation checks
        /// VehicleId,RegistrationNumber,Manufacturer,Model,EngineSize,RegistationDate,InteriorColour
        /// </summary>
        /// <param name="values"></param>
        public Vehicle(string[] values)
        {
            long Id;
            DateTime regDate;
            int engineSize;
            decimal inputEngineSize;
            if (long.TryParse(values[0], out Id) && DateTime.TryParse(values[5], out regDate) && decimal.TryParse(values[4], out inputEngineSize))
            {
                engineSize = (int)(1000 * inputEngineSize);
                Setup(Id, values[1], values[2], values[3],engineSize,regDate, values[6]);
            }
            else
            {
                throw new Exception("Invalid data supplied");
            }
        }

        public Vehicle(Customer customer,long vehicleId, string registrationNumber, DateTime registationDate, 
            string manufacturer,
            string model, int engineSize, string interiorColour)
        {
            this.Customer = customer;
            this.Id = vehicleId;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.EngineSize = engineSize;
            this.RegistrationNumber = registrationNumber;
            this.RegistrationDate = registationDate;
            this.InteriorColour = interiorColour;
        }


        [Column(TypeName = "varchar(255)")]
        public string Manufacturer;
        [Column(TypeName = "int")]
        public int EngineSize;
        [Column(TypeName = "varchar(255)")]
        public string Model;
        [Column(TypeName = "varchar(255)")]
        public string RegistrationNumber;
        [Column(TypeName = "smalldatetime")]
        public DateTime RegistrationDate;
        [Column(TypeName = "varchar(255)")]
        public string InteriorColour;

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;

        [ForeignKey("Customer")]
        public long CustomerId;
        public Customer Customer;

    }
}