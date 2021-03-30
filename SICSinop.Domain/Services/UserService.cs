using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<UserViewModel> GetAllUsers()
        {
            return _userRepository.GetAllUsers()
                .Select(user => new UserViewModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    CPF = user.CPF,
                    Email = user.Email,
                    CEP = user.CEP,
                    Rank = user.Rank,
                    
                })
                .ToList();
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return (user != null ? new UserViewModel()
            {
                Id = user.Id,
                Name = user.Name,
                CPF = user.CPF,
                Email = user.Email,
                CEP = user.CEP,
                Rank = user.Rank,
                
            } : null);
        }
    }
}