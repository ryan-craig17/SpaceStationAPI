using SpaceStationAPI.Models.View;

namespace SpaceStationAPI.Interfaces
{
    public interface INasaLogic
    {
        public Task<AstroPictureView> GetAstronomyPictureURL(DateTime? pictureDate);
        public Task<MarsRoverPhotoView> GetMarsRoverPhotos(DateTime? earthDate);
    }
}
