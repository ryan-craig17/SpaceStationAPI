using Microsoft.AspNetCore.Mvc;
using SpaceStationAPI.Interfaces;
using System.Net;


namespace SpaceStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarWarsController : ControllerBase
    {
        private IStarWarsLogic _starWarsLogic;

        public StarWarsController(IStarWarsLogic starWarsLogic)
        {
            _starWarsLogic = starWarsLogic;
        }

        // GET: api/<StarWarsController>/5
        [HttpGet]
        [Route("films/{id}")]
        public async Task<IActionResult> GetFilm(int id)
        {
            var film = await _starWarsLogic.GetFilms(id);
            var resultCode = (int)(film?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, film)); ;
        }

        [HttpGet]
        [Route("films-search")]
        public async Task<IActionResult> GetFilms(string searchTerm)
        {
            var films = await _starWarsLogic.SearchFilms(searchTerm);
            var resultCode = (int)(films?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, films)); ;
        }

        [HttpGet]
        [Route("person/{id}")]
        public async Task<IActionResult> GetPerson(int id)
        {
            var person = await _starWarsLogic.GetPerson(id);
            var resultCode = (int)(person?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, person)); ;
        }

        [HttpGet]
        [Route("people-search")]
        public async Task<IActionResult> GetPeople(string searchTerm)
        {
            var people = await _starWarsLogic.SearchPeople(searchTerm);
            var resultCode = (int)(people?.StatusCode ?? HttpStatusCode.InternalServerError);

            return await Task.FromResult<IActionResult>(StatusCode(resultCode, people)); ;
        }
    }
}
