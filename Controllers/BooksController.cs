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
        public class BooksController : Controller
        {
            private readonly IBooksService _booksService;
            private readonly ILogger<BooksController> _logger;
            public BooksController(IBooksService booksService, ILogger<BooksController> logger)
            {
                _booksService = booksService;
                _logger = logger;
            }
            [HttpGet]
            public async Task<IActionResult> GetBooks()
            {
                try
                {
                    _logger.LogInformation("GetBooks start");
                    var books = await _booksService.GetBooksAsync();
                    if (books == null || !books.Any())
                    {
                        return StatusCode((int)HttpStatusCode.NoContent, "No element");
                    }
                    return Ok(books);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetBooks error: {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBookAsync([FromRoute] Guid id)
            {
                try
                {
                    _logger.LogInformation("GetBookbyId strated");
                    var books = await _booksService.GetBooksByIdAsync(id);
                    if (books == null)
                    {
                        return NotFound(ErrorMessagesEnum.NoElementFound);
                    }
                    return Ok(books);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetBookByID error:{ex.Message}");
                    return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
                }

            }
            [HttpPost]
            public async Task<IActionResult> PostBook([FromBody] Book book)
            {
                try
                {
                    _logger.LogInformation("CreateBookAsync started");
                    if (book == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    await _booksService.CreateBooksAsync(book);
                    return Ok(SuccessMessagesEnum.ElementSuccesfullyUptated);
                }
                catch (ModelValidationException ex)
                {
                    _logger.LogError($"validation exception {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            [HttpDelete("{Id}")]
            public async Task<IActionResult> DeleteBookAsync([FromRoute] Guid Id)
            {
                try
                {
                    _logger.LogInformation("Delete Book Started");
                    bool result = await _booksService.DeleteBooksAsync(Id);
                    if (result)
                    {
                        return Ok(SuccessMessagesEnum.ElementSuccesfullyDeleted);
                    }
                    return BadRequest(ErrorMessagesEnum.NoElementFound);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Validation exception {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            [HttpPut("{id}")]
            public async Task<IActionResult> PutBook([FromRoute] Guid id, [FromBody] CreateUpdateBooks books)
            {
                try
                {
                    _logger.LogInformation("Update started..");
                    if (books == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    CreateUpdateBooks updatedBook = await _booksService.UpdateBooksAsync(id, books);
                    if (updatedBook == null)
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
            public async Task<IActionResult> PatchBook([FromRoute] Guid id, [FromBody] CreateUpdateBooks book)
            {
                try
                {
                    _logger.LogInformation("Update started..");
                    if (book == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    CreateUpdateBooks updatedBook = await _booksService.UpdatePartiallyBooksAsync(id, book);
                    if (updatedBook == null)
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

