using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace iForceCustomerVehicleDatabase.CustomerVehicleModel
{

    /// <summary>
    /// records the customers
    /// </summary>
    [Table("Customer")]
    public class Customer
    {

        public void Setup(long id, string forename, string surname, DateTime dob)
        {
            this.Id = id;
            this.Forename = forename;
            this.Surname = surname;
            this.DOB = dob;
        }

        public Customer()
        {

        }

        /// <summary>
        /// Constructor with simple validation checks
        /// CustomerId,Forename,Surname,DateOfBirth
        /// </summary>
        /// <param name="values"></param>
        public Customer(string[] values)
        {
            long customerId;
            DateTime dob;
            if (long.TryParse(values[0], out customerId)  && DateTime.TryParse(values[3], out dob))
            {
                Setup(customerId, values[1], values[2], dob);
            }
            else
            {
                throw new Exception("Invalid data supplied");
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

        private List<Vehicle> _Vehicles;

        public List<Vehicle> Vehicles
        {
            get
            {
                if (_Vehicles == null) _Vehicles = new List<Vehicle>();
                return _Vehicles;
            }
            set
            {
                _Vehicles = value;
            }
        }





    }


}