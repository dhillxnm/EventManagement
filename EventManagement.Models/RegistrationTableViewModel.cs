using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventManagement.Models
{
    public class RegistrationTableViewModel
    {
        [Required]
        public string ParticipateName { get; set; }

        [Required]
        [EmailAddress]
        public string ParticipateEmail { get; set; }

        [Required]
        public string ParticipateAddress { get; set; }

        [Required]
        public int EventId { get; set; }
        public IEnumerable<EventTable>? Events { get; set; }
        
    }
}
