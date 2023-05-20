using HospitalManagementSystem.Core.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccess.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalDbContext _dbContext;

        public UnitOfWork(HospitalDbContext context)
        {
            _dbContext = context;
            Appointments = new AppointmentRepository(_dbContext);
            Records = new RecordRepository(_dbContext);
            Roles = new RoleRepository(_dbContext);
            Users = new UserRepository(_dbContext);
            Medicals = new MedicalRepository(_dbContext);
        }

        public IAppointmentRepository Appointments { get; private set; }

        public IRecordRepository Records { get; private set; }

        public IRoleRepository Roles { get; private set; }

        public IUserRepository Users { get; private set; }
        public IMedicalRepository Medicals { get; private set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
