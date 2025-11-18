using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApp.Models.Config
{
    public class RoleCFG : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(new Role { Id = 1, Name = "Admin", NormalizedName = "Admin" });
            builder.HasData(new Role { Id = 2, Name = "Member", NormalizedName = "Member" });
        }
    }
}
