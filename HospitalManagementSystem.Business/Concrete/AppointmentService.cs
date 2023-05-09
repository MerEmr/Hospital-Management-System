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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Appointment entity)
        {
            try
            {
                _unitOfWork.Appointments.Add(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public IEnumerable<Appointment> GetAll()
        {
            try
            {
                var appointmentList = _unitOfWork.Appointments.GetAll();
                return appointmentList;
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public Appointment GetById(int id)
        {
            try
            {
                var appointment = _unitOfWork.Appointments.GetById(id);
                return appointment;
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
                var appointment = _unitOfWork.Appointments.Find(x => x.Id == id);
                if (appointment != null)
                {
                    _unitOfWork.Appointments.Remove(appointment);
                    _unitOfWork.Save();
                }
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }

        public void Update(Appointment entity)
        {
            try
            {
                var appointment = _unitOfWork.Appointments.Find(x => x.Id == entity.Id);
                if (appointment != null)
                {
                    entity.Id = appointment.Id;
                    entity.Name = appointment.Name;
                    entity.UserId = appointment.UserId;
                    entity.DateOfAppointment = appointment.DateOfAppointment;
                    entity.Description = appointment.Description;
                    entity.DoctorId = appointment.DoctorId;
                   
                }
                _unitOfWork.Appointments.Update(entity);
                _unitOfWork.Save();
            }
            catch (Exception excep)
            {
                throw new Exception("Hata oluştu: " + excep.Message);
            }
        }
    }
}
