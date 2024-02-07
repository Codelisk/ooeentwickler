using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.services.Provider.AccountProvider;

namespace ooeentwickleruno.services;

public class ModuleInitializer : IModule
{
    public void OnInitialized(IContainerProvider containerProvider) { }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IAccountProvider, AccountProvider>();
        containerRegistry.RegisterSingleton<IAccountSetupProvider, AccountSetupProvider>();
    }
}
