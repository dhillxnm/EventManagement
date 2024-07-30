using EventManagement.Models;

namespace EventManagement.DAL
{
    public class EventTableDAL
    {
        private readonly EventManagementDatabaseContext _context;

        public EventTableDAL(EventManagementDatabaseContext context)
        {
            _context = context;
        }

        public List<EventTable> GetEvents()
        {
            return _context.EventTables.ToList();
        }

        public void AddEvent(EventTable eventTable)
        {
            _context.EventTables.Add(eventTable);
            _context.SaveChanges();
        }

        public void DeleteEvent(int eventId)
        {
            var eventToDelete = _context.EventTables.Find(eventId);
            if (eventToDelete != null)
            {
                _context.EventTables.Remove(eventToDelete);
                _context.SaveChanges();
            }
        }

        //public void UpdateEvent(EventTable eventTable)
        //{
        //    _context.EventTables.Update(eventTable);
        //    _context.SaveChanges();
        //}
    }
}
