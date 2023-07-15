using HR.Infrustructure.Implement;
using HR.Infrustructure.InfrastructBases.GeneRepo;
using HR.Infrustructure.InfrastructBases.GenericRepositry;
using HR.Infrustructure.Repositry;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Infrustructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRep, EmployeeRep>();
            services.AddTransient(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddTransient(typeof(IGenericRepAsync<>), typeof(GenericRepAsync<>));

            return services;
        }
    }
}
