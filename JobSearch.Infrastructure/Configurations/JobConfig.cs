using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Infrastructure.Data.Configurations
{
    public class JobConfig : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.Property(j => j.Title)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(j => j.EmploymentType)
                .IsRequired();

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
