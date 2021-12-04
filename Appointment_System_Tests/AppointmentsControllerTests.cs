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


        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            _context = new ApplicationDbContext(options);

            var admin = new Admin
            {
                AdminId = 1000,
                Initials = "TT",
                Username = "TestAdmin",
                Password = "Test@123"
            };
            _context.Admins.Add(admin);

            var appointment1 = new Appointment
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
            _context.Appointments.Add(appointment1);

            var appointment2 = new Appointment
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
            _context.Appointments.Add(appointment2);

            _context.SaveChanges();

            controller = new AppointmentsController(_context);

        }

        #region Delete_Get_Tests
        [TestMethod]
        public void DeleteNullIdLoads404()
        {
            var result = (ViewResult)controller.Delete(null).Result;
            Assert.AreEqual("404",result.ViewName);
        }

        [TestMethod]
        public void DeleteInvalidIdLoads404()
        {
            var result = (ViewResult)controller.Delete(22222).Result;
            Assert.AreEqual("404", result.ViewName);
        }

        [TestMethod]
        public void DeleteValidDeletesAppointment()
        {
            var result = (ViewResult)controller.Delete(1000).Result;
            Assert.AreEqual("Delete", result.ViewName);
        }

        #endregion
    }
}
