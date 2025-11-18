using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Models.Config;
using WebApplication1.Models;

namespace WebApp.DAL
{
    //public class HospiralDB:IdentityDbContext
    public class HospitalDB:IdentityDbContext<Member,Role,int>
    {
        public HospitalDB(DbContextOptions<HospitalDB> options):base(options)
        {
                
        }

       

        public DbSet<Member> Members{ get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Polyclinic> Polyclinics { get; set; }
        public DbSet<DateEntity> Dates { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<AppointmentDefinition> AppointmentDefinitions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Appointment_VM> Appointment_VMs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Doctor>()
              .HasOne(d => d.Polyclinic)
              .WithMany(p=>p.Doctors) // or .WithMany(t => t.DateEntities) if you add a collection to Time
              .HasForeignKey(d => d.PolyclinicID);

            builder.Entity<DateEntity>()
              .HasOne(d => d.Doctor)
              .WithMany() // or .WithMany(t => t.DateEntities) if you add a collection to Time
              .HasForeignKey(d => d.DoctorId);

            builder.Entity<DateEntity>()
              .HasOne(d => d.Time)
              .WithMany()
              .HasForeignKey(d => d.TimeID);

            builder.Entity<AppointmentDefinition>()
                .HasOne(a => a.Time)
                .WithMany(t => t.AppointmentDefinitions)
                .HasForeignKey(a => a.TimeID);

            builder.Entity<AppointmentDefinition>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.AppointmentDefinitions)
                .HasForeignKey(a => a.DoctorID);

            builder.Entity<AppointmentDefinition>()
                .HasOne(a => a.Polyclinic)
                .WithMany(p => p.AppointmentDefinitions)
                .HasForeignKey(a => a.PolyclinicID);

            builder.Entity<AppointmentDefinition>()
                .HasOne(a => a.Date)
                .WithMany(d => d.AppointmentDefinitions)
                .HasForeignKey(a => a.DateEntityId);

            builder.Entity<AppointmentDefinition>()
               .HasOne(a => a.Member)
               .WithMany()
               .HasForeignKey(a => a.MemberId);

            builder.ApplyConfiguration(new DateEntityCFG());
            builder.ApplyConfiguration(new PolyclinicCFG());
            builder.ApplyConfiguration(new TimeCFG());
            builder.ApplyConfiguration(new RoleCFG());
            builder.ApplyConfiguration(new DoctorCFG());
        }
    }
}
