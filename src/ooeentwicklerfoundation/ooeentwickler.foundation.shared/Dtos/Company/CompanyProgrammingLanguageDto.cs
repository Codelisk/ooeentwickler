[Dto]
public partial class CompanyProgrammingLanguageDto : CompanyReferenceBaseDto
{
    [ForeignKey(nameof(ProgrammingLanguageDto))]
    public Guid ProgrammingLanguageId { get; set; }
}
