namespace SpaceStationAPI.Models.View
{
    public class NearEarthObjectListView : BaseResponse
    {
        public List<NearEarthItem> NearEarthObjects { get; set; }
        public Page Page { get; set; }
    }

    public class Page
    {
        public int Size { get; set; }
        public int Number { get; set; }
        public int TotalElements { get; set; }
        public int TotalPages { get; set; }
    }
}
