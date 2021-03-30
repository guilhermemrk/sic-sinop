using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class Marker : BasicEntity
    {
        public Int64 UserId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public String Status { get; set; }
        
        public User User { get; set; }
                
    }
}