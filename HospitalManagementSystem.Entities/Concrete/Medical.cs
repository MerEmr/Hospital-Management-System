﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities.Concrete
{
    public class Medical
    {
        public int Id { get; set; }
        public string? Medication { get; set; }
        public string ?Diagnosis { get; set; }
        public string? Description { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
