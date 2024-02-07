using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace ooeentwickleruno.viewmodels.ViewModels.Company.CreateCompany;

public partial class CreateBenefitViewModel : RegionBaseViewModel
{
    public ObservableCollection<object> SelectedBenefits { get; set; }

    [Reactive]
    public string CurrentBenefitTitle { get; set; }

    [Reactive]
    public string CurrentBenefitDescription { get; set; }

    public CreateBenefitViewModel(VmServices vmServices)
        : base(vmServices) { }

    public ICommand TestCommand => LoadingCommand<object>(OnTestAsync);

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        SelectedBenefits =
            navigationContext.Parameters["SelectedBenefits"] as ObservableCollection<object>;
        this.RaisePropertyChanged(nameof(SelectedBenefits));
    }

    private async Task OnTestAsync(object o)
    {
        SelectedBenefits.Add(
            new CompanyBenefitDto
            {
                CompanyId = Guid.Empty,
                Title = CurrentBenefitTitle,
                Description = CurrentBenefitDescription
            }
        );
        this.RaisePropertyChanged(nameof(SelectedBenefits));
    }
}
