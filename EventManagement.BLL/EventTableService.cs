using EventManagement.DAL;
using EventManagement.Models;

namespace EventManagement.BLL
{
    public class EventTableService
    {
        private readonly EventTableDAL _eventTableDAL;

        public EventTableService(EventTableDAL eventTableDAL)
        {
            _eventTableDAL = eventTableDAL;
        }

        public List<EventTable> GetEvents()
        {
            return _eventTableDAL.GetEvents();//not a list just a method passing way from DAL to BLL
        }

        public void AddEvent(EventTable eventTable)
        {
            _eventTableDAL.AddEvent(eventTable);
        }

        public void DeleteEvent(int eventId)
        {
            _eventTableDAL.DeleteEvent(eventId);
        }

        //public void UpdateEvent(EventTable eventTable)
        //{
        //    _eventTableDAL.UpdateEvent(eventTable);
        //}
    }
}
