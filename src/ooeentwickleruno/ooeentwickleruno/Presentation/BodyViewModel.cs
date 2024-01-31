using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ooeentwickleruno.apiclient;
using ReactiveUI;

namespace Sample.Presentation;
public partial class BodyViewModel : RegionBaseViewModel
{
    private string test="Test";
    private readonly ITestRepository testRepository;

    public string Test
    {
        get { return test; }
        set { this.RaiseAndSetIfChanged(ref test, value); }
    }
    public BodyViewModel(VmServices vmServices, ITestRepository testRepository) : base(vmServices)
    {
        this.testRepository = testRepository;
    }
    public ICommand NavigateCommand => this.LoadingCommand(OnNavigateAsync);
    private async Task OnNavigateAsync()
    {
        var test = await testRepository.GetAll();
        ChangeCurrentRegion("CompanyEntryDetailView");
    }
}
