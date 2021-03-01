using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Infrastructure.Data.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(u => u.Surname)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(u => u.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
