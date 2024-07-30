using EventManagement.Models;
using EventManagement.DAL;


namespace EventManagement.BLL
{
    public class RegistrationTableService
    {
        private RegistrationTableDAL _registrationTableDAL;
        public RegistrationTableService(RegistrationTableDAL registrationTableDAL)
        {
            _registrationTableDAL = registrationTableDAL;
        }
        public List<RegistrationTable> GetRegistrations()
        {
            return _registrationTableDAL.GetRegistrations();
        }
        public void AddRegistration(RegistrationTable registrations)
        {
            _registrationTableDAL.AddRegistration(registrations);
        }
        public void DeleteRegistration(int registrationId)
        {
            _registrationTableDAL.DeleteRegistration(registrationId);
        }
    }

}
