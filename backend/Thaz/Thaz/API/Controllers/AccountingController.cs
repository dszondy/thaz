using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thaz.API.DTOs;
using Thaz.API.QueryObjects;
using Thaz.BLL.Model;
using Thaz.BLL.Services;
using Thaz.DAL.Repositories;
using Thaz.DAL.Repositories.Accounting;

namespace Thaz.API.Controllers{

    [ApiController]
    [Route("accounting")]
    [Authorize]
    public class AccountingController : ControllerBase
    {
        public AccountingController(AccountingService accountingService)
        {
            AccountingService = accountingService;
        }

        private AccountingService AccountingService { get; }

        [HttpGet]
        [Route("balance")]
        public ActionResult<Balance> GetBalance([FromQuery] AccountingParams accountingParams)
        {
            return AccountingService.GetBalance(accountingParams.ToModel());
        }


        [HttpGet]
        [Route("history")]
        public ActionResult<Dictionary<string, Balance>> GetBalanceHistory(
            [FromQuery] AccountingParams accountingParams)
        {
            return AccountingService.GetMonthlyBalanceHistory(accountingParams.ToModel());
        }

        [HttpGet]
        [Route("balances")]
        public ActionResult<PagedResponse<PartnerCondominiumBalance>> PartnerBalances([FromQuery] int page = 0)
        {
            var b = AccountingService.PartnerBalances(page);
            return Ok(new PagedResponse<PartnerCondominiumBalance>
            {
                Values = b.Take(Utils.PageSize),    
                MorePages = b.Count() > Utils.PageSize
            });
        }
    }
}