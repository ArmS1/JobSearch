using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace JobSearch.Infrastructure.Data.Context
{
    public class JobSearchContext : DbContext
    {
        public JobSearchContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserJob> UserJobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
