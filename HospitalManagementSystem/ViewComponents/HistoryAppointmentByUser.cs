using HospitalManagementSystem.Core.Abstract.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.ViewComponents
{
    public class HistoryAppointmentByUser: ViewComponent
    {
        private readonly IAppointmentService _appointmentService;

        public HistoryAppointmentByUser(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IViewComponentResult Invoke()
        {

            var historyAppointment = _appointmentService.GetAll();
            return View(historyAppointment);
        }
    }
}
