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
		
		public UserModel SaveUser(UserModel model)
        {
            var user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                CPF = model.CPF,
                Email = model.Email,
                CEP = model.CEP,
                Rank = model.Rank,
                
            };
			
            user = _userRepository.CreateUser(user);
			
            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                CPF = user.CPF,
                Email = user.Email,
                CEP = user.CEP,
                Rank = user.Rank,
                
            };
        }

        public UserModel UpdateUser(UserModel model)
        {
            var user = new User()
            {
                Id = model.Id,
                Name = model.Name,
                CPF = model.CPF,
                Email = model.Email,
                CEP = model.CEP,
                Rank = model.Rank,
                
            };
			
            user = _userRepository.UpdateUser(user);
			
            return new UserModel()
            {
                Id = user.Id,
				Name = model.Name,
				CPF = model.CPF,
				Email = model.Email,
				CEP = model.CEP,
				Rank = model.Rank,
				
            };
        }

        public bool DeleteUser(int id)
        {
            try
            {
                var user = _userRepository.GetUserById(id);
                if (user == null)
                {
                    throw new Exception("Not found!");
                }

                _userRepository.DeleteUser(user);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}