using System;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thaz.BLL.Model;
using Thaz.BLL.Services;
using Thaz.DAL.Repositories;

namespace Thaz.API.Controllers
{
    [Route("bill/{id?}/file")]
    [ApiController]
    [Authorize]
    public class BillFileController : ControllerBase
    {
        private BillService BillService { get; }

        public BillFileController(BillService billService)
        {
            BillService = billService;
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        public int UploadFile([FromRoute] int id)
        {
            var file = Request.Form.Files[0];
            ;
            var fileName = Path.GetFileNameWithoutExtension(file.FileName);
            var extension = Path.GetExtension(file.FileName);
            var fileModel = new BillFile
            {
                BillId = id,
                CreatedOn = DateTime.UtcNow,
                FileType = file.ContentType,
                Extension = extension,
                Name = fileName
            };
            using (var dataStream = new MemoryStream())
            {
                file.CopyTo(dataStream);
                fileModel.Data = dataStream.ToArray();
            }

            return BillService.SaveBillFile(fileModel);
        }

        [HttpGet]
        public ActionResult Download([FromRoute] int id)
        {
            var file = BillService.GetBillFile(id);
            return File(file.Data, file.FileType, file.Name + file.Extension);
        }

        [HttpDelete]
        public ActionResult Delete([FromRoute] int id)
        {
            BillService.DeleteBillFile(id);
            return Ok();
        }
    }
}