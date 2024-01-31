using Framework.Restservice.Repositories;
using ooeentwicklerapi.Managers;
using ooeentwicklerapi.Repositories;
using ooeentwicklerapi.Controller;

namespace ooeentwicklerapi.Host
{
    public static class ModuleInitializer
    {
        public static void InitModules(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddManager();
            services.AddControllerServices();
        }
    }
}
