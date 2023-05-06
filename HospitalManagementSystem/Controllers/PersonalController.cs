using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class PersonalController : Controller
    {
        public IActionResult PersonalList()
        {
            return View();
        }

        public IActionResult PersonalOperations()
        {

            return View();
        }
    }
}
