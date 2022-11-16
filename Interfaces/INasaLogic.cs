namespace SpaceStationAPI.Interfaces
{
    public interface INasaLogic
    {
        public Task<Uri> GetAstronomyPictureURL(DateTime? pictureDate);
    }
}
