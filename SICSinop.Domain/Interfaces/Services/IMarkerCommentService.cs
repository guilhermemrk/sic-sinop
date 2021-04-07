using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Services
{
    public interface IMarkerCommentService
    {
        ICollection<MarkerCommentViewModel> GetAllMarkerComments();
        MarkerCommentViewModel GetMarkerCommentById(int id);
		MarkerCommentModel SaveMarkerComment(MarkerCommentModel model);
        MarkerCommentModel UpdateMarkerComment(MarkerCommentModel model);
        bool DeleteMarkerComment(int id);
    }
}