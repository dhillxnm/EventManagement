using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.BLL;


namespace EventManagement.Controllers
{
    public class RegistrationTableController : Controller
    {
        private readonly RegistrationTableService _registrationTableService;
        private readonly EventTableService _eventTableService;

        public RegistrationTableController(RegistrationTableService registrationTableService, EventTableService eventTableService)
        {
            _registrationTableService = registrationTableService;
            _eventTableService = eventTableService;
        }

        public IActionResult Index()
        {
            List<RegistrationTable> registrations = _registrationTableService.GetRegistrations();
            return View(registrations);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var events = _eventTableService.GetEvents();

            var combineView = new RegistrationTableViewModel
            {
                Events = events
            };

            return View(combineView);
        }

        [HttpPost]
        public IActionResult Create(RegistrationTableViewModel combineView)
        {
            if (ModelState.IsValid)
            {
                RegistrationTable newRegistration = new RegistrationTable
                {
                    ParticipateName = combineView.ParticipateName,
                    ParticipateEmail = combineView.ParticipateEmail,
                    ParticipateAddress = combineView.ParticipateAddress,
                    EventId = combineView.EventId
                };
                _registrationTableService.AddRegistration(newRegistration);
                return RedirectToAction("Index");
            }

            combineView.Events = _eventTableService.GetEvents();
            return View(combineView);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var registration = _registrationTableService.GetRegistrations().FirstOrDefault(r => r.RegistrationId == id);
                if (registration != null)
                {
                    return View(registration);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _registrationTableService.DeleteRegistration(id);
            return RedirectToAction("Index");
        }
    }
}
