using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Abstract
{
    public interface IUnitOfWork
    { 
        IAppointmentRepository Appointments { get; }
        IRecordRepository Records { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        void Save();
    }
}
