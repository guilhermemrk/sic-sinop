using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class User : BasicEntity
    {
        public String Name { get; set; }
        public String CPF { get; set; }
        public String Email { get; set; }
        public String CEP { get; set; }
        public Int64 Rank { get; set; }
        
        public ICollection<Marker> Markers { get; set; } = new List<Marker>();
                
    }
}