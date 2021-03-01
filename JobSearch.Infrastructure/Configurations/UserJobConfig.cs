using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JobSearch.Infrastructure.Data.Configurations
{
    public class UserJobConfig : IEntityTypeConfiguration<UserJob>
    {
        public void Configure(EntityTypeBuilder<UserJob> builder)
        {
            builder.HasOne(uj => uj.User)
                .WithMany(u => u.UserJobs)
                .HasForeignKey(uj => uj.UserId);
            builder.HasOne(uj => uj.Job)
                .WithMany(j => j.UserJobs)
                .HasForeignKey(uj => uj.JobId);

            builder.Property(uj => uj.IsBookMark)
                .IsRequired();
            builder.Property(uj => uj.IsApply)
                .IsRequired();

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}
