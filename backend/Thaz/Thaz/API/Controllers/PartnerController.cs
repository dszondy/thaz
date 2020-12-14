using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thaz.API.DTOs;
using Thaz.BLL.Model;
using Thaz.BLL.QueryObjects;
using Thaz.BLL.Services;
using Thaz.DAL.Repositories;
using Thaz.DAL.Repositories.Accounting;
using PartnerSearchParams = Thaz.API.QueryObjects.PartnerSearchParams;

namespace Thaz.API.Controllers
{
    [ApiController]
    [Route("partner")]
    [Authorize]
    public class PartnerController : ControllerBase
    {
        public PartnerController(PartnerService partnerService, AccountingService accountingService)
        {
            PartnerService = partnerService;
            AccountingService = accountingService;
        }

        private PartnerService PartnerService { get; }
        private AccountingService AccountingService { get; }

        [HttpGet]
        public PagedResponse<Partner> Get([FromQuery] PartnerSearchParams searchParams)
        {
            var partners = PartnerService
                .List(searchParams.ToModel())
                .ToArray();
            return new PagedResponse<Partner>
            {
                Values = partners.Take(Utils.PageSize),
                MorePages = partners.Count() > Utils.PageSize
            };
        }

        [HttpGet]
        [Route("{id?}")]
        public ActionResult<PartnerDetails> Get([FromRoute] int id)
        {
                return Ok(PartnerService.Get(id));
        }

        [HttpPost]
        public Partner Post([FromBody] PartnerDetails partner)
        {
            return PartnerService.Create(partner);
        }

        [HttpPatch]
        [Route("{id?}")]
        public Partner Patch([FromBody] PartnerDetails partner)
        {
            return PartnerService.Update(partner);
        }

        [HttpGet]
        [Route("{id?}/balance")]
        public Balance GetBalance([FromRoute] int id)
        {
            return AccountingService.GetBalance(new AccountingParams() {PartnerId = id});
        }
    }
}