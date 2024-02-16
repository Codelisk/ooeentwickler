public class CompanyReferenceBaseDto : BaseUserDto
{
    [ForeignKey(nameof(CompanyDto))]
    public Guid CompanyId { get; set; }
}
