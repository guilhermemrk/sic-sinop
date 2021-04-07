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
    public class MarkerCommentRepository : Repository<MarkerComment>, IMarkerCommentRepository
    {
        public MarkerCommentRepository(MainDbContext context) : base(context) { }

        public List<MarkerComment> GetAllMarkerComments()
        {
            return GetAll().ToList();
        }

        public MarkerComment GetMarkerCommentById(int id)
        {
            return FindById(id);
        }

        public MarkerComment CreateMarkerComment(MarkerComment markercomments)
        {
            Create(markercomments);
            SaveChanges();
            return markercomments;
        }

        public MarkerComment UpdateMarkerComment(MarkerComment markercomments)
        {
            Update(markercomments);
            SaveChanges();
            return markercomments;
        }

        public void CreateMarkerCommentList(List<MarkerComment> list)
        {
            Create(list);
            SaveChanges();
        }

        public MarkerComment DeleteMarkerComment(MarkerComment markercomments)
        {
            Remove(markercomments);
            SaveChanges();
            return markercomments;
        }
    }
}

