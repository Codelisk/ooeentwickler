[Dto]
public partial class CompanyInfrastructureDto : CompanyReferenceBaseDto
{
    [ForeignKey(nameof(InfrastructureDto))]
    public Guid InfrastructureId { get; set; }
}
