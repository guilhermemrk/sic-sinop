using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class UserViewModel
    {
        public Int64 Id { get; set; }
        public String Name { get; set; }
        public String CPF { get; set; }
        public String Email { get; set; }
        public String CEP { get; set; }
        public Int64 Rank { get; set; }
        
        public UserViewModel FromModel(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                CPF = user.CPF,
                Email = user.Email,
                CEP = user.CEP,
                Rank = user.Rank,
                
            };
        }
    }
}