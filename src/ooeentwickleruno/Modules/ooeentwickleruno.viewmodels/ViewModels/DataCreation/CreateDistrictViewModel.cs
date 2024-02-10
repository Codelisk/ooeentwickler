using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Application;
using Framework.Services.Services.Vms;
using ReactiveUI;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace ooeentwickleruno.views.Views.DataCreation;

public partial class CreateDistrictViewModel : RegionBaseViewModel
{
    private readonly IDispatcher _dispatcher;
    private readonly IMainWindowProvider<Window> _mainWindow;
    private readonly IDistrictImageRepository _districtImageRepository;
    private readonly IDistrictRepository _districtRepository;

    public CreateDistrictViewModel(
        VmServices vmServices,
        IDispatcher dispatcher,
        IMainWindowProvider<Window> mainWindowProvider,
        IDistrictImageRepository districtImageRepository,
        IDistrictRepository districtRepository
    )
        : base(vmServices)
    {
        _dispatcher = dispatcher;
        _mainWindow = mainWindowProvider;
        _districtImageRepository = districtImageRepository;
        _districtRepository = districtRepository;
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
        _districtRepository
            .GetAll()
            .ContinueWith(x =>
            {
                Districts = x.Result;
                this.RaisePropertyChanged(nameof(Districts));
            });
    }

    public List<DistrictDto> Districts { get; set; }
    public DistrictDto District { get; set; } = new DistrictDto() { Name = string.Empty };
    public byte[] imageBytes { get; set; }
    public ICommand AddLogoCommand => this.LoadingCommand(OnAddLogoAsync);

    private async Task OnAddLogoAsync()
    {
        await _dispatcher.ExecuteAsync(async () =>
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".gif");
            fileOpenPicker.FileTypeFilter.Add(".jpg");

            // For Uno.WinUI-based apps
            var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(_mainWindow.MainWindow);
            WinRT.Interop.InitializeWithWindow.Initialize(fileOpenPicker, hwnd);

            StorageFile pickedFile = await fileOpenPicker.PickSingleFileAsync();
            if (pickedFile != null)
            {
                // File was picked, you can now use it
                var text = await FileIO.ReadBufferAsync(pickedFile);
                imageBytes = text.ToArray();
            }
            else
            {
                // No file was picked or the dialog was cancelled.
            }
        });
    }

    public ICommand SaveCommand => this.LoadingCommand(OnSaveAsync);

    private async Task OnSaveAsync()
    {
        await _districtRepository.Save(District);
        if (imageBytes is not null)
        {
            await _districtImageRepository.Save(
                new DistrictImageDto { bytes = imageBytes, DistrictId = District.GetId() }
            );
        }
    }
}
