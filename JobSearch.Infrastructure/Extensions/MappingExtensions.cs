using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JobSearch.Infrastructure.Data.Extensions
{
    public static class MappingExtensions
    {
        public static void ConfigureMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(new Assembly[] { typeof(JobSearch.Application.Mappers.AssemblyReference).Assembly });
        }
    }
}
