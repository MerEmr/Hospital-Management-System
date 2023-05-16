using HospitalManagementSystem.DataAccess.Concrete;
using HospitalManagementSystem.Entities.Concrete;
using HospitalManagementSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.UI.Controllers
{
    public class PatientController : Controller
    {
        private readonly HospitalDbContext hospitalDbContext;

        public PatientController(HospitalDbContext hospitalDbContext)
        {
            this.hospitalDbContext = hospitalDbContext;
        }
        [HttpGet]
        public async Task<IActionResult> PatientList()
        {
            var patients = await hospitalDbContext.Users
                .Where(u => u.RoleId == 3 ) // Filter by RoleId == 3
                .ToListAsync();
          
            return View(patients);
        }
        public IActionResult PatientOperations()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserModel addUserRequest)
        {
            if (string.IsNullOrWhiteSpace(addUserRequest.Firstname) ||
                string.IsNullOrWhiteSpace(addUserRequest.Lastname) ||
                string.IsNullOrWhiteSpace(addUserRequest.Mail))
            {
                ViewBag.ErrorMessage = "Lütfen boşlukları doldurunuz.";
                return View("PatientOperations");
            }
            else
            {
                var doctor = new User()
                {
                    Id = addUserRequest.Id,
                    FirstName = addUserRequest.Firstname,
                    LastName = addUserRequest.Lastname,
                    Password = addUserRequest.Password,
                    Mail = addUserRequest.Mail,
                    TCIdNo = addUserRequest.TcIdNo,
                    RoleId = 3,
                };

                await hospitalDbContext.Users.AddAsync(doctor);
                await hospitalDbContext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Kayıt Başarılı";
                return RedirectToAction("PatientOperations");
            }
        }

    }
}
