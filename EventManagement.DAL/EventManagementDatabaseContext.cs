using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Models;

public partial class EventManagementDatabaseContext : DbContext
{
    public EventManagementDatabaseContext()
    {
    }

    public EventManagementDatabaseContext(DbContextOptions<EventManagementDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EventTable> EventTables { get; set; }

    public virtual DbSet<RegistrationTable> RegistrationTables1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DHILLXN_MN\\SQLEXPRESS;Database=EventManagementDatabase;Integrated Security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventTable>(entity =>
        {
            entity.HasKey(e => e.EventId);

            entity.ToTable("EventTable");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.EventLocation).HasMaxLength(100);
            entity.Property(e => e.EventName).HasMaxLength(50);
        });

        modelBuilder.Entity<RegistrationTable>(entity =>
        {
            entity.HasKey(e => e.RegistrationId);

            entity.ToTable("RegistrationTable");

            entity.Property(e => e.RegistrationId).HasColumnName("RegistrationID");
            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.ParticipateAddress).HasMaxLength(100);
            entity.Property(e => e.ParticipateEmail).HasMaxLength(100);
            entity.Property(e => e.ParticipateName).HasMaxLength(50);

            entity.HasOne(d => d.Event).WithMany(p => p.RegistrationTables)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RegistrationTable_EventTable");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
