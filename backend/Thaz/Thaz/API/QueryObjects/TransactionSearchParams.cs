using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Thaz.API.QueryObjects
{
    public class TransactionSearchParams
    {
        [FromQuery(Name = "page")]
        public int Page { get; set; }
        [FromQuery(Name = "after")]
        public DateTime? After { get; set; }
        [FromQuery(Name = "before")]
        public DateTime? Before { get; set; }
        [FromQuery(Name = "amountLess")]
        public double? AmountLess { get; set; }
        [FromQuery(Name = "amountMore")]
        public double? AmountMore { get; set; }
        [FromQuery(Name = "accountNumber")]
        public string AccountNumber { get; set; }
        [FromQuery(Name = "partnerId")]
        public int? PartnerId { get; set; }
        [FromQuery(Name = "transactionIdentifier")]
        public string TransactionIdentifier { get; set; }
        
        private static Mapper Mapper { get; } =
            new Mapper(new MapperConfiguration(x =>
                x.CreateMap<TransactionSearchParams, BLL.QueryObjects.TransactionSearchParams>()));

        public BLL.QueryObjects.TransactionSearchParams ToModel()
        {
            return Mapper.Map<BLL.QueryObjects.TransactionSearchParams>(this);
        }
    }
}