using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using Microsoft.UI.Xaml.Media.Imaging;
using ooeentwickleruno.services.Provider.AccountProvider;
using ReactiveUI;

namespace ooeentwickleruno.viewmodels.ViewModels.Company.Show;

public partial class ShowCompanyPageViewModel : RegionBaseViewModel
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
    private readonly ICompanyLogoRepository _companyLogoRepository;
    private readonly ICompanyPresentationImageRepository _companyPresentationImageRepository;

    public List<ProgrammingLanguageDto> AllProgrammingLanguages { get; set; }
    public List<ProgrammingFrameworkDto> AllProgrammingFrameworks { get; set; }
    public List<IndustryDto> AllIndustries { get; set; }
    public List<IssueTrackerDto> AllIssueTrackers { get; set; }
    public List<RepositoryHostingDto> AllRepositoryHostings { get; set; }

    public ObservableCollection<ProgrammingLanguageDto> CompanyProgrammingLanguages { get; set; } =
        new();
    public ObservableCollection<ProgrammingFrameworkDto> CompanyProgrammingFrameworks { get; set; } =
        new();
    public ObservableCollection<IndustryDto> CompanyIndustries { get; set; } = new();
    public CompanyInfrastructureDto CompanyCompanyInfrastructure { get; set; }
    public ObservableCollection<CompanyBenefitDto> CompanyCompanyBenefits { get; set; }
    public IssueTrackerDto SelectedIssueTracker { get; set; }
    public RepositoryHostingDto SelectedRepositoryHosting { get; set; }
    public List<string> InfrastructureNames { get; set; }

    public CompanyDto Company { get; set; }

    public BitmapImage CompanyLogo { get; set; }
    public BitmapImage CompanyPresentationImage { get; set; }

    public ShowCompanyPageViewModel(
        VmServices vmServices,
        ICompanyRepository companyRepository,
        IInfrastructureRepository infrastructureRepository,
        IProgrammingLanguageRepository programmingLanguageRepository,
        IProgrammingFrameworkRepository programmingFrameworkRepository,
        ICompanyProgrammingLanguageRepository companyProgrammingLanguageRepository,
        ICompanyIndustryRepository companyIndustryRepository,
        ICompanyInfrastructureRepository companyInfrastructureRepository,
        ICompanyProgrammingFrameworkRepository companyProgrammingFrameworkRepository,
        ICompanyLocationRepository companyLocationRepository,
        ICompanyBenefitRepository companyBenefitRepository,
        IIndustryRepository industryRepository,
        IIssueTrackerRepository issueTrackerRepository,
        IRepositoryHostingRepository repositoryHostingRepository,
        IAccountProvider accountProvider,
        ICompanyLogoRepository companyLogoRepository,
        ICompanyPresentationImageRepository companyPresentationImageRepository
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
        _companyLogoRepository = companyLogoRepository;
        _companyPresentationImageRepository = companyPresentationImageRepository;
    }

    public override async void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        Company = await _companyRepository.GetLast();
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

        var companyIndustries = await _companyIndustryRepository.GetAll();
        foreach (var companyIndustrie in companyIndustries)
        {
            CompanyIndustries.Add(await _industryRepository.Get(companyIndustrie.IndustryId));
        }

        var companyLanguages = await _companyProgrammingLanguageRepository.GetAll();
        foreach (var companyLanguage in companyLanguages)
        {
            CompanyProgrammingLanguages.Add(
                await _programmingLanguageRepository.Get(companyLanguage.ProgrammingLanguageId)
            );
        }
        var companyFrameworks = await _companyProgrammingFrameworkRepository.GetAll();
        foreach (var companyFramework in companyFrameworks)
        {
            CompanyProgrammingFrameworks.Add(
                await _programmingFrameworkRepository.Get(companyFramework.ProgrammingFrameworkId)
            );
        }

        CompanyCompanyInfrastructure = await _companyInfrastructureRepository.GetLast();
        var oldInfrastructure = await _infrastructureRepository.Get(
            CompanyCompanyInfrastructure.InfrastructureId
        );
        SelectedIssueTracker = AllIssueTrackers.First(x =>
            x.GetId() == oldInfrastructure.IssueTrackerId
        );
        SelectedRepositoryHosting = AllRepositoryHostings.First(x =>
            x.GetId() == oldInfrastructure.RepositoryHostingId
        );
        InfrastructureNames = new List<string>
        {
            SelectedIssueTracker.Name,
            SelectedRepositoryHosting.Name
        };
        this.RaisePropertyChanged(nameof(InfrastructureNames));

        CompanyCompanyBenefits = new ObservableCollection<CompanyBenefitDto>(
            await _companyBenefitRepository.GetAll()
        );
        this.RaisePropertyChanged(nameof(CompanyIndustries));
        this.RaisePropertyChanged(nameof(CompanyProgrammingFrameworks));
        this.RaisePropertyChanged(nameof(CompanyProgrammingLanguages));
        this.RaisePropertyChanged(nameof(CompanyCompanyInfrastructure));
        this.RaisePropertyChanged(nameof(SelectedIssueTracker));
        this.RaisePropertyChanged(nameof(SelectedRepositoryHosting));
        this.RaisePropertyChanged(nameof(CompanyCompanyBenefits));

        var companyLogoBytes = (await _companyLogoRepository.GetLast()).bytes;
        var companyPresentationImageBytes = (
            await _companyPresentationImageRepository.GetLast()
        ).bytes;
        CompanyLogo = new BitmapImage();
        CompanyLogo.SetSource(new MemoryStream(companyLogoBytes));
        CompanyPresentationImage = new BitmapImage();
        CompanyPresentationImage.SetSource(new MemoryStream(companyPresentationImageBytes));
        this.RaisePropertyChanged(nameof(CompanyLogo));
        this.RaisePropertyChanged(nameof(CompanyPresentationImage));
    }
}
