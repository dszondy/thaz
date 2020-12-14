using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Thaz.API.QueryObjects
{
    public class BillSearchParams
    {
        [FromQuery(Name = "partnerId")]
        public int? PartnerId { get; set; }
        [FromQuery(Name = "page")]
        public int Page { get; set; }
        [FromQuery(Name = "serialFilter")]
        public string SerialFilter { get; set; }
        [FromQuery(Name = "dueAfter")]
        public DateTime? DueAfter { get; set; }
        [FromQuery(Name = "dueBefore")]
        public DateTime? DueBefore { get; set; }
        [FromQuery(Name = "issuedAfter")]
        public DateTime? IssuedAfter { get; set; }
        [FromQuery(Name = "issuedBefore")]
        public DateTime? IssuedBefore { get; set; }
        [FromQuery(Name = "isDone")]
        public bool? IsDone { get; set; }
        [FromQuery(Name = "valueMore")]
        public double? ValueMore { get; set; }
        [FromQuery(Name = "valueLess")]
        public double? ValueLess { get; set; }
        [FromQuery(Name = "includeCompletion")]
        public bool? IncludeCompletion { get; set; }
        
        public BLL.QueryObjects.BillSearchParams ToModel()
        {
            return Mapper.Map<BLL.QueryObjects.BillSearchParams>(this);
        }
        
        private static Mapper Mapper { get; } =
            new Mapper(new MapperConfiguration(x =>
                x.CreateMap<BillSearchParams, BLL.QueryObjects.BillSearchParams>()));
    }

}