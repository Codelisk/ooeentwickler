using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DynamicData;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using Microsoft.UI.Xaml.Media.Imaging;
using ooeentwickleruno.apiclient;
using ooeentwickleruno.viewmodels.Models;
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

    public override async void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        var districts = await _districtRepository.GetAll();

        foreach (var district in districts)
        {
            var districtImage = await _districtImageRepository.Get(district.GetId());

            if (districtImage is null)
            {
                Districts.Add(new(district, null));
            }
            else
            {
                var image = new BitmapImage();
                image.SetSource(new MemoryStream(districtImage.bytes));
                Districts.Add(new(district, image));
            }
        }

        this.RaisePropertyChanged(nameof(Districts));
    }

    public ObservableCollection<DistrictBitmapModel> Districts { get; set; } = new();
    public ICommand NavigateCommand => this.LoadingCommand(OnNavigateAsync);

    private async Task OnNavigateAsync()
    {
        ChangeCurrentRegion("ShowCompanyPage");
    }
}
