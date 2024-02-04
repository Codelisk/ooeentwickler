using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.ApiClient.Repositories;
using Framework.ApiClient.Services.Helper;
using Framework.ApiClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ooeentwickleruno.apiclient;

public partial class ModuleInitializer : Framework.ApiClient.ModuleInitializer
{
    partial void AddServices(IServiceCollection services);
    public void Configure<TAuthService>(IServiceCollection services) where TAuthService : class, IAuthenticationService
    {
        base.AddApi<TAuthService>(services);
        AddServices(services);
    }
}
