using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinDecoderSalvageApi.Interface;

namespace VinDecoderSalvageApi.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class VinController : ControllerBase
        {
            private readonly IVinDecoderService _vinDecoderService;

            public VinController(IVinDecoderService vinDecoderService)
            {
                _vinDecoderService = vinDecoderService;
            }

        //[HttpGet("decode/{vin}")]
        //public async Task<IActionResult> DecodeVin(string vin)
        //{
        //    var vinData = await _vinDecoderService.DecodeVinAsync(vin);
        //    if (vinData != null)
        //    {
        //        return Ok(vinData);
        //    }
        //    return NotFound("VIN data not found.");
        //}

        // Enable CORS for this specific controller
        [EnableCors]
        [HttpGet("decode/{vin}")]
            public async Task<IActionResult> DecodeVin(string vin)
            {
                var vinData = await _vinDecoderService.DecodeVinAsync(vin);
                if (vinData == null)
                {
                    return NotFound("VIN not found");
                }

                return Ok(vinData);
            }
    }
}


