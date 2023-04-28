using HospitalManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Abstract
{
    public interface IAppointmentRepository:IGenericRepository<Appointment>
    {
    }
}
