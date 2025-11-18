using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApp.Models;

namespace WebApp.Models.Config
{
    public class DateEntityCFG : IEntityTypeConfiguration<DateEntity>
    {
        public void Configure(EntityTypeBuilder<DateEntity> builder)
        {
            builder.HasData(
                new DateEntity { DateEntityID = 1, Date = new DateTime(2025, 12, 12), DoctorId = 1, TimeID = 1 },
                new DateEntity { DateEntityID = 2, Date = new DateTime(2025, 12, 13), DoctorId = 2, TimeID = 2 },
                new DateEntity { DateEntityID = 3, Date = new DateTime(2025, 12, 14) , DoctorId = 3, TimeID = 3 },
                new DateEntity {DateEntityID = 4, Date = new DateTime(2025, 12, 15), DoctorId = 4, TimeID = 4 },
                new DateEntity {DateEntityID = 5, Date = new DateTime(2025, 12, 16), DoctorId = 5, TimeID = 5 },
                new DateEntity {DateEntityID = 6, Date = new DateTime(2025, 12, 17), DoctorId = 6, TimeID = 6 },
                new DateEntity {DateEntityID = 7, Date = new DateTime(2025, 12, 12), DoctorId = 1, TimeID = 7 },
                new DateEntity { DateEntityID = 8, Date = new DateTime(2025, 12, 13), DoctorId = 2, TimeID = 1 },
                new DateEntity { DateEntityID = 9, Date = new DateTime(2025, 12, 14), DoctorId = 3, TimeID = 2 },
                new DateEntity { DateEntityID = 10, Date = new DateTime(2025, 12, 15) , DoctorId = 4, TimeID = 3},
                new DateEntity { DateEntityID = 11, Date = new DateTime(2025, 12, 16), DoctorId = 5, TimeID = 4 },
                new DateEntity { DateEntityID = 12, Date = new DateTime(2025, 12, 17) , DoctorId = 6, TimeID = 5},
                new DateEntity { DateEntityID = 13, Date = new DateTime(2025, 12, 18) , DoctorId = 1, TimeID = 6},
                new DateEntity { DateEntityID = 14, Date = new DateTime(2025, 12, 19) , DoctorId = 2, TimeID = 7},
                new DateEntity { DateEntityID = 15, Date = new DateTime(2025, 12, 20) , DoctorId = 3, TimeID = 1},
                new DateEntity { DateEntityID = 16, Date = new DateTime(2025, 12, 12) , DoctorId = 4, TimeID = 2},
                new DateEntity { DateEntityID = 17, Date = new DateTime(2025, 12, 16) , DoctorId = 5, TimeID = 3},
                new DateEntity { DateEntityID = 18, Date = new DateTime(2025, 12, 15) , DoctorId = 6, TimeID = 4 },
                new DateEntity { DateEntityID = 19, Date = new DateTime(2025, 12, 18) , DoctorId = 1 , TimeID = 5},
                new DateEntity { DateEntityID = 20, Date = new DateTime(2025, 12, 19) , DoctorId = 2 , TimeID  = 6 },
                new DateEntity { DateEntityID = 21, Date = new DateTime(2025, 12, 20) , DoctorId = 3 , TimeID = 7},
                new DateEntity { DateEntityID = 22, Date = new DateTime(2025, 12, 12) , DoctorId = 4 , TimeID = 1},
                new DateEntity { DateEntityID = 23, Date = new DateTime(2025, 12, 16) , DoctorId = 5 , TimeID = 2 },
                new DateEntity { DateEntityID = 24, Date = new DateTime(2025, 12, 15) , DoctorId = 6 , TimeID = 3},
                new DateEntity { DateEntityID = 25, Date = new DateTime(2025, 12, 18) , DoctorId = 1 , TimeID = 4 },
                new DateEntity { DateEntityID = 26, Date = new DateTime(2025, 12, 19) , DoctorId = 2, TimeID = 5},
                new DateEntity { DateEntityID = 27, Date = new DateTime(2025, 12, 20) , DoctorId = 3 , TimeID = 6},
                new DateEntity { DateEntityID = 28, Date = new DateTime(2025, 12, 12) , DoctorId = 4 , TimeID = 7},
                new DateEntity { DateEntityID = 29, Date = new DateTime(2025, 12, 16) , DoctorId = 5 , TimeID = 1},
                new DateEntity { DateEntityID = 30, Date = new DateTime(2025, 12, 15) , DoctorId = 6 , TimeID = 2},
                new DateEntity { DateEntityID = 31, Date = new DateTime(2025, 12, 13) , DoctorId = 1 , TimeID = 3},
                new DateEntity { DateEntityID = 32, Date = new DateTime(2025, 12, 14) , DoctorId = 2 , TimeID = 4},
                new DateEntity { DateEntityID = 33, Date = new DateTime(2025, 12, 18) , DoctorId = 3 , TimeID = 5},
                new DateEntity { DateEntityID = 34, Date = new DateTime(2025, 12, 20) , DoctorId = 4 , TimeID = 6},
                new DateEntity { DateEntityID = 35, Date = new DateTime(2025, 12, 22) , DoctorId = 5 , TimeID = 7},
                new DateEntity { DateEntityID = 36, Date = new DateTime(2025, 12, 23) , DoctorId = 6 , TimeID = 1},
                new DateEntity { DateEntityID = 37, Date = new DateTime(2025, 12, 10) , DoctorId = 1 , TimeID = 2},
                new DateEntity { DateEntityID = 38, Date = new DateTime(2025, 12, 11) , DoctorId = 2 , TimeID = 3},
                new DateEntity { DateEntityID = 39, Date = new DateTime(2025, 12, 15) , DoctorId = 3 , TimeID = 4},
                new DateEntity { DateEntityID = 40, Date = new DateTime(2025, 12, 16) , DoctorId = 4 , TimeID = 5},
                new DateEntity { DateEntityID = 41, Date = new DateTime(2025, 12, 18) , DoctorId = 5 , TimeID = 6},
                new DateEntity { DateEntityID = 42, Date = new DateTime(2025, 12, 23) , DoctorId = 6 , TimeID = 7}
            );
       }
    }
}
