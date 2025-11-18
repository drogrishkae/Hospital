using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class PolyclinicCFG : IEntityTypeConfiguration<Polyclinic>
    {
        public void Configure(EntityTypeBuilder<Polyclinic> builder)
        {
            builder.HasData(
                new Polyclinic { PolyclinicID = 1, PolyclinicName = "Kulak Burun Boğaz", Image = "Image1.jpg" },
                new Polyclinic { PolyclinicID = 2, PolyclinicName = "Genel Cerrahi", Image = "Image2.jpg" },
                new Polyclinic { PolyclinicID = 3, PolyclinicName = "Göz", Image = "Image3.jpg" }
                );
        }
    }
}
