using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thaz.API.DTOs;
using Thaz.API.QueryObjects;
using Thaz.BLL.Model;
using Thaz.BLL.Services;
using Thaz.DAL.Repositories;

namespace Thaz.API.Controllers
{
    [ApiController]
    [Route("transaction")]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        private TransactionService TransactionService { get; }

        public TransactionController(TransactionService transactionService)
        {
            this.TransactionService = transactionService;
        }

        [HttpGet]
        public PagedResponse<Transaction> List([FromQuery] TransactionSearchParams search)
        {


            var t = TransactionService.List(search.ToModel());
            return new PagedResponse<Transaction>
            {
                Values = t.Take(Utils.PageSize),
                MorePages = t.Count() > Utils.PageSize
            };
        }

        [HttpGet]
        [Route("{id?}")]
        public TransactionDetails Get([FromRoute] int id)
        {
            return TransactionService.Get(id);
        }

        [HttpPost]
        public TransactionDetails Post([FromBody] TransactionDetails transaction)
        {
            return TransactionService.Create(transaction);
        }

        [HttpPatch]
        public TransactionDetails Patch([FromBody] TransactionDetails transaction)
        {
            return TransactionService.Update(transaction);
        }
    }
}