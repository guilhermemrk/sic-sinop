using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class MarkerViewModel
    {
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public String Status { get; set; }
        
        public MarkerViewModel FromModel(Marker marker)
        {
            return new MarkerViewModel()
            {
                Id = marker.Id,
                UserId = marker.UserId,
                Title = marker.Title,
                Description = marker.Description,
                Latitude = marker.Latitude,
                Longitude = marker.Longitude,
                Status = marker.Status,
                
            };
        }
    }
}