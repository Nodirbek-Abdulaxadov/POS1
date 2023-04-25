using BLL.Dtos.WarehouseItemDtos;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet("paged")]
        public async Task<IActionResult> Get(int pageSize, int pageNumber)
        {
            var list = await _transferService.GetPagedAsync(pageNumber, pageSize);
            var metaData = new
            {
                list.TotalCount,
                list.PageSize,
                list.CurrentPage,
                list.HasNext,
                list.HasPrevious,
                list.TotalPages
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));
            var json = JsonConvert.SerializeObject(list.Data, Formatting.Indented,
                new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            return Ok(json);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] TransferParametrs parametrs, [FromBody] List<TransferItem> items)
        {
            try
            {
                await _transferService.CreateNewTransferAsync(parametrs, items);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
