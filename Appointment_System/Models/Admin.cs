using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Appointment_System.Models
{
    public class Admin
    {
        [Required()]
        public int AdminId { get; set; }

        [Required()]
        [StringLength(2)]
        public string Initials { get; set; }

        [Required()]
        public string Username { get; set; }

        [Required()]
        public string Password { get; set; }


        public List<Appointment> Appointments { get; set; }
    }
}
