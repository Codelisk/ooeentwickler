[Dto]
public partial class CompanyProgrammingFrameworkDto : CompanyReferenceBaseDto
{
    [ForeignKey(nameof(ProgrammingFrameworkDto))]
    public Guid ProgrammingFrameworkId { get; set; }
}
