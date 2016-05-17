﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DDSTP.Domain.Components;

namespace DDSTP.Domain.Entities
{
    public class Community
    {
        [Key]
        public int ID { get; set; }
        public DbGeography Polygon { get; set; }
        public int CommunityNumber { get; set; }

        public bool IsInclude(double lat, double lng)
        {
            var pointInside = GeoHelper.PointFromLatLng(lat, lng);
            return !Polygon.Intersects(pointInside);
        }
    }
}