[Dto]
[PrimaryKey(nameof(DistrictId))]
[CustomizeGetAll(AllowAnonymous = true)]
public partial class DistrictImageDto : BaseBaseIdDto
{
    public required byte[] bytes { get; set; }
    [Id]
    [Key]
    [ForeignKey(nameof(DistrictDto))]
    public required Guid DistrictId { get; set; }

    public override Guid GetId()
    {
        return DistrictId;
    }
}