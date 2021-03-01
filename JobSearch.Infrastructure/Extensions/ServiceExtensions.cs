using JobSearch.Application.Services.Jobs;
using JobSearch.Domain.Interfaces;
using JobSearch.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure.Data.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();

            services.AddScoped<IJobService, JobService>();
        }
    }
}
