using SpaceStationAPI.Models.View;

namespace SpaceStationAPI.Interfaces
{
    public interface IStarWarsLogic
    {
        public Task<StarWarsFilmView> GetFilms(int id);
        public Task<StarWarsFilmListView> SearchFilms(string searchTerm);
        public Task<StarWarsPersonView> GetPerson(int id);
        public Task<StarWarsPersonListView> SearchPeople(string searchTerm);
    }
}
