namespace SpaceStationAPI.Models.View
{
    public class NearEarthObjectView : BaseResponse
    {
        public NearEarthItem NearEarthItem { get; set; }
    }

    public class NearEarthItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NameShort { get; set; }
        public double AbsoluteMagnitudeH { get; set; }
        public double MinimumDiameterMiles { get; set; }
        public double MaximumDiameterMiles { get; set; }
        public bool IsHazardous { get; set; }
        public CloseApproachData ClosestApproach { get; set; }
    }

    public class CloseApproachData
    {
        public DateTime? Date { get; set; }
        public double? SpeedMilesPerHour { get; set; }
        public double? MissDistanceMiles { get; set; }
    }
}
