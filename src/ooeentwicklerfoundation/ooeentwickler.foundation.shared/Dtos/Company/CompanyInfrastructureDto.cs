[Dto]
public partial class CompanyInfrastructureDto : CompanyReferenceBaseDto
{
    [ForeignKey(nameof(InfrastructureDto))]
    public required Guid InfrastructureId { get; set; }
}
