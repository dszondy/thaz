namespace Thaz.BLL.QueryObjects
{
    public class PartnerSearchParams
        {
            public int Page { get; set; }
            public string Name { get; set; }
            public bool? IsResident { get; set; }
            public bool? IsSupplier { get; set; }
            public int? CondominiumId { get; set; }
        }
}