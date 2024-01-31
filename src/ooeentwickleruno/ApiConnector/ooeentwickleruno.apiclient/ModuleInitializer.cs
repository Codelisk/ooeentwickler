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

internal partial class ModuleInitializer : Framework.ApiClient.ModuleInitializer
{
    public override void AddApi<TAuthService>(IServiceCollection services)
    {
        AddApis(services);
        base.AddApi<TAuthService>(services);
    }
}
