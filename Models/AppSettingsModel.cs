namespace SpaceStationAPI.Models
{
    public class AppSettingsModel
    {
        public Settings Settings { get; set; }
    }

    public class Settings
    {
        public StaticValues StaticValues { get; set; }
        public EnvironmentValues EnvironmentValues { get; set; }
    }

    public class StaticValues
    {
        public string APIname { get; set; }
        public StarWarsResources StarWarsResources { get; set; }
        public NasaResources NasaResources { get; set; }
    }

    public class EnvironmentValues
    {
        public string NASA_API_URL { get; set; }
        public string StarWars_API_URL { get; set; }
        public string APIkey_NASA { get; set; }
        public string CorsAllowedSites { get; set; }
        public Logging Logging { get; set; }
    }

    public class StarWarsResources
    {
        public string Films { get; set; }
        public string People { get; set; }
        public string Planets { get; set; }
        public string Species { get; set; }
        public string StarShips { get; set; }
        public string Vehicles { get; set; }
    }

    public class NasaResources
    {
        public string APOD { get; set; }
        public string AsteroidList { get; set; }
        public string AsteroidLookup { get; set; }
        public string AsteroidBrowse { get; set; }
        public string MarsRoverPhotos { get; set; }
    }

    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }

    public class LogLevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }
}
