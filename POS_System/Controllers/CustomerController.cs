using BLL.Dtos.CustomerDtos;
using BLL.Dtos.WarehouseDtos;
using BLL.Interfaces;
using BLL.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerViewDto>>> Get()
        {
            try
            {
                var list = await _customerService.GetAllAsync();
                return Ok(list);
            }
            catch(ArgumentNullException)
            {
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("paged")]
        public async Task<ActionResult<IEnumerable<CustomerViewDto>>> Get(int pageSize, int pageNumber)
        {
            try
            {
                var list = await _customerService.GetPagedAsync(pageSize, pageNumber);
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

                return Ok(list.Data);
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

        [HttpGet("archived/paged")]
        public async Task<ActionResult<IEnumerable<CustomerViewDto>>> GetArchived(int pageSize, int pageNumber)
        {
            try
            {
                var list = await _customerService.GetArchivedAsync(pageSize, pageNumber);
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

                return Ok(list.Data);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerViewDto>> Get(int id)
        {
            try
            {
                var model = await _customerService.GetByIdAsync(id);
                return Ok(model);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CustomerViewDto>> Post(AddCustomerDto model)
        {
            try
            {
                var res = await _customerService.AddAsync(model);
                return StatusCode(201, res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<CustomerViewDto>> Put(CustomerViewDto model)
        {
            try
            {
                var res = await _customerService.UpdateAsync(model);
                return Ok(res);
            }
            catch (MarketException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var model = await _customerService.GetByIdAsync(id);
                await _customerService.RemoveAsync(id);
                return NoContent();
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}