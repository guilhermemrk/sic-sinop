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
    public class MarkerController
    {
        private readonly IMarkerService _markerService;

        public MarkerController(IMarkerService markerService)
        {
            _markerService = markerService;
        }

        // GET markercomment/list
        /// <summary>
        /// Retorna todos os markers
        /// </summary>
        /// <returns>Lista de markers</returns>
        [HttpGet]
        [Route("list")]
        public IEnumerable<MarkerViewModel> GetAll()
        {
            return _markerService.GetAllMarkers();
        }

        // GET markercomment/{id}
        /// <summary>
        /// Retorna um marker
        /// </summary>
        /// <returns>Um marker</returns>
        [HttpGet]
        [Route("{id}")]
        public MarkerViewModel Get(int id)
        {
            return _markerService.GetMarkerById(id);
        }

        // POST markercomment
        /// <summary>
        /// Adiciona um Marker
        /// </summary>
        /// <returns>O marker criado</returns>
        [HttpPost]
        public MarkerModel Post([FromBody] MarkerModel model)
        {
            return _markerService.SaveMarker(model);
        }

        // PUT markercomment
        /// <summary>
        /// Edita um marker
        /// </summary>
        /// <returns>O marker editado</returns>
        [HttpPut]
        public MarkerModel Put([FromBody] MarkerModel model)
        {
            return _markerService.UpdateMarker(model);
        }

        // DELETE markercomment/{id}
        /// <summary>
        /// Deleta um marker
        /// </summary>
        /// <returns>Boolean</returns>
        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _markerService.DeleteMarker(id);
        }
    }
}