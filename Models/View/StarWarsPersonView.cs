namespace SpaceStationAPI.Models.View
{
    public class StarWarsPersonView : BaseResponse
    {
        public StarWarsPersonItem StarWarsPerson { get; set; }
    }

    public class StarWarsPersonItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public double Height_cm { get; set; }
        public double Mass_kg { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public int HomeWorldId { get; set; }
        public List<int> Films { get; set; }
        public List<int> Species { get; set; }
        public List<int> Starships { get; set; }
        public List<int> Vehicles { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Edited { get; set; }
        public Uri Url { get; set; }

        public StarWarsPersonItem()
        {
            Films = new List<int>();
            Species = new List<int>();
            Starships = new List<int>();
            Vehicles = new List<int>();
        }
    }

    public class StarWarsPersonListView : BaseResponse
    {
        public int Count { get; set; }
        public string Next { get; set; }
        public string Previous { get; set; }
        public List<StarWarsPersonItem> StarWarsPeople { get; set; }

        public StarWarsPersonListView()
        {
            StarWarsPeople = new List<StarWarsPersonItem>();
        }
    }
}
