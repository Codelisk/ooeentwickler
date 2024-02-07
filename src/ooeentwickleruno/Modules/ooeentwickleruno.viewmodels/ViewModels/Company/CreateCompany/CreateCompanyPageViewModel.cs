using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ooeentwickleruno.services.Provider.AccountProvider;
using ReactiveUI;

namespace ooeentwickleruno.viewmodels.ViewModels.Company.CreateCompany;

public partial class CreateCompanyPageViewModel : RegionBaseViewModel
{
    private readonly VmServices _vmServices;
    private readonly ICompanyRepository _companyRepository;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
    private readonly ICompanyProgrammingLanguageRepository _companyProgrammingLanguageRepository;
    private readonly ICompanyIndustryRepository _companyIndustryRepository;
    private readonly ICompanyInfrastructureRepository _companyInfrastructureRepository;
    private readonly ICompanyProgrammingFrameworkRepository _companyProgrammingFrameworkRepository;
    private readonly ICompanyLocationRepository _companyLocationRepository;
    private readonly IIndustryRepository _industryRepository;
    private readonly ICompanyBenefitRepository _companyBenefitRepository;
    private readonly IIssueTrackerRepository _issueTrackerRepository;
    private readonly IRepositoryHostingRepository _repositoryHostingRepository;
    private readonly IAccountProvider _accountProvider;

    public List<ProgrammingLanguageDto> ProgrammingLanguages { get; set; }
    public List<ProgrammingFrameworkDto> ProgrammingFrameworks { get; set; }
    public List<IndustryDto> Industries { get; set; }
    public List<IssueTrackerDto> IssueTrackers { get; set; }
    public List<RepositoryHostingDto> RepositoryHostings { get; set; }

    public List<object> SelectedProgrammingLanguages { get; set; } = new List<object>();
    public List<object> SelectedProgrammingFrameworks { get; set; } = new List<object>();
    public List<object> SelectedIndustries { get; set; } = new List<object>();
    public IssueTrackerDto SelectedIssueTracker { get; set; }
    public RepositoryHostingDto SelectedRepositoryHosting { get; set; }
    public ObservableCollection<object> SelectedBenefits { get; set; } = new();

    public CompanyDto Company { get; set; } =
        new CompanyDto()
        {
            Description = "",
            HowWeDevelopDescription = "",
            Name = ""
        };

    public CreateCompanyPageViewModel(
        VmServices vmServices,
        ICompanyRepository companyRepository,
        IProgrammingLanguageRepository programmingLanguageRepository,
        IProgrammingFrameworkRepository programmingFrameworkRepository,
        ICompanyProgrammingLanguageRepository companyProgrammingLanguageRepository,
        ICompanyIndustryRepository companyIndustryRepository,
        ICompanyInfrastructureRepository companyInfrastructureRepository,
        ICompanyProgrammingFrameworkRepository companyProgrammingFrameworkRepository,
        ICompanyLocationRepository companyLocationRepository,
        IIndustryRepository industryRepository,
        ICompanyBenefitRepository companyBenefitRepository,
        IIssueTrackerRepository issueTrackerRepository,
        IRepositoryHostingRepository repositoryHostingRepository,
        IAccountProvider accountProvider
    )
        : base(vmServices)
    {
        _vmServices = vmServices;
        _companyRepository = companyRepository;
        _programmingLanguageRepository = programmingLanguageRepository;
        _programmingFrameworkRepository = programmingFrameworkRepository;
        _companyProgrammingLanguageRepository = companyProgrammingLanguageRepository;
        _companyIndustryRepository = companyIndustryRepository;
        _companyInfrastructureRepository = companyInfrastructureRepository;
        _companyProgrammingFrameworkRepository = companyProgrammingFrameworkRepository;
        _companyLocationRepository = companyLocationRepository;
        _industryRepository = industryRepository;
        _companyBenefitRepository = companyBenefitRepository;
        _issueTrackerRepository = issueTrackerRepository;
        _repositoryHostingRepository = repositoryHostingRepository;
        _accountProvider = accountProvider;
    }

    public override async void OnNavigatedTo(NavigationContext navigationContext)
    {
        Company = await _companyRepository.GetLast();

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

        _vmServices.RegionManager.RequestNavigate(
            "CompanyBenefitRegion",
            "CreateBenefitView",
            new NavigationParameters { { "test", SelectedBenefits } }
        );
    }

    public ICommand AddCompanyCommand => this.LoadingCommand(OnAddCompanyAsync);

    private async Task AddCompanyProgrammingLanguageAsync()
    {
        var account = _accountProvider.Account!;
        var programmingLanguages = SelectedProgrammingLanguages.Select(x =>
        {
            return new CompanyProgrammingLanguageDto
            {
                CompanyId = Company.GetId(),
                ProgrammingLanguageId = (x as ProgrammingLanguageDto).GetId()
            };
        });

        await _companyProgrammingLanguageRepository.AddRange(programmingLanguages.ToList());
    }

    private async Task AddCompanyProgrammingFrameworksAsync()
    {
        var account = _accountProvider.Account!;
        var programmingFrameworks = SelectedProgrammingFrameworks.Select(x =>
        {
            return new CompanyProgrammingFrameworkDto
            {
                CompanyId = Company.GetId(),
                ProgrammingFrameworkId = (x as ProgrammingFrameworkDto).GetId()
            };
        });

        await _companyProgrammingFrameworkRepository.AddRange(programmingFrameworks.ToList());
    }

    private async Task AddCompanyIndustiresAsync()
    {
        var account = _accountProvider.Account!;
        var industries = SelectedIndustries.Select(x =>
        {
            return new CompanyIndustryDto
            {
                CompanyId = Company.GetId(),
                IndustryId = (x as IndustryDto).GetId()
            };
        });

        await _companyIndustryRepository.AddRange(industries.ToList());
    }

    private async Task AddCompanyInfrastructureAsync()
    {
        var InfrastructureDto = new InfrastructureDto { 
        IssueTrackerId = SelectedIssueTracker.GetId(),
        RepositoryHostingId = SelectedRepositoryHosting.GetId()
        };


        var account = _accountProvider.Account!;
        var companyInfrastructure = new CompanyInfrastructureDto
        {
            CompanyId = Company.GetId(),
            InfrastructureId = 
        };

        await _companyInfrastructureRepository.AddRange(industries.ToList());
    }

    private async Task OnAddCompanyAsync()
    {
        _companyBenefitRepository.AddRange(
            SelectedBenefits.Select(x => x as CompanyBenefitDto).ToList()
        );
    }
}
