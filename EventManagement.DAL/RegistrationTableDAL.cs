using System.Collections.Generic;
using System.Linq;
using EventManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.DAL
{
    public class RegistrationTableDAL
    {
        private readonly EventManagementDatabaseContext _context;

        public RegistrationTableDAL(EventManagementDatabaseContext context)
        {
            _context = context;
        }

        public List<RegistrationTable> GetRegistrations()
        {
            return _context.RegistrationTables1.ToList();
        }

        public void AddRegistration(RegistrationTable registration)
        {
            _context.RegistrationTables1.Add(registration);
            _context.SaveChanges();
        }

        public void DeleteRegistration(int registrationId)
        {
            var deleteRegistration = _context.RegistrationTables1.Find(registrationId);
            if (deleteRegistration != null)
            {
                _context.RegistrationTables1.Remove(deleteRegistration);
                _context.SaveChanges();
            }
        }
    }
}
