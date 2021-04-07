using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Data.Repository
{
    public class MarkerRepository : Repository<Marker>, IMarkerRepository
    {
        public MarkerRepository(MainDbContext context) : base(context) { }

        public List<Marker> GetAllMarkers()
        {
            return GetAll().ToList();
        }

        public Marker GetMarkerById(int id)
        {
            return FindById(id);
        }

        public Marker CreateMarker(Marker marker)
        {
            Create(marker);
            SaveChanges();
            return marker;
        }

        public Marker UpdateMarker(Marker marker)
        {
            Update(marker);
            SaveChanges();
            return marker;
        }

        public void CreateMarkerList(List<Marker> list)
        {
            Create(list);
            SaveChanges();
        }

        public Marker DeleteMarker(Marker marker)
        {
            Remove(marker);
            SaveChanges();
            return marker;
        }
    }
}

