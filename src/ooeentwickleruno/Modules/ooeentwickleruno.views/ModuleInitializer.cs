using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;
using ooeentwickleruno.views.Views.Account.Onboarding;

namespace ooeentwickleruno.views;
public class ModuleInitializer : IModule
{
    public void OnInitialized(IContainerProvider containerProvider)
    {
    }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
    }
}
