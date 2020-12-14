using System;
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
    [Route("bill")]
    [Authorize]
    public class BillController : ControllerBase
    {
        private BillService BillService { get; }
        private AccountingService AccountingService { get; }


        public BillController(BillService billService, AccountingService accountingService)
        {
            BillService = billService;
            AccountingService = accountingService;
        }

        [HttpGet]
        public PagedResponse<Bill> List([FromQuery] BillSearchParams searchParams)
        {
            var b = BillService.GetBills(searchParams.ToModel());
            return new PagedResponse<Bill>
            {
                Values = b.Take(Utils.PageSize),
                MorePages = b.Count() > Utils.PageSize
            };
        }

        [HttpGet]
        [Route("completion/{id?}")]
        public PagedResponse<BillWithCompletion> Completion([FromRoute] int id, [FromQuery] int page = 0)
        {
            var b = AccountingService.GetIssuedBillsWithTotalCompletion(id, page);
            return new PagedResponse<BillWithCompletion>
            {
                Values = b.Take(Utils.PageSize),
                MorePages = b.Count() > Utils.PageSize
            };
        }

        [HttpGet]
        [Route("{id?}")]
        public BillDetails Get([FromRoute] int id)
        {
            return BillService.GetBill(id);
        }

        [HttpPost]
        public BillDetails Post([FromBody] BillDetails bill)
        {
            Console.WriteLine(bill);
            Console.WriteLine("bill/post");
            if (bill.Created is null) bill.Created = DateTime.Now;

            return BillService.CreateBill(bill);
        }

        [HttpPatch]
        [Route("{id?}")]
        public BillDetails Patch([FromBody] BillDetails bill)
        {
            return BillService.Edit(bill);
        }
    }
}