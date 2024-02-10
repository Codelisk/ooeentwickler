using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;
using ooeentwickleruno.viewmodels.ViewModels.Company.CreateCompany;
using ooeentwickleruno.viewmodels.ViewModels.Company.Show;
using ooeentwickleruno.views.Views.Account.Onboarding;
using ooeentwickleruno.views.Views.Company.Create;
using ooeentwickleruno.views.Views.Company.Show;
using ooeentwickleruno.views.Views.DataCreation;

namespace ooeentwickleruno.views;

public class ModuleInitializer : IModule
{
    public void OnInitialized(IContainerProvider containerProvider) { }

    public void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterForNavigation<RegisterPage, RegisterPageViewModel>();
        containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
        containerRegistry.RegisterForNavigation<CreateCompanyPage, CreateCompanyPageViewModel>();
        containerRegistry.RegisterForNavigation<CreateBenefitView, CreateBenefitViewModel>();
        containerRegistry.RegisterForNavigation<ShowCompanyPage, ShowCompanyPageViewModel>();
        containerRegistry.RegisterForNavigation<CreateDistrictView, CreateDistrictViewModel>();
        containerRegistry.RegisterForNavigation<
            CompanyOverviewPage,
            CompanyOverviewPageViewModel
        >();
    }
}
