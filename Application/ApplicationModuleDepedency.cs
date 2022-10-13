using Application.Services;
using Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationModuleDepedency
    {
        public static void AddApplicationModule(this IServiceCollection services)
        {
            //Services Dependecy Injection
            services.AddScoped<ITodosService, TodosManager>();
            services.AddScoped<INotificator, Notificator>();
            
        }
    }
}
