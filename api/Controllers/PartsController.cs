using api.Models;
using api.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PartsController : ControllerBase
    {
        private readonly IPartInterface _partService;
        private readonly ILogger<PartsController> _logger;

        public PartsController(IPartInterface partInterface, ILogger<PartsController> logger)
        {
            _logger = logger;
            _partService = partInterface;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PartDTO>>> GetAllPartsAsync()
        {
            try
            {
                var parts = await _partService.GetAllPartsAsync();
                _logger.LogInformation("Retrived All Parts successfully");
                return Ok(parts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occured while trying to get all parts");
                return BadRequest("Internal Server Error");
            }
        }

        [HttpGet("{serialNo}")]
        public async Task<ActionResult<IEnumerable<PartDTO>>> GetPartBySerialNumberAsync(string serialNo)
        {
            try
            {
                var parts = await _partService.GetPartBySerialNumberAsync(serialNo);
                _logger.LogInformation("Retrieved parts with serial number {SerialNo} successfully.", serialNo);
                return Ok(parts);
            }
            catch (KeyNotFoundException ex)
            {
                _logger.LogWarning(ex, "Part with serial number {SerialNo} not found.", serialNo);
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the part by serial number.");
                return StatusCode(500, "Internal server error");
            }
        }

    }
}
