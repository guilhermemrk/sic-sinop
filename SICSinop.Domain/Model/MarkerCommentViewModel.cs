using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class MarkerCommentViewModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MarkerId { get; set; }
        public string Message { get; set; }
        
        public MarkerCommentViewModel FromModel(MarkerComment markercomments)
        {
            return new MarkerCommentViewModel()
            {
                Id = markercomments.Id,
                UserId = markercomments.UserId,
                MarkerId = markercomments.MarkerId,
                Message = markercomments.Message,
                
            };
        }
    }
}