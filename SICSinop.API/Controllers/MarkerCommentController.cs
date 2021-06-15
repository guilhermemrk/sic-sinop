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
    public class MarkerCommentController
    {
        private readonly IMarkerCommentService _markercommentsService;

        public MarkerCommentController(IMarkerCommentService markercommentsService)
        {
            _markercommentsService = markercommentsService;
        }

        // GET markercomment/list
        /// <summary>
        /// Retorna todos os comentarios de markers
        /// </summary>
        /// <returns>Lista de MarkerComments</returns>
        [HttpGet]
        [Route("list")]
        public IEnumerable<MarkerCommentViewModel> GetAll()
        {
            return _markercommentsService.GetAllMarkerComments();
        }

        // GET markercomment/{id}
        /// <summary>
        /// Retorna markercomment por id
        /// </summary>
        /// <returns>Um MarkerComment</returns>
        [HttpGet]
        [Route("{id}")]
        public MarkerCommentViewModel Get(int id)
        {
            return _markercommentsService.GetMarkerCommentById(id);
        }

        // POST markercomment
        /// <summary>
        /// Adiciona um MarkerComment
        /// </summary>
        /// <returns>O MarkerComment criado</returns>
        /// <response code="201">Retorna o novo item criado</response>
        /// <response code="400">Se o item não for criado</response>
        [HttpPost]
        public MarkerCommentModel Post([FromBody] MarkerCommentModel model)
        {
            return _markercommentsService.SaveMarkerComment(model);
        }

        // PUT markercomment
        /// <summary>
        /// Edita um MarkerComment
        /// </summary>
        /// <returns>O MarkerComment editado</returns>
        /// <response code="201">Retorna o item editado</response>
        /// <response code="400">Se o item não for editado</response>
        [HttpPut]
        public MarkerCommentModel Put([FromBody] MarkerCommentModel model)
        {
            return _markercommentsService.UpdateMarkerComment(model);
        }

        // DELETE markercomment/{id}
        /// <summary>
        /// Deleta um MarkerComment
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _markercommentsService.DeleteMarkerComment(id);
        }
    }
}