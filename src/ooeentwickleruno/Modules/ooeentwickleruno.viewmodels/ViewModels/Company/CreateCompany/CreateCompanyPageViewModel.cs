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

namespace ooeentwickleruno.viewmodels.ViewModels.Company.CreateCompany;

public partial class CreateCompanyPageViewModel : RegionBaseViewModel
{
    private readonly VmServices _vmServices;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
    private readonly IIndustryRepository _industryRepository;
    private readonly IIssueTrackerRepository _issueTrackerRepository;
    private readonly IRepositoryHostingRepository _repositoryHostingRepository;
    private readonly ICompanyBenefitRepository _companyBenefitRepository;

    public List<ProgrammingLanguageDto> ProgrammingLanguages { get; set; }
    public List<ProgrammingFrameworkDto> ProgrammingFrameworks { get; set; }
    public List<IndustryDto> Industries { get; set; }
    public List<IssueTrackerDto> IssueTrackers { get; set; }
    public List<RepositoryHostingDto> RepositoryHostings { get; set; }
    public List<object> SelectedProgrammingLanguages { get; set; } = new List<object>();
    public List<object> SelectedIndustries { get; set; } = new List<object>();

    public CreateCompanyPageViewModel(
        VmServices vmServices,
        IProgrammingLanguageRepository programmingLanguageRepository,
        IProgrammingFrameworkRepository programmingFrameworkRepository,
        IIndustryRepository industryRepository,
        IIssueTrackerRepository issueTrackerRepository,
        IRepositoryHostingRepository repositoryHostingRepository,
        ICompanyBenefitRepository companyBenefitRepository
    )
        : base(vmServices)
    {
        _vmServices = vmServices;
        _programmingLanguageRepository = programmingLanguageRepository;
        _programmingFrameworkRepository = programmingFrameworkRepository;
        _industryRepository = industryRepository;
        _issueTrackerRepository = issueTrackerRepository;
        _repositoryHostingRepository = repositoryHostingRepository;
        _companyBenefitRepository = companyBenefitRepository;
    }

    public override async void OnNavigatedTo(NavigationContext navigationContext)
    {
        ProgrammingLanguages = await _programmingLanguageRepository.GetAll();
        this.RaisePropertyChanged(nameof(ProgrammingLanguages));
        ProgrammingFrameworks = await _programmingFrameworkRepository.GetAll();
        this.RaisePropertyChanged(nameof(ProgrammingFrameworks));
        Industries = await _industryRepository.GetAll();
        this.RaisePropertyChanged(nameof(Industries));
        IssueTrackers = await _issueTrackerRepository.GetAll();
        this.RaisePropertyChanged(nameof(IssueTrackers));
        RepositoryHostings = await _repositoryHostingRepository.GetAll();
        this.RaisePropertyChanged(nameof(RepositoryHostings));
        base.OnNavigatedTo(navigationContext);

        _vmServices.RegionManager.RequestNavigate("CompanyBenefitRegion", "CreateBenefitView");
    }
}
