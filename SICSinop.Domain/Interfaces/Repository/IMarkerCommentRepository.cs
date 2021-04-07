using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Repository
{
    public interface IMarkerCommentRepository
    {
        List<MarkerComment> GetAllMarkerComments();
        MarkerComment GetMarkerCommentById(int id);
        MarkerComment CreateMarkerComment(MarkerComment markercomments);
        MarkerComment UpdateMarkerComment(MarkerComment markercomments);
        void CreateMarkerCommentList(List<MarkerComment> list);
        MarkerComment DeleteMarkerComment(MarkerComment markercomments);
	}
}