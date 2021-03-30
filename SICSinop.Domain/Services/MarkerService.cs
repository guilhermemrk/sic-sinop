using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Services
{
    public class MarkerService : IMarkerService
    {
        private readonly IMarkerRepository _markerRepository;

        public MarkerService(IMarkerRepository markerRepository)
        {
            _markerRepository = markerRepository;
        }

        public ICollection<MarkerViewModel> GetAllMarkers()
        {
            return _markerRepository.GetAllMarkers()
                .Select(marker => new MarkerViewModel()
                {
                    Id = marker.Id,
                    UserId = marker.UserId,
                    Title = marker.Title,
                    Description = marker.Description,
                    Latitude = marker.Latitude,
                    Longitude = marker.Longitude,
                    Status = marker.Status,
                    
                })
                .ToList();
        }

        public MarkerViewModel GetMarkerById(int id)
        {
            var marker = _markerRepository.GetMarkerById(id);
            return (marker != null ? new MarkerViewModel()
            {
                Id = marker.Id,
                UserId = marker.UserId,
                Title = marker.Title,
                Description = marker.Description,
                Latitude = marker.Latitude,
                Longitude = marker.Longitude,
                Status = marker.Status,
                
            } : null);
        }
    }
}