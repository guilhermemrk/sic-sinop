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
    public class MarkerController
    {
        private readonly IMarkerService _markerService;

        public MarkerController(IMarkerService markerService)
        {
            _markerService = markerService;
        }

        [HttpGet]
        [Route("list")]
        public IEnumerable<MarkerViewModel> GetAll()
        {
            return _markerService.GetAllMarkers();
        }

        [HttpGet]
        [Route("{id}")]
        public MarkerViewModel Get(int id)
        {
            return _markerService.GetMarkerById(id);
        }

        [HttpPost]
        public MarkerModel Post([FromBody] MarkerModel model)
        {
            return _markerService.SaveMarker(model);
        }

        [HttpPut]
        public MarkerModel Put([FromBody] MarkerModel model)
        {
            return _markerService.UpdateMarker(model);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return _markerService.DeleteMarker(id);
        }
    }
}