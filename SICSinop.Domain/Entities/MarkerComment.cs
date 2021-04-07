using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class MarkerComment : BaseEntity
    {
        public long UserId { get; set; }
        public long MarkerId { get; set; }
        public string Message { get; set; }
        
        public User User { get; set; }
        public Marker Marker { get; set; }
    }
}