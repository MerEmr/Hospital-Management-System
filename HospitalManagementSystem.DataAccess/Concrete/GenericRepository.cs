using HospitalManagementSystem.Core.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.DataAccess.Concrete
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected HospitalDbContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(HospitalDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
<<<<<<< HEAD

=======
         
>>>>>>> bfe4dc2e8bc79b5b2b64fc7f8d9ed8518390f4ff
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T? Find(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _dbSet.FirstOrDefault(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id)!;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
