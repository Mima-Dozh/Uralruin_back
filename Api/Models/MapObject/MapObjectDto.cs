﻿namespace Uralruin_back.Models.MapObject
{
    public class MapObjectDto
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public double[] Latlong { get; set; }
    }
}
