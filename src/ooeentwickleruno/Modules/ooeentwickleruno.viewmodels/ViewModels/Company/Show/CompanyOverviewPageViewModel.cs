using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;
using ooeentwickleruno.viewmodels.Models;

namespace ooeentwickleruno.viewmodels.ViewModels.Company.Show;

public partial class CompanyOverviewPageViewModel : RegionBaseViewModel
{
    private readonly IDistrictRepository _districtRepository;
    private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyLocationRepository _companyLocationRepository;
    private readonly ICompanyInfrastructureRepository _companyInfrastructureRepository;
    private readonly IInfrastructureRepository _infrastructureRepository;
    private readonly IIssueTrackerRepository _issueTrackerRepository;
    private readonly IRepositoryHostingRepository _repositoryHostingRepository;
    private readonly ICompanyProgrammingFrameworkRepository _companyProgrammingFrameworkRepository;
    private readonly ICompanyProgrammingLanguageRepository _companyProgrammingLanguageRepository;

    public CompanyOverviewPageViewModel(
        VmServices vmServices,
        IDistrictRepository districtRepository,
        IProgrammingFrameworkRepository programmingFrameworkRepository,
        IProgrammingLanguageRepository programmingLanguageRepository,
        ICompanyRepository companyRepository,
        ICompanyLocationRepository companyLocationRepository,
        ICompanyInfrastructureRepository companyInfrastructureRepository,
        IInfrastructureRepository infrastructureRepository,
        IIssueTrackerRepository issueTrackerRepository,
        IRepositoryHostingRepository repositoryHostingRepository,
        ICompanyProgrammingFrameworkRepository companyProgrammingFrameworkRepository,
        ICompanyProgrammingLanguageRepository companyProgrammingLanguageRepository
    )
        : base(vmServices)
    {
        _districtRepository = districtRepository;
        _programmingFrameworkRepository = programmingFrameworkRepository;
        _programmingLanguageRepository = programmingLanguageRepository;
        _companyRepository = companyRepository;
        _companyLocationRepository = companyLocationRepository;
        _companyInfrastructureRepository = companyInfrastructureRepository;
        _infrastructureRepository = infrastructureRepository;
        _issueTrackerRepository = issueTrackerRepository;
        _repositoryHostingRepository = repositoryHostingRepository;
        _companyProgrammingFrameworkRepository = companyProgrammingFrameworkRepository;
        _companyProgrammingLanguageRepository = companyProgrammingLanguageRepository;
    }

    public async Task CompanyTappedAsync(CompanyOverviewModel companyOverviewModel)
    {
        ChangeCurrentRegion(
            "ShowCompanyPage",
            new NavigationParameters() { { "CompanyOverviewModel", companyOverviewModel } }
        );
    }

    public ObservableCollection<CompanyOverviewModel> Companies { get; set; } = new();

    public override async void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);

        navigationContext.Parameters.TryGetValue("DistrictId", out Guid districtId);

        var allProgrammingFrameworks = await _programmingFrameworkRepository.GetAll();
        var allProgrammingLanguages = await _programmingLanguageRepository.GetAll();
        var allInfrastructures = await _infrastructureRepository.GetAll();
        var allIssueTrackers = await _issueTrackerRepository.GetAll();
        var allRepositoryHostings = await _repositoryHostingRepository.GetAll();
        var companyInfrastructures = await _companyInfrastructureRepository.GetAll();
        var companyProgrammingFrameworks = await _companyProgrammingFrameworkRepository.GetAll();
        var companyProgrammingLanguages = await _companyProgrammingLanguageRepository.GetAll();

        var allCompanyLocations = await _companyLocationRepository.GetAllFull();
        var locations = allCompanyLocations
            .Where(x => x.companyLocationDto.DistrictId == districtId)
            .ToList();

        for (var i = 0; i < 30; i++)
        {
            foreach (var item in locations)
            {
                var companyId = item.company.companyDto.GetId();
                var languages = companyProgrammingLanguages
                    .Where(x => x.CompanyId == companyId)
                    .Select(x =>
                        allProgrammingLanguages.FirstOrDefault(y =>
                            y.GetId() == x.ProgrammingLanguageId
                        )
                    )
                    .ToList();
                var frameworks = companyProgrammingFrameworks
                    .Where(x => x.CompanyId == companyId)
                    .Select(x =>
                        allProgrammingFrameworks.FirstOrDefault(y =>
                            y.GetId() == x.ProgrammingFrameworkId
                        )
                    )
                    .ToList();

                var infrastructureId = companyInfrastructures
                    .FirstOrDefault(x => x.CompanyId == companyId)
                    .InfrastructureId;
                var infrastructure = allInfrastructures.FirstOrDefault(x =>
                    x.GetId() == infrastructureId
                );
                var issueTracker = allIssueTrackers.FirstOrDefault(x =>
                    x.GetId() == infrastructure.IssueTrackerId
                );
                var repositoryHosting = allRepositoryHostings.FirstOrDefault(x =>
                    x.GetId() == infrastructure.RepositoryHostingId
                );

                Companies.Add(
                    new CompanyOverviewModel(
                        item.company.companyDto,
                        item.companyLocationDto,
                        languages,
                        frameworks,
                        repositoryHosting,
                        issueTracker
                    )
                );
            }
        }
    }
}
