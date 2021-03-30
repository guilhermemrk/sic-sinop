using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class UserModel
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String CPF { get; set; }
        public String Email { get; set; }
        public String CEP { get; set; }
        public Int64 Rank { get; set; }
        
    }
}