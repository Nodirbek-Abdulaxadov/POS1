using BLL.Dtos.ReceiptDtos;
using BLL.Dtos.TransactionDtos;
using BLL.Dtos.WarehouseDtos;
using BLL.Interfaces;
using BLL.Validations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptService _receiptService;

        public ReceiptController(IReceiptService receiptService)
        {
            _receiptService = receiptService;
        }

        [HttpPost]
        public async Task<ActionResult<ReceiptDto>> Put([FromQuery] AddReceiptDto dto, 
            [FromBody] List<TransactionAsReceiptItemDto> transactions)
        {
            try
            {
                var model = await _receiptService.AddAsync(dto, transactions);
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paged")]
        public async Task<IActionResult> Get(int pageSize, int pageNumber)
        {
            try
            {
                var list = await _receiptService.GetPagedReceiptsWithoutLoans(pageSize, pageNumber);

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
            catch (MarketException)
            {
                var list = new List<WarehouseViewDto>();
                var metaData = new
                {
                    TotalCount = 0,
                    PageSize = 0,
                    CurrentPage = 0,
                    HasNext = 0,
                    HasPrevious = 0,
                    TotalPages = 0
                };

                Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metaData));

                return Ok(list);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}