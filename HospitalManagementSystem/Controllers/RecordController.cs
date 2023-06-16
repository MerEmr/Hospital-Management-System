using HospitalManagementSystem.Core.Abstract.Services;
using HospitalManagementSystem.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.UI.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _recordService;
        private readonly IUserService _userService;

        public RecordController(IRecordService recordService,IUserService userService)
        {
            _recordService = recordService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAll()
        {
            var recordList = _recordService.GetAll();
            return View(recordList);
        }

        [HttpGet]
        public IActionResult AddRecord()
        {
            ViewBag.User = _userService.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult AddRecord(Record record)
        {
            try
            {
                if (record !=null)
                {
                    _recordService.Add(record);
                }
                return RedirectToAction("");  
            }
            catch (Exception)
            {

                throw;
            }
        }

     


    }
}
