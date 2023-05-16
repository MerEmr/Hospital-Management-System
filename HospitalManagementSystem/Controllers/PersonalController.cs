using HospitalManagementSystem.DataAccess.Concrete;
using HospitalManagementSystem.Entities.Concrete;
using HospitalManagementSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace HospitalManagementSystem.UI.Controllers
{
    public class PersonalController : Controller
    {
        private readonly HospitalDbContext hospitalDbContext;
        public PersonalController(HospitalDbContext hospitalDbContext)
        {
            this.hospitalDbContext=hospitalDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> PersonalList()
        {
            var personals = await hospitalDbContext.Users
                .Where(u => u.RoleId == 2) // Filter by RoleId == 2
                .ToListAsync();

            return View(personals);
        }

        public IActionResult PersonalOperations()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserModel addPersonalRequest)
        {

            if (string.IsNullOrWhiteSpace(addPersonalRequest.Firstname) ||
                string.IsNullOrWhiteSpace(addPersonalRequest.Lastname) ||
                string.IsNullOrWhiteSpace(addPersonalRequest.Mail))
            {
                ViewBag.ErrorMessage = "Lütfen boşlukları doldurunuz.";
                return View("PersonalOperations");
            }
            else
            {
                var personal = new User()
                {
                    Id = addPersonalRequest.Id,
                    FirstName = addPersonalRequest.Firstname,
                    LastName = addPersonalRequest.Lastname,
                    Password = addPersonalRequest.Password,
                    Mail = addPersonalRequest.Mail,
                    TCIdNo = addPersonalRequest.TcIdNo,
                    RoleId = 2,
                };

                await hospitalDbContext.Users.AddAsync(personal);
                await hospitalDbContext.SaveChangesAsync();

                TempData["SuccessMessage"] = "Kayıt Başarılı";
                return RedirectToAction("PersonalOperations");
            }
        }
    }
}
