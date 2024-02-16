[Dto]
public partial class CompanyLocationDto : CompanySubBaseDto
{
    [ForeignKey(nameof(DistrictDto))]
    public Guid DistrictId { get; set; }
    public string Street { get; set; }
    public string Zipcode { get; set; }
    public string City { get; set; }
}
