using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AsyncAwaitBestPractices;
using Framework.ApiClient.Services;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Application;
using Framework.Services.Services.Vms;
using Microsoft.UI.Xaml.Automation.Provider;
using ooeentwickleruno.services.Provider.AccountProvider;
using ReactiveUI;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ooeentwickleruno.viewmodels.ViewModels.Account.Onboarding;

public partial class SignInPageViewModel : RegionBaseViewModel
{
    private readonly IAccountProvider _accountProvider;
    private readonly IDispatcher _dispatcher;
    private readonly IMainWindowProvider<Window> _mainWindow;
    private readonly Framework.ApiClient.Services.IAuthenticationService _authenticationService;

    public SignInPageViewModel(
        IAccountProvider accountProvider,
        VmServices vmServices,
        IDispatcher dispatcher,
        IMainWindowProvider<Window> mainWindow,
        Framework.ApiClient.Services.IAuthenticationService authenticationService
    )
        : base(vmServices)
    {
        _accountProvider = accountProvider;
        _dispatcher = dispatcher;
        _mainWindow = mainWindow;
        _authenticationService = authenticationService;
        OnAddImageAsync();
    }

    private async Task OnAddImageAsync()
    {
        Console.WriteLine("AddImageCommand");

        await _dispatcher.ExecuteAsync(async () =>
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".jpg");

            // For Uno.WinUI-based apps
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(_mainWindow.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(fileOpenPicker, hwnd);

            StorageFile pickedFile = await fileOpenPicker.PickSingleFileAsync();
            if (pickedFile != null)
            {
                // File was picked, you can now use it
                var text = await FileIO.ReadBufferAsync(pickedFile);
                var bytes = text.ToArray();
            }
            else
            {
                // No file was picked or the dialog was cancelled.
            }
        });
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
