using Microsoft.AspNetCore.Mvc;
using EventManagement.Models;
using EventManagement.BLL;

namespace EventManagement.Controllers
{
    public class EventTableController : Controller
    {

        private readonly EventTableService _eventTableService;

        public EventTableController(EventTableService eventTableService)
        {
            _eventTableService = eventTableService;
        }

        public IActionResult Index()
        {
            List<EventTable> events = _eventTableService.GetEvents();
            return View(events);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventTable events)
        {
            if (ModelState.IsValid)
            {
                EventTable newEvent = new EventTable
                {
                    EventName = events.EventName,
                    EventLocation = events.EventLocation,
                    EventParticipants = events.EventParticipants
                };
                _eventTableService.AddEvent(newEvent);
                return RedirectToAction("Index");
            }
            return View(events);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                var deleteEvent = _eventTableService.GetEvents().FirstOrDefault(e => e.EventId == id);
                if (deleteEvent != null)
                {
                    return View(deleteEvent);
                }
            }
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _eventTableService.DeleteEvent(id);
            return RedirectToAction("Index");
        }
    }
}
