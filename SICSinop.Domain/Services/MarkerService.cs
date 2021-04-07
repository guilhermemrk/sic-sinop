using Microsoft.EntityFrameworkCore;
using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using SICSinop.Domain.Repository;
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

        private IRepository<Marker> Repository { get => (_markerRepository as IRepository<Marker>); }

        // @TODO! Add Decimal datatype options to XSLT

        public ICollection<MarkerViewModel> GetAllMarkers()
        {
            return Repository.GetAll()
                .Include(x => x.User)
                .Select(marker => new MarkerViewModel()
                {
                    Id = marker.Id,
                    UserId = marker.UserId,
                    Title = marker.Title,
                    Description = marker.Description,
                    Latitude = marker.Latitude,
                    Longitude = marker.Longitude,
                    Status = marker.Status,
                    User = (new UserViewModel()).FromModel(marker.User)

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
		
		public MarkerModel SaveMarker(MarkerModel model)
        {
            var marker = new Marker()
            {
                Id = model.Id,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Status = model.Status,
                
            };
			
            marker = _markerRepository.CreateMarker(marker);
			
            return new MarkerModel()
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

        public MarkerModel UpdateMarker(MarkerModel model)
        {
            var marker = new Marker()
            {
                Id = model.Id,
                UserId = model.UserId,
                Title = model.Title,
                Description = model.Description,
                Latitude = model.Latitude,
                Longitude = model.Longitude,
                Status = model.Status,
                
            };
			
            marker = _markerRepository.UpdateMarker(marker);
			
            return new MarkerModel()
            {
                Id = marker.Id,
				UserId = model.UserId,
				Title = model.Title,
				Description = model.Description,
				Latitude = model.Latitude,
				Longitude = model.Longitude,
				Status = model.Status,
				
            };
        }

        public bool DeleteMarker(int id)
        {
            try
            {
                var marker = _markerRepository.GetMarkerById(id);
                if (marker == null)
                {
                    throw new Exception("Not found!");
                }

                _markerRepository.DeleteMarker(marker);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}