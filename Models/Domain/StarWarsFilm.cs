namespace SpaceStationAPI.Models.Domain
{
    public class StarWarsFilm : BaseResponse
    {
        public string title { get; set; }
        public int episode_id { get; set; }
        public string opening_crawl { get; set; }
        public string director { get; set; }
        public string producer { get; set; }
        public string release_date { get; set; }
        public IEnumerable<string> characters { get; set; }
        public IEnumerable<string> planets { get; set; }
        public IEnumerable<string> species { get; set; }
        public IEnumerable<string> starships { get; set; }
        public IEnumerable<string> vehicles { get; set; }
        public DateTime? created { get; set; }
        public DateTime? edited { get; set; }
        public string url { get; set; }
    }

    public class StarWarsFilmList : BaseResponse
    {
        public int count { get; set; }
        public string next { get; set; }
        public string previous { get; set; }
        public IEnumerable<StarWarsFilm> results { get; set; }
    }
}
