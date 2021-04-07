using SICSinop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SICSinop.Domain.Interfaces.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserById(int id);
        User CreateUser(Useruser);
        User UpdateUser(Useruser);
        void CreateUserList(List<User> list);
        User DeleteUser(Useruser);
	}
}
}