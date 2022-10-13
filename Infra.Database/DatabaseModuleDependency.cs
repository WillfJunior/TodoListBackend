using Domain.Adapters;
using Domain.Adapters.UoW;
using Infra.Database.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Database
{
    public static class DataBaseModuleDependency
    {
        public static void AddDataBaseModule(this IServiceCollection services)
        {
            //Repositories Dependency Injection
            services.AddScoped<IUnitOfWork, Infra.Database.UnitOfWork.UnitOfWork>();
            services.AddScoped<ITodosRepository, TodosRepository>();
        }
    }
}
