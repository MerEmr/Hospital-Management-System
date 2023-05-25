using HospitalManagementSystem.Core.Abstract.Services;
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
        private readonly IUserService _userService;

        public PatientController(HospitalDbContext hospitalDbContext, IUserService userService)
        {
            this.hospitalDbContext = hospitalDbContext;
            this._userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> PatientList()
        {
            var patients = await hospitalDbContext.Users
                .Where(u => u.RoleId == 3) // Filter by RoleId == 3
                .ToListAsync();

            return View(patients);
        }
        public IActionResult PatientOperations()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            user.RoleId = 0;
            _userService.Add(user);
            TempData["SuccessMessage"] = "Kayıt Başarılı";
            return RedirectToAction("PatientOperations");

        }

        [HttpGet]
        public async Task<IActionResult> PatientView(int id)
        {
            var patient = await hospitalDbContext.Users!.FirstOrDefaultAsync(x => x.Id == id);
            if (patient != null)
            {
                var viewModel = new UpdateModel()
                {
                    Id = patient.Id,
                    Firstname = patient.FirstName,
                    Lastname = patient.LastName,
                    Mail = patient.Mail,
                    TcIdNo = (int)patient.TCIdNo,
                    RoleId = 1,
                };
                return await Task.Run(() => View("PatientView", (viewModel)));
            }

            return RedirectToAction("PatientList");
        }
        [HttpPost]
        public async Task<IActionResult> PatientView(UpdateModel model)
        {

            var patient = await hospitalDbContext.Users.FindAsync(model.Id);
            if (patient != null)
            {
                patient.FirstName = model.Firstname;
                patient.LastName = model.Lastname;
                patient.Mail = model.Mail;
                patient.TCIdNo = model.TcIdNo;
                await hospitalDbContext.SaveChangesAsync();
                return RedirectToAction("PatientView");
            }

            HttpContext.Session.SetString("SuccessMessage", "Güncelleme başarıyla tamamlandı!");
            return RedirectToAction("PatientView", new { id = patient.Id });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateModel model)
        {
            var doctor = hospitalDbContext.Users.Find(model.Id);
            if (doctor != null)
            {
                hospitalDbContext.Users.Remove(doctor);
                await hospitalDbContext.SaveChangesAsync();
                return RedirectToAction("PatientList");
            }
            return RedirectToAction("PatientList");

        }

    }
}
