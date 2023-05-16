using HospitalManagementSystem.DataAccess.Concrete;
using HospitalManagementSystem.Entities.Concrete;
using HospitalManagementSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Controllers
{
    public class DoctorController : Controller
    {
        private readonly HospitalDbContext hospitalDbContext;

        public DoctorController(HospitalDbContext hospitalDbContext)
        {
            this.hospitalDbContext= hospitalDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> DoctorList()
        {
            var doctors = await hospitalDbContext.Users
                .Where(u => u.RoleId == 1)
                .ToListAsync();

            
            return View(doctors);
        }


        public IActionResult DoctorOperations()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(User addDoctorRequest)
        {
            if (string.IsNullOrWhiteSpace(addDoctorRequest.FirstName) ||
                string.IsNullOrWhiteSpace(addDoctorRequest.LastName) ||
                string.IsNullOrWhiteSpace(addDoctorRequest.Mail))
            {
                ViewBag.ErrorMessage = "Lütfen boşlukları doldurunuz.";
                return View("DoctorOperations");
            }
            else
            {
                var doctor = new User()
                {
                    Id = addDoctorRequest.Id,
                    FirstName = addDoctorRequest.FirstName,
                    LastName = addDoctorRequest.LastName,
                    Password = addDoctorRequest.Password,
                    Mail = addDoctorRequest.Mail,
                    TCIdNo = addDoctorRequest.TCIdNo,
                    RoleId = 1,
                };

                await hospitalDbContext.Users.AddAsync(doctor);
                await hospitalDbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Kayıt Başarılı";
                return RedirectToAction("DoctorOperations");
            }
        }


    }
}
