using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class TimeCFG : IEntityTypeConfiguration<Time>
    {
        public void Configure(EntityTypeBuilder<Time> builder)
        {
            builder.HasData(
                new Time { TimeID = 1, AppointmentTimes = "10" },
                new Time { TimeID = 2, AppointmentTimes = "11" },
                new Time { TimeID = 3, AppointmentTimes = "12" },
                new Time { TimeID = 4, AppointmentTimes = "13" },
                new Time { TimeID = 5, AppointmentTimes = "14" },
                new Time { TimeID = 6, AppointmentTimes = "15" },
                new Time { TimeID = 7, AppointmentTimes = "16" }
                );
        }
    }
}
