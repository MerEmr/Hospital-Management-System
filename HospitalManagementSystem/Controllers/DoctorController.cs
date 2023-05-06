using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class DoctorController : Controller
    {
        public IActionResult DoctorList()
        {
            return View();
        }
        public IActionResult DoctorOperations()
        {
            return View();
        }
    }
}
