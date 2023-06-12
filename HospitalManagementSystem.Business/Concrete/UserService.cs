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
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(User entity)
        {
            try
            {
                _unitOfWork.Users.Add(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var userList = _unitOfWork.Users.GetAll(x=>x.Role!);
                return userList;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public User GetById(int id)
        {
            try
            {
                var user = _unitOfWork.Users.GetById(id);
                return user;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public User GetByMail(string mail)
        {
            try
            {
                var user = _unitOfWork.Users.Find(x=>x.Mail == mail );
                return user;
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
                var user = _unitOfWork.Users.Find(x => x.Id == id);
                if (user != null)
                {
                    _unitOfWork.Users.Remove(user);
                    _unitOfWork.Save();
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public void Update(User entity)
        {
            try
            {
                var user = _unitOfWork.Users.Find(x => x.Id == entity.Id);
                if (user != null)
                {
                    entity.Id = user.Id;
                    entity.RoleId = user.RoleId;
                    entity.TCIdNo = user.TCIdNo;
                    entity.FirstName = user.FirstName;
                    entity.LastName = user.LastName;
                    entity.Mail = user.Mail;
                    entity.Password = user.Password;

                }
                _unitOfWork.Users.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }
    }
}
