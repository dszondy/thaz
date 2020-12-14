using Microsoft.AspNetCore.Mvc;
using Thaz.BLL.Model;

namespace Thaz.API.QueryObjects
{
    public class AccountingParams
    {
        [FromQuery(Name = "partner_id")]
        public int? PartnerId { get; set; }
        
        [FromQuery(Name = "condominium_id")]
        public int? CondominiumId { get; set; }
        
        [FromQuery(Name = "tag")]
        public string Tag { get; set; }

        public BLL.QueryObjects.AccountingParams ToModel()
        {
            return new BLL.QueryObjects.AccountingParams()
            {
                PartnerId = PartnerId,
                CondominiumId = CondominiumId,
                Tag = Tag
            };
        }
    }
}