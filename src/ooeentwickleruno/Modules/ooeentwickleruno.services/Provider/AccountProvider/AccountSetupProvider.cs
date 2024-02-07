using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.services.Provider.AccountProvider;

internal class AccountSetupProvider : IAccountSetupProvider
{
    public DistrictDto? District { get; set; }
    public AccountTypeEnum? AccountType { get; set; }
    public SkillsDto? Skill { get; set; }
    public List<ProgrammingFrameworkDto>? PrimaryFrameworks { get; set; }
    public List<ProgrammingFrameworkDto>? SecondaryFrameworks { get; set; }
}
