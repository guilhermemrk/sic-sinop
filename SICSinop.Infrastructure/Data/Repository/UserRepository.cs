using SICSinop.Domain.Entities;
using SICSinop.Domain.Interfaces.Repository;
using SICSinop.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SICSinop.Domain.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MainDbContext context) : base(context) { }

        public List<User> GetAllUsers()
        {
            return GetAll().ToList();
        }

        public User GetUserById(int id)
        {
            return FindById(id);
        }

        public User CreateUser(User user)
        {
            Create(user);
            SaveChanges();
            return user;
        }

        public User UpdateUser(User user)
        {
            Update(user);
            SaveChanges();
            return user;
        }

        public void CreateUserList(List<User> list)
        {
            Create(list);
            SaveChanges();
        }

        public User DeleteUser(User user)
        {
            Remove(user);
            SaveChanges();
            return user;
        }
    }
}

