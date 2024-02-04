using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.ApiClient.Repositories;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using Microsoft.AspNetCore.Identity;
using ReactiveUI;

namespace ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;
public partial class RegisterPageViewModel : RegionBaseViewModel
{
    private readonly IAuthRepository _authRepository;

    public RegisterPageViewModel(VmServices vmServices, IAuthRepository _authRepository) : base(vmServices)
    {
        this._authRepository = _authRepository;
    }

    private string email;
    public string Email
    {
        get { return email; }
        set { this.RaiseAndSetIfChanged(ref email, value); }
    }

    private string password;
    public string Password
    {
        get { return password; }
        set { this.RaiseAndSetIfChanged(ref password, value); }
    }

    public ICommand RegisterCommand => this.LoadingCommand(OnRegisterAsync);
    private async Task OnRegisterAsync()
    {
        await _authRepository.RegisterAsync(new Framework.ApiClient.Models.AuthPayload { email=Email, password = Password});
    }
}
