using Appointment_System.Controllers;
using Appointment_System.Data;
using Appointment_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Appointment_System_Tests
{
    [TestClass]
    public class AppointmentsControllerTests
    {
        private ApplicationDbContext _context;
        AppointmentsController controller;

        // Initialize Mock Data to Use in Tests
        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            // new admin object
            var admin = new Admin
            {
                AdminId = 1000,
                Initials = "TT",
                Username = "TestAdmin",
                Password = "Test@123"
            };
            _context.Admins.Add(admin);

            // new appointment objects
            var appointment = new Appointment
            {
                AppointmentID = 1000,
                FirstName = "First Name",
                LastName = "Last Name",
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                City = "Barrie",
                Province = "ON",
                PostalCode = "L1N 6J3",
                PhoneNumber = 1234567890,
                BookingDateTime = DateTime.Now,
                Initials = admin.Initials,
                AdminId = admin.AdminId
            };
            _context.Appointments.Add(appointment);

            appointment = new Appointment
            {
                AppointmentID = 1001,
                FirstName = "First Name",
                LastName = "Last Name",
                AddressLine1 = "Address Line 1",
                AddressLine2 = "Address Line 2",
                City = "Barrie",
                Province = "ON",
                PostalCode = "L1N 6J3",
                PhoneNumber = 1234567890,
                BookingDateTime = DateTime.Now,
                Initials = admin.Initials,
                AdminId = admin.AdminId
            };
            _context.Appointments.Add(appointment);

            // saving _context after adding an admin and two apoointments
            _context.SaveChanges();

            controller = new AppointmentsController(_context);

        }


        // this region has a few tests for DELETE (GET) in Apoointments Controller
        #region Delete_Get

        // This Test Method checks wether the Enetered parameter Appointment Id is null then it loads 404
        [TestMethod]
        public void DeleteNullIdLoads404()
        {
            var result = (ViewResult)controller.Delete(null).Result;
            Assert.AreEqual("404",result.ViewName);
        }

        // This Test Method Checks if the entered Appointment Id is not valid then it loads 404
        [TestMethod]
        public void DeleteInvalidIdLoads404()
        {
            var result = (ViewResult)controller.Delete(22222).Result;
            Assert.AreEqual("404", result.ViewName);
        }

        // This Test Method Checks if the entered Appointment Id is valid then it loads Delete View
        [TestMethod]
        public void DeleteValidIdDeletesAppointment()
        {
            var result = (ViewResult)controller.Delete(1000).Result;
            Assert.AreEqual("Delete", result.ViewName);
        }

        // This Test Method Checks if the entered Appointment Id is valid then it targets that Exact Apoointment
        [TestMethod]
        public void ValidIdRetrievesExactAppointment()
        {
            var result = (ViewResult)controller.Delete(1001).Result;
            Assert.AreEqual(_context.Appointments.Find(1001),result.Model);
        }

        // This Test Method Checks if the entered Appointment Id is valid then it doesn't target any other Appointment
        [TestMethod]
        public void ValidIdsButNotExactApoointments()
        {
            var result = (ViewResult)controller.Delete(1001).Result;
            Assert.AreNotEqual(_context.Appointments.Find(1000), result.Model);
        }

        #endregion
    }
}
