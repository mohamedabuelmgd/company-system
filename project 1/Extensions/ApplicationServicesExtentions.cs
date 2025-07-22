using Company.Core.Repositories;
using Company.Core.Services;
using Company.Repository;
using Company.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using project_1.Errors;
using project_1.Helpers;
using System.Linq;

namespace project_1.Extensions
{
    public static class ApplicationServicesExtentions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IResponseCacheService), typeof(ResponseCacheService));
            services.AddScoped(typeof(IUniteOfWork), typeof(UniteOfWork));

            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped(typeof(IAttendanceService), typeof(AttendanceService));
            services.AddScoped(typeof(IPayrollService), typeof(PayrollService));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(M => M.Value.Errors.Count() > 0)
                    .SelectMany(M => M.Value.Errors)
                    .Select(E => E.ErrorMessage)
                    .ToArray();
                    var validationErrorResponse = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validationErrorResponse);
                };
            });
            return services;
        }
    }
}
