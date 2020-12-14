using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thaz.API.DTOs;
using Thaz.API.QueryObjects;
using Thaz.BLL.Model;
using Thaz.BLL.Services;
using Thaz.DAL.Repositories;
using Thaz.DAL.Repositories.Accounting;

namespace Thaz.API.Controllers
{
    [ApiController]
    [Route("condominium")]
    [Authorize]
    public class CondominiumController
    {
        public CondominiumController(CondominiumService condominiumService, AccountingService accountingService)
        {
            CondominiumService = condominiumService;
            AccountingService = accountingService;
        }

        private CondominiumService CondominiumService { get; }
        private AccountingService AccountingService { get; }

        [HttpGet]
        public PagedResponse<Condominium> List([FromQuery] CondominiumSearchParams searchParams)
        {
            return new PagedResponse<Condominium>
            {
                Values = CondominiumService.List(searchParams.ToModel()),
                MorePages = false
            };
        }

        [HttpGet]
        [Route("{id?}")]
        public Condominium Get([FromRoute] int id)
        {
            return CondominiumService.Get(id);
        }

        [HttpPost]
        public Condominium Post([FromBody] Condominium condominium)
        {
            return CondominiumService.Create(condominium);
        }


        [HttpPatch]
        [Route("{id?}")]
        public Condominium Patch([FromBody] Condominium condominium)
        {
            return CondominiumService.Update(condominium);
        }

        [HttpGet]
        [Route("debt/issued")]
        public PagedResponse<CondominiumTotals> ListCondominiumsWithDebt([FromQuery] int page = 0)
        {
            var result = AccountingService.Debt(page, true).ToList();
            return new PagedResponse<CondominiumTotals>
            {
                Values = result.Take(Utils.PageSize),
                MorePages = result.Count() > Utils.PageSize
            };
        }

        [HttpGet]
        [Route("{id}/partners")]
        public PagedResponse<PartnerBalanceToCondominium> GetPartnersInDebt( [FromRoute] int id,[FromQuery] int page = 0)
        {
            var result = AccountingService.PartnerBalance(page, id);
            return new PagedResponse<PartnerBalanceToCondominium>
            {
                Values = result.Take(Utils.PageSize),
                MorePages = result.Count() > Utils.PageSize
            };
        }
    }
}