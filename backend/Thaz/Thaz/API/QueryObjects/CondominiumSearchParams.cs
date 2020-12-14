using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Thaz.API.QueryObjects
{
    public class CondominiumSearchParams
    {
        [FromQuery(Name = "name")]
        public string Name { get; set; }
        
        public BLL.QueryObjects.CondominiumSearchParams ToModel()
        {
            return Mapper.Map<BLL.QueryObjects.CondominiumSearchParams>(this);
        }
        private static Mapper Mapper { get; } =
            new Mapper(new MapperConfiguration(x =>
                x.CreateMap<CondominiumSearchParams, BLL.QueryObjects.CondominiumSearchParams>()));
    }
}