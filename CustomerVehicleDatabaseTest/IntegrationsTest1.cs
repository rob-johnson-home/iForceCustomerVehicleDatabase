using AutoMapper;
using iForceCustomerVehicleDatabase.CustomerVehicleModel;
using iForceCustomerVehicleDatabase.Repository;
using iForceCustomerVehicleDatabase.Service;
using iForceCustomerVehicleDatabase.Utils;
using iForceCustomerVehicleDatabase.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace CustomerVehicleDatabaseTest
{
    [TestClass]
    public class IntegrationTest1
    {
        

        //check to see if the convert actually returns a list of customers
        [TestMethod]
        public void SimpleDataSetUploadTest()
        {
            var csvConverter = new CSVConverter();
            System.IO.MemoryStream inputDataStream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(demoData));
            var result = csvConverter.ReadAndDigestCustomersFromCsv(inputDataStream);
            Assert.IsInstanceOfType(result, typeof (List<Customer>));
            Assert.AreEqual(result.Count, 12);

        }

        // here's some demo data
        private string demoData => 
@"CustomerId,Forename,Surname,DateOfBirth,VehicleId,RegistrationNumber,Manufacturer,Model,EngineSize,RegistationDate,InteriorColour
1,Joe,Bloggs,1983-04-08,1,BJ07 YUK, Renault, Clio,1290,2007-02-28, Cream
1, Joe, Bloggs,1983-04-08,7, BJ12 UUY,Renault,Twingo,1190,2012-03-12,Grey
2,Jane,Doe,1979-09-04,2,BT58 OKJ, Ford, Fiesta,1187,2008-10-03, Black
3, Bob, Smith,1992-10-27,3, BJ53 WYR,Peugeot,108,987,2003-07-03,Grey
4,Kate,Jones,1990-12-09,4,BT12 UJJ, Renault, Clio,1190,2012-05-03, Grey
5, Ann, Banks,1987-03-10,5, BJ16 OIU,Citroen,C3,1298,2016-02-20,Black
6,Jeff,Hope,1963-01-19,6,BT15 PLM, Renault, Megane,1380,2015-04-04, Cream
7, Peter, SMith,1969-08-10,7, OW06 TTR,Ford,Focus,1200,2006-03-02,Red
6,Jeff,Hope,1963-01-19,8,PS12 PLK, Audi, A6,2000,2012-09-17, Black
6, Jeff, Hope,1963-01-19,9, SE13 CFG,Audi,A1,1610,2013-03-09,Silver
6,Jeff,Hope,1963-01-19,10,KL16 KMN, Renault, Megane,1380,2015-07-03, White
6, Jeff, Hope,1963-01-19,11, FD10 MMW,Renault,Megane,1380,2015-10-28,Grey";
    }
}
