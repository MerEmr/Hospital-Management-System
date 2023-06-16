using HospitalManagementSystem.DataAccess.Concrete;
using HospitalManagementSystem.Entities.Concrete;
using HospitalManagementSystem.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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


        [HttpGet]
        public async Task<IActionResult> View(int id)
        {
            var doctor =await hospitalDbContext.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (doctor != null)
            {
                var viewModel = new UpdateModel()
                {
                    Id = doctor.Id,
                    Firstname = doctor.FirstName,
                    Lastname = doctor.LastName,
                    Mail = doctor.Mail,
                    TcIdNo = (int)doctor.TCIdNo,
                    RoleId = 1,
                };
                return await Task.Run(() => View("View",(viewModel)));
            }
         
            return RedirectToAction("DoctorList");
        }
        [HttpPost]
        public async Task<IActionResult>View(UpdateModel model)
        {

            var doctor = await hospitalDbContext.Users.FindAsync(model.Id);
            if (doctor != null)
            {
                doctor.FirstName = model.Firstname;
                doctor.LastName = model.Lastname;
                doctor.Mail = model.Mail;
                doctor.TCIdNo = model.TcIdNo;
                await hospitalDbContext.SaveChangesAsync();
                return RedirectToAction("View");
            }

            HttpContext.Session.SetString("SuccessMessage", "Güncelleme başarıyla tamamlandı!");
            return RedirectToAction("View", new { id = doctor.Id });

        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateModel model)
        {
            var Doctor = await hospitalDbContext.Users.FindAsync(model.Id);
            if (Doctor != null)
            {
                hospitalDbContext.Users.Remove(Doctor);
                 await  hospitalDbContext.SaveChangesAsync();
                return  RedirectToAction("DoctorList");
            }
            return RedirectToAction("DoctorList");

        }



    }
}
