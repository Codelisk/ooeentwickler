using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooeentwickleruno.viewmodels.Models;

public record CompanyOverviewModel(
    CompanyDto Company,
    CompanyLocationDto CompanyLocation,
    List<ProgrammingLanguageDto> Languages,
    List<ProgrammingFrameworkDto> Frameworks,
    RepositoryHostingDto RepositoryHosting,
    IssueTrackerDto IssueTracker
);
