using SpaceStationAPI.Extensions;
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
                Url = astroPicture.url.ToUriOrNull(),
                HDurl = astroPicture.hdurl.ToUriOrNull(),
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
                    ImageURL = photo.img_src.ToUriOrNull(),
                    EarthDate = DateTime.TryParse(photo.earth_date, out var theDate) ? theDate : DateTime.UtcNow,
                    CameraName = photo.camera.name, 
                    RoverName = photo.rover.name,
                };

                result.MarsPhotos.Add(photoItem);
            }

            return result;
        }

        public static NearEarthObjectView DomainToView(NearEarthObject nearEarthObject)
        {
            if (nearEarthObject == null)
                return null;

            var closest = nearEarthObject.close_approach_data?.MinBy(data => data.miss_distance.miles);

            var result = new NearEarthObjectView
            {
                IsErrorResponse = nearEarthObject.IsErrorResponse,
                ErrorMessage = nearEarthObject.ErrorMessage,
                StatusCode = nearEarthObject.StatusCode,
                NearEarthItem = GetNearEarthItem(nearEarthObject)
            };

            return result;
        }

        public static NearEarthObjectListView DomainToView(NearEarthObjectList nearEarthObjectList)
        {
            if (nearEarthObjectList == null)
                return null;

            var result = new NearEarthObjectListView
            {
                IsErrorResponse = nearEarthObjectList.IsErrorResponse,
                StatusCode = nearEarthObjectList.StatusCode,
                NearEarthObjects = new List<NearEarthItem>()
            };

            foreach (var neo in nearEarthObjectList.near_earth_objects)
            {
                result.NearEarthObjects.Add(GetNearEarthItem(neo));
            }

            return result;
        }



        private static NearEarthItem GetNearEarthItem(NearEarthObject nearEarthObject)
        {
            var closest = nearEarthObject.close_approach_data?.MinBy(data => data.miss_distance.miles);

            var result = new NearEarthItem
            {
                AbsoluteMagnitudeH = nearEarthObject.absolute_magnitude_h,
                Id = nearEarthObject.id,
                IsHazardous = nearEarthObject.is_potentially_hazardous_asteroid,
                MaximumDiameterMiles = nearEarthObject.estimated_diameter?.miles.estimated_diameter_max ?? 0,
                MinimumDiameterMiles = nearEarthObject.estimated_diameter?.miles.estimated_diameter_min ?? 0,
                Name = nearEarthObject.name,
                NameShort = nearEarthObject.name_limited,
                ClosestApproach = new CloseApproachData
                {
                    Date = DateTime.TryParse(closest?.close_approach_date_full, out var missDate) ? missDate : null,
                    MissDistanceMiles = double.TryParse(closest?.miss_distance?.miles, out var missMiles) ? missMiles : null,
                    SpeedMilesPerHour = double.TryParse(closest?.relative_velocity?.miles_per_hour, out var speed) ? speed : null,
                }
            };

            return result;
        }
    }
}
