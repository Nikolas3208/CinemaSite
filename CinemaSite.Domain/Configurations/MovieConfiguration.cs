using CinemaSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaSite.Domain.Configurations
{
    public class MovieConfiguration : IEntityTypeConfiguration<MovieModel>
    {
        public void Configure(EntityTypeBuilder<MovieModel> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.Users).WithMany(u => u.Movies);
        }
    }
}
