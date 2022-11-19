namespace SpaceStationAPI.Models.View
{
    public class MarsRoverPhotoView : BaseResponse
    {
        public List<MarsPhotoItem> MarsPhotos { get; set; }
    }

    public class MarsPhotoItem 
    {
        public int Id { get; set; }
        public int MarsSol { get; set; }
        public DateTime EarthDate { get; set; }
        public Uri ImageURL { get; set; }
        public string RoverName { get; set; }
        public string CameraName { get; set; }
    }
}
