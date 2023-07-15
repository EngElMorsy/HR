using HR.Service.Abstracts;
using HR.Service.Abstracts.Address;
using HR.Service.Abstracts.BaseInterface;
using HR.Service.Abstracts.BCMDJ;
using HR.Service.Implementions;
using HR.Service.Implementions.Address;
using HR.Service.Implementions.BaseRepositry;
using HR.Service.Implementions.BCMDJ;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeServices, EmployeeServices>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<ICityServices, CityServices>();
            services.AddScoped<IDisrtrictServices, DistrictServices>();
            services.AddScoped<IDepartService, DepartService>();

            return services;
        }

    }

}