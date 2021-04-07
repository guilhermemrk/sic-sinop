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
    public class MarkerCommentService : IMarkerCommentService
    {
        private readonly IMarkerCommentRepository _markercommentsRepository;

        public MarkerCommentService(IMarkerCommentRepository markercommentsRepository)
        {
            _markercommentsRepository = markercommentsRepository;
        }

        public ICollection<MarkerCommentViewModel> GetAllMarkerComments()
        {
            return _markercommentsRepository.GetAllMarkerComments()
                .Select(markercomments => new MarkerCommentViewModel()
                {
                    Id = markercomments.Id,
                    UserId = markercomments.UserId,
                    MarkerId = markercomments.MarkerId,
                    Message = markercomments.Message,
                    
                })
                .ToList();
        }

        public MarkerCommentViewModel GetMarkerCommentById(int id)
        {
            var markercomments = _markercommentsRepository.GetMarkerCommentById(id);
            return (markercomments != null ? new MarkerCommentViewModel()
            {
                Id = markercomments.Id,
                UserId = markercomments.UserId,
                MarkerId = markercomments.MarkerId,
                Message = markercomments.Message,
                
            } : null);
        }
		
		public MarkerCommentModel SaveMarkerComment(MarkerCommentModel model)
        {
            var markercomments = new MarkerComment()
            {
                Id = model.Id,
                UserId = model.UserId,
                MarkerId = model.MarkerId,
                Message = model.Message,
                
            };
			
            markercomments = _markercommentsRepository.CreateMarkerComment(markercomments);
			
            return new MarkerCommentModel()
            {
                Id = markercomments.Id,
                UserId = markercomments.UserId,
                MarkerId = markercomments.MarkerId,
                Message = markercomments.Message,
                
            };
        }

        public MarkerCommentModel UpdateMarkerComment(MarkerCommentModel model)
        {
            var markercomments = new MarkerComment()
            {
                Id = model.Id,
                UserId = model.UserId,
                MarkerId = model.MarkerId,
                Message = model.Message,
                
            };
			
            markercomments = _markercommentsRepository.UpdateMarkerComment(markercomments);
			
            return new MarkerCommentModel()
            {
                Id = markercomments.Id,
				UserId = model.UserId,
				MarkerId = model.MarkerId,
				Message = model.Message,
				
            };
        }

        public bool DeleteMarkerComment(int id)
        {
            try
            {
                var markercomments = _markercommentsRepository.GetMarkerCommentById(id);
                if (markercomments == null)
                {
                    throw new Exception("Not found!");
                }

                _markercommentsRepository.DeleteMarkerComment(markercomments);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}