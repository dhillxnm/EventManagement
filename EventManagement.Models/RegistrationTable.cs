using System;
using System.Collections.Generic;

namespace EventManagement.Models;

public partial class RegistrationTable
{
    public int RegistrationId { get; set; }

    public int EventId { get; set; }

    public string ParticipateName { get; set; } = null!;

    public string ParticipateEmail { get; set; } = null!;

    public int ParticipateDateOfBirth { get; set; }

    public string ParticipateAddress { get; set; } = null!;

    public int? ParticipateNumber { get; set; }

    public virtual EventTable Event { get; set; } = null!;
}
