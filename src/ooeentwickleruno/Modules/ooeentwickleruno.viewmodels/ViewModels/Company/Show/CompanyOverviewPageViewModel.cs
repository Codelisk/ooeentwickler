using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Mvvm.ViewModels;
using Framework.Services.Services.Vms;

namespace ooeentwickleruno.viewmodels.ViewModels.Company.Show;

public partial class CompanyOverviewPageViewModel : RegionBaseViewModel
{
    private readonly IDistrictRepository _districtRepository;
    private readonly IProgrammingFrameworkRepository _programmingFrameworkRepository;
    private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyLocationRepository _companyLocationRepository;
    private readonly ICompanyInfrastructureRepository _companyInfrastructureRepository;
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
        _companyProgrammingFrameworkRepository = companyProgrammingFrameworkRepository;
        _companyProgrammingLanguageRepository = companyProgrammingLanguageRepository;
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        base.OnNavigatedTo(navigationContext);
    }
}
