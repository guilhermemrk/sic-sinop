using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Model
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public int Rank { get; set; }
        
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