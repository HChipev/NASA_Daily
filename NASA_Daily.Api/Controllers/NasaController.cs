using Microsoft.AspNetCore.Mvc;
using NASA_Daily.Domain.Services.Interfaces;

namespace NASA.Api.Controllers
{
    [Route("api/nasa")]
    [ApiController]
    public class NasaController : ControllerBase
    {
        private readonly INasaService _nasaService;

        public NasaController(INasaService nasaService)
        {
            _nasaService = nasaService;
        }

        [HttpGet("daily")]
        public async Task<IActionResult> GetDailyNasaImage([FromQuery] DateTime date)
        {
            var result = await _nasaService.GetDailyNasaImageAsync(date);
            return result.IsSuccess ? Ok(result.Data) : BadRequest(result.ErrorMessage);
        }
    }
}