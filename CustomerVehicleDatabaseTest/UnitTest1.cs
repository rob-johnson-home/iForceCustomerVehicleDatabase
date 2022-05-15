using AutoMapper;
using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using iForceCustomerVehicleDatabase.Repository;
using iForceCustomerVehicleDatabase.Service;
using iForceCustomerVehicleDatabase.Utils;
using iForceCustomerVehicleDatabase.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CustomerVehicleDatabaseTest
{
    [TestClass]
    public class UnitTest1
    {


        //test creating a customer
        [TestMethod]
        public void CreateCustomer()
        {

            var id = "1";
            var forename = "Rob";
            var surname = "Johnson";
            var DOB = "01/01/2000";
            DateTime parsedDate = DateTime.Parse(DOB);

            var input = new string[] { id, forename, surname, DOB };

            Customer c = new Customer(input);

            Assert.AreEqual(c.Forename, forename);
            Assert.AreEqual(c.Surname, surname);
            Assert.AreEqual(c.DOB, parsedDate);




        }

        //test creating a vehicle
        [TestMethod]
        public void CreateVehicle()
        {

            var id = "1";
            var model = "Golf";
            var manufacturer = "VW";
            var registrationNumber = "ABC123";
            var registrationDate = "01/01/2000";
            var interiorColour = "Red";
            var engineSize = "1.5";

            var input = new string[] { id, registrationNumber, manufacturer, model, engineSize, registrationDate, interiorColour };
            Vehicle v = new Vehicle(input);

            DateTime parsedDate = DateTime.Parse(registrationDate);
            long parsedId = long.Parse(id);
            int parsedEngineSize = (int)(decimal.Parse(engineSize) * 1000);

            Assert.AreEqual(v.Id, parsedId);
            Assert.AreEqual(v.RegistrationNumber, registrationNumber);
            Assert.AreEqual(v.RegistrationDate, parsedDate);
            Assert.AreEqual(v.Manufacturer, manufacturer);
            Assert.AreEqual(v.Model, model);
            Assert.AreEqual(v.InteriorColour, interiorColour);
            Assert.AreEqual(v.EngineSize, parsedEngineSize);



        }

        //test adding a vehicle to a customer
        [TestMethod]
        public void AddVehicleToCustomer()
        {

            Vehicle v = new Vehicle();
            v.Id = 1;
            v.Model = "Golf";
            v.Manufacturer = "VW";
            v.RegistrationNumber = "ABC123";
            v.RegistrationDate = DateTime.Today;
            v.InteriorColour = "Red";
            v.EngineSize = 1100;

            Customer c = new Customer();
            c.Id = 1;
            c.Forename = "Rob";
            c.Surname = "Johnson";
            c.DOB = DateTime.Today;

            c.Vehicles.Add(v);

            Assert.AreEqual(c.Vehicles.Count, 1);



        }

        //test adding 2 vehicle s to a customer
        [TestMethod]
        public void AddTwoVehiclesToCustomer()
        {
            Vehicle v = new Vehicle();
            v.Id = 1;
            v.Model = "Golf";
            v.Manufacturer = "VW";
            v.RegistrationNumber = "ABC123";
            v.RegistrationDate = DateTime.Today;
            v.InteriorColour = "Red";
            v.EngineSize = 1100;

            Vehicle vv = new Vehicle();
            vv.Id = 2;
            vv.Model = "Golf";
            vv.Manufacturer = "VW";
            vv.RegistrationNumber = "ABC123";
            vv.RegistrationDate = DateTime.Today;
            vv.InteriorColour = "Red";
            v.EngineSize = 1500;

            Customer c = new Customer();
            c.Id = 1;
            c.Forename = "Rob";
            c.Surname = "Johnson";
            c.DOB = DateTime.Today;

            c.Vehicles.Add(v);
            c.Vehicles.Add(vv);

            Assert.AreEqual(c.Vehicles.Count, 2);

        }

        //test customer repo 1
        [TestMethod]
        public void CustomerRepo1()
        {
            
            Customer c = new Customer();
            c.Id = 1;
            c.Forename = "Rob";
            c.Surname = "Johnson";
            c.DOB = DateTime.Today;

            Customer cc = new Customer();
            c.Id = 2;
            c.Forename = "Sue";
            c.Surname = "Johnson";
            c.DOB = DateTime.Today;

            var customerSet = new List<Customer> { c,cc}.AsQueryable();

            var mockSet = new Mock<DbSet<Customer>>();
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Provider).Returns(customerSet.Provider);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.Expression).Returns(customerSet.Expression);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.ElementType).Returns(customerSet.ElementType);
            mockSet.As<IQueryable<Customer>>().Setup(m => m.GetEnumerator()).Returns(customerSet.GetEnumerator());


            Mock<ICustomerVehicleDatabaseDbContext> _context = new Mock<ICustomerVehicleDatabaseDbContext>();

            _context.Setup(c => c.Customers).Returns(mockSet.Object);

             CustomerRepo _repo = new CustomerRepo(_context.Object);

            var customers = _repo.GetCustomers();

            Assert.AreEqual(customers.Count, 2);

        }

    }
}
