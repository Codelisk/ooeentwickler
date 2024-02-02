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
    public CreateCompanyPageViewModel(VmServices vmServices) : base(vmServices)
    {
    }
}
