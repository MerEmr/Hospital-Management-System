using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class PatientController : Controller
    {
        public IActionResult PatientList()
        {
            return View();
        }
        public IActionResult PatientOperations()
        {
            return View();
        }
    }
}
