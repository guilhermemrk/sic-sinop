using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class MarkerCommentModel
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long MarkerId { get; set; }
        public string Message { get; set; }
        
    }
}