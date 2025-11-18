using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class DoctorCFG : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasData(
                new Doctor { DoctorID = 1, DoctorName = "Petar Petrovski", PolyclinicID = 1},
                new Doctor { DoctorID = 2, DoctorName = "Ivana Ivanovska" ,PolyclinicID = 1 },
                new Doctor { DoctorID = 3, DoctorName = "Dimitar Dimitrovski", PolyclinicID = 2},
                new Doctor { DoctorID = 4, DoctorName = "Elena Nikolovska", PolyclinicID = 2 },
                new Doctor {DoctorID = 5, DoctorName = "Milena Stojanovska", PolyclinicID = 3 },
                new Doctor {DoctorID = 6, DoctorName = "Stefan Stefanovski", PolyclinicID = 3 },
                new Doctor {DoctorID = 7, DoctorName = "Aleksandar Petkovski", PolyclinicID = 3 }
                );
        }
    }
}
