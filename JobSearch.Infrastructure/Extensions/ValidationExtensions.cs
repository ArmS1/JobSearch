using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure.Data.Extensions
{
    public static class ValidationExtensions
    {
        public static void ConfigureValidation(this IServiceCollection services)
        {
            services.AddControllers()
                .AddFluentValidation(options =>
                {
                    options.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                    options.LocalizationEnabled = false;
                    options.RegisterValidatorsFromAssemblyContaining(typeof(JobSearch.Application.Validators.AssemblyReference));
                });
        }
    }
}
