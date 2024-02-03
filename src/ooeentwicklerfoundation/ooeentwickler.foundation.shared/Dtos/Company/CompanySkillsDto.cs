[Dto]
public partial class CompanySkillsDto : CompanySubBaseDto
{
    [ForeignKey(nameof(SkillsDto))]
    public Guid SkillsId { get; set; }
}
