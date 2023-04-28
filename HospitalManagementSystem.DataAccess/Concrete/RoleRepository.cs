using HospitalManagementSystem.Core.Abstract;
using HospitalManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccess.Concrete
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public RoleRepository(HospitalDbContext dbContext) : base(dbContext)
        {

        }
    }
}
