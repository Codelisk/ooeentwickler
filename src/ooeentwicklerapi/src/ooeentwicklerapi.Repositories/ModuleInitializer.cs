using Framework.Restservice.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwicklerapi.Repositories
{
    public partial class ModuleInitializer
    {
        public void Configure(IServiceCollection services)
        {
            AddServices(services);
            services.AddBaseServices();
            new ooeentwicklerapi.Database.ModuleInitializer().Configure(services);
        }
        partial void AddServices(IServiceCollection services);
    }
}
