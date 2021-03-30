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
    }
}

