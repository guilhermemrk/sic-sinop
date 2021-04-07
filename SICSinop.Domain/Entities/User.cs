using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public int Rank { get; set; }
        
        public ICollection<Marker>Markers { get; set; } = new List<Marker>();
                
    }
}