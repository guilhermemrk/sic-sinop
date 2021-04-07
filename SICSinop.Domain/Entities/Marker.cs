using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class Marker : BaseEntity
    {
        public long UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Status { get; set; }
        
        public User User { get; set; }
        public ICollection<MarkerComment>MarkerComments { get; set; } = new List<MarkerComment>();
    }
}