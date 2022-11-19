using SpaceStationAPI.Models.Domain;
using SpaceStationAPI.Models.View;

namespace SpaceStationAPI.Transforms
{
    public static class NasaTransformer
    {
        public static AstroPictureView DomainToView(AstroPicture astroPicture)
        {
            var result = new AstroPictureView
            {
                Description = astroPicture.explanation,
                Url = Uri.TryCreate(astroPicture.url, UriKind.Absolute, out var thisURL) ? thisURL : null,
                HDurl = Uri.TryCreate(astroPicture.hdurl, UriKind.Absolute, out var thisHDurl) ? thisHDurl : null,
                Title = astroPicture.title,
                IsErrorResponse = astroPicture.IsErrorResponse,
                ErrorMessage = astroPicture.ErrorMessage,
                StatusCode = astroPicture.StatusCode,
                Date = DateTime.TryParse(astroPicture.date, out var theDate) ? theDate : DateTime.UtcNow
            };

            return result;
        }

        public static MarsRoverPhotoView DomainToView(MarsRoverPhotos marsRoverPhotos)
        {
            var result = new MarsRoverPhotoView
            {
                MarsPhotos = new List<MarsPhotoItem>(),
                IsErrorResponse = marsRoverPhotos.IsErrorResponse,
                StatusCode = marsRoverPhotos.StatusCode,
            };

            foreach(var photo in marsRoverPhotos.photos)
            {
                var photoItem = new MarsPhotoItem 
                { 
                    Id = photo.id, 
                    MarsSol = photo.sol, 
                    ImageURL = Uri.TryCreate(photo.img_src, UriKind.Absolute, out var thisURL) ? thisURL : null,
                    EarthDate = DateTime.TryParse(photo.earth_date, out var theDate) ? theDate : DateTime.UtcNow,
                    CameraName = photo.camera.name, 
                    RoverName = photo.rover.name,
                };

                result.MarsPhotos.Add(photoItem);
            }

            return result;
        }
    }
}
