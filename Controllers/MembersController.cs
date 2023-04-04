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
    public class MembersController : ControllerBase
    {
        private readonly IMembersService _membersService;
        private readonly ILogger<MembersController> _logger;
        public MembersController(IMembersService membersService, ILogger<MembersController> logger)
        {
            _membersService = membersService;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetMembers()
        {
            try
            {
                _logger.LogInformation("GetMembers start");
                var members = await _membersService.GetMembersAsync();
                if (members == null || !members.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, "No element");
                }
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetMembers error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMemberAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetMemberbyId strated");
                var members = await _membersService.GetMembersByIdAsync(id);
                if (members == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(members);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetMemberByID error:{ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError), ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> PostMember([FromBody] Member member)
        {
            try
            {
                _logger.LogInformation("CreateMemberAsync started");
                if (member == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _membersService.CreateMembersAsync(member);
                return Ok(SuccessMessagesEnum.ElementSuccesfullyUptated);
            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteMemberAsync([FromRoute] Guid Id)
        {
            try
            {
                _logger.LogInformation("Delete Member Started");
                bool result = await _membersService.DeleteMembersAsync(Id);
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
        public async Task<IActionResult> PutMember([FromRoute] Guid id, [FromBody] CreateUpdateMembers members)
        {
            try
            {
                _logger.LogInformation("Update started..");
                if (members == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CreateUpdateMembers updatedMember = await _membersService.UpdateMembersAsync(id, members);
                if (updatedMember == null)
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
        public async Task<IActionResult> PatchMember([FromRoute] Guid id, [FromBody] CreateUpdateMembers member)
        {
            try
            {
                _logger.LogInformation("Update started..");
                if (member == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                CreateUpdateMembers updatedMember = await _membersService.UpdatePartiallyMembersAsync(id, member);
                if (updatedMember == null)
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
