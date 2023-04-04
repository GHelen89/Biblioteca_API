using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;
using Biblioteca_API.Helpers;
using Biblioteca_API.Model;
using Biblioteca_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Biblioteca_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        
            private readonly ICategoryService _categoryService;
            private readonly ILogger<CategoryController> _logger;
            public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
            {
                _categoryService = categoryService;
                _logger = logger;
            }
            [HttpGet]
            public async Task<IActionResult> GetGategory()
            {
                try
                {
                    _logger.LogInformation("GetCategory start");
                    var category = await _categoryService.GetCategoryAsync();
                    if (category == null || !category.Any())
                    {
                        return StatusCode((int)HttpStatusCode.NoContent, "No element");
                    }
                    return Ok(category);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetCategory error: {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetCategoryAsync([FromRoute] Guid id)
            {
                try
                {
                    _logger.LogInformation("GetCategorybyId strated");
                    var bookloan = await _categoryService.GetCategoryByIdAsync(id);
                    if (bookloan == null)
                    {
                        return NotFound(ErrorMessagesEnum.NoElementFound);
                    }
                    return Ok(bookloan);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetCategoryByID error:{ex.Message}");
                    return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
                }

            }
            [HttpPost]
            public async Task<IActionResult> PostCategory([FromBody] Category bookLoan)
            {
                try
                {
                    _logger.LogInformation("CreateCategoryAsync started");
                    if (bookLoan == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    await _categoryService.CreateCategoryAsync(bookLoan);
                    return Ok(SuccessMessagesEnum.ElementSuccesfullyUptated);
                }
                catch (ModelValidationException ex)
                {
                    _logger.LogError($"validation exception {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            [HttpDelete("{Id}")]
            public async Task<IActionResult> DeleteCategoryAsync([FromRoute] Guid Id)
            {
                try
                {
                    _logger.LogInformation("Delete Category Started");
                    bool result = await _categoryService.DeleteCategoryAsync(Id);
                    if (result)
                    {
                        return Ok(SuccessMessagesEnum.ElementSuccesfullyDeleted);
                    }
                    return BadRequest(ErrorMessagesEnum.NoElementFound);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Validation excption {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> PutCategory([FromRoute] Guid id, [FromBody] CreateUpdateCategory category)
            {
                try
                {
                    _logger.LogInformation("Update started..");
                    if (category == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    CreateUpdateCategory updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
                    if (updatedCategory == null)
                    {
                        return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                    }
                    return Ok(SuccessMessagesEnum.ElementSuccesfullyUptated);
                }
                catch (ModelValidationException ex)
                {
                    _logger.LogError($"Validation exception {ex.Message}");
                    return BadRequest(ex.Message);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Validation exception {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchCategory([FromRoute] Guid id, [FromBody] CreateUpdateCategory bookloan)
        {
            try
            {
                _logger.LogInformation("Update started..");
                if (bookloan == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CreateUpdateCategory updatedCategory = await _categoryService.UpdatePartiallyCategoryAsync(id, bookloan);
                if (updatedCategory == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccesfullyUptated);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }


        }
        
    }
}
