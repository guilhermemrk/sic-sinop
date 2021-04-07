using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Services
{
    public interface IMarkerService
    {
        ICollection<MarkerViewModel> GetAllMarkers();
        MarkerViewModel GetMarkerById(int id);
		MarkerModel SaveMarker(MarkerModel model);
        MarkerModel UpdateMarker(MarkerModel model);
        bool DeleteMarker(int id);
    }
}