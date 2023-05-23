using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Models
{
    public class DentalClinicContext : IdentityDbContext<User>
    {
        public DentalClinicContext(DbContextOptions <DentalClinicContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Consultation> Consultations { get; set; }
        public virtual DbSet<Billing> Billings { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<Treatment> Treatments { get; set; }
        public virtual DbSet<Specialization> Specializations { get; set; }
        public virtual DbSet<UserSpecialization> UserSpecializations { get; set; }
        public virtual DbSet<TreatmentConsultation> TreatmentConsultations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity
                    .HasOne<User>(s => s.User)
                    .WithMany(c => c.Appointments)
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity
                    .HasOne<User>(s => s.Dentist)
                    .WithMany()
                    .HasForeignKey(s => s.DentistId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity
                    .HasOne<Service>(s => s.Service)
                    .WithMany(c => c.Appointments)
                    .HasForeignKey(s => s.ServiceId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity
                    .HasOne<Consultation>(s => s.Consultation)
                    .WithOne(c => c.Appointment)
                    .HasForeignKey<Consultation>(s => s.AppointmentId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Billing>()
                .HasOne(s => s.Consultation)
                .WithOne(c => c.Billing)
                .HasForeignKey<Billing>(s => s.ConsultationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<TreatmentConsultation>(entity =>
            {
                entity
                   .HasKey(s => new { s.TreatmentId, s.ConsultationId });

                entity
                    .HasOne(s => s.Treatment)
                    .WithMany(c => c.TreatmentConsultations)
                    .HasForeignKey(s => s.TreatmentId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity
                    .HasOne(s => s.Consultation)
                    .WithMany(c => c.TreatmentConsultations)
                    .HasForeignKey(s => s.ConsultationId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Treatment>()
                .HasOne(s => s.Service)
                .WithMany(c => c.Treatments)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<Service>()
                .HasOne(s => s.Specialization)
                .WithMany(c => c.Services)
                .HasForeignKey(s => s.SpecializationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<UserSpecialization>(entity =>
            {
                entity
                   .HasKey(s => new { s.SpecializationId, s.UserId });

                entity
                    .HasOne(s => s.User)
                    .WithMany(c => c.UserSpecializations)
                    .HasForeignKey(s => s.UserId)
                    .OnDelete(DeleteBehavior.ClientNoAction);

                entity
                    .HasOne(s => s.Specialization)
                    .WithMany(c => c.UserSpecializations)
                    .HasForeignKey(s => s.SpecializationId)
                    .OnDelete(DeleteBehavior.ClientNoAction);
            });

            modelBuilder.Entity<Review>()
                .HasOne(s => s.User)
                .WithMany(c => c.Reviews)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.ClientNoAction);
        }
    }
}