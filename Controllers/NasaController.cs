using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.Models;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace SpaceStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasaController : ControllerBase
    {
        private Settings _settings { get; set; }
        private INasaLogic _nasaLogic { get; set; }

        public NasaController(IOptions<Settings> settings, INasaLogic nasaLogic)
        {
            _settings = settings.Value;
            _nasaLogic = nasaLogic;
        }

        [HttpGet]
        [Route("astronomy-picture")]
        public async Task<IActionResult> GetAPOD(DateTime? pictureDate)
        {
            var picture = await _nasaLogic.GetAstronomyPictureURL(pictureDate);
            var resultCode = (int)(picture?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, picture));
        }

        [HttpGet]
        [Route("asteroid-list")]
        public string GetAsteroidList(DateTime? startDate)
        {
            return $"startDate is {startDate:yyyy-MM-dd}";
        }

        [HttpGet]
        [Route("asteroid-lookup")]
        public string GetAsteroidLookup(int id)
        {
            return $"asteroid id is {id}";
        }

        [HttpGet]
        [Route("asteroid-browse")]
        public string BrowseAsteroids()
        {
            return "ok";
        }

        [HttpGet]
        [Route("mars-rover-photo")]
        public async Task<IActionResult> GetMarsRoverPhoto(DateTime? earthDate)
        {
            var photo = await _nasaLogic.GetMarsRoverPhotos(earthDate);
            var resultCode = (int)(photo?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, photo));
        }
    }
}
