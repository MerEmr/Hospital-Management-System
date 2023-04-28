using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities.Concrete
{
    public class Record
    {
        public int Id { get; set; }
        public int? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Address { get; set; }
        public int? InsuranceNumber { get; set; }
        public string? BloodType { get; set; }
        public string? Allergy { get; set; }



        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
