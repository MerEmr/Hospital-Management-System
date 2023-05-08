using HospitalManagementSystem.Core.Abstract;
using HospitalManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(HospitalDbContext dbContext ): base( dbContext )
        {
<<<<<<< HEAD

=======
             
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
        }
    }
}
