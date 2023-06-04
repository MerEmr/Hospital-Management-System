using HospitalManagementSystem.Core.Abstract.Services;
using HospitalManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

   

        [HttpPost]
        public IActionResult Login(User user)
        {
            var findUser = _userService.GetById(user.Id);
            
            if (findUser != null)
            {
                if (findUser.RoleId == 1) //Admin
                {
                    return RedirectToAction("Index","Admin");
                }
                else if (findUser.RoleId == 2)  //Doktor
                {
                    return RedirectToAction("GetAll", "Appointment");
                }
                else if (findUser.RoleId == 3) //Hasta
                {
                    return RedirectToAction("AddAppointment", "Appointment");
                }
               
            }

            return RedirectToAction("Login","Auth");
        }


        [HttpPost]
        public IActionResult Register(User user)
        {
            if (user != null)
            {
                user.RoleId = 3;
                _userService.Add(user);
            }
            return RedirectToAction("Login","Auth");
        }

    }
}
