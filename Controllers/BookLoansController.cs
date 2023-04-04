using Biblioteca_API.DTOs.CreateUpdateObjects;
using Biblioteca_API.DTOs;
using Biblioteca_API.Helpers;
using Biblioteca_API.Model;
using Biblioteca_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Biblioteca_API.Controllers
{

        [Route("api/[controller]")]
        [ApiController]
        [Authorize(AuthenticationSchemes= JwtBearerDefaults.AuthenticationScheme)]
        public class BookLoansController : Controller
        {
            private readonly IBookLoansService _bookLoansService;
            private readonly ILogger<BookLoansController> _logger;
            public BookLoansController(IBookLoansService bookLoansService, ILogger<BookLoansController> logger)
            {
                _bookLoansService = bookLoansService;
                _logger = logger;
            }
            [HttpGet]
            public async Task<IActionResult> GetBookLoans()
            {
                try
                {
                    _logger.LogInformation("GetBookLoans start");
                    var bookLoans = await _bookLoansService.GetBookLoanAsync();
                    if (bookLoans == null || !bookLoans.Any())
                    {
                        return StatusCode((int)HttpStatusCode.NoContent, "No element");
                    }
                    return Ok(bookLoans);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetBookLoans error: {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }

            }
            [HttpGet("{id}")]
            public async Task<IActionResult> GetBookLoanAsync([FromRoute] Guid id)
            {
                try
                {
                    _logger.LogInformation("GetBookLoanbyId strated");
                    var bookloan = await _bookLoansService.GetBookLoanByIdAsync(id);
                    if (bookloan == null)
                    {
                        return NotFound(ErrorMessagesEnum.NoElementFound);
                    }
                    return Ok(bookloan);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"GetBookLoanByID error:{ex.Message}");
                    return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
                }

            }
            [HttpPost]
            public async Task<IActionResult> PostBookLoan([FromBody] BookLoan bookLoan)
            {
                try
                {
                    _logger.LogInformation("CreateBookLoanAsync started");
                    if (bookLoan == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    await _bookLoansService.CreateBookLoanAsync(bookLoan);
                    return Ok(SuccessMessagesEnum.ElementSuccesfullyUptated);
                }
                catch (ModelValidationException ex)
                {
                    _logger.LogError($"validation exception {ex.Message}");
                    return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
                }
            }
            [HttpDelete("{Id}")]
            public async Task<IActionResult> DeleteBookLoanAsync([FromRoute] Guid Id)
            {
                try
                {
                    _logger.LogInformation("Delete BookLoan Started");
                    bool result = await _bookLoansService.DeleteBookLoanAsync(Id);
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
            public async Task<IActionResult> PutBookLoan([FromRoute] Guid id, [FromBody] CreateUpdateBookLoans bookLoans)
            {
                try
                {
                    _logger.LogInformation("Update started..");
                    if (bookLoans == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    CreateUpdateBookLoans updatedBookLoan = await _bookLoansService.UpdateBookLoanAsync(id, bookLoans);
                    if (updatedBookLoan == null)
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
            public async Task<IActionResult> PatchBookLoan([FromRoute] Guid id, [FromBody] CreateUpdateBookLoans bookloan)
            {
                try
                {
                    _logger.LogInformation("Update started..");
                    if (bookloan == null)
                    {
                        return BadRequest(ErrorMessagesEnum.BadRequest);
                    }
                    CreateUpdateBookLoans updatedBookLoan = await _bookLoansService.UpdatePartiallyBookLoanAsync(id, bookloan);
                    if (updatedBookLoan == null)
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

