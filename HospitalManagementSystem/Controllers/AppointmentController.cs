using HospitalManagementSystem.Core.Abstract.Services;
using HospitalManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddAppointment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAppointment(Appointment appointment)
        {
            if (appointment != null)
            {
                _appointmentService.Add(appointment);
            }
            return RedirectToAction("Index","Patient");
        }




        public IActionResult GetAll()
        {
            try
            {
                var appointmentList = _appointmentService.GetAll();
                if (appointmentList != null)
                {
                    return View(appointmentList);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }

        public IActionResult ConsultingList(int id)
        {
            try
            {
                var consulting = _appointmentService.GetByUserId(id);
                return View(consulting);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
