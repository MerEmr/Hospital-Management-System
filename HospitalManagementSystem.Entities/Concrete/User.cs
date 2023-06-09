﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Entities.Concrete
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Mail { get; set; }
        public int? TCIdNo { get; set; }

        public int RoleId { get; set; }
        public Role? Role { get; set; }

        public Record? Record { get; set; }

        public Medical? Medical { get; set; }

    }

}