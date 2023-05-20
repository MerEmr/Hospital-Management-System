using HospitalManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Abstract.Services
{
    public interface IMedicalService : IGenericService<Medical>
    {
        Medical GetByUserId(int id);
    }
}
