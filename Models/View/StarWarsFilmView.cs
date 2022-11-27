
namespace SpaceStationAPI.Models.View
{
    public class StarWarsFilmView : BaseResponse
    {
        public StarWarsFilmItem StarWarsFilm { get; set; }
    }

    public class StarWarsFilmItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public List<int> Characters { get; set; }
        public List<int> Planets { get; set; }
        public List<int> Species { get; set; }
        public List<int> Starships { get; set; }
        public List<int> Vehicles { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
        public Uri Url { get; set; }

        public StarWarsFilmItem()
        {
            Characters = new List<int>();
            Planets = new List<int>();
            Species = new List<int>();
            Starships = new List<int>();
            Vehicles = new List<int>();
        }
    }

    public class StarWarsFilmListView : BaseResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<StarWarsFilmItem> StarWarsFilms { get; set; }

        public StarWarsFilmListView()
        {
            StarWarsFilms = new List<StarWarsFilmItem>();
        }
    }
}
