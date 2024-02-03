public class CompanyReferenceBaseDto : BaseUserDto
{
    [ForeignKey(nameof(CompanyDto))]
    public required Guid CompanyId { get; set; }
}
