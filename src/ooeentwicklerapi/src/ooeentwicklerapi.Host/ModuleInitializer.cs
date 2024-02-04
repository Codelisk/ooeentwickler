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
            new ooeentwicklerapi.Managers.ModuleInitializer().Configure(services);
        }
    }
}
