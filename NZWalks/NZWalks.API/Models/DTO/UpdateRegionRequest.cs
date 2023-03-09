﻿namespace NZWalks.API.Models.DTO
{
    public class UpdateRegionRequest
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public double Area { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Population { get; set; }
    }
}
