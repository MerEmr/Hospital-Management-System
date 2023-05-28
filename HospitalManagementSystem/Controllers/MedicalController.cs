using HospitalManagementSystem.Core.Abstract.Services;
using HospitalManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class MedicalController : Controller
    {

        private readonly IMedicalService _medicalService;

        public MedicalController(IMedicalService medicalService)
        {
            _medicalService = medicalService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var medicalList = _medicalService.GetAll();
            return View(medicalList);
        }


        [HttpGet]
        public IActionResult AddMedical()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMedical(Medical medical)
        {
            if (medical != null)
            {
                _medicalService.Add(medical);
            }
            return RedirectToAction("Index", "Patient");
        }


        public IActionResult HistoryByUser(int id)
        {
            var medicalHistory = _medicalService.GetByUserId(id);
            return View(medicalHistory);
        }
    }
}
