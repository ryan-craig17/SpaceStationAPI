using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.Models;
using System.Net;
using System.Text.Json;

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

        // GET: api/<NasaController>
        [HttpGet]
        [Route("astro-picture")]
        public async Task<IActionResult> GetAPOD(DateTime? pictureDate)
        {
            var picURL = await _nasaLogic.GetAstronomyPictureURL(pictureDate);

            return await Task.FromResult<IActionResult>(StatusCode((int)HttpStatusCode.OK, picURL));
        }

        // GET api/<NasaController>/5
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            if (id == 420)
                return JsonSerializer.Serialize(_settings, new JsonSerializerOptions { WriteIndented = true });

            return $"id is {id}";
        }

        // POST api/<NasaController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NasaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NasaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
