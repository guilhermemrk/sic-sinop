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
    public class MarkerCommentController
    {
        private readonly IMarkerCommentService _markercommentsService;

        public MarkerCommentController(IMarkerCommentService markercommentsService)
        {
            _markercommentsService = markercommentsService;
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<MarkerCommentViewModel> GetAll()
        {
            return _markercommentsService.GetAllMarkerComments();
        }

        [HttpGet]
        [Route("{id}")]
        public MarkerCommentViewModel Get(int id)
        {
            return _markercommentsService.GetMarkerCommentById(id);
        }

        [HttpPost]
        public MarkerCommentModel Post([FromBody] MarkerCommentModel model)
        {
            return _markercommentsService.SaveMarkerComment(model);
        }

        [HttpPut]
        public MarkerCommentModel Put([FromBody] MarkerCommentModel model)
        {
            return _markercommentsService.UpdateMarkerComment(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _markercommentsService.DeleteMarkerComment(id);
        }
    }
}