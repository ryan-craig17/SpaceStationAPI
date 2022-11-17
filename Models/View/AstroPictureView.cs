namespace SpaceStationAPI.Models.View
{
    public class AstroPictureView : BaseResponse
    {
        public Uri Url { get; set; }
        public Uri HDurl { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
