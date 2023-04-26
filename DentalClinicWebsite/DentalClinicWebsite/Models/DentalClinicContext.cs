using Microsoft.EntityFrameworkCore;

namespace DentalClinicWebsite.Models
{
    public class DentalClinicContext : DbContext    
    {
        public DentalClinicContext(DbContextOptions <DentalClinicContext> options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
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
            /*
            modelBuilder.Entity<User>()
                .HasMany(u => u.Appointments)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);
            */

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Service)
                .WithMany(c => c.Appointments)
                .HasForeignKey(c => c.ServiceId);
            /*
            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Treatment)
                .WithMany(t => t.Consultations)
                .HasForeignKey(c => c.TreatmentId);

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Appointment)
                .WithOne(a => a.Consultation)
                .HasForeignKey<Appointment>(a => a.ID);

            modelBuilder.Entity<UserSpecialization>()
                .HasKey(us => new { us.UserId, us.SpecializationId });

            modelBuilder.Entity<UserSpecialization>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSpecializations)
                .HasForeignKey(us => us.UserId);

            modelBuilder.Entity<UserSpecialization>()
                .HasOne(us => us.Specialization)
                .WithMany(s => s.UserSpecializations)
                .HasForeignKey(us => us.SpecializationId);

            modelBuilder.Entity<TreatmentConsultation>()
                .HasKey(tc => new { tc.TreatmentId, tc.ConsultationId });

            modelBuilder.Entity<TreatmentConsultation>()
                .HasOne(tc => tc.Treatment)
                .WithMany(t => t.TreatmentConsultations)
                .HasForeignKey(tc => tc.TreatmentId);

            modelBuilder.Entity<TreatmentConsultation>()
                .HasOne(tc => tc.Consultation)
                .WithMany(c => c.TreatmentConsultations)
                .HasForeignKey(tc => tc.ConsultationId);
            */
            modelBuilder.Entity<Treatment>()
            .HasOne(t => t.Service)
            .WithMany(s => s.Treatments)
            .HasForeignKey(t => t.ServiceId)
            .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TreatmentConsultation>()
                .HasKey(tc => new { tc.TreatmentId, tc.ConsultationId });

            modelBuilder.Entity<TreatmentConsultation>()
                .HasOne(tc => tc.Treatment)
                .WithMany(t => t.TreatmentConsultations)
                .HasForeignKey(tc => tc.TreatmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TreatmentConsultation>()
                .HasOne(tc => tc.Consultation)
                .WithMany(c => c.TreatmentConsultations)
                .HasForeignKey(tc => tc.ConsultationId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}