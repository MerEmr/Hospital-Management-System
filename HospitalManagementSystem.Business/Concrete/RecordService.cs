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
    public class RecordService : IRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Record entity)
        {
            try
            {
                _unitOfWork.Records.Add(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<Record> GetAll()
        {
            try
            {
                var recordList = _unitOfWork.Records.GetAll();
                return recordList;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public Record GetById(int id)
        {
            try
            {
                var record = _unitOfWork.Records.GetById(id);
                return record;
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
                var record = _unitOfWork.Records.Find(x => x.Id == id);
                if (record != null)
                {
                    _unitOfWork.Records.Remove(record);
                    _unitOfWork.Save();
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public void Update(Record entity)
        {
            try
            {
                var record = _unitOfWork.Records.Find(x => x.Id == entity.Id);
                if (record != null)
                {
                    entity.Id = record.Id;
                    entity.Address = record.Address;
                    entity.InsuranceNumber = record.InsuranceNumber;
                    entity.PhoneNumber = record.PhoneNumber;
                    entity.Allergy = record.Allergy;
                    entity.BloodType = record.BloodType;
                    entity.City = record.City;
                    entity.UserId = record.UserId;

                }
                _unitOfWork.Records.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }
    }
}
