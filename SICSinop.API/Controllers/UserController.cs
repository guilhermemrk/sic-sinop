using SICSinop.Domain.Interfaces.Services;
using SICSinop.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SICSinop.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET user/authenticate
        /// <summary>
        /// Autentica o usuario
        /// </summary>
        /// <remarks>
        /// 
        /// Exemplo:
        ///
        ///     POST /
        ///     {
        ///     "usuario": "Guilherme",
        ///     "senha": "exemplo"
        ///     }
        ///
        /// </remarks>
        /// <returns>{
        ///     "Token": "89123hyrfib12u9f12bg89f1g2fg7821gf71218"
        /// }</returns>
        [HttpGet]
        [Route("authenticate")]
        public bool Authenticate()
        {
            return true;
        }

        // GET user/list
        /// <summary>
        /// Retorna todos os users
        /// </summary>
        /// <returns>Lista de user</returns>
        [HttpGet]
        [Route("list")]
        public IEnumerable<UserViewModel> GetAll()
        {
            return _userService.GetAllUsers();
        }

        // GET user/{id}
        /// <summary>
        /// Retorna o user
        /// </summary>
        /// <returns>Um user</returns>
        [HttpGet]
        [Route("{id}")]
        public UserViewModel Get(int id)
        {
            return _userService.GetUserById(id);
        }

        // POST user
        /// <summary>
        /// Adiciona um user
        /// </summary>
        /// <returns>O user criado</returns>
        [HttpPost]
        public UserModel Post([FromBody] UserModel model)
        {
            return _userService.SaveUser(model);
        }

        // PUT user
        /// <summary>
        /// Edita um user
        /// </summary>
        /// <returns>O user editado</returns>
        [HttpPut]
        public UserModel Put([FromBody] UserModel model)
        {
            return _userService.UpdateUser(model);
        }

        // DELETE user/{id}
        /// <summary>
        /// Deleta um user
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _userService.DeleteUser(id);
        }
    }
}