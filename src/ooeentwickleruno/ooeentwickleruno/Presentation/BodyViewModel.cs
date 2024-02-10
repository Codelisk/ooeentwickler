using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using Microsoft.UI.Xaml.Media.Imaging;
using ooeentwickleruno.apiclient;
using ReactiveUI;

namespace Sample.Presentation;

public partial class BodyViewModel : RegionBaseViewModel
{
    private string test = "Test";
    private readonly IDistrictImageRepository _districtImageRepository;
    private readonly IDistrictRepository _districtRepository;

    public string Test
    {
        get { return test; }
        set { this.RaiseAndSetIfChanged(ref test, value); }
    }

    public BodyViewModel(
        VmServices vmServices,
        IDistrictImageRepository districtImageRepository,
        IDistrictRepository districtRepository
    )
        : base(vmServices)
    {
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
                foreach (var district in x.Result)
                {
                    _districtImageRepository
                        .Get(district.GetId())
                        .ContinueWith(y =>
                        {
                            if (y.Result == null)
                            {
                                Districts.Add((district, null));
                            }
                            else
                            {
                                var image = new BitmapImage();
                                image.SetSource(new MemoryStream(y.Result.bytes));
                                Districts.Add((district, image));
                            }
                        });
                }
                this.RaisePropertyChanged(nameof(Districts));
            });
    }

    public List<(DistrictDto, BitmapImage)> Districts { get; set; } =
        new List<(DistrictDto, BitmapImage)>();
    public ICommand NavigateCommand => this.LoadingCommand(OnNavigateAsync);

    private async Task OnNavigateAsync()
    {
        ChangeCurrentRegion("ShowCompanyPage");
    }
}
