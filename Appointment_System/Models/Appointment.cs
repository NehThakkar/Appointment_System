using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_System.Models
{
    public class Appointment
    {
        [Required()]
        [Display(Name = "Appointment ID")]
        public int AppointmentID { get; set; }


        [Required()]
        [MinLength(2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required()]
        [MinLength(2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required()]
        [MinLength(2)]
        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required()]
        public string City { get; set; }


        public string Province { get; set; }

        public string PostalCode { get; set; }

        [Required()]
        [Display(Name = "Phone Number")]
        public double PhoneNumber { get; set; }

        [Required()]
        [Display(Name = "Choose a Date and Time")]
        public DateTime BookingDateTime { get; set; }

        [StringLength(2)]
        [Display(Name = "Admin Initials")]
        public string Initials { get; set; }

        [Required()]
        public int AdminId { get; set; }

        public Admin Admin { get; set; }
    }
}
