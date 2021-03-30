using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Repository
{
    public interface IMarkerRepository
    {
        List<Marker> GetAllMarkers();
        Marker GetMarkerById(int id);
    }
}