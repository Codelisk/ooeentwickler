[Dto]
public partial class CompanyProgrammingFrameworkDto : CompanyReferenceBaseDto
{
    [ForeignKey(nameof(ProgrammingFrameworkDto))]
    public required Guid ProgrammingFrameworkId { get; set; }
}
