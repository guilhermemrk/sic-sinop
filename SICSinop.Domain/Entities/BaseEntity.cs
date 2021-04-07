using SICSinop.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Entities
{
    public class BaseEntity : IEntity
    {
        public long Id { get; set; }
    }
}
