using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class MarkerViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }
        public UserViewModel User { get; set; }

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