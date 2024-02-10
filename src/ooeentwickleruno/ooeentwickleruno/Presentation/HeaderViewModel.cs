using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ReactiveUI.Fody.Helpers;

namespace Sample.Presentation;

public partial class HeaderViewModel : RegionBaseViewModel
{
    private readonly VmServices _vmServices;

    public HeaderViewModel(VmServices vmServices)
        : base(vmServices)
    {
        _vmServices = vmServices;
    }

    public ICommand NavigateCommand => this.LoadingCommand(OnNavigateAsync);

    private async Task OnNavigateAsync()
    {
        _vmServices.RegionManager.RequestNavigate("BodyRegion", ViewName);
    }

    [Reactive]
    public string ViewName { get; set; }

    public ICommand SignInCommand => this.LoadingCommand(OnSignInAsync);

    private async Task OnSignInAsync()
    {
        _vmServices.RegionManager.RequestNavigate("BodyRegion", "SignInPage");
    }

    public ICommand RegisterCommand => this.LoadingCommand(OnRegisterAsync);

    private async Task OnRegisterAsync()
    {
        _vmServices.RegionManager.RequestNavigate("BodyRegion", "RegisterPage");
    }
}
