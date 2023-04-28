using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Core.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        T? Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void Remove(T entity);
        void Update(T entity);
    }
}
