using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICSinop.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<UserViewModel> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [HttpGet]
        [Route("{id}")]
        public UserViewModel Get(int id)
        {
            return _userService.GetUserById(id);
        }

        [HttpPost]
        public UserModel Post([FromBody] UserModel model)
        {
            return _userService.SaveUser(model);
        }

        [HttpPut]
        public UserModel Put([FromBody] UserModel model)
        {
            return _userService.UpdateUser(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _userService.DeleteUser(id);
        }
    }
}