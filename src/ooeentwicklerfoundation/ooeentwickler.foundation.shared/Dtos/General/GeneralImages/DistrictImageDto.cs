[Dto]
[PrimaryKey(nameof(DistrictId))]
[CustomizeGetAll(AllowAnonymous = true)]
public partial class DistrictImageDto : BaseBaseIdDto
{
    public byte[] bytes { get; set; }
    [Id]
    [Key]
    [ForeignKey(nameof(DistrictDto))]
    public Guid DistrictId { get; set; }

    public override Guid GetId()
    {
        return DistrictId;
    }
}