using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwicklerapi.Database
{
    public partial class ModuleInitializer
    {
        partial void AddServices(IServiceCollection services);
        public void Configure(IServiceCollection services)
        {
            AddServices(services);
        }
    }
}
