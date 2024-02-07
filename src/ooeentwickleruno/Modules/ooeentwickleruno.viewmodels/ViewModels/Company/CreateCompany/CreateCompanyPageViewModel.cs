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
    private readonly IInfrastructureRepository _infrastructureRepository;
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

    public List<ProgrammingLanguageDto> AllProgrammingLanguages { get; set; }
    public List<ProgrammingFrameworkDto> AllProgrammingFrameworks { get; set; }
    public List<IndustryDto> AllIndustries { get; set; }
    public List<IssueTrackerDto> AllIssueTrackers { get; set; }
    public List<RepositoryHostingDto> AllRepositoryHostings { get; set; }

    public List<CompanyProgrammingLanguageDto> OldProgrammingLanguages { get; set; }
    public List<CompanyProgrammingFrameworkDto> OldProgrammingFrameworks { get; set; }
    public List<CompanyIndustryDto> OldIndustries { get; set; }
    public CompanyInfrastructureDto OldCompanyInfrastructure { get; set; }
    public List<CompanyBenefitDto> OldCompanyBenefits { get; set; }

    public List<object> SelectedProgrammingLanguages { get; set; } = new List<object>();
    public List<object> SelectedProgrammingFrameworks { get; set; } = new List<object>();
    public List<object> SelectedIndustries { get; set; } = new List<object>();
    public IssueTrackerDto SelectedIssueTracker { get; set; }
    public RepositoryHostingDto SelectedRepositoryHosting { get; set; }
    public ObservableCollection<object> SelectedBenefits { get; set; } = new();

    public CompanyDto Company { get; set; } = null;

    public CreateCompanyPageViewModel(
        VmServices vmServices,
        IInfrastructureRepository infrastructureRepository,
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
        _infrastructureRepository = infrastructureRepository;
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
        if (Company is null)
        {
            Company = new CompanyDto()
            {
                Description = "",
                HowWeDevelopDescription = "",
                Name = ""
            };
            Company = await _companyRepository.Add(Company);
        }
        this.RaisePropertyChanged(nameof(Company));

        AllProgrammingLanguages = await _programmingLanguageRepository.GetAll();
        this.RaisePropertyChanged(nameof(AllProgrammingLanguages));
        AllProgrammingFrameworks = await _programmingFrameworkRepository.GetAll();
        this.RaisePropertyChanged(nameof(AllProgrammingFrameworks));
        AllIndustries = await _industryRepository.GetAll();
        this.RaisePropertyChanged(nameof(AllIndustries));
        AllIssueTrackers = await _issueTrackerRepository.GetAll();
        this.RaisePropertyChanged(nameof(AllIssueTrackers));
        AllRepositoryHostings = await _repositoryHostingRepository.GetAll();
        this.RaisePropertyChanged(nameof(AllRepositoryHostings));

        OldIndustries = await _companyIndustryRepository.GetAll();
        SelectedIndustries = AllIndustries
            .Where(x => OldIndustries.Any(y => y.IndustryId == x.GetId()))
            .Cast<object>()
            .ToList();

        OldProgrammingFrameworks = await _companyProgrammingFrameworkRepository.GetAll();
        SelectedProgrammingFrameworks = AllProgrammingFrameworks
            .Where(x => OldProgrammingFrameworks.Any(y => y.ProgrammingFrameworkId == x.GetId()))
            .Cast<object>()
            .ToList();
        OldProgrammingLanguages = await _companyProgrammingLanguageRepository.GetAll();
        SelectedProgrammingLanguages = AllProgrammingLanguages
            .Where(x => OldProgrammingLanguages.Any(y => y.ProgrammingLanguageId == x.GetId()))
            .Cast<object>()
            .ToList();
        OldCompanyInfrastructure = await _companyInfrastructureRepository.GetLast();
        var oldInfrastructure = await _infrastructureRepository.Get(
            OldCompanyInfrastructure.InfrastructureId
        );
        SelectedIssueTracker = AllIssueTrackers.First(x =>
            x.GetId() == oldInfrastructure.IssueTrackerId
        );
        SelectedRepositoryHosting = AllRepositoryHostings.First(x =>
            x.GetId() == oldInfrastructure.RepositoryHostingId
        );
        OldCompanyBenefits = await _companyBenefitRepository.GetAll();
        SelectedBenefits = new ObservableCollection<object>(OldCompanyBenefits);

        this.RaisePropertyChanged(nameof(SelectedIndustries));
        this.RaisePropertyChanged(nameof(SelectedProgrammingFrameworks));
        this.RaisePropertyChanged(nameof(SelectedProgrammingLanguages));
        this.RaisePropertyChanged(nameof(SelectedIssueTracker));
        this.RaisePropertyChanged(nameof(SelectedRepositoryHosting));

        _vmServices.RegionManager.RequestNavigate(
            "CompanyBenefitRegion",
            "CreateBenefitView",
            new NavigationParameters { { "test", SelectedBenefits } }
        );

        base.OnNavigatedTo(navigationContext);
    }

    public ICommand AddCompanyCommand => this.LoadingCommand(OnAddCompanyAsync);

    private async Task AddCompanyProgrammingLanguageAsync()
    {
        foreach (var item in OldProgrammingLanguages)
        {
            await _companyProgrammingLanguageRepository.Delete(item.GetId());
        }

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
        foreach (var item in OldProgrammingFrameworks)
        {
            await _companyProgrammingFrameworkRepository.Delete(item.GetId());
        }

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
        foreach (var item in OldIndustries)
        {
            await _companyIndustryRepository.Delete(item.GetId());
        }

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
        await _companyInfrastructureRepository.Delete(OldCompanyInfrastructure.GetId());

        var infrastructureDto = new InfrastructureDto
        {
            IssueTrackerId = SelectedIssueTracker.GetId(),
            RepositoryHostingId = SelectedRepositoryHosting.GetId()
        };

        infrastructureDto = await _infrastructureRepository.Add(infrastructureDto);

        var companyInfrastructure = new CompanyInfrastructureDto
        {
            CompanyId = Company.GetId(),
            InfrastructureId = infrastructureDto.GetId()
        };

        await _companyInfrastructureRepository.Add(companyInfrastructure);
    }

    private async Task AddCompanyBenefitsAsync()
    {
        foreach (var item in OldCompanyBenefits)
        {
            await _companyBenefitRepository.Delete(item.GetId());
        }

        var benefits = SelectedBenefits.Select(x => x as CompanyBenefitDto).ToList();

        await _companyBenefitRepository.AddRange(benefits);
    }

    private async Task OnAddCompanyAsync()
    {
        Company = await _companyRepository.Save(Company);
        await AddCompanyProgrammingLanguageAsync();
        await AddCompanyProgrammingFrameworksAsync();
        await AddCompanyInfrastructureAsync();
        await AddCompanyIndustiresAsync();
        await AddCompanyBenefitsAsync();
    }
}
