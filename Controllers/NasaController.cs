using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.Models;
using SpaceStationAPI.Models.View;
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
        private INasaLogic _nasaLogic { get; set; }

        public NasaController(INasaLogic nasaLogic)
        {
            _nasaLogic = nasaLogic;
        }

        [HttpGet]
        [Route("astronomy-picture")]
        [Produces("application/json", Type = typeof(AstroPictureView))]
        public async Task<IActionResult> GetAPOD(DateTime? pictureDate)
        {
            var picture = await _nasaLogic.GetAstronomyPictureURL(pictureDate);
            var resultCode = (int)(picture?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, picture));
        }

        [HttpGet]
        [Route("asteroid-lookup")]
        [Produces("application/json", Type = typeof(NearEarthObjectView))]
        public async Task<IActionResult> GetAsteroidLookup(int id)
        {
            var neo = await _nasaLogic.GetNearEarthObject(id);
            var resultCode= (int)(neo?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, neo));
        }

        [HttpGet]
        [Route("asteroid-browse")]
        [Produces("application/json", Type = typeof(NearEarthObjectListView))]
        public async Task<IActionResult> BrowseAsteroids(int pageNumber = 0, int pageSize = 20)
        {
            var browse = await _nasaLogic.BrowseNearEarthObjects(pageNumber, pageSize);
            var resultCode = (int)(browse?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, browse));
        }

        [HttpGet]
        [Route("mars-rover-photo")]
        [Produces("application/json", Type = typeof(MarsRoverPhotoView))]
        public async Task<IActionResult> GetMarsRoverPhoto(DateTime? earthDate)
        {
            var photo = await _nasaLogic.GetMarsRoverPhotos(earthDate);
            var resultCode = (int)(photo?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, photo));
        }
    }
}
