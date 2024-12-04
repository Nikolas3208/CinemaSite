using CinemaSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaSite.Domain.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleModel>
    {
        public void Configure(EntityTypeBuilder<RoleModel> builder)
        {
            builder.HasKey(r => r.Id);

            builder.HasMany(r => r.Users).WithMany(u => u.Roles);
        }
    }
}
