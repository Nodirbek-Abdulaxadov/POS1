using BLL.Dtos.SubcategoryDtos;
using BLL.Helpers;
using BLL.Interfaces;
using BLL.Validations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class SubcategoryController : ControllerBase
{
    private readonly ISubcategoryService _subcategoryService;

    public SubcategoryController(ISubcategoryService subcategoryService)
	{
        _subcategoryService = subcategoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubcategoryDto>>> Get()
    {
        try
        {
            var list = await _subcategoryService.GetAllAsync();
            return Ok(list);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("paged")]
    public async Task<ActionResult<IEnumerable<SubcategoryDto>>> Get(int pageSize, int pageNumber)
    {
        try
        {
            var list = await _subcategoryService.GetSubcategoriesAsync(pageSize, pageNumber);
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
        catch (MarketException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("archived/paged")]
    public async Task<ActionResult<IEnumerable<SubcategoryDto>>> GetArchived(int pageSize, int pageNumber)
    {
        try
        {
            var list = await _subcategoryService.GetArchivedSubcategoriesAsync(pageSize, pageNumber);
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
        catch (MarketException ex)
        {
            return NotFound(ex.Message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubcategoryDto>> Get(int id)
    {
        try
        {
            var model = await _subcategoryService.GetByIdAsync(id);
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
    public async Task<ActionResult<SubcategoryDto>> Post(AddSubcategoryDto model)
    {
        try
        {
            var result = await _subcategoryService.AddAsync(model);
            return StatusCode(201, result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    public async Task<ActionResult<SubcategoryDto>> Put(UpdateSubcategoryDto model)
    {
        try
        {
            var res = await _subcategoryService.UpdateAsync(model);
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
            var model = await _subcategoryService.GetByIdAsync(id);
            await _subcategoryService.ActionAsync(id, ActionType.Remove);
            return Ok();
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

    [HttpPut("archive/{id}")]
    public async Task<IActionResult> Archive(int id)
    {
        try
        {
            var model = await _subcategoryService.GetByIdAsync(id);
            await _subcategoryService.ActionAsync(id, ActionType.Archive);
            return Ok();
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

    [HttpPut("recover/{id}")]
    public async Task<IActionResult> Recover(int id)
    {
        try
        {
            var model = await _subcategoryService.GetByIdAsync(id);
            await _subcategoryService.ActionAsync(id, ActionType.Recover);
            return Ok();
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