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
    }
}
