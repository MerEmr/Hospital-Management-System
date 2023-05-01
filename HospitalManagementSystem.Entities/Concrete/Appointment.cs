using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities.Concrete
{
    public class Appointment
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateOfAppointment { get; set; }
        public string? Description { get; set; }

        public int DoctorId { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
