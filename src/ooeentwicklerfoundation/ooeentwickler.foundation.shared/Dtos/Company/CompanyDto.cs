[Dto]
public partial class CompanyDto : BaseDtoWithName
{
    [ForeignKey(nameof(IndustryDto))]
    public Guid IndustryId { get; set; }
    public int FoundingYear { get; set; }
    public int DeveloperCount { get; set; }
    public required string Description { get; set; }
    public required string HowWeDevelopDescription { get; set; }
    public string? CareerLink { get; set; }
    public string? WebsiteLink { get; set; }
}
