using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;

namespace ooeentwickleruno.viewmodels.ViewModels.Company;
public partial class CreateCompanyPageViewModel : RegionBaseViewModel
{
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
    private readonly IIndustryRepository _industryRepository;
    private readonly IIssueTrackerRepository _issueTrackerRepository;
    private readonly IRepositoryHostingRepository _repositoryHostingRepository;

    public List<ProgrammingLanguageDto> ProgrammingLanguages { get; set; }
    public List<ProgrammingFrameworkDto> ProgrammingFrameworks { get; set; }
    public List<IndustryDto> Industries { get; set; }
    public List<IssueTrackerDto> IssueTrackers { get; set; }
    public List<RepositoryHostingDto> RepositoryHostings { get; set; }
    public CreateCompanyPageViewModel(VmServices vmServices,
        IProgrammingLanguageRepository programmingLanguageRepository,
        IProgrammingFrameworkRepository programmingFrameworkRepository,
        IIndustryRepository industryRepository,
        IIssueTrackerRepository issueTrackerRepository,
        IRepositoryHostingRepository repositoryHostingRepository) : base(vmServices)
    {
        _programmingLanguageRepository = programmingLanguageRepository;
        _programmingFrameworkRepository = programmingFrameworkRepository;
        _industryRepository = industryRepository;
        _issueTrackerRepository = issueTrackerRepository;
        _repositoryHostingRepository = repositoryHostingRepository;
    }

    public override async void OnNavigatedTo(NavigationContext navigationContext)
    {
        ProgrammingLanguages = await _programmingLanguageRepository.GetAll();
        ProgrammingFrameworks = await _programmingFrameworkRepository.GetAll();
        Industries = await _industryRepository.GetAll();
        IssueTrackers = await _issueTrackerRepository.GetAll();
        RepositoryHostings = await _repositoryHostingRepository.GetAll();
        base.OnNavigatedTo(navigationContext);
    }
}
