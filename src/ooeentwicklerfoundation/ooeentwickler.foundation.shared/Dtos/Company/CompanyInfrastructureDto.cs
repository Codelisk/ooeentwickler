[Dto]
public partial class CompanyInfrastructureDtoDto : CompanyReferenceBaseDto
{
    [ForeignKey(nameof(InfrastructureDto))]
    public required Guid InfrastructureId { get; set; }
}
