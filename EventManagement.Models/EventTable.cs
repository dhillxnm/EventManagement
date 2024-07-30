using System;
using System.Collections.Generic;

namespace EventManagement.Models;

public partial class EventTable
{
    public int EventId { get; set; }
    public string EventName { get; set; } = null!;

    public string EventLocation { get; set; } = null!;

    public int? EventParticipants { get; set; }

    public virtual ICollection<RegistrationTable> RegistrationTables { get; set; } = new List<RegistrationTable>();
}