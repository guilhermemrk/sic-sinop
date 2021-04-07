using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class UserModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public int Rank { get; set; }
        
    }
}