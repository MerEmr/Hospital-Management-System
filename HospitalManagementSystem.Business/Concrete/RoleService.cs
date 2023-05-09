using HospitalManagementSystem.Core.Abstract;
using HospitalManagementSystem.Core.Abstract.Services;
using HospitalManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Business.Concrete
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RoleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Role entity)
        {
            try
            {
                _unitOfWork.Roles.Add(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<Role> GetAll()
        {
            try
            {
                var roleList = _unitOfWork.Roles.GetAll();
                return roleList;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public Role GetById(int id)
        {
            try
            {
                var role = _unitOfWork.Roles.GetById(id);
                return role;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }


        public void Remove(int id)
        {
            try
            {
                var role = _unitOfWork.Roles.Find(x => x.Id == id);
                if (role != null)
                {
                    _unitOfWork.Roles.Remove(role);
                    _unitOfWork.Save();
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public void Update(Role entity)
        {
            try
            {
                var role = _unitOfWork.Roles.Find(x => x.Id == entity.Id);
                if (role != null)
                {
                    entity.Id = role.Id;
                    entity.Name = role.Name;
                 

                }
                _unitOfWork.Roles.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }
    }
}
