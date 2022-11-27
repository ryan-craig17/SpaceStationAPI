using Microsoft.Extensions.Options;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.Models;
using SpaceStationAPI.Models.Domain;
using SpaceStationAPI.Models.View;
using SpaceStationAPI.Transforms;

namespace SpaceStationAPI.LogicLayer
{
    public class StarWarsLogic : IStarWarsLogic
    {
        private IRestWorker _restWorker { get; set; }
        private Settings _settings { get; set; }
        private string wsURL_domain { get; set; }
        private const string querySearch = "?search={0}";

        public StarWarsLogic(IRestWorker restWorker, IOptions<Settings> settings)
        {
            _restWorker = restWorker;
            _settings = settings.Value;
            wsURL_domain = _settings.EnvironmentValues.StarWars_API_URL;
        }

        public async Task<StarWarsFilmView> GetFilms(int id)
        {
            var wsURL_path = $"{_settings.StaticValues.StarWarsResources.Films}{id}";
            var url = new Uri(new Uri(wsURL_domain), wsURL_path);

            var response = await _restWorker.CallService<StarWarsFilm>(url);
            var result = StarWarsTransformer.DomainToView(response);

            return result;
        }

        public async Task<StarWarsFilmListView> SearchFilms(string searchTerm)
        {
            var search = string.Format(querySearch, searchTerm);
            var wsURL_path = $"{_settings.StaticValues.StarWarsResources.Films}{search}";
            var url = new Uri(new Uri(wsURL_domain), wsURL_path);

            var response = await _restWorker.CallService<StarWarsFilmList>(url);
            var result = StarWarsTransformer.DomainToView(response);

            return result;
        }

        public async Task<StarWarsPersonView> GetPerson(int id)
        {
            var wsURL_path = $"{_settings.StaticValues.StarWarsResources.People}{id}";
            var url = new Uri(new Uri(wsURL_domain), wsURL_path);

            var response = await _restWorker.CallService<StarWarsPerson>(url);
            var result = StarWarsTransformer.DomainToView(response);

            return result;
        }

        public async Task<StarWarsPersonListView> SearchPeople(string searchTerm)
        {
            var search = string.Format(querySearch, searchTerm);
            var wsURL_path = $"{_settings.StaticValues.StarWarsResources.People}{search}";
            var url = new Uri(new Uri(wsURL_domain), wsURL_path);

            var response = await _restWorker.CallService<StarWarsPersonList>(url);
            var result = StarWarsTransformer.DomainToView(response);

            return result;
        }
    }
}
