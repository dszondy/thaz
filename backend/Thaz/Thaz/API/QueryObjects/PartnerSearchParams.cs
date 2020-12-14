using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Thaz.API.QueryObjects
{
    public class PartnerSearchParams
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; }
        
        [FromQuery(Name = "name")]
        public string Name { get; set; }
        
        [FromQuery(Name = "isResident")]
        public bool? IsResident { get; set; }
        
        [FromQuery(Name = "isSupplier")]
        public bool? IsSupplier { get; set; }
        
        [FromQuery(Name = "condominiumId")]
        public int? CondominiumId { get; set; }

        internal BLL.QueryObjects.PartnerSearchParams ToModel()
        {
            return Mapper.Map<BLL.QueryObjects.PartnerSearchParams>(this);
        }

        private static Mapper Mapper { get; } =
            new Mapper(new MapperConfiguration(x =>
                x.CreateMap<PartnerSearchParams, BLL.QueryObjects.PartnerSearchParams>()));
    }
}