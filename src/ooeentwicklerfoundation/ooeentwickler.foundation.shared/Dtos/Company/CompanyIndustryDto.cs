[Dto]
public partial class CompanyIndustryDto : CompanySubBaseDto
{
    [ForeignKey(nameof(IndustryDto))]
    public Guid IndustryId { get; set; }
}
