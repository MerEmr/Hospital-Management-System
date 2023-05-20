using HospitalManagementSystem.Core.Abstract.Services;
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

        public IActionResult HistoryByUser(int id)
        {
            var medicalHistory = _medicalService.GetByUserId(id);
            return View(medicalHistory);
        }
    }
}
