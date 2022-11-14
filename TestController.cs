using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SpaceStationAPI.Models;

namespace SpaceStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private Settings _settings { get; set; }

        public TestController(IOptions<Settings> settings)
        {
            _settings = settings.Value;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { $"API name: {_settings.StaticValues.APIname}", $"NASA API: {_settings.EnvironmentValues.NASA_API_URL}", $"API_key: {_settings.EnvironmentValues.APIkey_NASA}" };
        }

        // GET api/<TestController>/5
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return $"The id value is {id}";
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TestController>/5
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TestController>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
