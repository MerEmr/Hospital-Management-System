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

        [HttpGet]
        public async Task<IActionResult> PersonalView(int id)
        {
            var patient = await hospitalDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (patient != null)
            {
                var viewModel = new UpdateModel()
                {
                    Id = patient.Id,
                    Firstname = patient.FirstName,
                    Lastname = patient.LastName,
                    Mail = patient.Mail,
                    TcIdNo = (int)patient.TCIdNo,
                    RoleId = 2,
                };
                return await Task.Run(() => View("PersonalView", (viewModel)));
            }

            return RedirectToAction("PersonalList");
        }
        [HttpPost]
        public async Task<IActionResult> PersonalView(UpdateModel model)
        {
            var patient = await hospitalDbContext.Users.FindAsync(model.Id);
            if (patient != null)
            {
                patient.FirstName = model.Firstname;
                patient.LastName = model.Lastname;
                patient.Mail = model.Mail;
                patient.TCIdNo = model.TcIdNo;
                await hospitalDbContext.SaveChangesAsync();
                HttpContext.Session.SetString("SuccessMessage", "Güncelleme başarıyla tamamlandı!");
                return RedirectToAction("PersonalList");
            }

            return RedirectToAction("PersonalList");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(UpdateModel model)
        {
            var doctor = hospitalDbContext.Users.Find(model.Id);
            if (doctor != null)
            {
                hospitalDbContext.Users.Remove(doctor);
                await hospitalDbContext.SaveChangesAsync();
                return RedirectToAction("PersonalList");
            }
            return RedirectToAction("PersonalList");

        }
    }
}
