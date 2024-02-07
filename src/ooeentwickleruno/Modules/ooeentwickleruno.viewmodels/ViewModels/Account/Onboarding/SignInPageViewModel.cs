using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices;
using Framework.ApiClient.Services;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ooeentwickleruno.services.Provider.AccountProvider;
using ReactiveUI;

namespace ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;

public partial class SignInPageViewModel : RegionBaseViewModel
{
    private readonly IAccountProvider _accountProvider;
    private readonly Framework.ApiClient.Services.IAuthenticationService _authenticationService;

    public SignInPageViewModel(
        IAccountProvider accountProvider,
        VmServices vmServices,
        Framework.ApiClient.Services.IAuthenticationService authenticationService
    )
        : base(vmServices)
    {
        _accountProvider = accountProvider;
        _authenticationService = authenticationService;
    }

    private string email = "test@test.at";
    public string Email
    {
        get { return email; }
        set { this.RaiseAndSetIfChanged(ref email, value); }
    }

    private string password = "Test1234!";
    public string Password
    {
        get { return password; }
        set { this.RaiseAndSetIfChanged(ref password, value); }
    }

    public ICommand SignInCommand => this.LoadingCommand(OnSignInAsync);

    private async Task OnSignInAsync()
    {
        bool result = await _authenticationService.AuthenticateAndCacheTokenAsync(
            new Framework.ApiClient.Models.AuthPayload() { email = Email, password = Password }
        );

        _accountProvider.SetAccountAsync().SafeFireAndForget();

        if (result)
        {
            ChangeCurrentRegion("CreateCompanyPage");
        }
    }
}
