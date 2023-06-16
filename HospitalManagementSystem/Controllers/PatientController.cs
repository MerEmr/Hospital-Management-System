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
   

        public PatientController(HospitalDbContext hospitalDbContext, IUserService userService)
        {
            this.hospitalDbContext = hospitalDbContext;
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
        public async Task<IActionResult> Add(User addPatientRequest)
        {
            var Patient = new User()
            {
                Id = addPatientRequest.Id,
                FirstName = addPatientRequest.FirstName,
                LastName = addPatientRequest.LastName,
                Password = addPatientRequest.Password,
                Mail = addPatientRequest.Mail,
                TCIdNo = addPatientRequest.TCIdNo,
                RoleId =3,
            };
            await hospitalDbContext.Users.AddAsync(Patient);
            await hospitalDbContext.SaveChangesAsync();

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
        public async Task < IActionResult> Delete(UpdateModel model)
        {
            var Patient = await hospitalDbContext.Users.FindAsync(model.Id);
            if (Patient != null)
            {
                hospitalDbContext.Users.Remove(Patient);
               await hospitalDbContext.SaveChangesAsync();
                return RedirectToAction("PatientList");
            }
        
            return RedirectToAction("PatientList");
        
            
        }
        

    }
}
