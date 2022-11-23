﻿namespace SpaceStationAPI.Models.Domain
{
    public class NearEarthObject : BaseResponse
    {
        public Links links { get; set; }
        public string id { get; set; }
        public string neo_reference_id { get; set; }
        public string name { get; set; }
        public string name_limited { get; set; }
        public string designation { get; set; }
        public string nasa_jpl_url { get; set; }
        public double absolute_magnitude_h { get; set; }
        public EstimatedDiameter estimated_diameter { get; set; }
        public bool is_potentially_hazardous_asteroid { get; set; }
        public List<CloseApproachDatum> close_approach_data { get; set; }
        public OrbitalData orbital_data { get; set; }
        public bool is_sentry_object { get; set; }
    }

    public class CloseApproachDatum
    {
        public string close_approach_date { get; set; }
        public string close_approach_date_full { get; set; }
        public object epoch_date_close_approach { get; set; }
        public RelativeVelocity relative_velocity { get; set; }
        public MissDistance miss_distance { get; set; }
        public string orbiting_body { get; set; }
    }

    public class EstimatedDiameter
    {
        public MinMaxDiameter kilometers { get; set; }
        public MinMaxDiameter meters { get; set; }
        public MinMaxDiameter miles { get; set; }
        public MinMaxDiameter feet { get; set; }
    }

    public class MinMaxDiameter
    {
        public double estimated_diameter_min { get; set; }
        public double estimated_diameter_max { get; set; }
    }

    public class MissDistance
    {
        public string astronomical { get; set; }
        public string lunar { get; set; }
        public string kilometers { get; set; }
        public string miles { get; set; }
    }

    public class OrbitalData
    {
        public string orbit_id { get; set; }
        public string orbit_determination_date { get; set; }
        public string first_observation_date { get; set; }
        public string last_observation_date { get; set; }
        public int data_arc_in_days { get; set; }
        public int observations_used { get; set; }
        public string orbit_uncertainty { get; set; }
        public string minimum_orbit_intersection { get; set; }
        public string jupiter_tisserand_invariant { get; set; }
        public string epoch_osculation { get; set; }
        public string eccentricity { get; set; }
        public string semi_major_axis { get; set; }
        public string inclination { get; set; }
        public string ascending_node_longitude { get; set; }
        public string orbital_period { get; set; }
        public string perihelion_distance { get; set; }
        public string perihelion_argument { get; set; }
        public string aphelion_distance { get; set; }
        public string perihelion_time { get; set; }
        public string mean_anomaly { get; set; }
        public string mean_motion { get; set; }
        public string equinox { get; set; }
        public OrbitClass orbit_class { get; set; }
    }

    public class OrbitClass
    {
        public string orbit_class_type { get; set; }
        public string orbit_class_description { get; set; }
        public string orbit_class_range { get; set; }
    }

    public class RelativeVelocity
    {
        public string kilometers_per_second { get; set; }
        public string kilometers_per_hour { get; set; }
        public string miles_per_hour { get; set; }
    }
}
