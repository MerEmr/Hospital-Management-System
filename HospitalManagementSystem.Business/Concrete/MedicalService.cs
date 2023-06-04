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
    public class MedicalService : IMedicalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MedicalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Medical entity)
        {
            try
            {
                _unitOfWork.Medicals.Add(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<Medical> GetAll()
        {
            try
            {
                var medicalList = _unitOfWork.Medicals.GetAll();
                return medicalList;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public Medical GetById(int id)
        {
            try
            {
                var medical = _unitOfWork.Medicals.GetById(id);
                return medical;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public List<Medical> GetByUserId(int id)
        {
            try
            {
                var medical = _unitOfWork.Medicals.List(x => x.UserId == id,y=>y.User!);
                return medical!;
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
                var medical = _unitOfWork.Medicals.Find(x => x.Id == id);
                if (medical != null)
                {
                    _unitOfWork.Medicals.Remove(medical);
                    _unitOfWork.Save();
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public void Update(Medical entity)
        {
            try
            {
                var medical = _unitOfWork.Medicals.Find(x => x.Id == entity.Id);
                if (medical != null)
                {
                    medical.Id = entity.Id;
                    medical.Medication = entity.Medication;
                    medical.Diagnosis = entity.Diagnosis;
                    medical.Description = entity.Description;


                }
                _unitOfWork.Medicals.Update(medical);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }
    }
}
