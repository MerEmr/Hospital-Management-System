using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Abstract
{
    public interface IUnitOfWork
<<<<<<< HEAD
    {
=======
    { 
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
        IAppointmentRepository Appointments { get; }
        IRecordRepository Records { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }

        void Save();
    }
}
