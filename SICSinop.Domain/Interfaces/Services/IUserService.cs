using SICSinop.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Services
{
    public interface IUserService
    {
        ICollection<UserViewModel> GetAllUsers();
        UserViewModel GetUserById(int id);
		UserModel SaveUser(UserModel model);
        UserModel UpdateUser(UserModel model);
        bool DeleteUser(int id);
    }
}