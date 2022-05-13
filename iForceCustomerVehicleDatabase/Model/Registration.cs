
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace iForceCustomerVehicleDatabase.Model
{

    [Table("Registration")]
    public class Registration
    {

        public Registration()
        {
        }

        public Registration(string registrationNumber, string registationDate)
        {
            this.Number = registrationNumber;
            this.Date = DateTime.Parse(registationDate);
        }

        [Key]
        [Column(TypeName = "bigint")]
        public long Id;

        [Column(TypeName = "varchar(255)")]
        public string Number;

        [Column(TypeName = "smalldatetime")]
        public DateTime Date;


    }
}