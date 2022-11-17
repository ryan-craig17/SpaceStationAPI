using Microsoft.Extensions.Options;
using SpaceStationAPI.Interfaces;
using SpaceStationAPI.Models;
using SpaceStationAPI.Models.Domain;
using SpaceStationAPI.Models.View;
using SpaceStationAPI.Transforms;

namespace SpaceStationAPI.LogicLayer
{
    public class NasaLogic : INasaLogic
    {
        private IRestWorker _restWorker { get; set; }
        private Settings _settings { get; set; }
        private string wsURL_domain { get; set; }
        private string apiKey_Nasa { get; set; }

        public NasaLogic(IRestWorker restWorker, IOptions<Settings> settings)
        {
            _restWorker = restWorker;
            _settings = settings.Value;

            wsURL_domain = _settings.EnvironmentValues.NASA_API_URL;
            apiKey_Nasa = _settings.EnvironmentValues.APIkey_NASA;
        }

        public async Task<AstroPictureView> GetAstronomyPictureURL(DateTime? pictureDate)
        {
            var wsURL_path = string.Format(_settings.StaticValues.NasaResources.APOD, $"{pictureDate:yyyy-MM-dd}", apiKey_Nasa);
            var url = new Uri(new Uri(wsURL_domain), wsURL_path);

            var response = await _restWorker.CallService<AstroPicture>(url);
            var result = NasaTransformer.DomainToView(response);

            return result;
        }
    }
}
