[Dto]
public partial class CompanyIndustryDto : CompanySubBaseDto
{
    [ForeignKey(nameof(IndustryDto))]
    public required Guid IndustryId { get; set; }
}
