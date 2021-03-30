using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class MarkerModel
    {
        public Int64 Id { get; set; }
        public Int64 UserId { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }
        public String Latitude { get; set; }
        public String Longitude { get; set; }
        public String Status { get; set; }
        
    }
}